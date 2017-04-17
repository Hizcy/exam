using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;

public partial class center_Center : System.Web.UI.Page
{
    public string user = "";
    public string name = "";
    public string position = "";
    public string sex = "";
    public string phone = "";
    public string mail = "";
    public string pass = "";
    public string description = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserIdentity identity = this.Page.User.Identity as UserIdentity;
            if (identity != null)
            {
                user = identity.Name + identity._domain;
                Exam.Entity.tb_UserEntity list = Exam.BLL.tb_UserBLL.GetInstance().GetModelByNameSchoolId(identity.Name, identity._schoolID);
                if (list != null)
                {
                    name = list.RealName;
                    position = list.Position;
                    sex = list.Sex==0?"女":"男";
                    phone = list.Phone;
                    mail = list.Mail;
                    description = list.Description;
                }
            }

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
             UserIdentity identity = this.Page.User.Identity as UserIdentity;
             if (identity != null)
             {
                 Exam.Entity.tb_UserEntity list = Exam.BLL.tb_UserBLL.GetInstance().GetModelByNameSchoolId(identity.Name, identity._schoolID);
                 if(list!=null)
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
                         MessageBox.ShowAndRedirect(this, "修改成功！", "Center.aspx");
                     }
                     else 
                     {
                         MessageBox.ShowAndRedirect(this, "修改失败！", "Center.aspx");
                     }
                     
                 }
             }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}