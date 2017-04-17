using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Exam.Entity;
using Exam.BLL;
public partial class record_RecordList :System.Web.UI.Page
{
    public int schoolId
    {
        get
        {
            object obj = Request.QueryString["schoolid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public int UserId
    {
        get
        {
            object obj = Request.QueryString["userid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public string idName
    {
        get
        {
            object obj = Request.QueryString["idname"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    public string iddomain
    {
        get
        {
            object obj = Request.QueryString["iddomain"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                BindData();
            }
            catch (Exception ex)
            {
                Jnwf.Utils.Log.Logger.Log4Net.Error("1.recordlist.aspx:" + ex.Message + "|" + ex.StackTrace);
            }
            
        }
    }
    private void BindData()
    {
        DataSet ds = Exam.BLL.tb_ResultBLL.GetInstance().GetStatListByUserId(UserId);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null && ds.Tables[0].Rows.Count > 0)
        {
            rptrecord.DataSource = ds;
            rptrecord.DataBind();
        }
        else
        {
            rptrecord.DataSource = string.Empty;
            rptrecord.DataBind();
        }
         
    }

}