using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class user_CanReadBookList :BasePage// System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datainfo();
        }
    }
    public void Datainfo()
    {
        UserIdentity identity = User.Identity as UserIdentity;
        if (identity != null)
        {
            DataSet ds = Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Get_School_QuestionClsRelationIdBySchoolId(identity._schoolID,0);
            rptResultsList.DataSource = ds;
            rptResultsList.DataBind();
        }
    }
    protected void rptResultsList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "show")
        {
            for(int i=0;i<rptResultsList.Items.Count;i++)
            {
                Repeater trpt = (Repeater)rptResultsList.Items[i].FindControl("rptResults2");
                Button btn = (Button)rptResultsList.Items[i].FindControl("btn");
                if (btn != e.Item.FindControl("btn") as Button)
                {
                    if (btn.Text == "▼")
                    {
                        btn.Text = "▲";
                        if (trpt != null && trpt.Items.Count > 0)
                        {
                            trpt.DataSource = string.Empty;
                            trpt.DataBind();
                        }
                    }
                }
            }
            if(identity != null)
            {
                DataSet ds = Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Get_School_QuestionClsRelationIdBySchoolId(identity._schoolID,int.Parse(e.CommandArgument.ToString()));
                if (ds != null)
                {
                    Button btn = e.Item.FindControl("btn") as Button;
                    Repeater rpt = e.Item.FindControl("rptResults2") as Repeater;
                    if (btn.Text == "▲")
                    {
                        btn.Text = "▼";
                        rpt.DataSource = ds;
                        rpt.DataBind();
                    }
                    else
                    {
                        btn.Text = "▲";
                        rpt.DataSource = string.Empty;
                        rpt.DataBind();
                    }
                }
            }
        }
    }

    protected void rptResultsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
    }
}