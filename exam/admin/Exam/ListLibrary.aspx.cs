using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Exam_ListLibrary : BasePage// System.Web.UI.Page
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
        if (identity != null)
        {
            string where = "";
            if(!string.IsNullOrEmpty(hid.Text.Trim()))
            {

                IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().QuestionClsList();//所有状态为一的
                IList<Exam.Entity.tb_QuestionClsEntity> list2 = new List<Exam.Entity.tb_QuestionClsEntity>();
                list2 = list.Where(c => c.ParentId == int.Parse(SqlInject(hid.Text.Trim()))).ToList();//查找当前子类
                IList<Exam.Entity.tb_QuestionClsEntity> tlist = null;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                //如果有值说明不是最后部分
                if (list2 != null && list2.Count > 0)
                {
                    sb.Append(",");
                    //第一或第二部分
                    foreach (Exam.Entity.tb_QuestionClsEntity model in list2)
                    {
                        tlist = new List<Exam.Entity.tb_QuestionClsEntity>();
                        sb.Append(model.QuestionClsId);
                        sb.Append(",");
                        tlist = list.Where(c => c.ParentId == model.QuestionClsId).ToList();
                        //如果有值说明当前是第二级 以上为第一级
                        if (tlist != null && tlist.Count > 0)
                        {
                            //第二或最后一级
                            foreach (Exam.Entity.tb_QuestionClsEntity tmodel in tlist)
                            {
                                sb.Append(tmodel.QuestionClsId);
                                sb.Append(",");
                            }
                        }
                    }
                }
                where += " and QuestionClsId in ("+ SqlInject(hid.Text.Trim())+sb.ToString().TrimEnd(',')+")";
            }
            //难度
            if (int.Parse(dllharde.SelectedItem.Value) != -1)
            {
                where += " and Isdifficulty =" + dllharde.SelectedValue;
            }
            //状态
            if (int.Parse(dllstatus.SelectedItem.Value) != -1)
            {
                where += " and Status=" + dllstatus.SelectedValue;
            }
            //单选
            if (int.Parse(dlltype.SelectedItem.Value) != -1)
            {
                where += " and Type=" + dlltype.SelectedValue;
            }
            int allCount;
            int CurrentPage = 0;
            CurrentPage = this.pager1.CurrentPageIndex;
            DataSet ds = Exam.BLL.tb_QuestionBLL.GetInstance().GetList(pager1.PageSize, CurrentPage, " schoolid=" + 0 + where, out allCount);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count>0)
            {
                rptQuestion.DataSource = ds;
                rptQuestion.DataBind();
                pager1.RecordCount = allCount;
                pager1.CurrentPageIndex = CurrentPage;
                i = 2;
            }
            else
            {
                rptQuestion.DataSource = string.Empty;
                rptQuestion.DataBind();
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
                Exam.BLL.tb_QuestionBLL.GetInstance().Delete(int.Parse(e.CommandArgument.ToString()));
                Response.Redirect("listlibrary.aspx");
            }
            catch (Exception ex)
            {
                MessageBox.ShowMsg(this, "删除失败！");
            }
        }
        else
        {
            Response.Redirect("addtestqm.aspx?questionid=" + int.Parse(e.CommandArgument.ToString()));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        BindData();
    }
    public string type(int type)
    {
        if (type == 1)
        {
            return "单选";
        }
        else if (type == 2)
        {
            return "多选";
        }
        else if (type == 3)
        {
            return "判断";
        }
        else 
        {
            return "填空";
        }
    }
    /// <summary>
    /// 截取字符串方法
    /// </summary>
    /// <param name="RawString"></param>
    /// <returns></returns>

    public string content(string content)
    {
        if (content.Length > 30)
        {
            content = content.Trim().Substring(0, 20) + "……";
        }
        return content;
    }

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        if (identity != null)
        {

            string where = "";
            if (hid.Text.Trim() != "")
            {
                Exam.Entity.tb_QuestionClsEntity model = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(int.Parse(hid.Text.Trim()));
                if (model.ParentId != 0)
                {
                    where += " and ParentId =" + hid.Text.Trim();
                    DataSet tds = Exam.BLL.tb_QuestionBLL.GetInstance().GetList("schoolid=" + 0 + where);
                    gvlistbrary.DataSource = tds;
                    gvlistbrary.DataBind();
                    if (gvlistbrary.Rows.Count > 0)
                    {
                        //调用导出方法  
                        GridViewToExcel(gvlistbrary, DateTime.Now.Ticks + ".xls");
                    }
                    return;
                }
            }
            if (!string.IsNullOrEmpty(hid.Text.Trim()))
            {
                where += " and QuestionClsId =" + hid.Text.Trim();
            }
            //难度
            if (int.Parse(dllharde.SelectedItem.Value) != -1)
            {
                where += " and Isdifficulty =" + dllharde.SelectedValue;
            }
            //状态
            if (int.Parse(dllstatus.SelectedItem.Value) != -1)
            {
                where += " and Status=" + dllstatus.SelectedValue;
            }
            //单选
            if (int.Parse(dlltype.SelectedItem.Value) != -1)
            {
                where += " and Type=" + dlltype.SelectedValue;
            }
            DataSet ds = Exam.BLL.tb_QuestionBLL.GetInstance().GetList("schoolid=" + 0 + where);
            gvlistbrary.DataSource = ds;
            gvlistbrary.DataBind();
            if (gvlistbrary.Rows.Count > 0)
            {
                //调用导出方法  
                GridViewToExcel(gvlistbrary, DateTime.Now.Ticks + ".xls");
            }
            else
            {
                MessageBox.Show(this, "没有数据可导出，请先查询数据!");
            }
        }
    }
 
}