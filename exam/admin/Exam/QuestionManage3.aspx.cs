using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_QuestionManage3 : System.Web.UI.Page
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
    public int tkid
    {
        get
        {
            object obj = Request.QueryString["tkid"];
            if (obj == null)
            {
                return 32;
            }
            return int.Parse(obj.ToString());
        }
    }
    public static string name = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Exam.Entity.tb_QuestionClsEntity model = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(tkid);
            if (model != null)
            {
                name = model.Name;
                IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsListParentIdTow(model.QuestionClsId);
                if (list != null && list.Count > 0)
                {
                    listboxManage.DataSource = list;
                    listboxManage.DataTextField = "name";
                    listboxManage.DataValueField = "questionclsid";
                    listboxManage.DataBind();
                }
            }
        }

    }
    protected void listboxManage_SelectedIndexChanged(object sender, EventArgs e)
    {
        hid1.Text = listboxManage.SelectedItem.Text;
        hid2.Text = listboxManage.SelectedValue;
    }
}