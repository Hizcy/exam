using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_ForumsList : BasePage//System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (identity != null)
            {
                if (identity._roleID == 4)//超级管理员
                    BindData(" and 1=1");
                else if (identity._roleID == 5 || identity._roleID == 1)//代理商 管理员
                    BindData(" and schoolid=" + identity._schoolID);
            }
        }
    }
    private void BindData(string where)
    {
        int allCount;
        int CurrentPage = 0;
        CurrentPage = this.pager1.CurrentPageIndex;
        DataSet ds = Exam.BLL.tb_ForumsBLL.GetInstance().GetList(pager1.PageSize, CurrentPage, " 1=1 and status=1 " + where, out allCount);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            rptForumsList.DataSource = ds;
            rptForumsList.DataBind();

            pager1.RecordCount = allCount;
            pager1.CurrentPageIndex = CurrentPage;
        }
        else
        {
            rptForumsList.DataSource = string.Empty;
            rptForumsList.DataBind();
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
        if (identity != null)
        {
            if (identity._roleID == 4)//超级管理员
                BindData(" and 1=1");
            else if (identity._roleID == 5 || identity._roleID == 1)//代理商
                BindData(" and schoolid=" + identity._schoolID);
        }
    }
}