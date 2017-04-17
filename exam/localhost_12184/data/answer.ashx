<%@ WebHandler Language="C#" Class="answer" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

public class answer : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");

        //context.Response.Write("{\"msg\":\"True\",\"release_info\":\"\",\"is_pass\":\"通过\"}");
        
        if (string.IsNullOrEmpty(json) || exampaperid==0 || clsid == 0)
        {
            context.Response.Write("{\"msg\":\"False\",\"release_info\":\"参数错误\",\"is_pass\":\"\"}");
        }
        else
        {
            try
            {
                int userId = int.Parse(context.Request.Form["UserId"].ToString());
                int schoolId = int.Parse(context.Request.Form["schoolid"].ToString());
                if (userId != 0)
                {
                    List<item> list = Jnwf.Utils.Json.JsonHelper.DeserializeJsonReturnList<item>(json);
                    string where = "";
                    list.ForEach(c => { where += c.qid + ","; });
                    //获取所有的试题
                    List<Exam.Entity.tb_QuestionEntity> temp = Exam.BLL.tb_QuestionBLL.GetInstance().GetQuestionList(where.TrimEnd(',')) as List<Exam.Entity.tb_QuestionEntity>;
                    //获取考试书的信息
                    Exam.Entity.tb_QuestionClsEntity tempcls = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(clsid);
                    //获取试卷信息
                    Exam.Entity.tb_ExampaperEntity exampaper = Exam.BLL.tb_ExampaperBLL.GetInstance().GetAdminSingle(exampaperid);
                    //构建考试结果
                    Exam.Entity.tb_ResultEntity model = new Exam.Entity.tb_ResultEntity();
                    model.SchoolId = schoolId;
                    model.UserId = userId;
                    model.ExampaperId = exampaperid;
                    model.Score = 0;
                    model.Point = 0;
                    model.Addtime = DateTime.Now;
                    //获取考试的实际分数
                    foreach (item i in list)
                    {
                        Exam.Entity.tb_QuestionEntity t = temp.FirstOrDefault(c => c.QuestionId == i.qid);

                        if (t != null)
                        {
                            if (i.val.TrimEnd(',') == t.Answer)
                            {
                                model.Score += i.score;
                            }
                        }
                    }
                    //获取这本书籍的积分
                    if (model.Score >= exampaper.Pass)
                    {
                        model.Point = tempcls.Score;
                    }
                    //插入考试结果
                    int rows = Exam.BLL.tb_ResultBLL.GetInstance().Insert(model);
                    //整理考试扩展表
                    List<Exam.Entity.tb_ResultExtEntity> extlist = new List<Exam.Entity.tb_ResultExtEntity>();
                    foreach(item i in list)
                    {
                        Exam.Entity.tb_ResultExtEntity ext = new Exam.Entity.tb_ResultExtEntity();
                        ext.ResultId = rows;
                        ext.QuestionId = i.qid;
                        ext.Answer = i.val.TrimEnd(',');
                        Exam.Entity.tb_QuestionEntity t = temp.FirstOrDefault(c => c.QuestionId == i.qid);
                        if (t != null)
                        {
                            if (i.val.TrimEnd(',') == t.Answer)
                            {
                                ext.IsRight = 1;
                            }
                            else
                            {
                                ext.IsRight = 0;        
                            }
                        }
                        extlist.Add(ext);
                    }
                    Exam.BLL.tb_ResultExtBLL.GetInstance().InsertSelect(extlist);
                    if (model.Point > 0)
                        context.Response.Write("{\"msg\":\"True\",\"release_info\":\"\",\"is_pass\":\"通过\"}");
                    else
                        context.Response.Write("{\"msg\":\"True\",\"release_info\":\"\",\"is_pass\":\"未通过\"}");
                }
                else
                {
                    context.Response.Write("{\"msg\":\"False\",\"release_info\":\"参数错误\",\"is_pass\":\"\"}");    
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"msg\":\"False\",\"release_info\":\"" + ex.Message + "\",\"is_pass\":\"\"}");
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    public string json
    {
        get
        {
            object obj = HttpContext.Current.Request.Form["data"];
            if (obj == null)
                return "";
            return obj.ToString();
        }
    }
    public int exampaperid
    {
        get
        {
            object obj = HttpContext.Current.Request.Form["exampaperid"];
            if (obj == null)
                return 0;
            return int.Parse(obj.ToString());
        }
    }
    //书库（表示是什么书）
    public int clsid
    {
        get
        {
            object obj = HttpContext.Current.Request.Form["clsid"];
            if (obj == null)
                return 0;
            return int.Parse(obj.ToString());
        }
    }
}

public class item
{
    public string type { get; set; }
    
    public string val { get; set; }

    public int qid { get; set; }
    
    public int score { get; set; }
}