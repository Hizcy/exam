using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forum_Forum : System.Web.UI.Page
{
    public int clsid
    {
        get
        {
            object obj = Request.QueryString["clsid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public string forumname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                IList<Exam.Entity.tb_ForumsEntity> list = Exam.BLL.tb_ForumsBLL.GetInstance().GetForumsList(clsid);
                rptforum.DataSource = list;
                rptforum.DataBind();
            }
            Exam.Entity.tb_ExampaperEntity tlist = Exam.BLL.tb_ExampaperBLL.GetInstance().GetexampaperclsId(clsid);
            if (tlist != null)
            {
                forumname = tlist.Name;
            }
        }
    }
}