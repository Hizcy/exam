using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Exam.BLL;

public partial class user_ListAgent :BasePage //System.Web.UI.Page
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
        //UserIdentity identity = User.Identity as UserIdentity;
        if (identity != null)
        {
            int schoolid = int.Parse(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("agentid"));
            string where = "";
            string name = SqlInject(txtname.Text.Trim());
            if (!string.IsNullOrEmpty(name))
            {
                where = " and realname='" + name + "'";
            }
            if (this.ddlstatus.SelectedValue != "")
            {
                where += " and status=" + SqlInject(ddlstatus.SelectedValue);
            }
            int allCount;
            int CurrentPage = 0;
            CurrentPage = this.pager1.CurrentPageIndex;
            DataSet ds = tb_UserBLL.GetInstance().GetList(pager1.PageSize, CurrentPage, " 1=1" + where, out allCount);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                rptResultsList.DataSource = ds;
                rptResultsList.DataBind();

                pager1.RecordCount = allCount;
                pager1.CurrentPageIndex = CurrentPage;
                i = 2;
            }
            else
            {
                rptResultsList.DataSource = string.Empty;
                rptResultsList.DataBind();
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

    protected void btncx_Click(object sender, EventArgs e)
    {
        BindData();
    }
}