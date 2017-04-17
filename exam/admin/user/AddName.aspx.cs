using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;
public partial class user_AddName :BasePage //System.Web.UI.Page
{
    public string padcss = "";
    public int UserId
    {
        get
        {
            object obj = Request.QueryString["userid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (identity != null)
            {
                txtdomain.Text = identity._domain;
                txtdomain.Enabled = false;
                if (UserId > 0)
                {
                    radselect2.Checked = true;
                    txtname.Enabled = false;
                    tb_UserEntity model = tb_UserBLL.GetInstance().GetAdminSingle(UserId);
                    this.txtname.Text = model.Name;
                    this.txtrealname.Text = model.RealName;
                    this.ddlstatus.SelectedValue = model.Status.ToString();
                    this.txtposition.Text = model.Position ;
                    this.txtemail.Text = model.Mail;
                    this.txtphone.Text = model.Phone;    
                    this.txtnotice.Text = model.Description;
                    this.ddlrole.SelectedValue = model.RoleId.ToString();
                    if (model.Sex == 1)
                    {
                        male.Checked = true;
                    }
                    else
                    {
                        female.Checked = true;
                    }
                    Exam.Entity.tb_DepartmentEntity temp = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(model.DepartmentId);
                    if (temp != null)
                    {
                        Exam.Entity.tb_DepartmentEntity ttemp = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(temp.ParentId);
                        if (ttemp != null)
                        {
                            labdepartment.Text = ttemp.Name + temp.Name;
                        }
                    }
                    hiddepartmentId.Text = model.DepartmentId.ToString();
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string name = SqlInject(this.txtname.Text.Trim());//用户名
            string pwd = "";
            string realname = SqlInject(this.txtrealname.Text.Trim());//姓名
            int sex = 0;//性别
            if (this.male.Checked)
                sex = 1;
            else if (this.female.Checked)
                sex = 0;
            string status = SqlInject(ddlstatus.SelectedValue);//状态
            string position = SqlInject(this.txtposition.Text.Trim());//职位
            string mail = SqlInject(this.txtemail.Text.Trim());//邮箱
            string phone = SqlInject(this.txtphone.Text.Trim());//电话
            string notice = SqlInject(this.txtnotice.Text.Trim());//备注  
            int departmentId = 0;//部门
            if (hiddepartmentId.Text != "")
            {
                departmentId = int.Parse(SqlInject(hiddepartmentId.Text));
            }
            if (identity != null)
            {
                //添加
                if (UserId == 0)
                {
                    pwd = SqlInject(this.txtpassword.Text.Trim());
                    Exam.Entity.tb_UserEntity temp = Exam.BLL.tb_UserBLL.GetInstance().GetModelByNameSchoolId(name, identity._schoolID);
                    if (temp != null)
                    {
                        MessageBox.ShowMsg(this, "登入名已存在！");
                        return;
                    }
                    Exam.Entity.tb_DepartmentEntity department = null;
                    if (departmentId > 0)
                        department = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(departmentId);
                    else
                        department = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentEntityBySchoold(identity.SchoolID);

                    tb_UserEntity model = new tb_UserEntity();
                    model.SchoolId = identity._schoolID;
                    model.DepartmentId = departmentId;//部门id
                    //path
                    if (department != null)
                    {
                        if (department.RoleId == 1)
                        {
                            model.Path = "/" + department.DepartmentId + "/";
                        }
                        else if (department.RoleId == 2)
                        {
                            model.Path = "/" + department.ParentId + "/" + department.DepartmentId + "/";
                        }
                        else
                        {
                            Exam.Entity.tb_DepartmentEntity tempdepartment = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(department.ParentId);
                            if (tempdepartment != null)
                            {
                                model.Path = "/" + tempdepartment.ParentId + "/" + department.ParentId + "/" + department.DepartmentId + "/";
                            }
                            else
                            {
                                model.Path = "";
                            }
                        }
                    }
                    else
                    {
                        model.Path = "";
                    }

                    model.Name = name;
                    model.Pwd = pwd;
                    model.RealName = realname;
                    model.Sex = sex;
                    model.Position = position;
                    model.Mail = mail;
                    model.IdentityCard = "";
                    model.Phone = phone;
                    model.Description = notice;
                    model.Status = int.Parse(status);
                    model.Addtime = DateTime.Now;
                    model.RoleId = int.Parse(SqlInject(ddlrole.SelectedValue));
                    int num  = tb_UserBLL.GetInstance().Insert(model);
                    if(num >0)
                        MessageBox.ShowAndRedirect(this, "添加成功！", "listname.aspx");
                    else
                    {
                        MessageBox.ShowMsg(this, "保存失败！");
                        labdepartment.Text = SqlInject(hidname.Text.Trim());
                    }

                }
                //修改
                else
                {
                    if (radselect.Checked)
                    {
                        pwd = SqlInject(this.txtpassword.Text.Trim());
                        if (pwd == "")
                        {
                            MessageBox.ShowMsg(this, "密码不能为空！");
                            return;
                        }
                        if (txtpasswordSafe.Text.Trim() != pwd)
                        {
                            MessageBox.ShowMsg(this, "两次密码不同！");
                            return;
                        }
                    }
                    Exam.Entity.tb_DepartmentEntity department = null;
                    if (departmentId > 0)
                        department = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(departmentId);
                    else
                        department = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentEntityBySchoold(identity.SchoolID);

                    tb_UserEntity model = tb_UserBLL.GetInstance().GetAdminSingle(UserId);
                    //model.Name = name;
                    if (radselect.Checked)
                        model.Pwd = pwd;
                    model.RealName = realname;
                    model.Sex = sex;
                    model.Position = position;
                    model.Mail = mail;
                    model.Phone = phone;
                    model.Description = notice;
                    model.DepartmentId = departmentId;
                    if (department != null)
                    {
                        if (department.RoleId == 1)
                        {
                            model.Path = "/" + department.DepartmentId + "/";
                        }
                        else if (department.RoleId == 2)
                        {
                            model.Path = "/" + department.ParentId + "/" + department.DepartmentId + "/";
                        }
                        else
                        {
                            Exam.Entity.tb_DepartmentEntity tempdepartment = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(department.ParentId);
                            if (tempdepartment != null)
                            {
                                model.Path = "/" + tempdepartment.ParentId + "/" + department.ParentId + "/" + department.DepartmentId + "/";
                            }
                            else
                            {
                                model.Path = "";
                            }
                        }
                    }
                    else
                    {
                        model.Path = "";
                    }
                    model.RoleId = int.Parse(ddlrole.SelectedValue);
                    model.Pwd = pwd;
                    tb_UserBLL.GetInstance().Update(model);
                    Response.Redirect("listname.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}