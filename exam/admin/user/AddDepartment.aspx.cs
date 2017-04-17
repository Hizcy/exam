using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_AddDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserIdentity identity = User.Identity as UserIdentity;
            //超级管理员
            if (identity._roleID == 4)
            {
                IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentSchoolIdAll();
                if (list.Count > 0 && list != null)
                {
                    listMent.DataSource = list;
                    listMent.DataTextField = "name";
                    listMent.DataValueField = "departmentid";
                    listMent.DataBind();
                }
            }
            //管理员 和 教师
            else
            {
                if (identity != null)
                {
                    IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentSchoolIdListTow(identity._schoolID);
                    if (list.Count > 0 && list != null)
                    {
                        listMent.DataSource = list;
                        listMent.DataTextField = "name";
                        listMent.DataValueField = "departmentid";
                        listMent.DataBind();
                    }
                }
            }
        }
    }
    protected void listMent_SelectedIndexChanged(object sender, EventArgs e)
    {
        hid1.Text = listMent.SelectedItem.Text;
        hid2.Text = listMent.SelectedValue;
        UserIdentity identity = User.Identity as UserIdentity;
        int parentid = int.Parse(listMent.SelectedValue.ToString());
        if (identity != null)
        {
            //管理员and超级管理员
            if (identity._roleID ==1 || identity._roleID == 4)
            {
                IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdList(parentid);
                listMent2.Items.Clear();
                listMent3.Items.Clear();
                if (list.Count > 0 && list != null)
                {
                    listMent2.DataSource = list;
                    listMent2.DataTextField = "name";
                    listMent2.DataValueField = "departmentid";
                    listMent2.DataBind();
                }
            }
            //教师
            else if (identity._roleID == 2)
            {
                listMent2.Items.Clear();
                listMent3.Items.Clear();
                Exam.Entity.tb_User_DepartmentEntity tmodel = Exam.BLL.tb_User_DepartmentBLL.GetInstance().GetAdminByUserId(identity.UserID);
                if (tmodel != null)
                {
                    DataSet ds = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentDatasetId(tmodel.DepartmentId, identity._schoolID);
                    if(ds != null)
                    {   
                        listMent2.DataSource = ds;
                        listMent2.DataTextField = "parentname";
                        listMent2.DataValueField = "parentid";
                        listMent2.DataBind();
                    }
                }
                
            }
        }

    }
    protected void listMent2_SelectedIndexChanged(object sender, EventArgs e)
    {
        hid1.Text = listMent2.SelectedItem.Text;
        hid2.Text = listMent2.SelectedValue; 
         int parentid = int.Parse(listMent2.SelectedValue.ToString());
         UserIdentity identity = User.Identity as UserIdentity;
         if (identity != null)
         {
             //管理员
             if (identity._roleID == 1 || identity._roleID==4)
             {
                 IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdList(parentid);
                 listMent3.Items.Clear();
                 if (list.Count > 0 && list != null)
                 {
                     listMent3.DataSource = list;
                     listMent3.DataTextField = "name";
                     listMent3.DataValueField = "departmentid";
                     listMent3.DataBind();
                 }
             }
             //教师
             else if (identity._roleID == 2)
             {
                //老师所教（所有班级）
                Exam.Entity.tb_User_DepartmentEntity tmodel = Exam.BLL.tb_User_DepartmentBLL.GetInstance().GetAdminByUserId(identity.UserID);
                if (tmodel != null)
                {
                    DataSet ds = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentDatasetIdThree(tmodel.DepartmentId, identity._schoolID, parentid);
                    listMent3.Items.Clear();
                    if ( ds != null)
                    {
                        listMent3.DataSource = ds;
                        listMent3.DataTextField = "name";
                        listMent3.DataValueField = "departmentid";
                        listMent3.DataBind();
                    }
                }
            }
        }
            
     }
    protected void listMent3_SelectedIndexChanged(object sender, EventArgs e)
    {
        hid1.Text += listMent3.SelectedItem.Text;
        hid2.Text = listMent3.SelectedValue; ;
    }
}