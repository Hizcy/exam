using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;

public partial class user_AddAgent : BasePage //System.Web.UI.Page
{
    public string padcss = "";
    public int sex = -1;
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
                txtdomain.Text = "@agents.com";
                txtdomain.Enabled = false;
                ddlRole.Enabled = false;
                if (UserId > 0)
                {
                    txtname.Enabled = false;
                    tb_UserEntity model = tb_UserBLL.GetInstance().GetAdminSingle(UserId);
                    if (model != null)
                    {
                        this.txtname.Text = model.Name;
                        this.txtrealname.Text = model.RealName;
                        this.ddlstatus.SelectedValue = model.Status.ToString();
                        this.txtposition.Text = model.Position;
                        this.txtemail.Text = model.Mail;
                        this.txtphone.Text = model.Phone;
                        this.txtnotice.Text = model.Description;
                        this.ddlRole.SelectedValue = model.RoleId.ToString();
                        ddlRole.Enabled = false;
                        sex = model.Sex;
                    }
                }
            }
        }
    }
}