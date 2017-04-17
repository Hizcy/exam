using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Exam.BLL;
public partial class user_ListReview : System.Web.UI.Page
{
    public int i = 1;
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

            DataSet ds = Exam.BLL.tb_UserBLL.GetInstance().GetStatus0List();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                var matches = from c in ds.Tables[0].AsEnumerable() where c.Field<string>("Name") == "admin" select c;
                rptlistreview.DataSource = matches.AsDataView();
                //rptlistreview.DataSource = ds;
                rptlistreview.DataBind();
                i = 2;
            }
            else
            {
                rptlistreview.DataSource = string.Empty;
                rptlistreview.DataBind();
            }

        }
    }
   
}