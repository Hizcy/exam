using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Exam_ListTest : System.Web.UI.Page
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
            if (!string.IsNullOrEmpty(txtname.Text.Trim()))
            {
                where += " and name='" + txtname.Text.Trim() + "'";
            }
            if (int.Parse(ddlstatus.SelectedItem.Value) != -1)
            {
                where += " and Status=" + ddlstatus.SelectedValue;
            }
            int allCount;
            int CurrentPage = 0;
            CurrentPage = this.pager1.CurrentPageIndex;
            if (identity._roleID == 4)
            {
                DataSet ds = Exam.BLL.tb_ExampaperBLL.GetInstance().GetList(pager1.PageSize, CurrentPage, "1=1 " + where, out allCount);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    rptexampaper.DataSource = ds;
                    rptexampaper.DataBind();
                    pager1.RecordCount = allCount;
                    pager1.CurrentPageIndex = CurrentPage;
                    i = 2;
                }
                else
                {
                    rptexampaper.DataSource = string.Empty;
                    rptexampaper.DataBind();
                }
            }
            else
            {
                DataSet ds = Exam.BLL.tb_ExampaperBLL.GetInstance().GetList(pager1.PageSize, CurrentPage, " schoolId="+identity._schoolID + where, out allCount);
                if (ds != null && ds.Tables.Count > 0)
                {
                    rptexampaper.DataSource = ds;
                    rptexampaper.DataBind();
                    pager1.RecordCount = allCount;
                    pager1.CurrentPageIndex = CurrentPage;
                }
                else
                {
                    rptexampaper.DataSource = string.Empty;
                    rptexampaper.DataBind();
                }
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
                int id = int.Parse(e.CommandArgument.ToString());
                IList<Exam.Entity.tb_ExampaperExtEntity> list = Exam.BLL.tb_ExampaperExtBLL.GetInstance().GetListByExampaperId(id);
                if(list != null && list.Count>0)
                {
                    Exam.BLL.tb_ExampaperExtBLL.GetInstance().Delete(id);
                }
                Exam.BLL.tb_ExampaperBLL.GetInstance().Delete(id);
                Response.Redirect("listtest.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.ShowMsg(this, "删除失败！");
            }
        }
        else
        {
            Response.Redirect("formed.aspx?exampaperid=" + int.Parse(e.CommandArgument.ToString()));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        BindData();
    }
}