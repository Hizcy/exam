using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class count_Count : BasePage
{
    public string score = "";
    public string realname = "";
    public string point = "";
    public int zf = 0;//总分
    public float avgscore = 0;//平均分
    public int maxscore = 0;//最高分
    public int minscore = 0;//最低分
   

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
        if (identity != null)
        {
           
            if (identity._roleID == 2 || identity._roleID==4 || identity._roleID==5  )
            {

               string departmentid =hiddepartmentId.Text.Trim();
               if (departmentid != "")
               {
                   labdepartment.Text = hidname.Text.Trim();
                   DataSet ds = Exam.BLL.tb_ResultBLL.GetInstance().GetListByDepartmentId(int.Parse(departmentid));
                   if (ds != null && ds.Tables.Count > 0)
                   {
                       rptCountList.DataSource = ds;
                       rptCountList.DataBind();
                   }
                   if (ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows != null)
                   {
                       System.Text.StringBuilder sbname = new System.Text.StringBuilder();
                       System.Text.StringBuilder sbscore = new System.Text.StringBuilder();
                       System.Text.StringBuilder sbpass = new System.Text.StringBuilder();
                       System.Text.StringBuilder tsbscore = new System.Text.StringBuilder();
                      
                       for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                       {
                           tsbscore.Append(ds.Tables[0].Rows[i]["score"]+",");
                           sbscore.Append("{\"value\":\"" + ds.Tables[0].Rows[i]["score"] + "\"},");
                           sbname.Append("{\"label\":\"" + ds.Tables[0].Rows[i]["realname"] + "\"},");
                           sbpass.Append("{\"value\":\"" + ds.Tables[0].Rows[i]["point"] + "\"},");
                       }

                       score = sbscore.ToString().TrimEnd(',');
                       realname = sbname.ToString().TrimEnd(',');
                       point = sbpass.ToString().TrimEnd(',');
                       string[] arr = tsbscore.ToString().TrimEnd(',').Split(',');
                       maxscore = int.Parse(arr[0]);
                       minscore = int.Parse(arr[0]);
                       foreach (string str in arr)
                       {
                           if (maxscore < int.Parse(str))
                           {
                               maxscore = int.Parse(str);
                           }
                           if (minscore > int.Parse(str))
                           {
                               minscore = int.Parse(str);
                           }
                           zf += int.Parse(str);
                       }
                       avgscore = zf / int.Parse(arr.Length.ToString());
                  
                   }
               }     
           }
              
        }
    }
    protected void btncx_Click(object sender, EventArgs e)
    {
        BindData();
    } 
}
