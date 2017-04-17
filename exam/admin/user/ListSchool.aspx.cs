using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;
using System.Data;
public partial class user_ListSchool : BasePage//System.Web.UI.Page
{
    public int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<tb_LocationEntity> list = Exam.BLL.tb_LocationBLL.GetInstance().GetProvinceByCache();
            this.ddlprovince.DataSource = list;
            this.ddlprovince.DataTextField = "LocationName";
            this.ddlprovince.DataValueField = "LocationId";
            this.ddlprovince.DataBind();
            BindData();
        }

    }
    private void BindData()
    {
        string where = "";
        if (!string.IsNullOrEmpty(selecteurozone.Text) && !selecteurozone.Text.Equals("0"))
        {
             where = "and LocationId=" + selecteurozone.Text.Trim();
        }
        else if (!string.IsNullOrEmpty(selectcity.Text) && !selectcity.Text.Equals("0"))
        {
            Exam.Entity.tb_LocationEntity model = Exam.BLL.tb_LocationBLL.GetInstance().GetAdminSingle(int.Parse(ddlcity.Value));
            where = " and locationpath like '" + model.LocationPath + "%'";
        }
        else if (!string.IsNullOrEmpty(ddlprovince.Value))
        {
            if (ddlprovince.Value.Equals("0"))
            {
                where = " and 1=1";
            }
            else
            {
                Exam.Entity.tb_LocationEntity model = Exam.BLL.tb_LocationBLL.GetInstance().GetAdminSingle(int.Parse(ddlprovince.Value));
                where = " and locationpath like '" + model.LocationPath + "%'";
            }
        }
        if (identity != null)
        {
            //超级管理员
            if (identity._roleID == 4)
            {
                if (!string.IsNullOrEmpty(ddlstatus.SelectedValue))
                {
                    where += " and status=" + ddlstatus.SelectedValue;
                }
            }
            //代理商
            else if (identity._roleID == 5)
            {
                where += " and agent=" + identity.UserID;
                int schoolid = int.Parse(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("agentid"));
                if (!string.IsNullOrEmpty(ddlstatus.SelectedValue))
                {
                    where += " and status=" + ddlstatus.SelectedValue;
                }
            }
            
            int allCount;
            int CurrentPage = 0;
            CurrentPage = this.pager1.CurrentPageIndex;
            DataSet ds = Exam.BLL.tb_SchoolBLL.GetInstance().GetList(pager1.PageSize, CurrentPage, " 1=1 " + where, out allCount);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                rptResultsList.DataSource = ds;
                rptResultsList.DataBind();
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
    protected void selectcity_Load(object sender, EventArgs e)
    {
        if (ddlprovince.Value.Equals("0"))
        {
            List<tb_LocationEntity> list = new List<tb_LocationEntity>();
            tb_LocationEntity model = new tb_LocationEntity();
            model.LocationName = "市";
            model.LocationId = 0;
            list.Add(model);
            ddlcity.DataSource = list;
            ddlcity.DataTextField = "LocationName";
            ddlcity.DataValueField = "LocationId";
            ddlcity.DataBind();

            List<tb_LocationEntity> tlist = new List<tb_LocationEntity>();
            tb_LocationEntity tmodel = new tb_LocationEntity();
            tmodel.LocationName = "县/区";
            tmodel.LocationId = 0;
            tlist.Add(tmodel);
            ddleurozone.DataSource = tlist;
            ddleurozone.DataTextField = "LocationName";
            ddleurozone.DataValueField = "LocationId";
            ddleurozone.DataBind();
            
        }
        if (!string.IsNullOrEmpty(selectcity.Text) && !ddlprovince.Value.Equals("0"))
        {
            IList<Exam.Entity.tb_LocationEntity> ds = Exam.BLL.tb_LocationBLL.GetInstance().GetCityByCache(int.Parse(ddlprovince.Value));
            if (ds != null && ds.Count > 0)
            {
                tb_LocationEntity model = new tb_LocationEntity();
                model.LocationName = "全部";
                model.LocationId = 0;
                ds.Insert(0, model);
                ddlcity.DataSource = ds;
                ddlcity.DataTextField = "LocationName";
                ddlcity.DataValueField = "LocationId";
                ddlcity.DataBind();
                for (int i = 0; i < ddlcity.Items.Count; i++)
                {
                    if (ddlcity.Items[i].Value == selectcity.Text)
                    {
                        ddlcity.Items[i].Selected = true;
                    }
                }
            }

        }
        if (!string.IsNullOrEmpty(selecteurozone.Text))
        {
            if (!selecteurozone.Text.Equals("0"))
            {
                IList<Exam.Entity.tb_LocationEntity> ds = Exam.BLL.tb_LocationBLL.GetInstance().GetEurozoneByCache(int.Parse(ddlcity.Value));
                if (ds != null)
                {
                    tb_LocationEntity model = new tb_LocationEntity();
                    model.LocationName = "全部";
                    model.LocationId = 0;
                    ds.Insert(0, model);
                    ddleurozone.DataSource = ds;
                    ddleurozone.DataTextField = "LocationName";
                    ddleurozone.DataValueField = "LocationId";
                    ddleurozone.DataBind();
                    for (int i = 0; i < ddleurozone.Items.Count; i++)
                    {
                        if (ddleurozone.Items[i].Value == selecteurozone.Text)
                        {
                            ddleurozone.Items[i].Selected = true;
                        }
                    }
                }
            }
            else
            {
                IList<Exam.Entity.tb_LocationEntity> ds = new List<Exam.Entity.tb_LocationEntity>();
                tb_LocationEntity model = new tb_LocationEntity();
                if (!ddlcity.Value.Equals("0"))
                {
                    model.LocationName = "全部";
                    model.LocationId = 0;
                    ds.Insert(0, model);
                    ddleurozone.DataSource = ds;
                    ddleurozone.DataTextField = "LocationName";
                    ddleurozone.DataValueField = "LocationId";
                    ddleurozone.DataBind();
                }
                else
                {
                    model.LocationName = "县/区";
                    model.LocationId = 0;
                    ds.Insert(0, model);
                    ddleurozone.DataSource = ds;
                    ddleurozone.DataTextField = "LocationName";
                    ddleurozone.DataValueField = "LocationId";
                    ddleurozone.DataBind();
                }
            }
        }
    }
} 