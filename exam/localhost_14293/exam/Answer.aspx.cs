using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exam.Entity;
using System.Text;
using System.IO;
public partial class exam_Answer : System.Web.UI.Page
{
    public int ExampaperId
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
    public int ClsId
    {
        get
        {
            object obj = Request.QueryString["clsid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public string num
    {
        get
        {
            object obj = Request.QueryString["num"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    public string num2
    {
        get
        {
            object obj = Request.QueryString["num2"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    public int userid
    {
        get
        {
            object obj = Request.QueryString["userid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
    public static string Name = "考试范例";
    public static string Mm = "3600";
    public static string body = "";
    public int t_index = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /*UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                string data = Session["exam-" + identity.UserID + "-" + ClsId] == null ? "" : Session["exam-" + identity.UserID + "-" + ClsId].ToString();
                if (string.IsNullOrEmpty(data))
                    BindData();
                else
                {
                    tmp t = Jnwf.Utils.Json.JsonHelper.DeserializeJson<tmp>(data);
                    
                    DateTime d = DateTime.Parse(t.time);
                    TimeSpan span = (TimeSpan)(DateTime.Now - d);

                    int duration = int.Parse(t.duration);
                    if (span.Seconds >= duration* 60)
                    {
                        Session["exam-" + identity.UserID + "-" + ClsId] = null;
                        BindData();
                    }
                    else
                    {
                        body = Server.HtmlDecode(t.data);
                        Mm = ((duration * 60) - span.Seconds).ToString();
                    }
                }
            }*/

            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {

                string path = Server.MapPath(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("userpath")) + "/exam-" + identity.UserID + "-" + ClsId + ".txt";
                string pathext = Server.MapPath(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("userpath")) + "/exam-" + identity.UserID + "-" + ClsId + "-dict.txt";
                if (!File.Exists(path))
                {
                    BindData(identity.UserID);
                    //Jnwf.Utils.Log.Logger.Log4Net.Error("2.Answer,userid:");
                }
                else
                {
                    //Jnwf.Utils.Log.Logger.Log4Net.Error("3.Answer,userid:");
                    string data = Jnwf.Utils.Helper.FileHelper.GetFileContent(path);

                    tmp t = Jnwf.Utils.Json.JsonHelper.DeserializeJson<tmp>(data);

                    DateTime d = DateTime.Parse(t.time);
                    TimeSpan span = (TimeSpan)(DateTime.Now - d);

                    int duration = int.Parse(t.duration);
                    if (span.Seconds >= duration * 60)
                    {
                        Jnwf.Utils.Helper.FileHelper.DeleteFile(path);
                        Jnwf.Utils.Helper.FileHelper.DeleteFile(pathext);
                        //current = 1;
                        t_index = 0;
                        BindData(identity.UserID);
                        //Jnwf.Utils.Log.Logger.Log4Net.Error("4.Answer,userid:");
                    }
                    else
                    {
                        //Jnwf.Utils.Log.Logger.Log4Net.Error("5.Answer,userid:");
                        Mm = ((duration * 60) - span.Seconds).ToString();
                        Name = t.name;
                        string data_d = Jnwf.Utils.Helper.FileHelper.GetFileContent(pathext);

                        Dictionary<int, string> dict = Jnwf.Utils.Json.JsonHelper.DeserializeJson<Dictionary<int, string>>(data_d);
                        if (dict != null)
                        {
                            if (string.IsNullOrEmpty(num))
                            {
                                //Jnwf.Utils.Log.Logger.Log4Net.Error("t8.Answer,userid:");
                                if (dict.Count > 0)
                                    GetQuestion(1, dict);
                            }
                            else
                            {
                                //Jnwf.Utils.Log.Logger.Log4Net.Error("t9.Answer,userid:");
                                if (dict.Count > int.Parse(num))
                                    GetQuestion(int.Parse(num), dict);
                            }
                        }

                    }
                }
            }
        }
    } 
    /*
    private void BindData()
    {
        tb_ExampaperEntity model = Exam.BLL.tb_ExampaperBLL.GetInstance().GetAdminSingle(ExampaperId);
        if(model != null)
        {
            Name = model.Name;
            Mm = (model.Duration * 60).ToString();
        }
        else
        {
            MessageBox.ShowMsg(this,"检测信息异常");
            return;
        }
        UserIdentity identity= User.Identity as UserIdentity;
        if(identity != null)
        {

            List<tb_ExampaperExtEntity> list = Exam.BLL.tb_ExampaperExtBLL.GetInstance().GetListByExampaperId(ExampaperId) as List<tb_ExampaperExtEntity>;
            
            StringBuilder sb = new StringBuilder();
            int i = 0;
            if (list != null && list.Count > 0)
            {
                foreach (tb_ExampaperExtEntity m in list)
                {
                    List<tb_QuestionEntity> questionlist = Exam.BLL.tb_QuestionBLL.GetInstance().GetQuestionList(m.tb_QuestionClsId) as List<tb_QuestionEntity>;

                    List<tb_QuestionEntity> radio_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> radio_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_radio_k = null;
                    List<tb_QuestionEntity> t_radio_j = null;

                    List<tb_QuestionEntity> check_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> check_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_check_k = null;
                    List<tb_QuestionEntity> t_check_j = null;

                    List<tb_QuestionEntity> panduan_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> panduan_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_panduan_k = null;
                    List<tb_QuestionEntity> t_panduan_j = null;

                    List<tb_QuestionEntity> tiankong_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> tiankong_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_tiankong_k = null;
                    List<tb_QuestionEntity> t_tiankong_j = null;

                    if (questionlist != null && questionlist.Count > 0)
                    {
                        radio_k = questionlist.Where(c => c.Type == 1 && c.Isdifficulty == 1).ToList();
                        radio_j = questionlist.Where(c => c.Type == 1 && c.Isdifficulty == 0).ToList();

                        check_k = questionlist.Where(c => c.Type == 2 && c.Isdifficulty == 1).ToList();
                        check_j = questionlist.Where(c => c.Type == 2 && c.Isdifficulty == 0).ToList();

                        panduan_k = questionlist.Where(c => c.Type == 3 && c.Isdifficulty == 1).ToList();
                        panduan_j = questionlist.Where(c => c.Type == 3 && c.Isdifficulty == 0).ToList();

                        tiankong_k = questionlist.Where(c => c.Type == 4 && c.Isdifficulty == 1).ToList();
                        tiankong_j = questionlist.Where(c => c.Type == 4 && c.Isdifficulty == 0).ToList();
                    }
                    else
                    {
                        continue;
                    }
                    i++;

                    if (m.Type == 1 && (m.Number > 0 && radio_j.Count > 0 && (radio_j.Count - m.Number) >= 0) || (m.Diff > 0 && radio_k.Count > 0 && (radio_k.Count - m.Diff) >= 0))
                    {
                        sb.Append("<div class=\"questions\"><h5>" + GetDaXie(i) + " " + m.Title + "</h5>");
                        int k = 0;
                        //单选-简单
                        if (m.Number > 0 && radio_j.Count > 0 && (radio_j.Count - m.Number) >= 0)
                        {
                            t_radio_j = radio_j;
                            for (int a = 0; a < t_radio_j.Count; a++)
                            {
                                t_radio_j[a].TempId = a + 1;
                            }

                            
                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Number * 2 > t_radio_j.Count)
                            {
                                t_radio_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_radio_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_radio_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_radio = t_radio_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_radio != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_radio.QuestionId + "\" questionscore=\""+m.Score+"\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_radio.Title.IndexOf("<p>") >= 0 ? temp_radio.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_radio.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"1\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");

                                    if (!string.IsNullOrEmpty(temp_radio.A))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"A\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>A. " + (temp_radio.A.StartsWith("<p>")?temp_radio.A.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.A) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.B))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"B\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>B. " + (temp_radio.B.StartsWith("<p>")?temp_radio.B.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.B) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.C))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"C\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>C. " + (temp_radio.C.StartsWith("<p>")?temp_radio.C.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.C) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.D))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"D\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>D. " + (temp_radio.D.StartsWith("<p>")?temp_radio.D.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.D) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.E))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"E\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>E. " + (temp_radio.E.StartsWith("<p>")?temp_radio.E.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.E) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.F))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"F\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>F. " + (temp_radio.F.StartsWith("<p>")?temp_radio.F.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.F) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.G))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"G\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>G. " + (temp_radio.G.StartsWith("<p>")?temp_radio.G.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.G) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.H))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"H\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>H. " + (temp_radio.H.StartsWith("<p>")?temp_radio.H.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.H) + "</dd></span>");
                                    sb.Append("</dl>");
                                }
                            }
                        }
                        //单选-困难
                        if (m.Diff > 0 && radio_k.Count > 0 && (radio_k.Count - m.Diff) >= 0)
                        {
                            t_radio_k = radio_k;
                            for (int a = 0; a < t_radio_k.Count; a++)
                            {
                                t_radio_k[a].TempId = a + 1;
                            }

                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_radio_k.Count)
                            {
                                t_radio_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_radio_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_radio_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_radio = t_radio_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_radio != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_radio.QuestionId + "\" questionscore=\"" + m.Score + "\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_radio.Title.IndexOf("<p>") >= 0 ? temp_radio.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_radio.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"1\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");

                                    if (!string.IsNullOrEmpty(temp_radio.A))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"A\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>A. " + (temp_radio.A.StartsWith("<p>")?temp_radio.A.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.A) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.B))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"B\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>B. " + (temp_radio.B.StartsWith("<p>")?temp_radio.B.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.B) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.C))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"C\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>C. " + (temp_radio.C.StartsWith("<p>")?temp_radio.C.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.C) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.D))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"D\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>D. " + (temp_radio.D.StartsWith("<p>")?temp_radio.D.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.D) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.E))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"E\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>E. " + (temp_radio.E.StartsWith("<p>")?temp_radio.E.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.E) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.F))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"F\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>F. " + (temp_radio.F.StartsWith("<p>")?temp_radio.F.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.F) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.G))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"G\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>G. " + (temp_radio.G.StartsWith("<p>")?temp_radio.G.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.G) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_radio.H))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"H\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>H. " + (temp_radio.H.StartsWith("<p>")?temp_radio.H.Replace("<p>", "<p style=\"display: inline;\">"):temp_radio.H) + "</dd></span>");
                                    sb.Append("</dl>");
                                }
                            }
                        }
                        sb.Append("</div>");
                    }
                    else if (m.Type == 2 && (m.Number > 0 && check_j.Count > 0 && (check_j.Count - m.Number) >= 0) || (m.Diff > 0 && check_k.Count > 0 && (check_k.Count - m.Diff) >= 0))
                    {
                        //多选-简单
                        sb.Append("<div class=\"questions\"><h5>" + GetDaXie(i) + " " + m.Title + "</h5>");
                        int k = 0;
                        if (m.Number > 0 && check_j.Count > 0 && (check_j.Count - m.Number) >= 0)
                        {
                            t_check_j = check_j;
                            for (int a = 0; a < t_check_j.Count; a++)
                            {
                                t_check_j[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Number * 2 > t_check_j.Count)
                            {
                                t_check_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_check_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_check_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_check = t_check_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_check != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_check.QuestionId + "\" questionscore=\"" + m.Score + "\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_check.Title.IndexOf("<p>") >= 0 ? temp_check.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_check.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"2\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");
                                                                                                                                                                                                                                                                           
                                    if (!string.IsNullOrEmpty(temp_check.A))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"A\" questionstype=\"2\"/>A. " + (temp_check.A.StartsWith("<p>")?temp_check.A.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.A) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.B))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"B\" questionstype=\"2\"/>B. " + (temp_check.B.StartsWith("<p>")?temp_check.B.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.B) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.C))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"C\" questionstype=\"2\"/>C. " + (temp_check.C.StartsWith("<p>")?temp_check.C.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.C) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.D))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"D\" questionstype=\"2\"/>D. " + (temp_check.D.StartsWith("<p>")?temp_check.D.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.D) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.E))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"E\" questionstype=\"2\"/>E. " + (temp_check.E.StartsWith("<p>")?temp_check.E.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.E) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.F))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"F\" questionstype=\"2\"/>F. " + (temp_check.F.StartsWith("<p>")?temp_check.F.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.F) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.G))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"G\" questionstype=\"2\"/>G. " + (temp_check.G.StartsWith("<p>")?temp_check.G.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.G) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.H))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"H\" questionstype=\"2\"/>H. " + (temp_check.H.StartsWith("<p>")?temp_check.H.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.H) + "</dd></span>");
                                    sb.Append("</dl>");
                                }
                            }
                        }
                        //多选-困难
                        if (m.Diff > 0 && check_k.Count > 0 && (check_k.Count - m.Diff) >= 0)
                        {
                            t_check_k = check_k;
                            for (int a = 0; a < t_check_k.Count; a++)
                            {
                                t_check_k[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_check_k.Count)
                            {
                                t_check_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_check_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }
                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_check_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_check = t_check_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_check != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_check.QuestionId + "\" questionscore=\"" + m.Score + "\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_check.Title.IndexOf("<p>") >= 0 ? temp_check.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_check.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"2\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");

                                    if (!string.IsNullOrEmpty(temp_check.A))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"A\" questionstype=\"2\"/>A. " + (temp_check.A.StartsWith("<p>")?temp_check.A.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.A) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.B))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"B\" questionstype=\"2\"/>B. " + (temp_check.B.StartsWith("<p>")?temp_check.B.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.B) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.C))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"C\" questionstype=\"2\"/>C. " + (temp_check.C.StartsWith("<p>")?temp_check.C.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.C) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.D))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"D\" questionstype=\"2\"/>D. " + (temp_check.D.StartsWith("<p>")?temp_check.D.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.D) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.E))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"E\" questionstype=\"2\"/>E. " + (temp_check.E.StartsWith("<p>")?temp_check.E.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.E) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.F))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"F\" questionstype=\"2\"/>F. " + (temp_check.F.StartsWith("<p>")?temp_check.F.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.F) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.G))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"G\" questionstype=\"2\"/>G. " + (temp_check.G.StartsWith("<p>")?temp_check.G.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.G) + "</dd></span>");
                                    if (!string.IsNullOrEmpty(temp_check.H))
                                        sb.Append("<span class=\"answers\"><dd class=\"a\"><input type=\"checkbox\" class=\"radioOrCheck\" answername=\"H\" questionstype=\"2\"/>H. " + (temp_check.H.StartsWith("<p>")?temp_check.H.Replace("<p>", "<p style=\"display: inline;\">"):temp_check.H) + "</dd></span>");
                                    sb.Append("</dl>");
                                }
                            }
                        }
                        sb.Append("</div>");
                    }
                    else if (m.Type == 3 && (m.Number > 0 && panduan_j.Count > 0 && (panduan_j.Count - m.Number) >= 0) || (m.Diff > 0 && panduan_k.Count > 0 && (panduan_k.Count - m.Diff) >= 0))
                    {
                        sb.Append("<div class=\"questions\"><h5>" + GetDaXie(i) + " " + m.Title + "</h5>");
                        int k = 0;
                        //判断-简单
                        if (m.Number > 0 && panduan_j.Count > 0 && (panduan_j.Count - m.Number) >= 0)
                        {
                            t_panduan_j = panduan_j;
                            for (int a = 0; a < t_panduan_j.Count; a++)
                            {
                                t_panduan_j[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if ((m.Number * 2) > t_panduan_j.Count)
                            {
                                t_panduan_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_panduan_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_panduan_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_panduan = t_panduan_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_panduan != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_panduan.QuestionId + "\" questionscore=\"" + m.Score + "\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_panduan.Title.IndexOf("<p>") >= 0 ? temp_panduan.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_panduan.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"3\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");

                                    sb.Append("<span class=\"answers\" style=\"float:left\"><dd class=\"rt\"><input type=\"radio\" class=\"radioOrCheck\" value=\"1\" answername=\"1\" questionstype=\"3\" name=\"radio" + temp_panduan.QuestionId + "\"/> 正确 </dd></span>");

                                    sb.Append("<span class=\"answers\"><dd class=\"rt\"><input type=\"radio\" class=\"radioOrCheck\" value=\"0\" answername=\"0\" questionstype=\"3\" name=\"radio" + temp_panduan.QuestionId + "\"/> 错误 </dd></span>");
                                    
                                    sb.Append("</dl>");
                                }
                            }
                        }
                        //判断-困难
                        if (m.Diff > 0 && panduan_k.Count > 0 && (panduan_k.Count - m.Diff) >= 0)
                        {
                            t_panduan_k = panduan_k;
                            for (int a = 0; a < t_panduan_k.Count; a++)
                            {
                                t_panduan_k[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_panduan_k.Count)
                            {
                                t_panduan_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_panduan_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_panduan_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_panduan = t_panduan_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_panduan != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_panduan.QuestionId + "\" questionscore=\"" + m.Score + "\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_panduan.Title.IndexOf("<p>") >= 0 ? temp_panduan.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_panduan.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"3\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");

                                    sb.Append("<span class=\"answers\" style=\"float:left\"><dd class=\"rt\"><input type=\"radio\" class=\"radioOrCheck\" value=\"1\" answername=\"1\" questionstype=\"3\" name=\"radio" + temp_panduan.QuestionId + "\"/> 正确 </dd></span>");

                                    sb.Append("<span class=\"answers\"><dd class=\"rt\"><input type=\"radio\" class=\"radioOrCheck\" value=\"0\" answername=\"0\" questionstype=\"3\" name=\"radio" + temp_panduan.QuestionId + "\"/> 错误 </dd></span>");

                                    sb.Append("</dl>");
                                }
                            }
                        }
                        sb.Append("</div>");
                    }
                    else if (m.Type == 4 && (m.Number > 0 && tiankong_j.Count > 0 && (tiankong_j.Count - m.Number) >= 0) || (m.Diff > 0 && tiankong_k.Count > 0 && (tiankong_k.Count - m.Diff) >= 0))
                    {
                        sb.Append("<div class=\"questions\"><h5>" + GetDaXie(i) + " " + m.Title + "</h5>");
                        int k = 0;
                        //填空-简单
                        if (m.Number > 0 && tiankong_j.Count > 0 && (tiankong_j.Count - m.Number) >= 0)
                        {
                            t_tiankong_j = tiankong_j;
                            for (int a = 0; a < t_tiankong_j.Count; a++)
                            {
                                t_tiankong_j[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Number * 2 > t_tiankong_j.Count)
                            {
                                t_tiankong_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_tiankong_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_tiankong_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_tiankong = t_tiankong_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_tiankong != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_tiankong.QuestionId + "\" questionscore=\"" + m.Score + "\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_tiankong.Title.IndexOf("<p>") >= 0 ? temp_tiankong.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_tiankong.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"4\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");


                                    sb.Append("<span class=\"answers\"><dd class=\"filled\"><input name=\"key1\" type=\"text\" class=\"keyFill\" value=\"\" /></dd></span>");
                                    
                                    sb.Append("</dl>");
                                }
                            }
                        }
                        //填空-困难
                        if (m.Diff > 0 && tiankong_k.Count > 0 && (tiankong_k.Count - m.Diff) >= 0)
                        {
                            t_tiankong_k = tiankong_k;
                            for (int a = 0; a < t_tiankong_k.Count; a++)
                            {
                                t_tiankong_k[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_tiankong_k.Count)
                            {
                                t_tiankong_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_tiankong_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_tiankong_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                k++;
                                tb_QuestionEntity temp_tiankong = t_tiankong_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_tiankong != null)
                                {
                                    sb.Append("<dl class=\"questionsContent\" questionsid=\"" + temp_tiankong.QuestionId + "\" questionscore=\"" + m.Score + "\"><dt><em class=\"mark\" ></em>" + (k) + "、" + (temp_tiankong.Title.IndexOf("<p>") >= 0 ? temp_tiankong.Title.Replace("<p>", "<p style=\"display: inline;\">") : temp_tiankong.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"4\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></dt>");

                                    sb.Append("<span class=\"answers\"><dd class=\"filled\"><input name=\"key1\" type=\"text\" class=\"keyFill\" value=\"\" /></dd></span>");

                                    sb.Append("</dl>");
                                }
                            }
                        }
                        sb.Append("</div>");
                    }
                    
                }
            }
            body = sb.ToString();

            Session["exam-" + identity.UserID + "-" + ClsId] = "{\"data\":\"" + Server.HtmlEncode(body) + "\",\"time\":\"" + DateTime.Now.ToString() + "\",\"duration\":\"" + model.Duration + "\"}";
            
        }

    }*/
    private void BindData(int userid)
    {
        Jnwf.Utils.Log.Logger.Log4Net.Error("6.Answer,userid:");
        tb_ExampaperEntity model = Exam.BLL.tb_ExampaperBLL.GetInstance().GetAdminSingle(ExampaperId);
        if (model != null)
        {
            Name = model.Name;
            Mm = (model.Duration * 60).ToString();
        }
        else
        {
            MessageBox.ShowMsg(this, "检测信息异常");
            return;
        }
        Dictionary<int, string> dirc = new Dictionary<int, string>();
        if (userid != 0)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("7.Answer,userid:");
            List<tb_ExampaperExtEntity> list = Exam.BLL.tb_ExampaperExtBLL.GetInstance().GetListByExampaperId(ExampaperId) as List<tb_ExampaperExtEntity>;

            StringBuilder sb = new StringBuilder();
            int i = 0;
            t_index = 0;
            if (list != null && list.Count > 0) // && questionlist != null && questionlist.Count > 0
            {
                foreach (tb_ExampaperExtEntity m in list)
                {

                    List<tb_QuestionEntity> questionlist = Exam.BLL.tb_QuestionBLL.GetInstance().GetQuestionList(m.tb_QuestionClsId) as List<tb_QuestionEntity>;

                    List<tb_QuestionEntity> radio_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> radio_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_radio_k = null;
                    List<tb_QuestionEntity> t_radio_j = null;

                    List<tb_QuestionEntity> check_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> check_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_check_k = null;
                    List<tb_QuestionEntity> t_check_j = null;

                    List<tb_QuestionEntity> panduan_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> panduan_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_panduan_k = null;
                    List<tb_QuestionEntity> t_panduan_j = null;

                    List<tb_QuestionEntity> tiankong_j = new List<tb_QuestionEntity>();
                    List<tb_QuestionEntity> tiankong_k = new List<tb_QuestionEntity>();

                    List<tb_QuestionEntity> t_tiankong_k = null;
                    List<tb_QuestionEntity> t_tiankong_j = null;

                    if (questionlist != null && questionlist.Count > 0)
                    {
                        radio_k = questionlist.Where(c => c.Type == 1 && c.Isdifficulty == 1).ToList();
                        radio_j = questionlist.Where(c => c.Type == 1 && c.Isdifficulty == 0).ToList();

                        check_k = questionlist.Where(c => c.Type == 2 && c.Isdifficulty == 1).ToList();
                        check_j = questionlist.Where(c => c.Type == 2 && c.Isdifficulty == 0).ToList();

                        panduan_k = questionlist.Where(c => c.Type == 3 && c.Isdifficulty == 1).ToList();
                        panduan_j = questionlist.Where(c => c.Type == 3 && c.Isdifficulty == 0).ToList();

                        tiankong_k = questionlist.Where(c => c.Type == 4 && c.Isdifficulty == 1).ToList();
                        tiankong_j = questionlist.Where(c => c.Type == 4 && c.Isdifficulty == 0).ToList();
                    }
                    else
                    {
                        continue;
                    }

                    i++;
                    //StringBuilder tsb = new StringBuilder();
                    if (m.Type == 1 && (m.Number > 0 && radio_j.Count > 0 && (radio_j.Count - m.Number) >= 0) || (m.Diff > 0 && radio_k.Count > 0 && (radio_k.Count - m.Diff) >= 0))
                    {
                        int k = 0;
                        //单选-简单
                        if (m.Number > 0 && radio_j.Count > 0 && (radio_j.Count - m.Number) >= 0)
                        {
                            t_radio_j = radio_j;
                            for (int a = 0; a < t_radio_j.Count; a++)
                            {
                                t_radio_j[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Number * 2 > t_radio_j.Count)
                            {
                                t_radio_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_radio_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_radio_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }

                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;
                                k++;
                                tb_QuestionEntity temp_radio = t_radio_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_radio != null)
                                {

                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";


                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_radio.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_radio.Title.IndexOf("<p>") >= 0 ? temp_radio.Title.Replace("<p>", "") : temp_radio.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"1\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";


                                    if (!string.IsNullOrEmpty(temp_radio.A))
                                        temp_question += "<div class=\"exam-main answers\"><div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"A\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>A." + (temp_radio.A.StartsWith("<p>") ? temp_radio.A.Replace("<p>", "").Trim() : temp_radio.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.B))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"B\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>B." + (temp_radio.B.StartsWith("<p>") ? temp_radio.B.Replace("<p>", "").Trim() : temp_radio.B.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.C))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"C\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>C." + (temp_radio.C.StartsWith("<p>") ? temp_radio.C.Replace("<p>", "").Trim() : temp_radio.C.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.D))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"D\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>D." + (temp_radio.D.StartsWith("<p>") ? temp_radio.D.Replace("<p>", "").Trim() : temp_radio.D.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.E))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"E\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>E." + (temp_radio.E.StartsWith("<p>") ? temp_radio.E.Replace("<p>", "").Trim() : temp_radio.E.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.F))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"F\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>F." + (temp_radio.F.StartsWith("<p>") ? temp_radio.F.Replace("<p>", "").Trim() : temp_radio.F.Trim()) + "</div>";


                                    temp_question += "</div></div>";

                                    //dirc.Add(t_index, Server.HtmlEncode(temp_question));
                                    dirc.Add(t_index, temp_question);
                                }
                            }
                        }
                        //单选-困难
                        if (m.Diff > 0 && radio_k.Count > 0 && (radio_k.Count - m.Diff) >= 0)
                        {
                            t_radio_k = radio_k;
                            for (int a = 0; a < t_radio_k.Count; a++)
                            {
                                t_radio_k[a].TempId = a + 1;
                            }

                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_radio_k.Count)
                            {
                                t_radio_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_radio_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_radio_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;
                                k++;
                                tb_QuestionEntity temp_radio = t_radio_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_radio != null)
                                {

                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";


                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_radio.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_radio.Title.IndexOf("<p>") >= 0 ? temp_radio.Title.Replace("<p>", "") : temp_radio.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"1\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";


                                    if (!string.IsNullOrEmpty(temp_radio.A))
                                        temp_question += "<div class=\"exam-main answers\"><div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"A\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>A." + (temp_radio.A.StartsWith("<p>") ? temp_radio.A.Replace("<p>", "").Trim() : temp_radio.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.B))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"B\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>B." + (temp_radio.A.StartsWith("<p>") ? temp_radio.A.Replace("<p>", "").Trim() : temp_radio.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.C))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"C\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>C." + (temp_radio.A.StartsWith("<p>") ? temp_radio.A.Replace("<p>", "").Trim() : temp_radio.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.D))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"D\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>D." + (temp_radio.A.StartsWith("<p>") ? temp_radio.A.Replace("<p>", "").Trim() : temp_radio.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.E))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"E\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>E." + (temp_radio.A.StartsWith("<p>") ? temp_radio.A.Replace("<p>", "").Trim() : temp_radio.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_radio.F))
                                        temp_question += "<div class=\"answers\"><input type=\"radio\" class=\"radioOrCheck\" answername=\"F\" questionstype=\"1\" name=\"radio" + temp_radio.QuestionId + "\"/>F." + (temp_radio.A.StartsWith("<p>") ? temp_radio.A.Replace("<p>", "").Trim() : temp_radio.A.Trim()) + "</div>";


                                    temp_question += "</div></div>";

                                    //dirc.Add(t_index, Server.HtmlEncode(temp_question));
                                    dirc.Add(t_index, temp_question);
                                }
                            }
                            //Session.Add("radio", tsb.ToString());
                        }
                    }
                    else if (m.Type == 2 && (m.Number > 0 && check_j.Count > 0 && (check_j.Count - m.Number) >= 0) || (m.Diff > 0 && check_k.Count > 0 && (check_k.Count - m.Diff) >= 0))
                    {
                        //多选-简单
                        int k = 0;
                        if (m.Number > 0 && check_j.Count > 0 && (check_j.Count - m.Number) >= 0)
                        {
                            t_check_j = check_j;
                            for (int a = 0; a < t_check_j.Count; a++)
                            {
                                t_check_j[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Number * 2 > t_check_j.Count)
                            {
                                t_check_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_check_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_check_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;
                                k++;
                                tb_QuestionEntity temp_check = t_check_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_check != null)
                                {
                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";


                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_check.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_check.Title.IndexOf("<p>") >= 0 ? temp_check.Title.Replace("<p>", "") : temp_check.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"2\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";
                                    if (!string.IsNullOrEmpty(temp_check.A))
                                        temp_question += "<div class=\"exam-main answers\"><div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"A\" questionstype=\"2\"/>A." + (temp_check.A.StartsWith("<p>") ? temp_check.A.Replace("<p>", "").Trim() : temp_check.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.B))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"B\" questionstype=\"2\"/>B." + (temp_check.B.StartsWith("<p>") ? temp_check.B.Replace("<p>", "").Trim() : temp_check.B.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.C))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"C\" questionstype=\"2\"/>C." + (temp_check.C.StartsWith("<p>") ? temp_check.C.Replace("<p>", "").Trim() : temp_check.C.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.D))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"D\" questionstype=\"2\"/>D." + (temp_check.D.StartsWith("<p>") ? temp_check.D.Replace("<p>", "").Trim() : temp_check.D.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.E))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"E\" questionstype=\"2\"/>E." + (temp_check.E.StartsWith("<p>") ? temp_check.E.Replace("<p>", "").Trim() : temp_check.E.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.F))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"F\" questionstype=\"2\"/>F." + (temp_check.F.StartsWith("<p>") ? temp_check.F.Replace("<p>", "").Trim() : temp_check.F.Trim()) + "</div>";
                                    temp_question += "</div></div>";

                                    //dirc.Add(t_index, Server.HtmlEncode(temp_question));
                                    dirc.Add(t_index, temp_question);
                                }
                            }
                        }
                        //多选-困难
                        if (m.Diff > 0 && check_k.Count > 0 && (check_k.Count - m.Diff) >= 0)
                        {
                            t_check_k = check_k;
                            for (int a = 0; a < t_check_k.Count; a++)
                            {
                                t_check_k[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_check_k.Count)
                            {
                                t_check_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_check_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }
                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_check_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;
                                k++;
                                tb_QuestionEntity temp_check = t_check_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_check != null)
                                {
                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";


                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_check.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_check.Title.IndexOf("<p>") >= 0 ? temp_check.Title.Replace("<p>", "") : temp_check.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"2\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";
                                    if (!string.IsNullOrEmpty(temp_check.A))
                                        temp_question += "<div class=\"exam-main answers\"><div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"A\" questionstype=\"2\"/>A." + (temp_check.A.StartsWith("<p>") ? temp_check.A.Replace("<p>", "").Trim() : temp_check.A.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.B))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"B\" questionstype=\"2\"/>B." + (temp_check.B.StartsWith("<p>") ? temp_check.B.Replace("<p>", "").Trim() : temp_check.B.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.C))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"C\" questionstype=\"2\"/>C." + (temp_check.C.StartsWith("<p>") ? temp_check.C.Replace("<p>", "").Trim() : temp_check.C.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.D))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"D\" questionstype=\"2\"/>D." + (temp_check.D.StartsWith("<p>") ? temp_check.D.Replace("<p>", "").Trim() : temp_check.D.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.E))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"E\" questionstype=\"2\"/>E." + (temp_check.E.StartsWith("<p>") ? temp_check.E.Replace("<p>", "").Trim() : temp_check.E.Trim()) + "</div>";
                                    if (!string.IsNullOrEmpty(temp_check.F))
                                        temp_question += "<div class=\"answers\"><input type=\"checkbox\" class=\"radioOrCheck\"  answername=\"F\" questionstype=\"2\"/>F." + (temp_check.F.StartsWith("<p>") ? temp_check.F.Replace("<p>", "").Trim() : temp_check.F.Trim()) + "</div>";
                                    temp_question += "</div></div>";

                                    dirc.Add(t_index, temp_question);
                                }
                            }
                        }
                    }
                    else if (m.Type == 3 && (m.Number > 0 && panduan_j.Count > 0 && (panduan_j.Count - m.Number) >= 0) || (m.Diff > 0 && panduan_k.Count > 0 && (panduan_k.Count - m.Diff) >= 0))
                    {
                        int k = 0;
                        //判断-简单
                        if (m.Number > 0 && panduan_j.Count > 0 && (panduan_j.Count - m.Number) >= 0)
                        {
                            t_panduan_j = panduan_j;
                            for (int a = 0; a < t_panduan_j.Count; a++)
                            {
                                t_panduan_j[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if ((m.Number * 2) > t_panduan_j.Count)
                            {
                                t_panduan_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_panduan_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_panduan_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;

                                k++;
                                tb_QuestionEntity temp_panduan = t_panduan_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_panduan != null)
                                {
                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";


                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_panduan.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_panduan.Title.IndexOf("<p>") >= 0 ? temp_panduan.Title.Replace("<p>", "") : temp_panduan.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"3\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";
                                    temp_question += " &nbsp;&nbsp;&nbsp;&nbsp;<input type=\"radio\" class=\"radioOrCheck\" value=\"1\" answername=\"1\" questionstype=\"3\" name=\"pandu\" />正确&nbsp;&nbsp;&nbsp;&nbsp; <input type=\"radio\" class=\"radioOrCheck\" value=\"0\" answername=\"0\" questionstype=\"3\" name=\"pandu\" />错误</div>";

                                    //dirc.Add(t_index, Server.HtmlEncode(temp_question));
                                    dirc.Add(t_index, temp_question);
                                }
                            }
                        }
                        //判断-困难
                        if (m.Diff > 0 && panduan_k.Count > 0 && (panduan_k.Count - m.Diff) >= 0)
                        {
                            t_panduan_k = panduan_k;
                            for (int a = 0; a < t_panduan_k.Count; a++)
                            {
                                t_panduan_k[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_panduan_k.Count)
                            {
                                t_panduan_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_panduan_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_panduan_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;

                                k++;
                                tb_QuestionEntity temp_panduan = t_panduan_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_panduan != null)
                                {
                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";

                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_panduan.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_panduan.Title.IndexOf("<p>") >= 0 ? temp_panduan.Title.Replace("<p>", "") : temp_panduan.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"3\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";
                                    temp_question += " &nbsp;&nbsp;&nbsp;&nbsp;<input type=\"radio\" class=\"radioOrCheck\" value=\"1\" answername=\"1\" questionstype=\"3\" name=\"pandu\" />正确&nbsp;&nbsp;&nbsp;&nbsp; <input type=\"radio\" class=\"radioOrCheck\" value=\"0\" answername=\"0\" questionstype=\"3\" name=\"pandu\" />错误</div>";

                                    //dirc.Add(t_index, Server.HtmlEncode(temp_question));
                                    dirc.Add(t_index, temp_question);
                                }
                            }
                        }
                        //Session.Add("panduan", sb.ToString());
                    }
                    else if (m.Type == 4 && (m.Number > 0 && tiankong_j.Count > 0 && (tiankong_j.Count - m.Number) >= 0) || (m.Diff > 0 && tiankong_k.Count > 0 && (tiankong_k.Count - m.Diff) >= 0))
                    {
                        int k = 0;
                        //填空-简单
                        if (m.Number > 0 && tiankong_j.Count > 0 && (tiankong_j.Count - m.Number) >= 0)
                        {
                            t_tiankong_j = tiankong_j;
                            for (int a = 0; a < t_tiankong_j.Count; a++)
                            {
                                t_tiankong_j[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Number * 2 > t_tiankong_j.Count)
                            {
                                t_tiankong_j.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Number)
                                {
                                    int num = r.Next(1, t_tiankong_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Number)
                                {
                                    int num = r.Next(1, t_tiankong_j.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;

                                k++;
                                tb_QuestionEntity temp_tiankong = t_tiankong_j.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_tiankong != null)
                                {
                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";

                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_tiankong.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_tiankong.Title.IndexOf("<p>") >= 0 ? temp_tiankong.Title.Replace("<p>", "") : temp_tiankong.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"4\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";
                                    temp_question += "<textarea name=\"key1\" class=\"keyFill\" style=\"width:100%;height:80px\"></textarea></div>";

                                    //dirc.Add(t_index, Server.HtmlEncode(temp_question));
                                    dirc.Add(t_index, temp_question);
                                }
                            }
                        }
                        //填空-困难
                        if (m.Diff > 0 && tiankong_k.Count > 0 && (tiankong_k.Count - m.Diff) >= 0)
                        {
                            t_tiankong_k = tiankong_k;
                            for (int a = 0; a < t_tiankong_k.Count; a++)
                            {
                                t_tiankong_k[a].TempId = a + 1;
                            }


                            List<int> templist = new List<int>();
                            Random r = new Random();
                            if (m.Diff * 2 > t_tiankong_k.Count)
                            {
                                t_tiankong_k.ForEach(c => { templist.Add(c.TempId); });

                                while (templist.Count > m.Diff)
                                {
                                    int num = r.Next(1, t_tiankong_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a != 0)
                                    {
                                        templist.Remove(a);
                                    }

                                }
                            }
                            else
                            {
                                while (templist.Count < m.Diff)
                                {
                                    int num = r.Next(1, t_tiankong_k.Count);

                                    int a = templist.FirstOrDefault(c => c == num);
                                    if (a == 0)
                                    {
                                        templist.Add(num);
                                    }

                                }
                            }
                            for (int a = 0; a < templist.Count; a++)
                            {
                                string temp_question = "";
                                t_index++;

                                k++;
                                tb_QuestionEntity temp_tiankong = t_tiankong_k.FirstOrDefault(c => c.TempId == templist[a]);
                                if (temp_tiankong != null)
                                {
                                    temp_question += "<div class=\"title\"><div class=\"title-text\" id=\"examPanelTitle\">" + GetDaXie(i) + " " + m.Title + "(每题" + m.Score + "分，共" + (m.Number + m.Diff) + "题，合计" + ((m.Number + m.Diff) * m.Score) + "分)<br /></div>";
                                    temp_question += "<div class=\"title-btn\"><a href=\"javascript:void(0)\" id=\"questionsNum\" class=\"btn btn-primary  btn-xs btn-pass\" role=\"button\">" + k + "/" + (m.Number + m.Diff) + "</a></div></div>";

                                    temp_question += "<div class=\"content exam-content questionsContent\" questionsid=\"" + temp_tiankong.QuestionId + "\" questionscore=\"" + m.Score + "\" style=\"display: block;\">";
                                    temp_question += "<div class=\"exam-title questions\">" + (k) + "、" + (temp_tiankong.Title.IndexOf("<p>") >= 0 ? temp_tiankong.Title.Replace("<p>", "") : temp_tiankong.Title) + "<input type=\"hidden\" name=\"questionsType\" value=\"4\"/><input type=\"hidden\" name=\"questionsAnswered\" value=\"\"/></div>";
                                    temp_question += " <textarea name=\"key1\" class=\"keyFill\" style=\"width:100%;height:80px\"></textarea></div>";

                                    dirc.Add(t_index, temp_question);
                                }
                            }
                        }
                    }

                }
            }

            string path = Server.MapPath(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("userpath")) + "/exam-" + userid + "-" + ClsId + ".txt";
            string pathext = Server.MapPath(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("userpath")) + "/exam-" + userid + "-" + ClsId + "-dict.txt";

            Jnwf.Utils.Helper.FileHelper.GenerateFile(path, "{\"time\":\"" + DateTime.Now.ToString() + "\",\"duration\":\"" + model.Duration + "\",\"name\":\"" + Name + "\"}");

            string filestr = Jnwf.Utils.Json.JsonHelper.SerializeJson(dirc);
            Jnwf.Utils.Helper.FileHelper.GenerateFile(pathext, filestr);
            Jnwf.Utils.Log.Logger.Log4Net.Error("t11.Answer,dirc.Count:" + dirc.Count);
            if (dirc.Count > 0)
            {
                Jnwf.Utils.Log.Logger.Log4Net.Error("t12.Answer,dirc.Count:" + dirc.Count);
                GetQuestion(1, dirc);
            }
        }

    }
    private void GetQuestion(int index, Dictionary<int, string> dict)
    {
        if (dict != null)
        {
            string temp = dict[index];
            if (!string.IsNullOrEmpty(temp))
            {
                Jnwf.Utils.Log.Logger.Log4Net.Error("t10.Answer,userid:");
                body = Server.HtmlDecode(dict[index]);
                //是否第一次执行，学校后缀，题内容， hiddown 值,试题名  ，时间
                string srcEncode = System.Uri.EscapeDataString(body);
                Response.Write("{\"hidindex\":\"1\",\"body\":\"" + srcEncode + "\",\"hiddown\":\"" + dict.Count + "\",\"name\":\"" + Name + "\",\"time\":\"" + Mm + "\"}");
            }

        }
    }
    private string GetDaXie(int i)
    {
        string daxie = "";
        switch(i)
        {
            case 1:
                daxie = "一、";
                break;
            case 2:
                daxie = "二、";
                break;
            case 3:
                daxie = "三、";
                break;
            case 4:
                daxie = "四、";
                break;
            case 5:
                daxie = "五、";
                break;
            case 6:
                daxie = "六、";
                break;
            case 7:
                daxie = "七、";
                break;
            case 8:
                daxie = "八、";
                break;
            case 9:
                daxie = "九、";
                break;
        }
        return daxie;
    }
}
public class tmp
{
    public string data { get; set; }

    public string time { get; set; }

    public string duration { get; set; }

    public string name { get; set; }
}