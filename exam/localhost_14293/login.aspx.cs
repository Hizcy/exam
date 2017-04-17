using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    public int schoolid
    {
        get
        {
            object obj = Request.QueryString["account"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public static string domain = "";
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
        {
            if (schoolid > 0)
            {
                Exam.Entity.tb_SchoolEntity model = Exam.BLL.tb_SchoolBLL.GetInstance().GetAdminSingle(schoolid);
                //school = model.SchoolId.ToString();
                if (model != null)
                {
                    domain = model.Domain;
                }
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string redirectUrl = Request.QueryString["ReturnUrl"];
        //try
        //{
        //    string name = string.Empty;
        //    if (schoolid > 0)
        //    {
        //        if (string.IsNullOrEmpty(this.txtUserNamey.Text.Trim()))
        //        {
        //            MessageBox.ShowMsg(this, "用户名不能为空");
        //            return;
        //        }
        //        name = this.txtUserNamey.Text.Trim() + domain;
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
        //        {
        //            MessageBox.ShowMsg(this, "用户名不能为空");
        //            return;
        //        }
        //        name = this.txtUserName.Text.Trim();
        //    }
        //    if (string.IsNullOrEmpty(this.txtPwd.Text.Trim()))
        //    {
        //        MessageBox.ShowMsg(this, "密码不能为空");
        //        return;
        //    }

        //    if (UserIdentity.AuthenticateUser(name, this.txtPwd.Text.Trim(), slideThree.Checked))
        //    {
        //        //if (string.IsNullOrEmpty(redirectUrl) || redirectUrl == "/")
        //            redirectUrl = "exam/listexam.aspx";

        //        Response.Redirect(redirectUrl);
        //    }
        //    else if (UserIdentity.Flag == 1)
        //    {
        //        MessageBox.ShowMsg(this, "您输入的用户名不正确");
        //    }
        //    else if (UserIdentity.Flag == 2)
        //    {
        //        MessageBox.ShowMsg(this, "您输入的或密码不正确");
        //    }
        //    else
        //    {
        //        MessageBox.ShowMsg(this, "您输入的用户名或密码不正确");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //Jnwf.Utils.Log.Logger.Log4Net.Error("login,name:" + this.txtUserName.Text.Trim() + ",pwd:" + this.txtPwd.Text.Trim() + ",ex:" + ex.Message + "|" + ex.StackTrace);
        //    MessageBox.ShowMsg(this, "您输入的用户名或密码异常，请联系管理员");
        //}
    }
}