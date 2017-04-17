<%@ WebHandler Language="C#" Class="getquestion" %>

using System;
using System.Web;

public class getquestion : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (index == 0 || clsid == 0)
        {
            context.Response.Write("{\"msg\":\"False\",\"release_info\":\"参数错误\",\"is_pass\":\"\"}");
        }
        else
        {
            try
            {
                int userid =int.Parse(context.Request.Form["userid"].ToString());
                if (userid != 0)
                {
                    string path = context.Server.MapPath(Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("userpath")) + "/exam-" + userid + "-" + clsid + "-dict.txt";
                    if (!System.IO.File.Exists(path))
                    {
                        context.Response.Write("{\"msg\":\"False\",\"release_info\":\"获取不到试题\",\"is_pass\":\"\"}");
                    }
                    else
                    {
                        string data = Jnwf.Utils.Helper.FileHelper.GetFileContent(path);
                        System.Collections.Generic.Dictionary<int, string> dict = Jnwf.Utils.Json.JsonHelper.DeserializeJson<System.Collections.Generic.Dictionary<int, string>>(data);

                        if (dict != null)
                        {
                            string temp = dict[index];

                            
                            context.Response.Write("{\"msg\":\"True\",\"release_info\":\"" + context.Server.HtmlEncode(temp) + "\",\"is_pass\":\"\"}");
                            
                            
                        }
                        else
                            context.Response.Write("{\"msg\":\"False\",\"release_info\":\"获取不到试题\",\"is_pass\":\"\"}");
                    }
                }
            }
            catch(Exception ex)
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
    public int index
    {
        get
        {
            object obj = HttpContext.Current.Request.Form["index"];
            if (obj == null)
                return 0;
            return int.Parse(obj.ToString());
        }
    }

}