using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class data_data :BasePage //System.Web.UI.Page
{
    public string type
    {
        get
        {
            object obj = Request.Form["type"];
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            switch (type)
            {
                case "enditmenu":
                    EndMenu(departmentid, name);
                    break;
                case "addmenu":
                    AddMenu(departmentid, name);
                    break;
                case "deletemenu":
                    DeleteMenu(departmentid);
                    break;
                case "deluser":
                    DeleteUser(userid);
                    break;
                case "addtestqmda":
                    Addtestqmda(int.Parse(Request.Form["questionId"].ToString()), int.Parse(Request.Form["department"].ToString()), Request.Form["typef"].ToString(), Request.Form["contentms"].ToString(), Request.Form["contentdaxa"].ToString(), Request.Form["contentdaxb"].ToString(), Request.Form["contentdaxc"].ToString(), Request.Form["contentdaxd"].ToString(), Request.Form["contentdaxe"].ToString(), Request.Form["contentdaxf"].ToString(), Request.Form["contentdaxg"].ToString(), Request.Form["contentdaxh"].ToString(), Request.Form["harder"].ToString(), Request.Form["status"].ToString(), Request.Form["contentjx"].ToString(), Request.Form["dd"].ToString());
                    break;
                case "addtestqmdd":
                    Addtestqmdd(int.Parse(Request.Form["questionId"].ToString()), int.Parse(Request.Form["department"].ToString()), Request.Form["typef"].ToString(), Request.Form["contentms"].ToString(), Request.Form["contentduxa"].ToString(), Request.Form["contentduxb"].ToString(), Request.Form["contentduxc"].ToString(), Request.Form["contentduxd"].ToString(), Request.Form["contentduxe"].ToString(), Request.Form["contentduxf"].ToString(), Request.Form["contentduxg"].ToString(), Request.Form["contentduxh"].ToString(), Request.Form["harder"].ToString(), Request.Form["status"].ToString(), Request.Form["contentjx"].ToString(), Request.Form["dd"].ToString());
                    break;
                case "addtestqmpd":
                    Addtestqmpd(int.Parse(Request.Form["questionId"].ToString()), int.Parse(Request.Form["department"].ToString()), Request.Form["typef"].ToString(), Request.Form["contentms"].ToString(), Request.Form["harder"].ToString(), Request.Form["status"].ToString(), Request.Form["contentjx"].ToString(), Request.Form["pd"].ToString());
                    break;
                case "addtestqmtk":
                    Addtestqmtk(int.Parse(Request.Form["questionId"].ToString()), int.Parse(Request.Form["department"].ToString()), Request.Form["typef"].ToString(), Request.Form["contentms"].ToString(), Request.Form["harder"].ToString(), Request.Form["status"].ToString(), Request.Form["contentjx"].ToString(), Request.Form["txttk"].ToString());
                    break;
                case "addquestionmenu":
                    addquestionmenu(int.Parse(Request.Form["parentId"].ToString()), Request.Form["name"].ToString(),int.Parse(Request.Form["pass"]),int.Parse(Request.Form["ismust"]));
                    break;
                case "enditquestionmenu":
                    enditquestionmenu(int.Parse(Request.Form["parentId"].ToString()), Request.Form["name"].ToString(),int.Parse(Request.Form["pass"]),int.Parse(Request.Form["ismust"]));
                    break;
                case "deletequestionmenu":
                    deletequestionmenu(int.Parse(Request.Form["parentId"].ToString()));
                    break;
                case "classstatus":
                    classstatus(int.Parse(Request.Form["id"]));
                    break;
                case "addconreadbook":
                    addconreadbook(int.Parse(Request.Form["id"].ToString()),int.Parse(Request.Form["status"].ToString()));
                    break;
                case "delagent":
                    delagent(int.Parse(Request.Form["userid"]));
                    break;
                case "delschool":
                    delschool(int.Parse(Request.Form["schoolid"]));
                    break;
                case "passset":
                    passset(int.Parse(Request.Form["id"].ToString()), int.Parse(Request.Form["pass"].ToString()));
                    break;
                case "select":
                    select(int.Parse(Request.Form["locationid"].ToString()),int.Parse(Request.Form["tmp"].ToString()));
                    break;
                case "addagent":
                     addagent(
                        Request.Form["name"].ToString(), 
                        Request.Form["password"].ToString(), 
                        Request.Form["realname"].ToString(), 
                        int.Parse(Request.Form["sex"].ToString()), 
                        int.Parse(Request.Form["role"].ToString()),
                        int.Parse(Request.Form["status"].ToString()),
                        Request.Form["position"].ToString(),
                        Request.Form["email"].ToString(),
                        Request.Form["phone"].ToString(),
                        Request.Form["notice"].ToString(),
                        int.Parse(Request.Form["userid"].ToString()));
                    break; 
                case "delname":
                    delname(Request.Form["userid"].ToString());
                    break;
                case "delti":
                    delti(Request.Form["tiid"].ToString());
                    break;
                case "selectdepartment":
                    selectdepartment(int.Parse(Request.Form["locationid"].ToString()),int.Parse(Request.Form["tmp"].ToString()));
                    break;
                case "addad"://添加广告语
                    addad(Request.Form["adcontent"].ToString(), Request.Form["adlink"].ToString(), Request.Form["adid"].ToString());
                    break;
                case "updatead"://修改广告语 赋值
                    updatead(int.Parse(Request.Form["id"].ToString()));
                    break;
                case "deletead"://删除广告语
                    deletead(int.Parse(Request.Form["id"].ToString()));
                    break;
                case "deleteforums"://删除评论
                    deleteforums(int.Parse(Request.Form["id"]));
                    break;
                case "deleteword"://删除敏感词
                    deleteword(int.Parse(Request.Form["id"].ToString()));
                    break;
                case "addeword"://添加敏感词
                    addeword(Request.Form["word"].ToString());
                    break;
            }
           
        }
    }
    //单选录入
    public void Addtestqmda(int questionId, int department, string typef, string contentms, string contentdaxa, string contentdaxb, string contentdaxc, string contentdaxd, string contentdaxe, string contentdaxf, string contentdaxg, string contentdaxh, string harder, string status, string contentjx, string dd)
    {
        contentms = contentms.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        //A-H
        contentdaxa = contentdaxa.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentdaxb = contentdaxb.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentdaxc = contentdaxc.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentdaxd = contentdaxd.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentdaxe = contentdaxe.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentdaxf = contentdaxf.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentdaxg = contentdaxg.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentdaxh = contentdaxh.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");     

        contentjx = contentjx.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");          
        try
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                Exam.Entity.tb_QuestionEntity model = null;
                if (questionId == 0 && identity!=null)
                {
                       model = new Exam.Entity.tb_QuestionEntity();
                        model.Type = int.Parse(typef);

                        model.SchoolId = 0;//identity._schoolID;
                        model.QuestionClsId = department; 
                        model.Title = contentms;
                        if(contentdaxa!=null){
                            model.A = contentdaxa; 
                         }
                        if(contentdaxb!=null){
                            model.B = contentdaxb;
                        }
                        if(contentdaxc!=null){
                            model.C = contentdaxc;
                        }
                       if(contentdaxd!=null){
                           model.D = contentdaxd;
                       }
                        if(contentdaxe!=null){

                            model.E = contentdaxe;
                        }
                       if(contentdaxf!=null){

                           model.F = contentdaxf;
                       }
                       if(contentdaxg!=null){
                           model.G = contentdaxg;
                       } 
                       if(contentdaxh!=null){
                           model.H = contentdaxh;
                       }
                        model.Answer = dd;
                        model.Interpretation = contentjx;
                        model.Isdifficulty = int.Parse(harder);
                        model.Status = int.Parse(status);
                        model.Addtime = DateTime.Now;
                        model.Updatetime = DateTime.Now;
               
                Exam.BLL.tb_QuestionBLL.GetInstance().Insert(model);
                Response.Write("1");
                }
                else
                {
                    model = Exam.BLL.tb_QuestionBLL.GetInstance().GetAdminSingle(questionId);
                    if(model!=null)
                    {
                    
                       model.Type = int.Parse(typef);

                       model.SchoolId = 0;//identity._schoolID;
                        model.QuestionClsId = department; 
                        model.Title = contentms;
                        if(contentdaxa!=null){
                            model.A = contentdaxa; 
                         }
                        if(contentdaxb!=null){
                            model.B = contentdaxb;
                        }
                        if(contentdaxc!=null){
                            model.C = contentdaxc;
                        }
                       if(contentdaxd!=null){
                           model.D = contentdaxd;
                       }
                        if(contentdaxe!=null){

                            model.E = contentdaxe;
                        }
                       if(contentdaxf!=null){

                           model.F = contentdaxf;
                       }
                       if(contentdaxg!=null){
                           model.G = contentdaxg;
                       } 
                       if(contentdaxh!=null){
                           model.H = contentdaxh;
                       }
                        model.Answer = dd;
                        model.Interpretation = contentjx;
                        model.Isdifficulty = int.Parse(harder);
                        model.Status = int.Parse(status);
                        model.Updatetime = DateTime.Now;
                    }
                Exam.BLL.tb_QuestionBLL.GetInstance().Update(model);
                Response.Write("2");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,EndMenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //试题多选
    public void Addtestqmdd(int questionId, int department, string typef, string contentms, string contentduxa, string contentduxb, string contentduxc, string contentduxd, string contentduxe, string contentduxf, string contentduxg, string contentduxh, string harder, string status, string contentjx, string dd)
    {
        contentms = contentms.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");      
        //AA-HH
        contentduxa = contentduxa.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentduxb = contentduxb.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentduxc = contentduxc.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentduxd = contentduxd.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentduxe = contentduxe.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentduxf = contentduxf.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentduxg = contentduxg.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentduxh = contentduxh.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");

        contentjx = contentjx.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        try
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
               Exam.Entity.tb_QuestionEntity model = null;
               if (questionId == 0 && identity != null)
               {
                   model = new Exam.Entity.tb_QuestionEntity();
                   model.Type = int.Parse(typef);
                   model.SchoolId = 0;//identity._schoolID;
                   model.QuestionClsId = department;
                   model.Title = contentms;
                   if (contentduxa != null)
                   {
                       model.A = contentduxa;
                   }
                   if (contentduxb != null)
                   {
                       model.B = contentduxb;
                   }
                   if (contentduxc != null)
                   {

                       model.C = contentduxc;
                   }
                   if (contentduxd != null)
                   {
                       model.D = contentduxd;
                   }
                   if (contentduxe != null)
                   {
                       model.E = contentduxe;
                   }
                   if (contentduxf != null)
                   {
                       model.F = contentduxf;
                   }
                   if (contentduxg != null)
                   {
                       model.G = contentduxg;
                   }
                   if (contentduxh != null)
                   {
                       model.H = contentduxh;
                   }
                   model.Answer = dd.TrimEnd(',');
                   model.Interpretation = contentjx;
                   model.Isdifficulty = int.Parse(harder);
                   model.Status = int.Parse(status);
                   model.Addtime = DateTime.Now;
                   model.Updatetime = DateTime.Now;
               
                Exam.BLL.tb_QuestionBLL.GetInstance().Insert(model);
                Response.Write("1");
            }
            else
            {
                model = Exam.BLL.tb_QuestionBLL.GetInstance().GetAdminSingle(questionId);
                if (model != null)
                {
                    model.Type = int.Parse(typef);
                    model.SchoolId = 0;//identity._schoolID;
                    model.QuestionClsId = department;
                    model.Title = contentms;
                    if (contentduxa != null)
                    {
                        model.A = contentduxa;
                    }
                    if (contentduxb != null)
                    {
                        model.B = contentduxb;
                    }
                    if (contentduxc != null)
                    {

                        model.C = contentduxc;
                    }
                    if (contentduxd != null)
                    {
                        model.D = contentduxd;
                    }
                    if (contentduxe != null)
                    {
                        model.E = contentduxe;
                    }
                    if (contentduxf != null)
                    {
                        model.F = contentduxf;
                    }
                    if (contentduxg != null)
                    {
                        model.G = contentduxg;
                    }
                    if (contentduxh != null)
                    {
                        model.H = contentduxh;
                    }
                    model.Answer = dd.TrimEnd(',');
                    model.Interpretation = contentjx;
                    model.Isdifficulty = int.Parse(harder);
                    model.Status = int.Parse(status);
                    model.Updatetime = DateTime.Now;
                }
                Exam.BLL.tb_QuestionBLL.GetInstance().Update(model);
                Response.Write("2");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,EndMenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //试题判断
     public void Addtestqmpd(int questionId, int department, string typef, string contentms, string harder, string status, string contentjx, string pd)
    {
        contentms = contentms.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentjx = contentjx.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        try
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                Exam.Entity.tb_QuestionEntity model = null;
                if (questionId == 0 && identity != null)
                {
                    model = new Exam.Entity.tb_QuestionEntity();
                    model.Type = int.Parse(typef);
                    model.SchoolId = 0;//identity._schoolID;
                    model.QuestionClsId = department;
                    model.Title = contentms;
                    model.Answer = pd;
                    model.Interpretation = contentjx;
                    model.Isdifficulty = int.Parse(harder);
                    model.Status = int.Parse(status);
                    model.Addtime = DateTime.Now;
                    model.Updatetime = DateTime.Now;
                    Exam.BLL.tb_QuestionBLL.GetInstance().Insert(model);
                    Response.Write("1");
                }
                else
                {
                    model = Exam.BLL.tb_QuestionBLL.GetInstance().GetAdminSingle(questionId);
                    if (model != null)
                    {
                    model.Type = int.Parse(typef);
                    model.SchoolId = 0;//identity._schoolID;
                    model.QuestionClsId = department;
                    model.Title = contentms;
                    model.Answer = pd;
                    model.Interpretation = contentjx;
                    model.Isdifficulty = int.Parse(harder);
                    model.Status = int.Parse(status);
                    model.Updatetime = DateTime.Now;
                    }
                 Exam.BLL.tb_QuestionBLL.GetInstance().Update(model);
                 Response.Write("2");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,EndMenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //试题填空
     public void Addtestqmtk(int questionId, int department, string typef, string contentms, string harder, string status, string contentjx, string txttk)
    {
        contentms = contentms.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        contentjx = contentjx.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&apos;", "'").Replace("&quot;", "\"");
        try
        {
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                Exam.Entity.tb_QuestionEntity model = null;
                if (questionId == 0 && identity != null)
                {
                    model = new Exam.Entity.tb_QuestionEntity();
                    model.Type = int.Parse(typef);
                    model.SchoolId = 0;//identity._schoolID;
                    model.QuestionClsId = department;
                    model.Title = contentms;
                    model.Answer = txttk;
                    model.Interpretation = contentjx;
                    model.Isdifficulty = int.Parse(harder);
                    model.Status = int.Parse(status);
                    model.Addtime = DateTime.Now;
                    model.Updatetime = DateTime.Now;
                    Exam.BLL.tb_QuestionBLL.GetInstance().Insert(model);
                    Response.Write("1");
                }
                else
                {
                    model = Exam.BLL.tb_QuestionBLL.GetInstance().GetAdminSingle(questionId);
                    if (model != null)
                    {
                        model.Type = int.Parse(typef);
                        model.SchoolId = 0;// identity._schoolID;
                        model.QuestionClsId = department;
                        model.Title = contentms;
                        model.Answer = txttk;
                        model.Interpretation = contentjx;
                        model.Isdifficulty = int.Parse(harder);
                        model.Status = int.Parse(status);
                        model.Updatetime = DateTime.Now;
                    }
                    Exam.BLL.tb_QuestionBLL.GetInstance().Update(model);
                    Response.Write("2");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,EndMenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
   
    //修改
    public void EndMenu(int departmentid,string name)
    {
         try
            {
                Exam.Entity.tb_DepartmentEntity model = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(departmentid);
                if (model != null)
                {
                    model.Name = name;
                    Exam.BLL.tb_DepartmentBLL.GetInstance().Update(model);
                    Response.Write("1");
                }
            }
            catch (Exception ex)
            {
                Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,EndMenu,ex:" + ex.Message + "|" + ex.StackTrace);
                Response.Write("error");
            }
    }
    //添加
    public void AddMenu(int departmentid, string name)
    {
        try
        {
            Exam.Entity.tb_DepartmentEntity model = new Exam.Entity.tb_DepartmentEntity();
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                model.SchoolId = identity._schoolID;
                model.RoleId = 0;
                model.ParentId = departmentid;
                model.Name = name;
                model.Description = name;
                model.Status = 1;
                model.Addtime = DateTime.Now;
                model.Updatetime = DateTime.Now;
                Exam.BLL.tb_DepartmentBLL.GetInstance().Insert(model);
                Response.Write("1");
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,AddMenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //删除
    public void DeleteMenu(int departmentid)
    {
        try
        {
            IList<Exam.Entity.tb_DepartmentEntity> list = Exam.BLL.tb_DepartmentBLL.GetInstance().Gettb_DepartmentParentIdList(departmentid);
            if (list.Count > 0 && list != null)
            {
                foreach (Exam.Entity.tb_DepartmentEntity model in list)
                {
                    Exam.BLL.tb_DepartmentBLL.GetInstance().Delete_DepartmentByParentId(model.DepartmentId);
                }
            }
            Exam.BLL.tb_DepartmentBLL.GetInstance().Delete_DepartmentByParentId(departmentid);
            Exam.BLL.tb_DepartmentBLL.GetInstance().Delete_DepartmentByDepartmentId(departmentid);
            Response.Write("1");
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,DeleteMenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    public void DeleteUser(int userid)
    {
        try
        {
            Exam.Entity.tb_UserEntity model = Exam.BLL.tb_UserBLL.GetInstance().GetAdminSingle(userid);
            if (model != null)
            {
                model.Status = 0;
                Exam.BLL.tb_UserBLL.GetInstance().Update(model);
            }
        }
        catch (Exception ex)
        {
            
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,DeleteUser,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //添加
    public void addquestionmenu(int questionId, string name,int pass,int ismust)
    {
        try
        {
            Exam.Entity.tb_QuestionClsEntity model = new Exam.Entity.tb_QuestionClsEntity();
            UserIdentity identity = User.Identity as UserIdentity;
            if (identity != null)
            {
                model.SchoolId = 0;//identity._schoolID;
                model.ParentId = questionId;
                model.Name = name;
                model.Description = name;
                model.Status = 1;
                model.Addtime = DateTime.Now;
                model.Updatetime = DateTime.Now;
                model.IsMust = ismust;
                model.Score = pass;
                Exam.BLL.tb_QuestionClsBLL.GetInstance().Insert(model);
                Response.Write("1");
            }
        }
        catch (Exception ex)
        {

            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,addquestionmenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //修改
    public void enditquestionmenu(int questionId, string name,int pass,int ismust)
    {
        try
        {
            Exam.Entity.tb_QuestionClsEntity model = Exam.BLL.tb_QuestionClsBLL.GetInstance().GetAdminSingle(questionId);
            if (model != null)
            {
                model.IsMust = ismust;
                model.Score = pass;
                model.Name = name;
                Exam.BLL.tb_QuestionClsBLL.GetInstance().Update(model);
                Response.Write("1");
            }
        }
        catch (Exception ex)
        {

            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,enditquestionmenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }

    }
    //删除
    public void deletequestionmenu(int questionId)
    {
        try
        {
            IList<Exam.Entity.tb_QuestionClsEntity> list = Exam.BLL.tb_QuestionClsBLL.GetInstance().Gettb_QuestionClsListParentIdTow(questionId);
            if (list.Count > 0 && list != null)
            {
                foreach (Exam.Entity.tb_QuestionClsEntity model in list)
                {
                    Exam.BLL.tb_QuestionClsBLL.GetInstance().Delete(model.QuestionClsId);
                }
            }
            Exam.BLL.tb_QuestionClsBLL.GetInstance().Delete(questionId);
            Exam.BLL.tb_QuestionClsBLL.GetInstance().Delete(questionId);
            Response.Write("1");
        }
        catch (Exception ex)
        {

            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,deletequestionmenu,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    public void classstatus(int id)
    {
        Exam.Entity.tb_DepartmentEntity model = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(id);
        try
        {
            if (model != null)
            {
                if (model.Status == 1)
                {
                    model.Status = 0;
                    Exam.BLL.tb_DepartmentBLL.GetInstance().Update(model);
                    Response.Write("1");
                }
                else
                {
                    model.Status = 1;
                    Exam.BLL.tb_DepartmentBLL.GetInstance().Update(model);
                    Response.Write("1");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,classstatus,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
       
    }
    //添加
    public void addconreadbook(int id,int status)
    {
        try
        {
            UserIdentity identyty = User.Identity as UserIdentity;
            if (identyty != null)
            {
                IList<Exam.Entity.tb_School_QuestionClsEntity> list = Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Gettb_School_QuestionClsList();
                Exam.Entity.tb_School_QuestionClsEntity tmodel = list.FirstOrDefault(c => c.QuestionClsId == id && c.SchoolId==identyty._schoolID);
                if (tmodel == null && status != 2)
                {
                    Exam.Entity.tb_School_QuestionClsEntity model = new Exam.Entity.tb_School_QuestionClsEntity();
                    model.SchoolId = identyty._schoolID;
                    model.QuestionClsId = id;
                    model.IsMust = status;
                    Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Insert(model);
                    Response.Write("1");
                }
                else if (status == 2)
                {
                    Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Delete(id);
                    Response.Write("1");
                }
                else if(status==0 || status==1)
                {
                    tmodel.IsMust = status;
                    Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Update(tmodel);
                    Response.Write("1");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,addconreadbook,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
        
    }
    //删除代理商
    public void delagent(int userid)
    {
        try
        {
            Exam.Entity.tb_UserEntity model = Exam.BLL.tb_UserBLL.GetInstance().GetAdminSingle(userid);
            if (model != null)
            {
                model.Status = 0;
            }
            Exam.BLL.tb_UserBLL.GetInstance().Update(model);
            Response.Write("1");
        }
        catch (Exception ex)
        {

            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,delagent,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //删除学校
    public void delschool(int schoolId)
    {
        try
        {
            Exam.Entity.tb_SchoolEntity model = Exam.BLL.tb_SchoolBLL.GetInstance().GetAdminSingle(schoolId);
            if (model != null)
            {
                model.Status = 0;
            }
            Exam.BLL.tb_SchoolBLL.GetInstance().Update(model);
            Response.Write("1");
        }
        catch (Exception ex)
        {

            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,delagent,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //设置通过积分
    public void passset(int id, int pass)
    {
        try
        {
            if (identity != null)
            {
                Exam.Entity.tb_School_QuestionClsEntity tmodel = Exam.BLL.tb_School_QuestionClsBLL.GetInstance().GetSchoolQuestionListByQuestionIdSchoolId(id,identity._schoolID);
                if (tmodel == null)
                {
                    Exam.Entity.tb_School_QuestionClsEntity model = new Exam.Entity.tb_School_QuestionClsEntity();
                    model.SchoolId = identity._schoolID;
                    model.QuestionClsId = id;
                    model.Path = "1";
                    model.Score = pass;
                    model.IsMust = 0;
                    if (Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Insert(model) > 0)
                    {
                        Response.Write("1");
                    }
                }
                else
                {
                    tmodel.Score = pass;
                    Exam.BLL.tb_School_QuestionClsBLL.GetInstance().Update(tmodel);
                    Response.Write("1");
                }
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,passset,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //添加代理商
    public void addagent(string name, string pwd, string realname, int sex, int role, int status, string position, string email, string phone, string ontice, int userid)
    {
        int schoolid = int.Parse(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("agentid"));
        int departmentId = 0;
        UserIdentity identity = User.Identity as UserIdentity;
        if (identity != null)
        {
            //添加
            if (userid == 0)
            {
                Exam.Entity.tb_DepartmentEntity department = null;
                if (departmentId > 0)
                    department = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(departmentId);
                else
                    department = Exam.BLL.tb_DepartmentBLL.GetInstance().Get_DepartmentEntityBySchoold(identity.SchoolID);

                Exam.Entity.tb_UserEntity model = new Exam.Entity.tb_UserEntity();
                model.SchoolId = schoolid;
                model.DepartmentId = departmentId;

                if (department != null)
                {
                    if (department.RoleId == 1)
                    {
                        model.Path = "/" + department.DepartmentId + "/";
                    }
                    else if (department.RoleId == 2)
                    {
                        model.Path = "/" + department.ParentId + "/" + department.DepartmentId + "/";
                    }
                    else
                    {
                        Exam.Entity.tb_DepartmentEntity tempdepartment = Exam.BLL.tb_DepartmentBLL.GetInstance().GetAdminSingle(department.ParentId);
                        if (tempdepartment != null)
                        {
                            model.Path = "/" + tempdepartment.ParentId + "/" + department.ParentId + "/" + department.DepartmentId + "/";
                        }
                        else
                        {
                            model.Path = "";
                        }
                    }
                }
                else
                {
                    model.Path = "";
                }
                model.Name = name;
                model.Pwd = pwd;
                model.RealName = realname;
                model.Sex = sex;
                model.Position = position;
                model.Mail = email;
                model.Phone = phone;
                if (!ontice.Equals("0"))
                {
                    model.Description = ontice;
                }
                model.Status = status;
                model.Addtime = DateTime.Now;
                model.RoleId = role;
                Exam.BLL.tb_UserBLL.GetInstance().Insert(model);
                MessageBox.ShowAndRedirect(this, "添加成功！", "listagent.aspx");
                Response.Write("1");
            }
            else
            {
                Exam.Entity.tb_UserEntity model = Exam.BLL.tb_UserBLL.GetInstance().GetAdminSingle(userid);
                if (model != null)
                {
                    if (!pwd.Equals("0"))
                    {
                        model.Pwd = pwd;
                    }
                    model.RealName = realname;
                    model.Sex = sex;
                    model.RoleId = role;
                    model.Status = status;
                    model.Position = position;
                    model.Mail = email;
                    model.Phone = phone;
                    model.Description = ontice;
                    Exam.BLL.tb_UserBLL.GetInstance().Update(model);
                    Response.Write("2");
                }
            }
        }
    }
    //地区级联
    public void select(int id,int tmp)
    {
        System.Text.StringBuilder sbr = new System.Text.StringBuilder();
        if (id != 0 || tmp == 1)
        {
            if (id == 0)
            {
                Response.Write("<option Value=\"0\">县/区</option>");
            }
            else
            {
                sbr.Append("<option Value=\"0\">全部</option>");
                IList<Exam.Entity.tb_LocationEntity> list = Exam.BLL.tb_LocationBLL.GetInstance().GetCityByCache(id);
                if (list != null && list.Count > 0)
                {
                    foreach (Exam.Entity.tb_LocationEntity model in list)
                    {
                        sbr.Append("<option Value=\"" + model.LocationId + "\">" + model.LocationName + "</option>");
                    }
                }
                Response.Write(sbr.ToString());
            }
            
        }
        else
        {
            if (tmp == 0)
            {
                Response.Write("<option Value=\"0\">市</option>");
            }
            else
            {
                Response.Write("<option Value=\"0\">县/区</option>");
            }
            
        }
    }
    public void selectdepartment(int id, int tmp)
    {
        System.Text.StringBuilder sbr = new System.Text.StringBuilder();
        if (id != 0 || tmp == 1)
        {
            if (id == 0)
            {
                Response.Write("<option Value=\"0\">县/区</option>");
            }
            else
            {
                IList<Exam.Entity.tb_LocationEntity> list = Exam.BLL.tb_LocationBLL.GetInstance().GetCityByCache(id);
                if (list != null && list.Count > 0)
                {
                    foreach (Exam.Entity.tb_LocationEntity model in list)
                    {
                        sbr.Append("<option Value=\"" + model.LocationId + "\">" + model.LocationName + "</option>");
                    }
                }
                Response.Write(sbr.ToString());
            }

        }
        else
        {
            if (tmp == 0)
            {
                Response.Write("<option Value=\"0\">市</option>");
            }
            else
            {
                Response.Write("<option Value=\"0\">县/区</option>");
            }

        }
    }
    //用户删除
    public void delname(string userid)
    {
        userid = userid.TrimEnd(',');
        try
        {
            int id = Exam.BLL.tb_UserBLL.GetInstance().UpdateByUserId(userid);
            if (id > 0)
            {
                Response.Write("1");
            }
        }
        catch (Exception ex)
        {

            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,DeleteUser,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    //删除试题
    public void delti(string tiid)
    {
        tiid = tiid.TrimEnd(',');
        try
        {
            int num = Exam.BLL.tb_QuestionBLL.GetInstance().DeleleQuestionByQuestionId(tiid);
            if (num > 0)
            {
                Response.Write("1");
            }
        }
        catch (Exception ex)
        {
            Jnwf.Utils.Log.Logger.Log4Net.Error("data.aspx.cs,delti,ex:" + ex.Message + "|" + ex.StackTrace);
            Response.Write("error");
        }
    }
    /// <summary>
    /// 添加广告语 /修改广告语 
    /// </summary>
    /// <param name="adContent"></param>
    public void addad(string adContent,string adLink,string adId)
    {
        if (identity != null)
        {
            if (adId == "")
            {
                try
                {
                    Exam.Entity.tb_AdEntity model = new Exam.Entity.tb_AdEntity();
                    model.UserId = identity.UserID;
                    model.RoleId = identity._roleID;
                    model.AdContent = SqlInject(adContent);
                    model.AdLink = SqlInject(adLink);
                    model.Status = 1;
                    model.Addtime = DateTime.Now;
                    model.Updatetime = DateTime.Now;
                    Exam.BLL.tb_AdBLL.GetInstance().Insert(model);
                    Response.Write(1);
                }
                catch (Exception ex)
                {
                    Response.Write(2);
                }
            }
            else
            {
                try
                {
                    Exam.Entity.tb_AdEntity model = Exam.BLL.tb_AdBLL.GetInstance().GetAdminSingle(int.Parse(adId));
                    model.AdContent = adContent;
                    model.AdLink = adLink;
                    model.Updatetime = DateTime.Now;
                    Exam.BLL.tb_AdBLL.GetInstance().Update(model);
                    Response.Write(1);
                }
                catch (Exception ex)
                {
                    Response.Write(3);
                }
            }
        }
    }
    /// <summary>
    /// 广告语修改赋值
    /// </summary>
    /// <param name="id"></param>
    public void updatead(int id)
    {
        try
        {
            Exam.Entity.tb_AdEntity model = Exam.BLL.tb_AdBLL.GetInstance().GetAdminSingle(id);
            if (model != null)
            {
                Response.Write(model.AdContent + "+" + model.AdLink);
            }
            else
                Response.Write("");
        }
        catch (Exception ex)
        {
            Response.Write("");
        }
    }
    /// <summary>
    /// 删除广告
    /// </summary>
    /// <param name="id"></param>
    public void deletead(int id)
    {
        try
        {
            Exam.Entity.tb_AdEntity model = Exam.BLL.tb_AdBLL.GetInstance().GetAdminSingle(id);
            if (model != null)
            {
                model.Status = 0;
                model.Updatetime = DateTime.Now;
                Exam.BLL.tb_AdBLL.GetInstance().Update(model);
                Response.Write(1);
            }
            else
                Response.Write(2);
        }
        catch (Exception ex)
        {
            Response.Write(2);
        }
    }
    /// <summary>
    /// 删除敏感词
    /// </summary>
    /// <param name="id"></param>
    public void deleteword(int id)
    {
        try
        {
            Exam.Entity.tb_WordEntity model = Exam.BLL.tb_WordBLL.GetInstance().GetAdminSingle(id);
            if (model != null)
            {
                model.Status = 0;
                model.Updatetime = DateTime.Now;
                Exam.BLL.tb_WordBLL.GetInstance().Update(model);
                Response.Write(1);
            }
            else
                Response.Write(2);
        }
        catch (Exception ex)
        {
            Response.Write(2);
        }
    }
    /// <summary>
    /// 添加敏感词
    /// </summary>
    /// <param name="word"></param>
    public void addeword(string word)
    {
        try
        {
            Exam.Entity.tb_WordEntity model = new Exam.Entity.tb_WordEntity();
            model.Addtime=DateTime.Now;
            model.Updatetime=DateTime.Now;
            model.Status=1;
            model.UserId = identity.UserID;
            model.Word = SqlInject(word);
            int i =  Exam.BLL.tb_WordBLL.GetInstance().Insert(model);
            if (i > 0)
                Response.Write(1);
            else
                Response.Write(2);
        }
        catch (Exception ex)
        {
            Response.Write(2);
        }
    }
    /// <summary>
    /// 删除广告
    /// </summary>
    /// <param name="id"></param>
    public void deleteforums(int id)
    {
        try
        {
            Exam.Entity.tb_ForumsEntity model = Exam.BLL.tb_ForumsBLL.GetInstance().GetAdminSingle(id);
            if (model != null)
            {
                model.Status = 0;
                Exam.BLL.tb_ForumsBLL.GetInstance().Update(model);
                Response.Write(1);
            }
            else
                Response.Write(2);
        }
        catch (Exception ex)
        {
            Response.Write(2);
        }
    }
    public int departmentid
    {
        get
        {
            object obj = Request.Form["departmentid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }
 public string name
    {
        get
        {
            object obj = Request.Form["name"];
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
            object obj = Request.Form["userid"];
            if (obj == null)
            {
                return 0;
            }
            return int.Parse(obj.ToString());
        }
    }

}