using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Exam.BLL;

public partial class user_ListName :BasePage// System.Web.UI.Page
{
    public int i = 1;
    public int userid
    {
        get
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity == null)
            {
                return 0;
            }
            return identity.UserID;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
        
    }
    private void BindData()
    {
        if (identity != null)
        {

            string where = "";
            //教师登录
            if (identity._roleID == 2)
            {
                Exam.Entity.tb_User_DepartmentEntity model = Exam.BLL.tb_User_DepartmentBLL.GetInstance().GetAdminByUserId(identity.UserID);
                if (model != null)
                {
                    string departmentid = model.DepartmentId;
                    where = " and departmentId in(" + departmentid + ")";
                    string partmentid = hiddepartmentId.Text.Trim();
                    if (!string.IsNullOrEmpty(partmentid))
                    {
                        where = " and CHARINDEX('/" + partmentid + "/',path)>0 ";
                        labdepartment.Text = hiddepartmentName.Text.Trim();
                    }
                    if (this.ddlsex.SelectedValue != "")
                    {
                        where += " and sex=" + ddlsex.SelectedValue;
                    }
                    if (this.ddlstatus.SelectedValue != "")
                    {
                        where += " and status=" + ddlstatus.SelectedValue;
                    }
                    int allCount;
                    int CurrentPage = 0;
                    CurrentPage = this.pager1.CurrentPageIndex;
                    DataSet ds = tb_UserBLL.GetInstance().GetListUser(pager1.PageSize, CurrentPage, "schoolid=" + identity._schoolID + where, out allCount);
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
            //管理员登录
            else if (identity._roleID == 1)
            {
                string partmentid = hiddepartmentId.Text.Trim();
                if (!string.IsNullOrEmpty(partmentid))
                {

                    where = " and CHARINDEX('/" + partmentid + "/',path)>0 ";
                    labdepartment.Text = hiddepartmentName.Text.Trim();
                }
                if (this.ddlsex.SelectedValue != "")
                {
                    where += " and sex=" + ddlsex.SelectedValue;
                }
                if (this.ddlstatus.SelectedValue != "")
                {
                    where += " and status=" + ddlstatus.SelectedValue;
                }
                int allCount;
                int CurrentPage = 0;
                CurrentPage = this.pager1.CurrentPageIndex;
                DataSet ds = tb_UserBLL.GetInstance().GetListUser(pager1.PageSize, CurrentPage, "schoolid=" + identity._schoolID + where, out allCount);
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
            //超级管理员
            else if(identity._roleID==4)
            {
                //部门选择
                string partmentid = hiddepartmentId.Text.Trim();
                if (!string.IsNullOrEmpty(partmentid))
                {
                    where = " and CHARINDEX('/" + partmentid + "/',path)>0 ";
                    labdepartment.Text = hiddepartmentName.Text.Trim();
                }
                if (this.ddlsex.SelectedValue != "")
                {
                    where += " and sex=" + ddlsex.SelectedValue;
                }
                if (this.ddlstatus.SelectedValue != "")
                {
                    where += " and status=" + ddlstatus.SelectedValue;
                }
                int allCount;
                int CurrentPage = 0;
                CurrentPage = this.pager1.CurrentPageIndex;
                DataSet ds = tb_UserBLL.GetInstance().GetListUser(pager1.PageSize, CurrentPage, " 1=1 " + where, out allCount);
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
    
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        if (identity != null)
        {

            string where = "";
            string partmentid = hiddepartmentId.Text.Trim();
            if (!string.IsNullOrEmpty(partmentid))
            {

                where = " and CHARINDEX('/" + partmentid + "/',path)>0 ";
                labdepartment.Text = hiddepartmentName.Text.Trim();
            }
            if (this.ddlsex.SelectedValue != "")
            {
                where += " and sex=" + ddlsex.SelectedValue;
            }
            if (this.ddlstatus.SelectedValue != "")
            {
                where += " and a.status=" + ddlstatus.SelectedValue;
            }
            DataSet ds = tb_UserBLL.GetInstance().GetListUser(" a.schoolid=" + identity._schoolID + where);
            gvlistname.DataSource = ds;
            gvlistname.DataBind();
            if (gvlistname.Rows.Count > 0)
            {
                //调用导出方法  
                GridViewToExcel(gvlistname, DateTime.Now.Ticks + ".xls");
            }
            else
            {
                MessageBox.Show(this, "没有数据可导出，请先查询数据!");
            }
        }

    }
    public static string Show_Online(Object key)
    {
        int tem = 2;
        try
        {
            tem = Convert.ToInt32(key);
        }
        catch (Exception)
        {
        }
        string Re = "";
        switch (tem)
        {
            case 0:
                Re = "男";
                break;
            case 1:
                Re = "女";
                break;
            default:
                Re = "暂无";
                break;
        }
        return Re;
    }
}
