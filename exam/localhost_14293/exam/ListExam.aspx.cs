using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class exam_ListExam : System.Web.UI.Page
{
    public static string domain = "";
    public static int UserId = 0;
    public static string school = "";
    public static int schoolId = 0;
    public List<Exam.Entity.tb_ResultEntity> result = new List<Exam.Entity.tb_ResultEntity>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserIdentity identity= User.Identity as UserIdentity;
            if(identity != null)
            {
                UserId = identity.UserID;
                string[] tarr = identity._domain.Split('.');
                domain = tarr[0].TrimStart('@');
                school = identity.Domain;
                schoolId = identity._schoolID;
                IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsListSchoolIdOne(0);
                if (list.Count > 0 && list != null)
                {
                    dllLevel.DataSource = list;
                    dllLevel.DataTextField = "name";
                    dllLevel.DataValueField = "QuestionClsId";
                    dllLevel.DataBind();
                    BindData();
                }
            }
        }
    }
    protected void tiaozhuan_click(object sender, EventArgs e)
    {
        Response.Redirect("Answer.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        rptlist.DataSource = string.Empty;
        rptlist.DataBind();
        BindData();
    }
    private void BindData()
    {

        UserIdentity identity = User.Identity as UserIdentity;
        if (identity != null)
        {
            //分页显示
            int id = int.Parse(dllLevel.SelectedValue);
            string where = " and ParentId=" + id;
            int allCount;
            int CurrentPage = 0;
            CurrentPage = this.pager1.CurrentPageIndex;
            DataSet ds = Exam.BLL.tb_ExampaperBLL.GetInstance().GetListByClient(pager1.PageSize, CurrentPage, "b.schoolid=" + identity._schoolID + where, out allCount);
            
            result = Exam.BLL.tb_ResultBLL.GetInstance().GetListByUserId(identity.UserID) as List<Exam.Entity.tb_ResultEntity>;
       
            if (ds != null && ds.Tables.Count > 0)
            {
                rptlist.DataSource = ds;
                rptlist.DataBind();
                pager1.RecordCount = allCount;
                pager1.CurrentPageIndex = CurrentPage;
            }
            

        }
    }

    /// <summary>
    /// 分页控件的翻页事件
    /// </summary>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        int currentPage = 1;   //默认显示第一页
        if (!string.IsNullOrEmpty(Request.QueryString["page"]))
        {
            currentPage = int.Parse(Request.QueryString["page"]);
        }   //通过网页get方式获取当前页码
        BindData();
    }
    public string GetResult(int exampaperid)
    {
        Exam.Entity.tb_ResultEntity m = result.FirstOrDefault(c => c.ExampaperId == exampaperid);
        if (m == null)
            return "未参加";
        else
            return "已通过";
    }

}