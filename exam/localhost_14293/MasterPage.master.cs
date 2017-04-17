using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public static string user = "";
    public static string menu = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            UserIdentity identity = this.Page.User.Identity as UserIdentity;
            if (identity != null)
            {
                user = identity.Name + identity._domain;
            }
            menu = GetMenu();
        }
    }
    protected string GetMenu()
    {
        string url = Request.Url.AbsolutePath;
        string[] arr = url.Split('/');

        string menu1 = @"
        <div id=""divshijuan"" class=""span3 setLeft"">
            <div class=""setLeftNav"">
                <ul>  
                    <li class=""{0}"">
                	    <a href=""/Exam/Listexam.aspx"" ><div class=""titleIcon"" ><img src=""../images/exam-2.png""></div>&nbsp;&nbsp;当前评测</a>
                    </li> 
                    <li class=""{1}"">
                        <a href=""/center/Center.aspx""><div class=""titleIcon""><img src=""../images/personal-2.png""/></div>&nbsp;&nbsp;个人中心</a>
                    </li>                  
                </ul>
            </div>
        </div>
        ";
        if (arr[1].ToLower() == "exam")
        {

            if (arr[2].ToLower().IndexOf("listexam") >= 0)
            {
                return string.Format(menu1, "sel", "");
            }
        }
        else if (arr[1].ToLower() == "center")
        {
            if (arr[2].ToLower().IndexOf("center") >= 0)
            {
                return string.Format(menu1, "", "sel");
            }
        }
        return "";

    }
}
