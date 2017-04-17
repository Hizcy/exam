<%@ Page Title="首页" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="home_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <img src="../images/choose.jpg" />
    <div style="height:120px ">
            <div style="margin-bottom:20px">
                <div style="float:left;margin-left:10%;">
                    <img src="../images/product.png" style="height:50px;border-radius:50px;margin-top:20px" />
                    <p style="margin-top:20px;font-size:10px">学校信息</p>
                </div>
                <div style="float:left;margin-left:2%;">
                     
                    <p style="font-size:10px">学校名称：<%=schoolname %></p>
                    <p style="font-size:10px">联&nbsp;&nbsp;系&nbsp;&nbsp;人：<%=schoollinkman %></p>
                    <%--<p style="font-size:10px">添加时间：<%=schooltime %></p>--%>
                </div>
            </div>
            <div style="">
                <div style="float:left;margin-left:20%">
                   <img src="../images/person.png" style="height:50px;border-radius:50px;margin-top:20px;margin-left:10px" />
                   <p style="margin-top:20px;font-size:10px">联系人信息</p>
                </div>
                <div style="float:left;margin-left:2%">
                    <p style="font-size:10px">用户名:<%=user %></p>
                    <p style="font-size:10px">姓名：<%=name %></p>
                    <p style="font-size:10px">邮箱：<%=mail %></p>
                    <p style="font-size:10px">手机：<%=phone%></p>
                </div>
           </div>
       
    </div>
        <div id="dizhi" style="margin:10px;text-align:center">
          <b><span>管理员登陆网址：</span> <span><%=yuming %>login.aspx?account=<%=schoolid %></span></b><br />
          <b><span>考生登陆网址：</span> <span><%=yumingks %>login.aspx?account=<%=schoolid %></span></b><br />
          <b><span>移动端考生登陆网址：</span> <span><%=yumingyd %>m_login.aspx?account=<%=schoolid %></span></b><br />
        </div>
       <div class="" style="text-align:center;border-bottom:1px solid #000">    </div>
         <p style="text-align:center;margin-top:20px;font-size:10px">  四川乐创云科技有限公司 版权所有  蜀ICP备15025679号</p>
 <script>
     $(function () {
         var s = "<%=roleid %>";
                  if (parseInt(s) == 1) {
                      $("#dizhi").css("display", "block");
                  }
                  else {
                      $("#dizhi").css("display", "none");

                  }
              })
    </script>
</asp:Content>

