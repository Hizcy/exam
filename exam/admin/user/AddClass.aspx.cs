using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_AddClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                Exam.Entity.tb_DepartmentEntity model = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentEntityBySchoold(identity._schoolID);
                IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdList(model.DepartmentId);
                if (list.Count > 0 && list != null)
                {
                    listClass.DataSource = list;
                    listClass.DataTextField = "name";
                    listClass.DataValueField = "DepartmentId";
                    listClass.DataBind();
                }
            }
        }
    }
    //转移到右边
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        List<ListItem> list = new List<ListItem>();
        for (int i = 0; i < listClass.Items.Count; i++)
        {
            if (listClass.Items[i].Selected)
            {
                ListItem tmp = new ListItem();
                tmp.Value = listClass.Items[i].Value;
                tmp.Text = listClass.Items[i].Text;
                list.Add(tmp);
            }
        }
        if (list.Count > 0 && list != null)
        {
            foreach (ListItem it in list)
            {
                listClass.Items.Remove(it);
                listClass2.Items.Add(it);
            }
        }
    }
    //转移到左边
    protected void imgleft_Click(object sender, ImageClickEventArgs e)
    {
        List<ListItem> list = new List<ListItem>();
        for (int i = 0; i < listClass2.Items.Count; i++)
        {
            if (listClass2.Items[i].Selected)
            {
                ListItem itme = new ListItem();
                itme.Value = listClass2.Items[i].Value;
                itme.Text = listClass2.Items[i].Text;
                list.Add(itme);
            }
        }
        if (list.Count > 0 && list != null)
        {
            foreach(ListItem tmp in list)
            {
                listClass2.Items.Remove(tmp);
                listClass.Items.Add(tmp);
            }
        }
        
    }
}