<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
    <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <title>注册</title>
        <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
    <link href="../css/register.css" rel="stylesheet" type="text/css">
    <script src="js/jquery-1.7.2.min.js"></script>
      
</head>
<body class="bg-blue login-body">
    <form runat="server">
    <div class="login_page">
        <div class="loginpage_top">
         
          <%--  <div class="rightbox">
  
                <a href="#" style="font-size:14px"><span  style="background-color:#0094ff;border-radius:10px;width:60px;height:20px;color:#fff">登录</span></a>
            </div>--%>
        </div>
        <div class="content">
            <div style="text-align:center">
               <span style="color:#fff;font-size:30px">轻松注册</span>
                <span style="color:#fff;font-size:48px"><b>快去读</b></span>
                <span style="color:#fff;font-size:30px">开启你的</span><br />
                <p style="color:#fff;font-size:30px;margin-top:24px"><b>专属考试旅程</b></p>
            </div>
         <div class="login">
            
                <div class="login_con">
                         <div class="conbox">
                        <div class="policy_tips" id="errorMsgDiv" style="display: none;">
                            <div id="errorMsg">
                            </div>
                        </div>
                        <ul>
                            <li style="color:#707070"><b>产品信息</b></li>
                            <li>
                                   <label style="color:#707070">域名：</label>  
                        <asp:TextBox ID="txtyuming" runat="server" CssClass="inputtextym color9" style="color:#707070" BorderColor="#bfbfbf"></asp:TextBox>
                       <asp:DropDownList ID="ddldomain" runat="server" placeholder="将作为账号后缀" CssClass="inputtextymlb color9"  BorderColor="#bfbfbf" >
                            <asp:ListItem Value=".com">.com</asp:ListItem>
                            <asp:ListItem Value=".cn">.cn</asp:ListItem>
                            <asp:ListItem Value=".net">.net</asp:ListItem>
                            <asp:ListItem Value=".org">.org</asp:ListItem>
                            <asp:ListItem Value=".so">.so</asp:ListItem>
                            <asp:ListItem Value=".com.cn">.com.cn</asp:ListItem>
                            <asp:ListItem Value=".gov.cn">.gov.cn</asp:ListItem>
                            <asp:ListItem Value=".edu.cn">.edu.cn</asp:ListItem>
                            <asp:ListItem Value=".co">.co</asp:ListItem>
                            <asp:ListItem Value=".me">.me</asp:ListItem>
                        </asp:DropDownList>
                            </li>
                            <li>
                                 <label style="color:#707070">学校：</label>
                                 <asp:TextBox ID="txtname" runat="server" CssClass="inputtext color9" style="color:#707070" BorderColor="#bfbfbf" ></asp:TextBox>	
                            </li>
                             <li>
                                  <label style="color:#707070">地区：</label>
                                    <select id="ddlprovince" runat="server" style="width:80px;height:24px" ></select>
                                    <select id="ddlcity" runat="server" style="width:80px;height:24px" >
                                        <option value="0">市</option>
                                    </select>
                                    <select id="ddleurozone" runat="server" style="width:80px;height:24px" >
                                        <option value="0">县/区</option>
                                    </select>
                               <%--  <label style="color:#707070">地区：</label>
                                 <asp:DropDownList ID="ddlprovince" runat="server"  CssClass="inputtextymlb color9"   BorderColor="#bfbfbf" AutoPostBack="True" OnSelectedIndexChanged="ddlprovince_SelectedIndexChanged">
                                    
                        </asp:DropDownList>	
                          
                                 <asp:DropDownList ID="ddlcity" runat="server" CssClass="inputtextymlb color9"   BorderColor="#bfbfbf" AutoPostBack="True" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged">
                                    <asp:ListItem Value="0">市</asp:ListItem>
                                     
                        </asp:DropDownList>	
                           
                                 <asp:DropDownList ID="ddleurozone" runat="server"  CssClass="inputtextymlb color9"  BorderColor="#bfbfbf" >
                                     <asp:ListItem Value="0" >县/区</asp:ListItem>
                                     
                        </asp:DropDownList>	--%>
                            </li>

                            

                            <li style="color:#707070"><b>用户信息</b></li>
                             <li>
                                 <label style="color:#707070">姓名：</label>
                                 <asp:TextBox ID="txtrealname" runat="server" CssClass="inputtext color9" style="color:#707070" BorderColor="#bfbfbf"></asp:TextBox>	
                            </li>
                            <li>
                                 <div class="ss">
                        <span  style="color:#707070">性别：</span>                  
                        <asp:RadioButton ID="male" runat="server"  GroupName="sex" style="margin-left:18px;width:30px" Width="50px"  /><span style="margin-left:20px;color:#707070">男</span>
                        <asp:RadioButton ID="female"  GroupName="sex" runat="server" style="margin-left:30px"/><span style="margin-left:20px;color:#707070">女</span>
                    </div>
                            </li>
                             <li>
                                 <label style="color:#707070">电话：</label>
                                 <asp:TextBox ID="txtphone" runat="server" CssClass="inputtext color9" style="color:#707070" BorderColor="#bfbfbf" ></asp:TextBox>	
                            </li>
                             <li>
                                 <label style="color:#707070">邮箱：</label>
                                 <asp:TextBox ID="txtmail" runat="server" CssClass="inputtext color9" style="color:#707070" BorderColor="#bfbfbf"></asp:TextBox>	
                            </li>
                            
                            <li>                              
                                <div  class="divdengl">
                                <asp:Button ID="tbnSave" CssClass="zhuce" runat="server" Text="立即注册" OnClick="btnSave_Click"  />
                                <asp:Button ID="Button1" CssClass="denglu" runat="server" Text="登    录" OnClientClick="go()"  />
                                </div> 
                          </li>                       
                        </ul>                    
                        <div class="clear">
                        </div>
                    </div>
            
                </div>
                </div>
            </div>
        </div>
        <div class="loginpage_footer" style="font-size:12px">
          Copyright © 2004-2015 EP Inc, All Rights Reserved. 济南微丰信息技术有限公司 版权所有
        </div>
        
    <asp:TextBox ID="selectcity" runat="server" OnLoad="selectcity_Load" style="display:none"></asp:TextBox>
    <asp:TextBox ID="selecteurozone" runat="server" OnLoad="selectcity_Load" style="display:none"></asp:TextBox>
