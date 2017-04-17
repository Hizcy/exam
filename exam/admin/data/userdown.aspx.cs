using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class data_userdown : System.Web.UI.Page
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
                    //Agents.Model.wx_UsersEntity model = Agents.BLL.wx_UsersBLL.GetInstance().GetAdminSingle(UserId);
                    if (model.Status == 0)
                    {
                        Response.Write("用户" + UserId + "已拒绝");
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