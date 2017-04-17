using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class center_m_Center : System.Web.UI.Page
{
    public string user = "";
    public string name = "";
    public string position = "";
    public string sex = "";
    public string phone = "";
    public string mail = "";
    public string description = "";
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
        if (!IsPostBack)
        {

            user = idName + iddomain;
            Exam.Entity.tb_UserEntity list = Exam.BLL.tb_UserBLL.GetInstance().GetModelByNameSchoolId(idName, schoolId);
            if(list !=null)
            {
                name = list.RealName;
                position = list.Position;
                sex = list.Sex == 0 ? "女" : "男";
                phone = list.Phone;
                mail = list.Mail;
                description = list.Description;
            }
        }
    }
   

}