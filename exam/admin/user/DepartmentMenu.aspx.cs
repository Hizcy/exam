using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class book_Default : System.Web.UI.Page
{
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
        }
    }
    public string TableCss(int schoolid)
    {

        System.Text.StringBuilder bu = new System.Text.StringBuilder();
        IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdList(0);
        if (list.Count > 0 && list != null)
        {

            bu.Append("<table  width=\"668px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"ListProduct\" style=\"margin-top:0px;border-top:0px;margin-top: -6px;\"> ");
            foreach (Exam.Entity.tb_DepartmentEntity department in list)
            {
                if (department.ParentId == 0)
                {
                    bu.Append("<thead>");
                    //父节点
                    bu.Append("<tr class=\"hover\" style=\"line-height:30px;height:30\">");
                    bu.Append("<td style=\"width:5%\"></td>");
                    bu.Append("<td style=\"width:61%\"><div><span>" + department.Name + "</span></div></td>");
                    bu.Append("<td style=\"width:34%;\">"
                                   + "<a href=\"javascript:Endit(" + department.DepartmentId + ")\"><img src=\"../images/edit.png\" style=\"margin-left:60px\" /></a>"
                                   + "<a href=\"javascript:Add(" + department.DepartmentId + ")\"><img src=\"../images/added.png\" style=\"margin-left:20px\" /></a>"
                                   + "<a href=\"javascript:Delete(" + department.DepartmentId + ")\"><img src=\"../images/delete.png\" style=\"margin-left:20px\" /></a>"
                                + "</td>");
                    bu.Append("</tr>");
                    //子节点
                    IList<Exam.Entity.tb_DepartmentEntity> templist = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdList(department.DepartmentId);
                    if (templist.Count > 0 && templist != null)
                    {
                        foreach (Exam.Entity.tb_DepartmentEntity tmp in templist)
                        {
                            bu.Append("<tr class=\"hover\"  style=\"line-height:30px;height:30\">");
                            bu.Append("<td style=\"width:5%\"></td>");
                            bu.Append("<td><div class=\"board\"><span>" + tmp.Name + "</span></div></td>");
                            bu.Append("<td>"
                                          + "<a href=\"javascript:Endit(" + tmp.DepartmentId + ")\"><img src=\"../images/edit.png\" style=\"margin-left:60px\" /></a>"
                                          + "<a href=\"javascript:Add(" + tmp.DepartmentId + ")\"><img src=\"../images/added.png\" style=\"margin-left:20px\" /></a>"
                                          + "<a href=\"javascript:Delete(" + tmp.DepartmentId + ")\"><img src=\"../images/delete.png\" style=\"margin-left:20px\" /></a>"
                                       + "</td>");
                            bu.Append("</tr>");
                            //三级节点
                            IList<Exam.Entity.tb_DepartmentEntity> templist2 = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdList(tmp.DepartmentId);
                            if (templist2.Count > 0 && templist2 != null)
                            {
                                foreach (Exam.Entity.tb_DepartmentEntity tmp2 in templist2)
                                {
                                    bu.Append("<tr class=\"hover\"  style=\"line-height:30px;height:30\">");
                                    bu.Append("<td style=\"width:%\"></td>");
                                    bu.Append("<td><div><span style=\"margin-left:55px\"><img src=\"../images/bg_repno.png\" />" + tmp2.Name + "</span></div></td>");
                                    bu.Append("<td>"
                                                 + "<a href=\"javascript:Endit(" + tmp2.DepartmentId + ")\"><img src=\"../images/edit.png\" style=\"margin-left:60px\" /></a>"
                                                 + "<a href=\"javascript:Add(-1)\"><img src=\"../images/added.png\" style=\"margin-left:20px\" /></a>"
                                                 + "<a href=\"javascript:Delete(" + tmp2.DepartmentId + ")\"><img src=\"../images/delete.png\" style=\"margin-left:20px\" /></a>"
                                              + "</td>");
                                    bu.Append("</tr>");
                                }
                            }
                        }
                    }

                    bu.Append("</thead>");
                    //bu.Append("</tbody>");
                }
            }
            bu.Append("</table>");
        }
        return bu.ToString();
    }
}