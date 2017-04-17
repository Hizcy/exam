using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class data_userthrough : System.Web.UI.Page
{
    public int UserId
    {
        get
        {
            Object obj = Request.QueryString["id"];
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
            try
            {
                if (UserId != 0)
                {
                    Exam.Entity.tb_UserEntity model = Exam.BLL.tb_UserBLL.GetInstance().GetAdminSingle(UserId);
                    Exam.Entity.tb_SchoolEntity tmodel = Exam.BLL.tb_SchoolBLL.GetInstance().GetAdminSingle(model.SchoolId);
                    if (model.Status == 0)
                    {
                        model.Status = 1;
                        Exam.BLL.tb_UserBLL.GetInstance().Update(model);
                        Response.Write("审核通过");
                        string body = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("body");
                        body = string.Format(body, "<p><b>",tmodel.Name, "</b></p><p>", "<br/>", "admin@" + tmodel.Domain  + "<br/>", model.Pwd + "<br/><p>", model.SchoolId + "</p>", "</p>");
                        Jnwf.Utils.Mail.MailHelper.SendEmail(
                               Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpServer"),
                               Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpUser"),
                               Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("smtpPass"),
                               model.Mail, "欢迎加入快去读", body, true, null);
                    }
                    else
                    {
                        Response.Write("用户" + UserId + "已申请");
                    }
                }
                else
                {
                    Response.Write("UserId为null");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}