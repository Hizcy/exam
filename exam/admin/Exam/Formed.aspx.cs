using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Exam_Formed : System.Web.UI.Page
{
    public int exampaperId
    {
        get
        {
            object obj = Request.QueryString["exampaperid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public int num = 0;
    public string namek = "";//所选书库名
    public string tempstr = "";
    public int exampaperclsd = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (exampaperId > 0)
            {
                Exam.Entity.tb_ExampaperEntity model = Exam.BLL.tb_ExampaperBLL.GetInstance().GetAdminSingle(exampaperId);
                if (model != null)
                {
                    Exam.Entity.tb_QuestionClsEntity question = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(model.ExampaperClsId);
                    if (question != null)
                    {
                        namek = question.Name;
                    }
                    txthid.Text = model.ExampaperClsId.ToString();
                    exampaperclsd = model.ExampaperClsId;
                    txthidname.Text = model.Name;
                    ddlstatus.SelectedValue = model.Status.ToString();
                    ddltype.SelectedIndex = model.Type;
                    txttime.Text = model.Duration.ToString();
                    txtscore.Text = model.Pass.ToString();
                }
                IList<Exam.Entity.tb_ExampaperExtEntity> list = Exam.BLL.tb_ExampaperExtBLL.GetInstance().GetListByExampaperId(exampaperId);
                System.Text.StringBuilder strb = new System.Text.StringBuilder();
                if (list.Count > 0 && list != null)
                {
                    int id = 0;
                    foreach (Exam.Entity.tb_ExampaperExtEntity temp in list)
                    {
                        string tempStr2 = "\"num1\":\"" + temp.Number + "\",\"num2\":\"" + temp.Diff+"\"";
                      
                        Exam.Entity.tb_QuestionClsEntity question = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(temp.tb_QuestionClsId);
                        if (temp.Type == 1)
                        {
                            id++;
                            strb.Append("<tr class=\"tr\" id=\"tr" + id + "\">"
                                        + "<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                        + "<td ><input id=\"txttype" + id + "\" type=\"text\"  style=\"display:none\" value=\"1\" /><span>单选</span></td>"
                                        + "<td ><span id=\"num" + id + "\">" + (temp.Number + temp.Diff) + "</span></td>"
                                        + "<td ><input id=\"txttile" + id + "\" Value=\"" + temp.Title + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" Value=\"" + temp.Score + "\" type=\"text\" style=\"width:50px\" /></td>"
                                        + "<td><a href=\"javascript:selectExam(" + id + ")\" style=\"text-decoration:none\"><span id=\"select" + id + "\">"+question.Name+"</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" value=\""+temp.tb_QuestionClsId+"\" id=parentid" + id + " /></td>"
                                        + "<td><a href=\"javascript:extractNum(1," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\" style=\"display:none\"   value='" + tempStr2 + "' id=hid" + id + " /></td></tr>");
                        }
                        else if(temp.Type == 2)
                        {
                            id++;
                            strb.Append("<tr  class=\"tr\" id=\"tr" + id + "\">"
                                        + "<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                        + "<td ><input id=\"txttype" + id + "\" type=\"text\"  style=\"display:none\" value=\"2\" /><span>多选</span></td>"
                                        + "<td ><span id=\"num" + id + "\">" + (temp.Number + temp.Diff) + "</span></td>"
                                        + "<td ><input id=\"txttile" + id + "\" Value=\"" + temp.Title + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" Value=\"" + temp.Score + "\" type=\"text\" style=\"width:50px\" /></td>"
                                        + "<td><a href=\"javascript:selectExam(" + id + ")\" style=\"text-decoration:none\"><span id=\"select" + id + "\">"+question.Name+"</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" value=\""+temp.tb_QuestionClsId+"\" id=parentid" + id + " /></td>"
                                        + "<td><a href=\"javascript:extractNum(2," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\" style=\"display:none\"   value='" + tempStr2 + "' id=hid" + id + " /></td></tr>");
                        }
                        else if(temp.Type == 3)
                        {
                            id++;
                            strb.Append("<tr class=\"tr\" id=\"tr" + id + "\">"
                                        + "<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                        + "<td ><input id=\"txttype" + id + "\" type=\"text\"  style=\"display:none\" value=\"3\" /><span>判断</span></td>"
                                        + "<td ><span id=\"num" + id + "\">" + (temp.Number + temp.Diff) + "</span></td>"
                                        + "<td ><input id=\"txttile" + id + "\" Value=\"" + temp.Title + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" Value=\"" + temp.Score + "\" type=\"text\" style=\"width:50px\" /></td>"
                                        + "<td><a href=\"javascript:selectExam(" + id + ")\" style=\"text-decoration:none\"><span id=\"select" + id + "\">" + question.Name + "</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" value=\"" + temp.tb_QuestionClsId + "\" id=parentid" + id + " /></td>"
                                        + "<td><a href=\"javascript:extractNum(3," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\" style=\"display:none\"   value='" + tempStr2 + "' id=hid" + id + " /></td></tr>");
                        }
                        else
                        {
                            id++;
                            strb.Append("<tr class=\"tr\" id=\"tr" + id + "\">"
                                        + "<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                        + "<td ><input id=\"txttype" + id + "\" type=\"text\"  style=\"display:none\" value=\"4\" /><span>填空</span></td>"
                                        + "<td ><span id=\"num" + id + "\">" + (temp.Number + temp.Diff) + "</span></td>"
                                        + "<td ><input id=\"txttile" + id + "\" Value=\"" + temp.Title + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" Value=\"" + temp.Score + "\" type=\"text\" style=\"width:50px\" /></td>"
                                        + "<td><a href=\"javascript:selectExam(" + id + ")\" style=\"text-decoration:none\"><span id=\"select" + id + "\">" + question.Name + "</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" value=\"" + temp.tb_QuestionClsId + "\" id=parentid" + id + " /></td>"
                                        + "<td><a href=\"javascript:extractNum(4," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\" style=\"display:none\"   value='" + tempStr2 + "' id=hid" + id + " /></td></tr>");
                        }
                    }
                    tempstr = strb.ToString();
                }
                Exam.Entity.tb_QuestionClsEntity tempQuestion = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(exampaperclsd);
                if (tempQuestion != null)
                {
                    namek = tempQuestion.Name;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int result = 0;
       
        try
        {
            if (string.IsNullOrEmpty(txthid.Text.Trim()))
            {
                MessageBox.ShowMsg(this, "请选择对应书库！");
                return;
            }
            if (string.IsNullOrEmpty(this.txttime.Text.Trim()))
            {
                MessageBox.ShowMsg(this, "请填写答卷时长");
                return;
            }
            if (string.IsNullOrEmpty(this.txtscore.Text.Trim()))
            {
                MessageBox.ShowMsg(this, "请填写及格分数！");
                return;
            }

            //试卷id
            int exampaperclsid = int.Parse(txthid.Text.Trim());
            txthid.Text = "";//清空
            txtcontent.Text = "";
            int timeleng = int.Parse(txttime.Text.Trim());
            int score = int.Parse(txtscore.Text.Trim());

            string name = this.txthidname.Text.Trim();
            int status = int.Parse(ddlstatus.SelectedValue);
            int type = int.Parse(ddltype.SelectedValue);
            int total = 0;//int.Parse(this.TextBox1.Text.Trim());
            int num = 0;
            string content = this.hid.Text.Trim();

            List<item> list = new List<item>();
            if (content.Length > 0)
            {
                list = Jnwf.Utils.Json.JsonHelper.DeserializeJsonReturnList<item>(content);
            }

            if (list != null && list.Count > 0)
            {
                //书库id ExampaperClaId \\，\\试卷名 name ， \\状态 status ，
                //\\组卷方式 type ， 答卷时长 Duration ，及格分数 pass
                num = list.Sum(c => c.num1 + c.num2);
                total = list.Sum(c => (c.num1 + c.num2) * c.score);
                if(int.Parse(txtscore.Text.Trim().ToString()) > total)
                {
                    MessageBox.ShowMsg(this, "及格分数超出实际总分！");
                    return;
                }
                int row = 0;
                UserIdentity identity = User.Identity as UserIdentity;
                //插入
                if (exampaperId == 0)
                {
                    Exam.Entity.tb_ExampaperEntity tmodel = new Exam.Entity.tb_ExampaperEntity();
                    IList<Exam.Entity.tb_ExampaperEntity> tlist = Exam.BLL.tb_ExampaperBLL.GetInstance().Gettb_ExampaperList();
                    tmodel = tlist.FirstOrDefault(c => c.Name == name);
                    if (tmodel != null)
                    {
                        MessageBox.ShowMsg(this, "此题库已存在");
                        return;
                    }
                    Exam.Entity.tb_ExampaperEntity model = new Exam.Entity.tb_ExampaperEntity();
                    model.SchoolId = 0;
                    model.ExampaperClsId = exampaperclsid;//xin
                    model.Name = name;
                    model.Type = type;
                    model.Num = num;
                    model.Status = status;
                    model.Total = total;
                    model.Founder = identity.Name;
                    model.Addtime = DateTime.Now;
                    model.Updatetime = DateTime.Now;
                    model.Pass = score;//xin
                    model.Duration = timeleng;//xin
                    row = Exam.BLL.tb_ExampaperBLL.GetInstance().Insert(model);
                }
                else
                {
                    Exam.Entity.tb_ExampaperEntity tempexampaper = Exam.BLL.tb_ExampaperBLL.GetInstance().GetAdminSingle(exampaperId);
                    if (tempexampaper != null)
                    {
                        tempexampaper.Name = name;
                        tempexampaper.Type = type;
                        tempexampaper.Num = num;
                        tempexampaper.Status = status;
                        tempexampaper.Total = total;
                        tempexampaper.Founder = identity.Name;
                        tempexampaper.Updatetime = DateTime.Now;
                        tempexampaper.Pass = score;//xin
                        tempexampaper.Duration = timeleng;//xin
                    }
                    Exam.BLL.tb_ExampaperBLL.GetInstance().Update(tempexampaper);
                    IList<Exam.Entity.tb_ExampaperExtEntity> templist = Exam.BLL.tb_ExampaperExtBLL.GetInstance().GetListByExampaperId(exampaperId);
                    if (templist != null && templist.Count > 0)
                    {
                        Exam.BLL.tb_ExampaperExtBLL.GetInstance().Delete(templist[0].ExampaperId);
                    }
                }
                foreach (item i in list)
                {
                    
                    Exam.Entity.tb_ExampaperExtEntity temp = new Exam.Entity.tb_ExampaperExtEntity();

                    if (exampaperId == 0)
                    {
                        temp.ExampaperId = row; 
                    }
                    else
                    {
                        temp.ExampaperId = exampaperId;
                    }
                    temp.tb_QuestionClsId = i.clsid;
                    temp.Type = i.type;
                    temp.Title = i.title;
                    temp.Number = i.num1;
                    temp.Diff = i.num2;
                    temp.Score = i.score;
                    temp.Addtime = DateTime.Now;

                    if (exampaperId > 0)
                    {
                        Exam.BLL.tb_ExampaperExtBLL.GetInstance().Insert(temp);
                        result = 1;
                    }
                    else
                    {
                        txthidname.Text = "";
                        txtscore.Text = "";
                        txttime.Text = "";
                        Exam.BLL.tb_ExampaperExtBLL.GetInstance().Insert(temp);
                        result = 2;
                    }
                }
                if (result == 1)
                {
                    Response.Redirect("listtest.aspx");
                }
                else if(result == 2)
                {
                    MessageBox.ShowMsg(this, "试卷添加成功");
                }
                
            }

        }
        catch (Exception ex)
        {
            MessageBox.ShowMsg(this, ex.Message);
        }
    }
} 

public class item
{
    public int type { get; set; }

    public string title { get; set; }

    public int score { get; set; }

    public int clsid { get; set; }
    public int num1 { get; set; }

    public int num2 { get; set; }
}