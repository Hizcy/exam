﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
    <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <title>登录</title>
        <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
    <link href="../css/login1.css" rel="stylesheet" type="text/css">
    <script src="js/jquery-1.7.2.min.js"></script>
</head>
<body>
    <form runat="server">
    <div class="login_page">
        <div class="loginpage_top">
            <div class="logo">
                <img src="../images/logo.png" alt="">
            </div>
        </div>
        <div class="content" >


            <%--<div class="login">
                <div class="login_top">
                    </div>
                <div class="login_con">
                    <div class="conbox">
                        <div class="policy_tips" id="errorMsgDiv" style="display: none;">
                            <div id="errorMsg">
                            </div>
                        </div>
                        <ul>--%>
            <%-- 没有Id的登陆界面 --%>
                <%-- <%if(schoolid ==0){ %>
            <li id="schoolid"  >
                    <label>账号</label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="inputtext color9" placeholder="请输入用户名"></asp:TextBox>
            </li>
                <%}else{ %>--%>
            <%-- 有学生Id的登陆界面 --%>
            <%--  <li id  ="schoolidy" >
                                  <label>账号</label>
                                  <asp:TextBox ID="txtUserNamey" runat="server" CssClass="inputtexty color9" placeholder="请输入用户名"></asp:TextBox>
                                  <span ><%=domain %></span>
                            </li>
                              <%} %>
                            <li>
                                 <label>密码</label>
                                 <asp:TextBox ID="txtPwd" runat="server" CssClass="inputtext color9" TextMode="Password"  placeholder="请输入密码"></asp:TextBox>	
                            </li>
                            
                            <li>
                                <div class="slideThree">
                 	                <asp:CheckBox ID="slideThree" runat="server"  />			 
			                        <label for="slideThree"> </label>                                   
		                        </div>                                 
                                <div  class="divdengl">
                                <a href="#" ><span style="">记住密码</span></a>
                                <asp:Button ID="Button1" CssClass="denglu" style="cursor:pointer;"  runat="server"  Text="登录" OnClick="Button1_Click" />
                                </div> 
                          </li>                       
                        </ul>                    
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>--%>

            <div style="width:400px;margin-top:170px;margin-left:500px">
                <div>
                    <img src="images/kqd.jpg" style="width:108px;height:108px;margin:0px 44px;line-height:108px" alt="" /><img src="images/kquapp.png" style="width:108px;height:108px;margin:0px 44px;line-height:108px" alt="" />
                </div>
                <div >
                    <span style="margin:10px 55px;font-size:16px;">微信公共号</span><span style="font-size:16px;margin-left: 48px;">APP客户端下载</span>
                </div>
            </div>
        </div>
        <div class="loginpage_footer">
            
          Copyright © 2004-2015 EP Inc, All Rights Reserved. 四川乐创云科技有限公司 版权所有
        </div>
    </div>
       
</form>
</body></html>


