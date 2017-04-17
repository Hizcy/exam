using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Exam_ExtractNumber : System.Web.UI.Page
{
    public  int jdNum = 0;
    public  int knNum = 0;
    public int questionclsId
    {
        get
        {
            object obj = Request.QueryString["questionclsid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public int id
    {
        get
        {
            object obj = Request.QueryString["id"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public int type
    {
        get
        {
            object obj = Request.QueryString["type"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {

                DataSet ds = Exam.BLL.tb_QuestionBLL.GetInstance().GetDiffCountBySchoolAndCls(0,questionclsId,type);
                if (ds != null && ds.Tables[0].Rows.Count>0 && ds.Tables[0].Rows[0] != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (int.Parse(dr["Isdifficulty"].ToString()) == 0)
                        {
                            jdNum += int.Parse(dr["Number"].ToString());
                        }
                        else
                        {
                            knNum += int.Parse(dr["Number"].ToString());
                        }
                    }
                }
            }
        }
    }
}