</form>
    <script type="text/javascript">
        function go() {
            window.location.href = "login.aspx";
            event.returnValue = false;
        }
        $("#<%=ddlcity.ClientID %>").change(function () {
            var id = $(this).val();
            $.ajax({
                url: '../Data/data.aspx',
                type: 'POST',
                data: {
                    type: "select",
                    locationid: id,
                    tmp: 0
                },
                success: function (result) {
                    $("#<%=ddleurozone.ClientID %>").html(result);
                    //放置id
                    var eurozoneid = $("#<%=ddleurozone.ClientID %>").val();
                    $("#<%=selecteurozone.ClientID %>").val(eurozoneid);
                }
            })
         })
        $("#<%=ddlprovince.ClientID %>").bind("change", function () {
            var id = $(this).val();
            $.ajax({
                url: '../Data/data.aspx',
                type: 'POST',
                data: {
                    type: "select",
                    locationid: id,
                    tmp: 0
                },
                success: function (result) {
                    if (result != "") {
                        $("#<%=ddlcity.ClientID %>").html(result);
                        //隐藏文本框放id
                        var cityid = $("#<%=ddlcity.ClientID %>").val();
                        $("#<%=selectcity.ClientID %>").val(cityid);
                        var tid = $("#<%=ddlcity.ClientID %>").select().val();
                        if (tid != "") {
                            $.ajax({
                                url: '../Data/data.aspx',
                                type: 'POST',
                                data: {
                                    type: "select",
                                    locationid: tid,
                                    tmp: 1
                                },
                                success: function (result) {
                                    $("#<%=ddleurozone.ClientID %>").html(result);
                                    var eurozoneid = $("#<%=ddleurozone.ClientID %>").val();
                                    $("#<%=selecteurozone.ClientID %>").val(eurozoneid);
                                }
                            })
                        }
                    }
                }
            });
        });
        $("#<%=ddlcity.ClientID %>").change(function () {
            var cityid = $(this).val();
            $("#<%=selectcity.ClientID  %>").val(cityid);
        })
        $("#<%=ddleurozone.ClientID %>").change(function () {
            var eurozoneid = $(this).val();
            $("#<%=selecteurozone.ClientID %>").val(eurozoneid);
        })
    </script>
</body></html>