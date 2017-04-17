using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using Exam.BLL;
using System.Text.RegularExpressions;

public partial class Exam_EnteringLibrary :BasePage //System.Web.UI.Page
{
    //试题描述
    public string contenms = "";
    //单选
    public string contenA = "";
    public string contenB = "";
    public string contenC = "";
    public string contenD = "";
    public string contenE = "";
    public string contenF = "";
    public string contenG = "";
    public string contenH = "";
    //多选
    public string contenAA = "";
    public string contenBB = "";
    public string contenCC = "";
    public string contenDD = "";
    public string contenEE = "";
    public string contenFF = "";
    public string contenGG = "";
    public string contenHH = "";
    //试题解析
    public string contenjx = "";
    public int questionclsid = 0;
    public string name = "";
    public int questionid
    {
        get
        {
            object obj = Request.QueryString["questionid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (questionid>0)
            {
                BindData();
               
            }
        }
    }
    private void BindData()
    {
        try
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
               
                Exam.Entity.tb_QuestionEntity model = Exam.BLL.tb_QuestionBLL.GetInstance().GetAdminSingle(questionid);
                model.SchoolId = identity._schoolID;
                if (model != null)
                {
                    //在修改题库时隐藏上面的两个按钮
                    this.divn.Style.Add("display", "none");
                    this.divnn.Style.Add("display", "none");
                    hidid.Text = model.Type.ToString();
                    questionclsid = model.QuestionClsId;
                    Exam.Entity.tb_QuestionClsEntity temp = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(model.QuestionClsId);
                    if (temp != null)
                    {
                        name = temp.Name;
                    }
                    this.ddlFirst.SelectedValue = model.Type.ToString();
                    this.ddlharder.SelectedValue = model.Isdifficulty.ToString();
                    this.ddlstatus.SelectedValue = model.Status.ToString();
                    //试题描述
                    this.contenms = model.Title.Replace("\"", "':");
                    //单选
                    if(int.Parse(this.ddlFirst.SelectedValue) ==1)
                    {
                        this.contenA = model.A.ToString();
                        this.contenB = model.B.ToString();
                        this.contenC = model.C.ToString();
                        this.contenD = model.D.ToString();
                        this.contenE = model.E.ToString();
                        this.contenF = model.F.ToString();
                        this.contenG = model.G.ToString();
                        this.contenH = model.H.ToString();
                        if (model.Answer.ToUpper() == "A")
                        {
                            raidaA.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "B")
                        {
                            raidaB.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "C")
                        {
                            raidaC.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "D")
                        {
                            raidaD.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "E")
                        {
                            raidaE.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "F")
                        {
                            raidaF.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "G")
                        {
                            raidaG.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "H")
                        {
                            raidaH.Checked = true;
                        }
                    }
                    //多选
                    if (int.Parse(this.ddlFirst.SelectedValue) == 2)
                    {
                        this.contenAA = model.A.ToString();
                        this.contenBB = model.B.ToString();
                        this.contenCC = model.C.ToString();
                        this.contenDD = model.D.ToString();
                        this.contenEE = model.E.ToString();
                        this.contenFF = model.F.ToString();
                        this.contenGG = model.G.ToString();
                        this.contenHH = model.H.ToString();
                        string str = model.Answer;
                        string[] arr = str.Split(',');
                        foreach (string answer in arr)
                        {
                            if (answer == "A")
                            {
                                ckdA.Checked = true;
                            }
                            if (answer == "B")
                            {
                                ckdB.Checked = true;
                            }
                            if (answer == "C")
                            {
                                ckdC.Checked = true;
                            }
                            if (answer == "D")
                            {
                                ckdD.Checked = true;
                            }
                            if (answer == "E")
                            {
                                ckdE.Checked = true;
                            }
                            if (answer == "F")
                            {
                                ckdF.Checked = true;
                            }
                            if (answer == "G")
                            {
                                ckdG.Checked = true;
                            }
                            if (answer == "H")
                            {
                                ckdH.Checked = true;
                            }
                        }
                        
                    }
                    //判断
                    if (int.Parse(this.ddlFirst.SelectedValue) == 3)
                    {
                        if (model.Answer.ToUpper() == "1")
                        {
                            raidzq.Checked = true;
                        }
                        if (model.Answer.ToUpper() == "0")
                        {
                            raidcw.Checked = true;
                        }
                    }
                    //填空
                    if (int.Parse(this.ddlFirst.SelectedValue) == 4)
                    {
                        this.txttk.Text = model.Answer;
                    }
                    //试题解析
                    this.contenjx = model.Interpretation.Replace("\"", "':");              
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
        }
    }
    protected void btnnsave_Click(object sender, EventArgs e)
    {
        try
        {
            string id = SqlInject(txthid.Text.Trim());
            int ddltype = int.Parse(SqlInject(ddlType.SelectedValue));
            int ddldiff = int.Parse(SqlInject(ddlDiff.SelectedValue));
            string content = this.txtAdvantages.Text.Trim();
            //去掉中英文符号
            if (Regex.IsMatch(content.Substring(content.Length - 1), "[,|、|.|，]$", RegexOptions.CultureInvariant))
            {
                content = content.Substring(0, content.Length - 1);
            }
            string[] arr = Regex.Split(content, "\r\n", RegexOptions.IgnoreCase);
            int tmp = 0;
            foreach (string str in arr)
            {
                tmp++;
                if (str == "")
                {
                    if (tmp < arr.Count())
                    {
                        MessageBox.ShowMsg(this, arr[tmp] + "  上面有换行，去掉换行后请重新录入！");
                        return;
                    }
                }

            }
            List<Exam.Entity.tb_QuestionEntity> list = new List<tb_QuestionEntity>();
            List<string> temp = new List<string>();
            int k = 0;
            bool b = false;
            string t = "";
            //检查
            foreach (string str in arr)
            {
                //问题
                if (k == 0)
                {
                    if(Regex.IsMatch(str,@"\d+[.|、]",RegexOptions.IgnoreCase))
                    {
                        temp.Add(str.Substring(str.IndexOf(".")+1));
                        k++;
                        continue;
                    }
                    else
                    { 
                        b = true;
                        break;
                    }
                }
                //选项
                if(k == 1)
                {
                    if(Regex.IsMatch(str.Substring(0, 2),@"[A-H][.|、]",RegexOptions.IgnoreCase))
                    {
                        t += str.Substring(2) + "|";
                    }
                    else if (str.Substring(0, 3)=="解析:")
                    {
                        temp.Add(t.TrimEnd('|'));
                        t = "";

                        temp.Add(str.Substring(3));
                        k = 3;
                        continue;
                    }
                    else
                    {
                        b = true;
                        break;
                    }
                }
                //解析
                if (k == 2)
                {

                }
                //答案
                if (k == 3)
                {
                    if (str.Substring(0, 3)=="答案:")
                    {
                        if (str.Substring(3) == "正确")
                            temp.Add("1");
                        else if (str.Substring(3) == "错误")
                            temp.Add("0");
                        else
                            temp.Add(str.Substring(3));
                        k = 0;
                    }
                    else
                    {
                        b = true;
                        break;
                    }
                }
            }
            if (b)
            {
                MessageBox.ShowMsg(this,"导入题库的格式错误！");
                return;
            }
        
            for (int i = 0; i < temp.Count; i+=4)
            {
                string[] tarr = temp[i + 3].Split(',');
                //如果长度大于1说明不是单选
                if (tarr.ToString().Length > 1)
                {
                    //单选
                    if (ddltype == 1)
                    {
                        MessageBox.ShowMsg(this, "答案应该为所选项的任意一个字母！");
                        return;
                    }
                    //多选
                    if (ddltype == 2)
                    {
                        if (tarr.Count() == 1)
                        {
                            MessageBox.ShowMsg(this, "答案应该为所选项之间的字母，并且用英文逗号分隔！");
                            return;
                        }
                    }
                    //判断
                    if (ddltype == 3)
                    {
                        if (temp[i + 3] != "1" || temp[i + 3] != "0")
                        {
                            MessageBox.ShowMsg(this, "答案格式不正确！");
                            return;
                        }
                    }
                    //填空
                    if (ddltype == 4)
                    {

                    }

                }
                else if (Regex.IsMatch(temp[i + 3],"^[A-H]$"))
                {
                    if (ddltype != 1)
                    {
                        MessageBox.ShowMsg(this, "答案应该为A-H之间的字母！ ");
                        return;
                    }
                }
                    Exam.Entity.tb_QuestionEntity model = new tb_QuestionEntity();
                  
                    model.SchoolId = 0;
                    model.QuestionClsId = int.Parse(id);
                    model.Type = ddltype;
                    model.Isdifficulty = ddldiff;
                   
                    //题号
                    model.Title = temp[i];
                    //选项
                    string[] array = temp[i + 1].Split('|');
                    if (array.Length > 0)
                    {
                        foreach (string s in array)
                        {
                            if (string.IsNullOrEmpty(model.A))
                            {
                                model.A = s;
                            }
                            else if (string.IsNullOrEmpty(model.B))
                            {
                                model.B = s;
                            }
                            else if (string.IsNullOrEmpty(model.C))
                            {
                                model.C = s;
                            }
                            else if (string.IsNullOrEmpty(model.D))
                            {
                                model.D = s;
                            }
                            else if (string.IsNullOrEmpty(model.E))
                            {
                                model.E = s;
                            }
                            else if (string.IsNullOrEmpty(model.F))
                            {
                                model.F = s;
                            }
                            else if (string.IsNullOrEmpty(model.G))
                            {
                                model.G = s;
                            }
                            else if (string.IsNullOrEmpty(model.H))
                            {
                                model.H = s;
                            }

                        }
                        //解析
                        model.Interpretation = temp[i + 2];
                        //答案
                        model.Answer = temp[i + 3];

                        model.Isdifficulty = ddldiff;
                        model.Status = 1;
                        model.Addtime = DateTime.Now;
                        model.Updatetime = DateTime.Now;

                        list.Add(model);
                    //}
                }
            }
            foreach (Exam.Entity.tb_QuestionEntity m in list)
            {
                Exam.BLL.tb_QuestionBLL.GetInstance().Insert(m);
            }
            MessageBox.ShowAndRedirect(this, "导入题库成功！", "ListLibrary.aspx");
        }
        catch (Exception ex)
        {
            MessageBox.ShowMsg(this, ex.Message);
        }
    }
}