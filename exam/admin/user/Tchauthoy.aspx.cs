using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_Tchauthoy :BasePage //System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //教师集合
            IList<Exam.Entity.tb_UserEntity> list = Exam.BLL.tb_UserBLL.GetInstance().GetNameBySchoolIdRoleId(identity._schoolID,2);
            if (list.Count > 0 && list != null)
            {
                ddlname.DataSource = list;
                ddlname.DataTextField = "RealName";
                ddlname.DataValueField = "userid";
                ddlname.DataBind();
            }
            //判断当前选中教师是否为空
            if (ddlname.Items != null && ddlname.Items.Count > 0)
            {
                int userid = int.Parse(ddlname.SelectedValue);
                Exam.Entity.tb_User_DepartmentEntity model = Exam.BLL.tb_User_DepartmentBLL.GetInstance().GetAdminByUserId(userid);//查找当前教师所教班级
                if (model != null)
                {
                    hidclassid.Text = model.DepartmentId;
                    string str = model.DepartmentId;
                    DataSet ds = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentDatasetByDepartmentId(str,identity._schoolID);//根据班级id显示当班级
                    rptclass.DataSource = ds;
                    rptclass.DataBind();
                }
            }
        }
    }
    //查询
    protected void btncx_Click(object sender, EventArgs e)
    {
        Select(identity._schoolID);
    }   
    //保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = hidclassid.Text.Trim();//所教班级
        str = str.TrimStart(',');
        str = str.TrimEnd(',');
        if (ddlname.Items != null && ddlname.Items.Count > 0)
        {
            int userId = int.Parse(ddlname.SelectedValue);
            try
            {
                //如果有修改
                Exam.Entity.tb_User_DepartmentEntity tmodel = Exam.BLL.tb_User_DepartmentBLL.GetInstance().GetAdminByUserId(userId);
                if (tmodel != null)
                {
                    //为空时，不给TA任何班级，清除数据
                    if (str == string.Empty)
                    {
                        Exam.BLL.tb_User_DepartmentBLL.GetInstance().Delete(tmodel.RelationId);
                    }
                    else
                    {
                        tmodel.DepartmentId = str;
                        Exam.BLL.tb_User_DepartmentBLL.GetInstance().Update(tmodel);
                    }
                }
                else
                {
                    Exam.Entity.tb_User_DepartmentEntity model = new Exam.Entity.tb_User_DepartmentEntity();
                    model.SchoolId = identity._schoolID;
                    model.UserId = userId;
                    model.DepartmentId = str;
                    Exam.BLL.tb_User_DepartmentBLL.GetInstance().Insert(model);
                }
                Select(identity._schoolID);
                MessageBox.ShowMsg(this, "保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.ShowMsg(this, ex.ToString());
            }
        }
        else
        {
            MessageBox.ShowMsg(this, "暂无教师！");
        }
    }
    /// <summary>
    /// 所选班级查询显示
    /// </summary>
    /// <param name="schoolid"></param>
    public void Select(int schoolid)
    {
        string departmentId = hidselect.Text.TrimEnd(',');
        if (!string.IsNullOrEmpty(departmentId))
        {
            DataSet ds = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentDataset(departmentId,schoolid);
            if (ds != null)
            {
                rptclass.DataSource = ds;
                rptclass.DataBind();
            }
        }
        if (ddlname.Items != null && ddlname.Items.Count > 0)
        {
            int userid = int.Parse(ddlname.SelectedValue);
            Exam.Entity.tb_User_DepartmentEntity model = Exam.BLL.tb_User_DepartmentBLL.GetInstance().GetAdminByUserId(userid);
            if (model != null)
            {
                hidclassid.Text = model.DepartmentId;
                
            }
            else
            {
                hidclassid.Text = "";
            }
        }
    }
    protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
    {
        hidname.Text = "";
        rptclass.DataSource = string.Empty;
        rptclass.DataBind();
        if (ddlname.Items != null && ddlname.Items.Count > 0)
        {
            int userid = int.Parse(ddlname.SelectedValue);
            Exam.Entity.tb_User_DepartmentEntity model = Exam.BLL.tb_User_DepartmentBLL.GetInstance().GetAdminByUserId(userid);
            if (model != null)
            {
                hidclassid.Text = model.DepartmentId;
                string str = model.DepartmentId;
                DataSet ds = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentDatasetByDepartmentId(str, identity._schoolID);
                rptclass.DataSource = ds;
                rptclass.DataBind();
            }
        }
    }
}