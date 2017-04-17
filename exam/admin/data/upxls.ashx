<%@ WebHandler Language="C#" Class="upxls" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;

public class upxls : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        var path = context.Request.Form["path"];
        var name=path.Substring(path.LastIndexOf('\\'));
        string tmppath = context.Request.PhysicalApplicationPath;
        tmppath += @"usernews\"+name;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        FileStream fs = new FileStream(path, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        sw.WriteLine(path);
        sw.Close();
        fs.Close();
       context.Response.Write("1");
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}