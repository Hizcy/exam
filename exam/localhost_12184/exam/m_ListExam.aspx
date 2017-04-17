<%@ Page Language="C#" AutoEventWireup="true" CodeFile="m_ListExam.aspx.cs" Inherits="exam_m_ListExam" %>
<!DOCTYPE html>
<html><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>

<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta name="description" content=""/>
<meta name="author" content=""/>
<meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Expires" content="0"/>
<title>快去读</title>
    <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="../css/m_login.css"/>
    <link href="../css/home.css" rel="stylesheet" />
    <link href="../css/new.css" rel="stylesheet" />

<%--<style>
   .searchInput{width:60%}
</style>--%>
</head>

<body class="bodyBg_main">
    <form id="form1" runat="server">
        <div class="navbar navbar-fixed-top navbar-inverse" role="navigation">
          <div class="container">
            <div class="navbar-header">
    	        <img src="../images/logo1.png" width="100" height="40" data-toggle="collapse" data-target=".navbar-collapse" style="margin-top:10px;margin-left:5px">
    	        <div class="nav-left">评测列表</div>
            </div>
            <div class="collapse navbar-collapse">
                  <ul class="nav navbar-nav">
                    <li class="active"><a href="../exam/m_ListExam.aspx">评测列表<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../center/m_Center.html?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idname %>&iddomain=<%=iddomain %>">个人中心<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../center/m_pass.html?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idname %>&iddomain=<%=iddomain %>">修改密码<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../record/RecordList.html?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idname %>&iddomain=<%=iddomain %>">考试统计<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                  </ul>
                </div>
          </div>
        </div>

        <div class="container main">
            <div class="navSearch" style="margin-bottom:5px">

                <asp:DropDownList ID="dllLevel" CssClass="form-control searchInput" style="width:100%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dllLevel_SelectedIndexChanged"></asp:DropDownList> 
    	        
                <%--<asp:Button ID="btnsele" runat="server" Text="查询" class="btn btn-default" style="text-align:right" OnClick="btnsele_Click"/>
                <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search"></span></button>--%>
            </div>
 
    
        
            <asp:Repeater runat="server" ID="rptlist">
                <ItemTemplate>
                    <div class="box">
                        <div class="title">
                            <div class="title-text titleIcon1 "><%#Eval("name") %></div>
                    
                                <div class="title-btn">
                                    <a href="../forum/Forum.html?clsid=<%#Eval("ExampaperClsId") %>&UserId=<%=UserId %>" class="btn btn-primary  btn-xs btn-pass">感悟交流</a>&nbsp;
                                    <a href="m_Answer.html?id=<%#Eval("ExampaperId") %>&UserId=<%=UserId %>&schoolid=<%=schoolId %>&clsid=<%#Eval("ExampaperClsId") %>&school=<%=school %>" class="btn btn-primary  btn-xs btn-pass" role="button"><%#GetResult(int.Parse(Eval("ExampaperId").ToString())) %>评测</a></div>
                                <div class="content" style="padding-bottom: 10px; line-height: 22px;display:block">
                                    评测时长：<%#Eval("Duration") %>分钟
                                </div>
                    
                        </div> 
                    </div>
                </ItemTemplate>
            </asp:Repeater>
         </div>
                   <%-- <div class="box">
                        <div class="title">
                            <div class="title-text titleIcon1">测试填空</div>
                    
                                <div class="title-btn"><a href="m_Answer.aspx" class="btn btn-primary  btn-xs btn-pass" role="button">参加</a></div>
                            <div class="content" style="padding-bottom:10px;line-height: 22px;">
                               
                                <br/>
                                考试时长：60分钟
                            </div>
                    
                        </div>
                    </div>--%>
     
            <!--吸低 子菜单 -->

     <div class="js-navmenu js-footer-auto-ele shop-nav nav-menu nav-menu-1 has-menu-3">
            <div id="wrapper">
                <div class="first">
                <dl id="ticker-1">
                    <asp:Repeater runat="server" ID="rptad">
                        <ItemTemplate>
                             <dt>走</dt>
                            <dd><a href="<%#Eval("AdLink") %>" target="_blank"><%#Eval("AdContent") %></a> </dd>
                        </ItemTemplate>
                    </asp:Repeater>
                </dl>
                </div>
            </div>
   <%--     <div class="nav-item">
            <a class="mainmenu js-mainmenu" href="http://ts.kuaiqudu.cn/?school=<%=domain %>">
                    <span class="mainmenu-txt">进入书城</span>
                  
            </a>
        </div>--%>
     </div>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            window.scrollTo(0, 1);
            $(".box .title").click(function (e) {
                $(this).find(".title-text").toggleClass("titleIcon2");
                $(this).find(".content").toggle();
            });
        });
    </script>
    <script src="../js/com.js"></script>
    <script src="../js/run.js"></script>
</form>
   
</body>
</html>