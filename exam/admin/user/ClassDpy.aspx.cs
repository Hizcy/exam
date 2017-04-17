using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ClassDpy : System.Web.UI.Page
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
        Exam.Entity.tb_DepartmentEntity model = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentEntityBySchoold(identity._schoolID);
        IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdListNowStatus(model.DepartmentId);
        if (list.Count > 0 && list != null)
        {
            rptResultsList.DataSource = list;
            rptResultsList.DataBind();
            for (int i = 0; i < rptResultsList.Items.Count; i++)
            {
                DropDownList dll = (DropDownList)rptResultsList.Items[i].FindControl("ddlstatus");
                if (list[i].Status == 0)
                {
                    dll.SelectedValue = "0";
                }
            }
        }
    }
    protected void rptResultsList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "show")
        {
            for (int i = 0; i < rptResultsList.Items.Count; i++)
            {
                Button tbtn = (Button)rptResultsList.Items[i].FindControl("btn");
                Repeater trpt = (Repeater)rptResultsList.Items[i].FindControl("rptResults2");
                if (tbtn != e.Item.FindControl("btn") as Button)
                {
                    if (tbtn.Text == "▼")
                    {
                        tbtn.Text = "▲";
                        trpt.DataSource = string.Empty;
                        trpt.DataBind();
                    }
                }
            }
            IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdListNowStatus(int.Parse(e.CommandArgument.ToString()));
            if (list != null && list.Count > 0)
            {
                Button btn = e.Item.FindControl("btn") as Button;
                Repeater rpt = e.Item.FindControl("rptResults2") as Repeater;

                if (btn.Text == "▲")
                {
                    btn.Text = "▼";
                    rpt.DataSource = list;
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
                                for(int k=0;k<tlist.Count;k++)
                                {
                                    //具体班级
                                    Exam.Entity.tb_DepartmentEntity tempmodel = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(tlist[k].DepartmentId);
                                    if(tempmodel != null)
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