using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;
public partial class center_m_pass :System.Web.UI.Page
{
    public string pass = "";
    public int schoolId
    {
        get
        {
            object obj = Request.QueryString["schoolid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
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
    public string idName
    {
        get
        {
            object obj = Request.QueryString["idname"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    public string iddomain
    {
        get
        {
            object obj = Request.QueryString["iddomain"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Exam.Entity.tb_UserEntity list = Exam.BLL.tb_UserBLL.GetInstance().GetModelByNameSchoolId(idName, schoolId);
                if (list != null)
                {
                    pass = list.Pwd;

                    if (pass != this.txtpass.Text.Trim())
                    {
                        MessageBox.ShowMsg(this, "原始密码不正确！");
                        return;
                    }
                    string newpass = "";
                    newpass = this.txtnewpass.Text.Trim();
                    if (newpass == "")
                    {
                        MessageBox.ShowMsg(this, "新密码不能为空！");
                        return;
                    }
                    if (txtpasswordSafe.Text.Trim() != newpass)
                    {
                        MessageBox.ShowMsg(this, "两次密码不同！");
                        return;
                    }
                    int userid = list.UserId;
                    tb_UserEntity model = tb_UserBLL.GetInstance().GetAdminSingle(userid);
                    if (model != null)
                    {
                        model.Pwd = newpass;
                        model.Addtime = DateTime.Now;
                        tb_UserBLL.GetInstance().Update(model);
                        MessageBox.ShowAndRedirect(this, "修改成功！", "m_Center.aspx");
                    }
                    else
                    {
                        MessageBox.ShowAndRedirect(this, "修改失败！", "m_Center.aspx");
                    }

                }
            }
        catch (Exception ex)
        {

            throw;
        }
    }
}