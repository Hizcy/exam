<%@ Page Language="C#" AutoEventWireup="true" CodeFile="m_login.aspx.cs" Inherits="m_login" %>

<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0 user-scalable=no" />
<meta http-equiv="cache-control" content="no-cache"/>
<meta http-equiv="pragma" content="no-cache"/>
<meta http-equiv="expires" content="-1"/>
<meta name="description" content=""/>
<meta name="author" content=""/>
<title>登录</title>
<link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css"/>
<link rel="stylesheet" type="text/css" href="../css/m_login.css"/>
<link href="css/home.css" rel="stylesheet" />
</head> 

<body class="bodyBg">
<div class="container">

  <form runat="server" method="post" class="form-signin" name="form_wm">
      <table style="width:100%">
          <tr>
              <td ><img src="images/logo.png" style="width:120px;height:50px"/></td> 
              <td style="float:right;"> 
                  <%if(schoolid ==0){ %>
                  <p style="opacity: 0.2;"><b  style="float:right;">User Login</b></p>
               <%}else{ %>
                  <p style="opacity: 0.2;"><b  style="float:right;">User Login</b></p>
                 <p><b style="font-size:14px;font-family:SimHei;float:right"><%=school %></b></p>
                  <%} %>
              </td>
          </tr>
      </table>
      <div style="background-color: #FFF;border: #c3c3c3 1px solid;border-radius:20px">
        <%-- 没有Id的登陆界面 --%>
        <%if(schoolid ==0){ %>
            <asp:TextBox ID="txtUserName" runat="server" Height="40" style="margin-top:16px;padding:10px;" placeholder="请输入用户名"></asp:TextBox><hr />
        <%}else{ %>
        <%-- 有学生Id的登陆界面 --%>
            <asp:TextBox ID="txtUserNamey" runat="server"  Height="40" style="margin-top:16px;padding:10px;" placeholder="请输入用户名"></asp:TextBox>
            <span ><%=domain %></span>
          <hr />
        <%} %>
        <span class="domainText_user"></span>
        <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" TextMode="Password"  placeholder="请输入密码"></asp:TextBox>
          </div>
        <asp:Button ID="btn_dl" runat="server" class="btn btn-lg btn-primary btn-block" style="margin-top:20px;" OnClick="Button1_Click" Text="立即登录" />

        <div style="margin-top:50px">
               <%if(schoolid ==0){ %>
               <%}else{ %>
               <div style="width:100%">
                    <a  href="http://ts.kuaiqudu.cn/?school=<%=domain1 %>">
                       <span style="margin:10px">
                           <img src="images/buy_btn.png" style="width:40%;height:40px;margin-left:10px" />
                       </span>
                    </a>
                    <a  href="BookList.html">
                       <span style="margin:10px">
                           <img src="images/catalogue_btn.png" style="width:40%;height:40px"/>
                       </span>
                    </a>
               </div>
            <div style="text-align:center"><img src="images/bottom.png" style="margin-top:20px;width:160px;height:15px"/></div>
                <%} %>
        </div>
        <div class="js-navmenu js-footer-auto-ele shop-nav nav-menu nav-menu-1 has-menu-3">
            <div class="nav-item">
                <a class="mainmenu js-mainmenu" href="http://ts.kuaiqudu.cn/">
                        <span class="mainmenu-txt">进入书城</span>
                </a>
            </div>
        </div>
  </form>

</div>
</body>
</html>
