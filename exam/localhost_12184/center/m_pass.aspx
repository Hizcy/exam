<%@ Page Language="C#" AutoEventWireup="true" CodeFile="m_pass.aspx.cs" Inherits="center_m_pass" %>


<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta name="description" content=""/>
<meta name="author" content=""/>
<meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Expires" content="0"/>
<title>修改密码</title>
    <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css"/>
<link rel="stylesheet" type="text/css" href="../css/m_login.css"/>
</head>

<body class="bodyBg_main">
    <form runat="server">
        <div class="navbar navbar-fixed-top navbar-inverse" role="navigation">
          <div class="container">
            <div class="navbar-header">
    	        <img src="../images/logo1.png" width="100" height="40" data-toggle="collapse" data-target=".navbar-collapse" style="margin-top:10px;margin-left:5px">
    	        <div class="nav-left">修改密码</div>
            </div>
            <div class="collapse navbar-collapse">
                  <ul class="nav navbar-nav">
                    <li><a href="../exam/m_ListExam.aspx">评测列表<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../center/m_Center.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>&iddomain=<%=iddomain %>">个人中心<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li class="active"><a href="../center/m_pass.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>">修改密码<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../record/RecordList.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>">考试记录<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                  </ul>
                </div>
          </div>
        </div>

        <div class="container main">
            <div class="box">
                <div class="content list">
                    原始密码：<asp:TextBox ID="txtpass" runat="server" style="width:190px;height:24px" TextMode="Password"></asp:TextBox>
                </div>
                <div class="content list">
                    新的密码：<asp:TextBox ID="txtnewpass" runat="server" style="width:190px;height:24px" TextMode="Password"></asp:TextBox>
                </div>
                <div class="content list">
                    确认密码：<asp:TextBox ID="txtpasswordSafe" runat="server" style="width:190px;height:24px" TextMode="Password"></asp:TextBox>
                </div>
                
            </div>
             <asp:Button ID="btnSave" runat="server" Text="保存" style="width:100%;height:35px;border:0;color:#fff;background-color:#464d77" OnClick="btnSave_Click"/>
        </div>
           <script src="../js/jquery-1.7.2.min.js"></script>
            <script src="../js/bootstrap.min.js"></script>
        </form>
</body>
</html>
