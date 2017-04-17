using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_QuestionManage : System.Web.UI.Page
{
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
    public int schoolId
    {
        get
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity == null)
            {
                return 0;
            }
            return identity._schoolID;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsListSchoolIdOne(schoolId);
            if (list.Count > 0 && list != null)
            {
                listMent.DataSource = list;
                listMent.DataTextField = "name";
                listMent.DataValueField = "questionclsid";
                listMent.DataBind();
            }
        }
    }
    protected void listMent_SelectedIndexChanged(object sender, EventArgs e)
    {
        hid1.Text = listMent.SelectedItem.Text;
        hid2.Text = listMent.SelectedValue; ;
        int parentid = int.Parse(listMent.SelectedValue.ToString());
        IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsListParentIdTow(parentid);
        listMent2.Items.Clear();
        listMent3.Items.Clear();
        if (list.Count > 0 && list != null)
        {
            listMent2.DataSource = list;
            listMent2.DataTextField = "name";
            listMent2.DataValueField = "questionclsid";
            listMent2.DataBind();
        }

    }
    protected void listMent2_SelectedIndexChanged(object sender, EventArgs e)
    {
        hid1.Text = listMent2.SelectedItem.Text;
        hid2.Text = listMent2.SelectedValue; ;
        int parentid = int.Parse(listMent2.SelectedValue.ToString());
        IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsListParentIdTow(parentid);
        listMent3.Items.Clear();
        if (list.Count > 0 && list != null)
        {
            listMent3.DataSource = list;
            listMent3.DataTextField = "name";
            listMent3.DataValueField = "questionclsid";
            listMent3.DataBind();
        }
    }
    protected void listMent3_SelectedIndexChanged(object sender, EventArgs e)
    {
        hid1.Text = listMent3.SelectedItem.Text;
        hid2.Text = listMent3.SelectedValue; ;
    }
}