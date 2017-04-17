using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;

public partial class home_Home : System.Web.UI.Page
{
    public string user = "";
    public string name = "";
    public string mail = "";
    public string phone = "";
    public string schoolname = "";
    public string schoollinkman = "";
    public string schooltime = "";
    public string schoolid = "";
    public string yuming = "";
    public string yumingks = "";
    public string yumingyd = "";
    public string roleid = "";
       
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserIdentity identity = this.Page.User.Identity as UserIdentity;
            if (identity != null)
            {
                user = identity.Name + identity._domain;
            }
           Exam.Entity.tb_UserEntity list= Exam.BLL.tb_UserBLL.GetInstance().GetModelByNameSchoolId(identity.Name,identity._schoolID);
               name = list.RealName;
               mail = list.Mail;
               phone = list.Phone;
               roleid = list.RoleId.ToString();
               if (list.RoleId == 1) { 
                   schoolid = list.SchoolId.ToString();
                   yuming=Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("yuming");
                   yumingks = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("yumingks");
                   yumingyd = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("yumingyd");
               }

           Exam.Entity.tb_SchoolEntity lists = Exam.BLL.tb_SchoolBLL.GetInstance().GetAdminSingle(identity._schoolID);
               schoolname = lists.Name;
               schoollinkman = lists.Linkman;
               schooltime = lists.Addtime.ToString("yyyy-MM-dd");
        }
    }

}