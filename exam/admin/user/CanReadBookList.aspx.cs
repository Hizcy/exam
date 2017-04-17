using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class user_CanReadBookList : System.Web.UI.Page
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
            IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsList();
            list = list.Where(c => c.ParentId == 0 && c.Status == 1).ToList();
            rptResultsList.DataSource = list;
            rptResultsList.DataBind();
        }
    }
    protected void rptResultsList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "show")
        {
            UserIdentity identity=User.Identity as UserIdentity;
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserIdentity identity = User.Identity as UserIdentity;
        //所属学校
        Exam.Entity.tb_DepartmentEntity model = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentEntityBySchoold(identity._schoolID);
        //年级
        IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdListNowStatus(163);
        try
        {
            if (list.Count > 0 && list != null)
            {
                for (int i = 0; i < rptResultsList.Items.Count; i++)
                {
                    DropDownList drp = rptResultsList.Items[i].FindControl("ddlstatus") as DropDownList;
                    //判断是否改动
                    if (list[i].Status != int.Parse(drp.SelectedValue))
                    {
                        //具体年级
                        Exam.Entity.tb_DepartmentEntity tmodel = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(list[i].DepartmentId);
                        if (tmodel != null)
                        {
                            //班级
                            IList<Exam.Entity.tb_DepartmentEntity> tlist = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdListNowStatus(tmodel.DepartmentId);
                            if (tlist.Count > 0 && tlist != null)
                            {
                                //班级循环
                                for (int k = 0; k < tlist.Count; k++)
                                {
                                    //具体班级
                                    Exam.Entity.tb_DepartmentEntity tempmodel = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(tlist[k].DepartmentId);
                                    if (tempmodel != null)
                                    {
                                        tempmodel.Status = int.Parse(drp.SelectedValue);
                                        Exam.BLL.tb_DepartmentBLL.GetInstance().Update(tempmodel);
                                    }

                                }
                            }
                            tmodel.Status = int.Parse(drp.SelectedValue);
                            Exam.BLL.tb_DepartmentBLL.GetInstance().Update(tmodel);
                        }
                    }
                }
            }
            Datainfo();

        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,btnSave_Click,ex:" + ex.Message + "|" + ex.StackTrace);
        }
    }
}