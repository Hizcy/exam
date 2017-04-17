using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Exam_Listexam : System.Web.UI.Page
{
    public int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }

    }
    private void BindData()
    {

        UserIdentity identity = User.Identity as UserIdentity;
        if (identity != null)
        {
            string where = ""; 
            if (int.Parse(ddlstatus.SelectedItem.Value) != -1)
            {
                where = " and Status=" + ddlstatus.SelectedValue;
            }
            int allCount;
            int CurrentPage = 0;
            CurrentPage = this.pager1.CurrentPageIndex;
            DataSet ds = Exam.BLL.tb_ExamBLL.GetInstance().GetList(pager1.PageSize, CurrentPage, "schoolid=" + identity._schoolID + where, out allCount);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
            {
                rptExam.DataSource = ds;
                rptExam.DataBind();
                pager1.RecordCount = allCount;
                pager1.CurrentPageIndex = CurrentPage;
                i = 2;
            }
            else
            {
                rptExam.DataSource = string.Empty;
                rptExam.DataBind();
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

    protected void rptexampaper_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("delete"))
        {
            try
            {
                Exam.BLL.tb_ExamBLL.GetInstance().Delete(int.Parse(e.CommandArgument.ToString()));
                Response.Redirect("listexam.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.ShowMsg(this, "删除失败！");
            }
        }
        else
        {
            Response.Redirect("release.aspx?exampaperid=" + int.Parse(e.CommandArgument.ToString()));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindData();
    }
}