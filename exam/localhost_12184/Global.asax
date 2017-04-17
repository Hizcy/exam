<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
    void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (this.Context.User != null && this.Context.User.Identity.IsAuthenticated)
        {
            FormsIdentity id = (FormsIdentity)this.Context.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket; // 取得身份验证票
            //if (Request.Path.EndsWith(".aspx")) DebugConsole.WriteLine("身份验证提取, UserData: {0}", ticket.UserData);

            try
            {
                UserIdentity user = new UserIdentity(ticket.UserData);
                if (user.IsAuthenticated)
                {
                    this.Context.User = new UserPrincipal(user);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        else
        {
            // 匿名访问
            //UserIdentity user = new UserIdentity("");
            //this.Context.User = new UserPrincipal(user);
        }
    }
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。

    }
       
</script>
