<%@ Page Language="C#" AutoEventWireup="true" CodeFile="m_Center.aspx.cs" Inherits="center_m_Center" %>

<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta name="description" content=""/>
<meta name="author" content=""/>
<meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Expires" content="0"/>
<title>个人中心</title>
    <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css"/>
<link rel="stylesheet" type="text/css" href="../css/m_login.css"/>
</head>

<body class="bodyBg_main">
    <form>
        <div class="navbar navbar-fixed-top navbar-inverse" role="navigation">
          <div class="container">
            <div class="navbar-header">
    	        <img src="../images/logo1.png" width="100" height="40" data-toggle="collapse" data-target=".navbar-collapse" style="margin-top:10px;margin-left:5px">
    	        <div class="nav-left">个人中心</div>
            </div>
            <div class="collapse navbar-collapse">
                  <ul class="nav navbar-nav">
                    <li><a href="../exam/m_ListExam.aspx">评测列表<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li class="active"><a href="../center/m_Center.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>&iddomain=<%=iddomain %>">个人中心<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li ><a href="../center/m_pass.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>">修改密码<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../record/RecordList.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>">考试记录<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                  </ul>
                </div>
          </div>
        </div>

        <div class="container main">
            <div class="box">
                <div class="content list">
                    账号：<%=user %>
                </div>
                <div class="content list">
                    姓名：<%=name %>
                </div>
                <div class="content list">
                    部门：<%=position %>
                </div>
                <div class="content list">
                    性别：<%=sex %>
                </div>
                <div class="content list">
                    手机：<%=phone %>
                </div>
                <div class="content list">
                    邮箱：<%=mail %>
                </div>
                 <div class="content list">
                    班级：<%=description %>
                </div>
            </div>
            <div >

            </div>
             <a href="javascript:void(0);" onclick="logout()" class="btn btn-primary btn-lg btn-block exitBtn">退出登录</a>
        </div>
           <script src="../js/jquery-1.7.2.min.js"></script>
            <script src="../js/bootstrap.min.js"></script>
        <script>
            function logout() {
                if (confirm("您确定退出吗？")) {
                    window.location.href = '<%= Page.ResolveUrl("~/Logout.aspx") %>';
           }

       }
        </script>
        </form>
</body>
</html>
