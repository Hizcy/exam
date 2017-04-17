using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class exam_m_ListExam :BasePage //System.Web.UI.Page
{
    public static string domain = "";
    public static string school = "";
    public static string name = "";
    public static string iddomain = "";
    public static string idname = "";
    public static int UserId=0;  
    public static int schoolId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(identity != null)
            {
                UserId = identity.UserID;
                string[] tarr = identity._domain.Split('.');
                domain = tarr[0].TrimStart('@');
                school = identity.Domain;
                iddomain = identity._domain;
                schoolId = identity._schoolID;
                idname = identity.Name;
            }
            IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsListSchoolIdOne(0);
            if (list.Count > 0 && list != null)
            {
                dllLevel.DataSource = list;
                dllLevel.DataTextField = "name";
                dllLevel.DataValueField = "QuestionClsId";
                dllLevel.DataBind();
            }
            int parentId = int.Parse(dllLevel.SelectedValue);
            DataSet ds = Exam.BLL.tb_ExampaperBLL.GetInstance().Get_ExampaperByParentId(parentId,identity._schoolID);
            if (ds != null)
            {
                rptlist.DataSource = ds;
                rptlist.DataBind();
            }

            IList<Exam.Entity.tb_AdEntity> tlist = Exam.BLL.tb_AdBLL.GetInstance().GetAd(identity._schoolID);
            if(list.Count>0&&list!=null)
            {
                rptad.DataSource = tlist;
                rptad.DataBind();
            }
        }
    }
    public string GetResult(int exampaperid)
    {
        //Exam.Entity.tb_ResultEntity m = result.FirstOrDefault(c => c.ExampaperId == exampaperid);
        //if (m == null)
        //    return "未参加";
        //else
        //    return "已通过";
        return "";
    }
    //protected void btnsele_Click(object sender, EventArgs e)
    //{
    //    rptlist.DataSource = string.Empty;
    //    rptlist.DataBind();
    //    int parentId = int.Parse(dllLevel.SelectedValue);
    //    DataSet ds = Exam.BLL.tb_ExampaperBLL.GetInstance().Get_ExampaperByParentId(parentId);
    //    if (ds != null)
    //    {
    //        rptlist.DataSource = ds;
    //        rptlist.DataBind();
    //    }
    //}
    protected void dllLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //UserIdentity identity = User.Identity as UserIdentity;
        rptlist.DataSource = string.Empty;
        rptlist.DataBind();
        int parentId = int.Parse(dllLevel.SelectedValue);
        DataSet ds = Exam.BLL.tb_ExampaperBLL.GetInstance().Get_ExampaperByParentId(parentId,identity._schoolID);
        if (ds != null)
        {
            rptlist.DataSource = ds;
            rptlist.DataBind();
        }
    }
}