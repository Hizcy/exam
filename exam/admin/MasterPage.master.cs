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
    public static string first = "";
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
            first = GetFirst();
        }
    }
    protected string GetFirst()
    { 
      
        string url = Request.Url.AbsolutePath;
        string[] arr = url.Split('/');

        string role1 = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("role1");        
        string role2 = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("role2");        
        string role4 = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("role4");        
        string role5 = Jnwf.Utils.Config.ConfigurationUtil.GetAppSettingValue("role5");        
        UserIdentity identity = this.Page.User.Identity as UserIdentity;
        //if (identity == null)
            
        if (identity.RoleID == 4)
        {
            if (role4.ToLower().IndexOf("," + arr[2].ToLower() + ",") < 0)
            {
                Response.Redirect("../login.aspx");
            }
        }
        else if (identity.RoleID == 5)
        {
            if (role5.ToLower().IndexOf("," + arr[2].ToLower() + ",") < 0)
            {
                Response.Redirect("../login.aspx");
            }
        }
        else if (identity.RoleID == 1)
        {
            if (role1.ToLower().IndexOf("," + arr[2].ToLower() + ",") < 0)
            {
                Response.Redirect("../login.aspx");
            }
        }
        else if (identity.RoleID == 2)
        {
            if (role2.ToLower().IndexOf("," + arr[2].ToLower() + ",") < 0)
            {
                Response.Redirect("../login.aspx");
            }
        }
        string menu = "";
        //超级管理员一级菜单权限
       if (identity._roleID == 4)
        {
            menu = @"
        <div class=""navbarCustomer"">
            <ul>
              <li ><a href=""/home/home.aspx""><p id=""home"" style=""{2}"">首页</p></a></li>
              <li ><a href=""/user/listreview.aspx""><p id=""name"" style=""{0}"">用户管理</p></a></li>
              <li ><a href=""/exam/listlibrary.aspx""><p  id=""shijuan"" style=""{1}"">题库管理</p></a></li>
              <li ><a href=""/count/count.aspx""><p  id=""tongji"" style=""{3}"">统计分析</p></a></li>       
            </ul>
        </div>
        ";
        }
        //教师权限一级菜单
        else if (identity._roleID == 2)
        {
            menu = @" 
        <div class=""navbarCustomer"">
            <ul>
              <li ><a href=""/home/home.aspx""><p id=""home"" style=""{2}"">首页</p></a></li>
              <li ><a href=""/user/listname.aspx""><p id=""name"" style=""{0}"">用户管理</p></a></li>
              <li ><a href=""/count/count.aspx""><p  id=""tongji"" style=""{3}"">统计分析</p></a></li>       
            </ul>
        </div>
        ";
        } 
        //管理员一级菜单权限
        else if (identity._roleID == 1)
        {
            menu = @"
        <div class=""navbarCustomer"">
            <ul>
              <li ><a href=""/home/home.aspx""><p id=""home"" style=""{2}"">首页</p></a></li>
              <li ><a href=""/user/listname.aspx""><p id=""name"" style=""{0}"">用户管理</p></a></li>
              <li ><a href=""/exam/canreadbooklist.aspx""><p  id=""shijuan"" style=""{1}"">题库管理</p></a></li>
              <li ><a href=""/count/count.aspx""><p  id=""tongji"" style=""{3}"">统计分析</p></a></li>       
            </ul>
        </div>
        ";
        }
        //代理商
        else if (identity._roleID == 5) 
        {
          menu = @"
        <div class=""navbarCustomer"">

            <ul>
             <li ><a href=""/home/home.aspx""><p id=""home"" style=""{2}"">首页</p></a></li>
             <li ><a href=""/user/AddSchool.aspx""><p id=""name"" style=""{0}"">用户管理</p></a></li>
            </ul>
        </div>
        ";
        }
        if (arr[1].ToLower() == "home")
        {
            return string.Format(menu, "", "", "color:#EA945A;border-top:5px #717171 solid;text-align:center;margin-top: -5px;","");
        }
        else if (arr[1].ToLower() == "user")
        {
            return string.Format(menu, "color:#EA945A;border-top:5px #717171 solid;text-align:center;margin-top: -5px;", "", "","","");
        }
        else if (arr[1].ToLower() == "exam")
        {
            return string.Format(menu, "", "color:#EA945A;border-top:5px #717171 solid;text-align:center;margin-top: -5px;", "","");
        }
        else if (arr[1].ToLower() == "count")
        {
            return string.Format(menu, "", "","","color:#EA945A;border-top:5px #717171 solid;text-align:center;margin-top: -5px;");
        }
        return "";
    }
    protected string GetMenu()
    {
        string url = Request.Url.AbsolutePath;
        string[] arr = url.Split('/');
        UserIdentity identity = this.Page.User.Identity as UserIdentity;
        string menu1 = "";
        //用户管理超级管理员
        if (identity._roleID == 4)
        {
            menu1 = @"
                    <div id=""divname"" class=""span3 setLeft"">
                          <div class=""setLeftNav""> 
                              <ul>    
                                 <li class=""{0}"">
                                      <a href=""/user/AddSchool.aspx""><div class=""titleIcon""><img src=""../images/add-user-2.png"" /></div>&nbsp;&nbsp;添加学校</a>
                                  </li>
                                  <li class=""{1}"">
                                      <a href=""/user/ListSchool.aspx""><div class=""titleIcon""><img src=""../images/school-m-2.png"" /></div>&nbsp;&nbsp;学校管理</a>
                                  </li>      
                                  <li class=""{2}"">
                                      <a href=""/user/AddAgent.aspx""><div class=""titleIcon""><img src=""../images/moreusers-2.png"" /></div>&nbsp;&nbsp;添加代理商</a>
                                  </li>
                                  <li class=""{3}"">
                                      <a href=""/user/ListAgent.aspx""><div class=""titleIcon""><img src=""../images/user-lib-2.png"" /></div>&nbsp;&nbsp;代理商管理</a>
                                  </li>
                                  <li class=""{4}"">
                                      <a href=""/user/ListReview.aspx""><div class=""titleIcon""><img src=""../images/shenhe-2.png"" /></div>&nbsp;&nbsp;审核管理</a>
                                  </li>
                                   <li class=""{5}"">
                                      <a href=""/user/adlist.aspx""><div class=""titleIcon""><img src=""../images/critic_set.png"" /></div>&nbsp;&nbsp;广告设置</a>
                                  </li>
                                   <li class=""{6}"">
                                      <a href=""/user/forumslist.aspx""><div class=""titleIcon""><img src=""../images/ads_set.png"" /></div>&nbsp;&nbsp;评论设置</a>
                                  </li>
                                   <li class=""{7}"">
                                      <a href=""/user/wordlist.aspx""><div class=""titleIcon""><img src=""../images/sensitive_set.png"" /></div>&nbsp;&nbsp;敏感词设置</a>
                                  </li>
                            </ul>
                        </div>
                    </div>  
                    ";
        }

        //用户管理老师
        else if (identity._roleID == 2)
        {
                 menu1 = @"
                    <div id=""divname"" class=""span3 setLeft"">
                          <div class=""setLeftNav""> 
                              <ul>          
                                  <li class=""{2}"">
                                      <a href=""/user/listname.aspx""><div class=""titleIcon""><img src=""../images/user-lib-2.png"" /></div>&nbsp;&nbsp;用户列表</a>
                                  </li>
                            </ul>
                        </div>
                    </div>  
                    ";
        }
        //用户管理员
        else if (identity._roleID == 1)
        {
            menu1 = @"
                    <div id=""divname"" class=""span3 setLeft"">
                          <div class=""setLeftNav""> 
                              <ul>          
                                  <li class=""{0}""  >
                                      <a href=""/user/addname.aspx""><div class=""titleIcon"" ><img src=""../images/add-user-2.png"" /></div>&nbsp;&nbsp;添加用户</a>
                                  </li>
                                  <li class=""{1}"">
                                      <a href=""/user/importname.aspx""><div class=""titleIcon""><img src=""../images/moreusers-2.png"" /></div>&nbsp;&nbsp;批量导入用户</a>
                                  </li>
                                  <li class=""{2}"">
                                      <a href=""/user/listname.aspx""><div class=""titleIcon""><img src=""../images/user-lib-2.png"" /></div>&nbsp;&nbsp;用户列表</a>
                                  </li>
                                  <li class=""leftTitle"">
                                      <a href=""#""><div class=""titleIcon""><img src=""../images/deploy-2.png""/></div>&nbsp;&nbsp;配置管理<div class=""titleArrow""></a>
                                  </li>   
                              
                                <li class=""leftLink {3}""><a href=""/user/ClassDpy.aspx"">&nbsp;&nbsp;班级配置</a></li>  
                                <li class=""leftLink {4}""><a href=""/user/Tchauthoy.aspx"">&nbsp;&nbsp;教师权限</a></li>  
                                <li class=""leftLink {5}""><a href=""/user/adlist.aspx"">&nbsp;&nbsp;广告设置</a></li>
                                <li class=""leftLink {6}""><a href=""/user/forumslist.aspx"">&nbsp;&nbsp;评论设置</a></li>      
                            </ul>
                        </div>
                    </div>  
                    ";
        }
            //代理商
         else if (identity._roleID == 5)
        {
            menu1 = @"
                    <div id=""divname"" class=""span3 setLeft"">
                          <div class=""setLeftNav""> 
                              <ul>  
                                  <li class=""{0}"">
                                      <a href=""/user/AddSchool.aspx""><div class=""titleIcon""><img src=""../images/add-user-2.png"" /></div>&nbsp;&nbsp;添加学校</a>
                                  </li>
                                  <li class=""{1}"">
                                      <a href=""/user/ListSchool.aspx""><div class=""titleIcon""><img src=""../images/school-m-2.png"" /></div>&nbsp;&nbsp;学校管理</a>
                                  </li>
                                  <li class=""{5}"">
                                      <a href=""/user/adlist.aspx""><div class=""titleIcon""><img src=""../images/critic_set.png"" /></div>&nbsp;&nbsp;广告设置</a>
                                  </li>
                                  <li class=""{6}"">
                                      <a href=""/user/forumslist.aspx""><div class=""titleIcon""><img src=""../images/ads_set.png"" /></div>&nbsp;&nbsp;评论设置</a>
                                  </li>           
                              </ul>
                        </div>
                    </div>  
                    ";
        }        

        string menu2 = "";
        //题库管理超级管理员
        if (identity._roleID == 4)
        {
            menu2 = @"
            <div id=""divshijuan"" class=""span3 setLeft"">
                <div class=""setLeftNav"">
                    <ul>
              	        <li class=""leftTitle"">
                	        <a href=""#""><div class=""titleIcon""><img src=""../images/exam-2.png""></div>&nbsp;&nbsp;题库信息<div class=""titleArrow""></div></a>
                        </li>
                        <li class=""leftLink {0}""><a href=""/Exam/Addtestqm.aspx"">&nbsp;&nbsp;录入试题</a></li>
                        <li class=""leftLink {1}""><a href=""/Exam/Formed.aspx"">&nbsp;&nbsp;检测设置</a></li>
                         
                        <li class=""{2}"">
                	        <a href=""/Exam/ListLibrary.aspx""><div class=""titleIcon""><img src=""../images/que-back-2.png""></div>&nbsp;&nbsp;题库管理</a>
                        </li>
                        <li class=""{3}"">
                	        <a href=""/Exam/ListTest.aspx""><div class=""titleIcon""><img src=""../images/paper-m-2.png""></div>&nbsp;&nbsp;检测管理</a>
                        </li>
                        <li class=""{4}"">
                            <a href=""/Exam/AddRankManage.aspx""><div class=""titleIcon""><img src=""../images/deploy-2.png""/></div>&nbsp;&nbsp;配置管理</a>
                        </li>         
                    </ul>
                </div>
            </div>
            ";
        }
        //题库管理老师
        else if (identity._roleID == 1)
        {
            menu2 = @"
            <div id=""divshijuan"" class=""span3 setLeft"">
                <div class=""setLeftNav"">
                    <ul>
                        <li class=""{4}"">
                            <a href=""/Exam/CanReadBookList.aspx""><div class=""titleIcon""><img src=""../images/deploy-2.png""/></div>&nbsp;&nbsp;配置管理</a>
                        </li>                  
                    </ul>
                </div>
            </div>
            ";
        }
        string menu3 = @"
        <div id=""divname"" class=""span3 setLeft"">
              <div class=""setLeftNav"">
                  <ul>          
                      <li class=""{0}""  >
                          <a href=""/count/Count.aspx""><div class=""titleIcon"" ><img src=""../images/analysis-e-2.png"" /></div>&nbsp;&nbsp;分析人员成绩</a>
                      </li>
                     
                </ul>
            </div>
        </div>  
        ";
    
        if (arr[1].ToLower() == "user")
        {
            if (arr[2].ToLower().IndexOf("addname") >= 0)
            {
                return string.Format(menu1, "sel", "", "", "", "", "","","");
            }
            else if (arr[2].ToLower().IndexOf("importname") >= 0)
            {
                return string.Format(menu1, "", "sel", "", "", "", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("listname") >= 0)
            {
                return string.Format(menu1, "", "", "sel", "", "", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("listreview") >= 0)
            {
                return string.Format(menu1, "", "", "", "", "sel", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("classdpy") >= 0)
            {
                return string.Format(menu1, "", "", "", "sel", "", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("tchauthoy") >= 0)
            {
                return string.Format(menu1, "", "", "", "", "sel", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("addschool") >= 0)
            {
                return string.Format(menu1, "sel", "", "", "", "", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("listschool") >= 0)
            {
                return string.Format(menu1, "", "sel", "", "", "", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("addagent") >= 0)
            {
                return string.Format(menu1, "", "", "sel", "", "", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("listagent") >= 0)
            {
                return string.Format(menu1, "", "", "", "sel", "", "", "", "");
            }
            else if (arr[2].ToLower().IndexOf("adlist") >= 0)
            {
                return string.Format(menu1, "", "", "", "", "", "sel", "", "");
            }
            else if (arr[2].ToLower().IndexOf("forumslist") >= 0)
            {
                return string.Format(menu1, "", "", "", "", "", "", "sel", "");
            }
            else if (arr[2].ToLower().IndexOf("wordlist") >= 0)
            {
                return string.Format(menu1, "", "", "", "", "", "", "", "sel");
            }
          
        }
        else if (arr[1].ToLower() == "exam")
        {
            if (arr[2].ToLower().IndexOf("addtestqm") >= 0)
            {
                return string.Format(menu2, "sel", "", "", "", "","");
            }
            else if (arr[2].ToLower().IndexOf("formed") >= 0)
            {
                return string.Format(menu2, "", "sel", "", "", "","");
            }
            else if (arr[2].ToLower().IndexOf("listlibrary") >= 0)
            {
                return string.Format(menu2, "", "", "sel", "", "","");
            }
            else if (arr[2].ToLower().IndexOf("listtest") >= 0)
            {
                return string.Format(menu2, "", "", "", "sel", "","");
            }
            else if (arr[2].ToLower().IndexOf("addrankmanage") >= 0)
            {
                return string.Format(menu2, "", "", "", "", "sel","");
            }
            else if (arr[2].ToLower().IndexOf("canreadbooklist") >= 0)
            {
                return string.Format(menu2, "", "", "", "", "sel","");
            }
        }
        else if (arr[1].ToLower() == "count")
        {
            if (arr[2].ToLower().IndexOf("count") >= 0)
            {
                return string.Format(menu3, "sel","");
            }
            else if (arr[2].ToLower().IndexOf("personnel") >= 0)
            {
                return string.Format(menu3, "","sel");
            }
        }
        return "";

    }
}
