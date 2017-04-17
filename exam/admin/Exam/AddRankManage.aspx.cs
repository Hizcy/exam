using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_AddRankManage_aspx : System.Web.UI.Page
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
        List<Exam.Entity.tb_QuestionClsEntity> listOne = new List<Exam.Entity.tb_QuestionClsEntity>();
        List<Exam.Entity.tb_QuestionClsEntity> listTwo = new List<Exam.Entity.tb_QuestionClsEntity>();
        List<Exam.Entity.tb_QuestionClsEntity> listThree = new List<Exam.Entity.tb_QuestionClsEntity>();
        IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().QuestionClsList();
        if (list != null && list.Count > 0)
        {
            listOne = list.Where(c => c.ParentId == 0).ToList();
            bu.Append("<table  width=\"668px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"ListProduct\" style=\"margin-top:0px;border-top:0px;margin-top: -6px;\"> ");
            foreach (Exam.Entity.tb_QuestionClsEntity question in listOne)
            {
                    bu.Append("<thead>");
                    //父节点
                    bu.Append("<tr class=\"hover\" style=\"line-height:30px;height:30\">");
                    bu.Append("<td style=\"width:5%\"></td>");
                    bu.Append("<td style=\"width:61%\"><div><span>" + question.Name + "</span></div></td>");
                    bu.Append("<td style=\"width:34%;\">"
                                   + "<a href=\"javascript:Endit(1," + question.QuestionClsId + "-1,-1,-1)\"><img src=\"../images/edit.png\" style=\"margin-left:60px\" /></a>"
                                   + "<a href=\"javascript:Add(1," + question.QuestionClsId + ")\"><img src=\"../images/added.png\" style=\"margin-left:20px\" /></a>"
                                   + "<a href=\"javascript:Delete(" + question.QuestionClsId + ")\"><img src=\"../images/delete.png\" style=\"margin-left:20px\" /></a>"
                                + "</td>");
                    bu.Append("</tr>");
                    //子节点
                    listTwo = list.Where(c => c.ParentId == question.QuestionClsId).ToList();
                    if (listTwo != null && listTwo.Count > 0)
                    {
                        foreach (Exam.Entity.tb_QuestionClsEntity tmp in listTwo)
                        {
                            bu.Append("<tr class=\"hover\"  style=\"line-height:30px;height:30\">");
                            bu.Append("<td style=\"width:5%\"></td>");
                            bu.Append("<td><div class=\"board\"><span>" + tmp.Name + ",积分：" + tmp.Score + "&nbsp;</span><span></div></td>");
                            bu.Append("<td>"
                                          + "<a href=\"javascript:Endit(2,"+tmp.QuestionClsId +",'"+tmp.Name+"','"+tmp.Score+"','"+tmp.IsMust+"')\"><img src=\"../images/edit.png\" style=\"margin-left:60px\" /></a>"
                                          + "<a href=\"javascript:Add(2," + tmp.QuestionClsId + ")\"><img src=\"../images/added.png\" style=\"margin-left:20px\" /></a>"
                                          + "<a href=\"javascript:Delete(" + tmp.QuestionClsId + ")\"><img src=\"../images/delete.png\" style=\"margin-left:20px\" /></a>"
                                       + "</td>");
                            bu.Append("</tr>");
                            //三级节点
                            listThree = list.Where(t => t.ParentId == tmp.QuestionClsId).ToList();
                            if (listThree != null && listThree.Count > 0)
                            {
                                foreach (Exam.Entity.tb_QuestionClsEntity tmp2 in listThree)
                                {
                                    bu.Append("<tr class=\"hover\"  style=\"line-height:30px;height:30\">");
                                    bu.Append("<td></td>");
                                    bu.Append("<td><div><span style=\"margin-left:55px\"><img src=\"../images/bg_repno.png\" />" + tmp2.Name + "</span></div></td>");
                                    bu.Append("<td>"
                                                 + "<a href=\"javascript:Endit(1," + tmp2.QuestionClsId + ")\"><img src=\"../images/edit.png\" style=\"margin-left:60px\" /></a>"
                                                 + "<a href=\"javascript:Delete(" + tmp2.QuestionClsId + ")\"><img src=\"../images/delete.png\" style=\"margin-left:62px\" /></a>"
                                              + "</td>");
                                    bu.Append("</tr>");

                                }
                            }
                        }
                    }
                    bu.Append("</thead>");
                    bu.Append("</tbody>");
            }
        }
        return bu.ToString();
    }
}
 