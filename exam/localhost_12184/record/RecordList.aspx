<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecordList.aspx.cs" Inherits="record_RecordList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta name="description" content=""/>
<meta name="author" content=""/>
<meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Expires" content="0"/>
    <title>考试记录</title>
<link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
<link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css"/>
<link rel="stylesheet" type="text/css" href="../css/m_login.css"/>
</head>
<body class="bodyBg_main">
    <form id="form1" runat="server">
      <div class="navbar navbar-fixed-top navbar-inverse" role="navigation">
          <div class="container">
            <div class="navbar-header">
    	        <img src="../images/logo1.png" width="100" height="40" data-toggle="collapse" data-target=".navbar-collapse" style="margin-top:10px;margin-left:5px">
    	        <div class="nav-left">考试记录</div>
            </div>
            <div class="collapse navbar-collapse">
                  <ul class="nav navbar-nav">
                    <li><a href="../exam/m_ListExam.aspx">评测列表<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../center/m_Center.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>&iddomain=<%=iddomain %>">个人中心<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li><a href="../center/m_pass.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>">修改密码<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                    <li class="active"><a href="../record/RecordList.aspx?userid=<%=UserId %>&schoolid=<%=schoolId %>&idname=<%=idName %>">考试记录<span class="glyphicon glyphicon-chevron-right"><img src="../images/arrow.png" /></span></a></li>
                  </ul>
                </div>
          </div>
        </div>
        <div class="container main">
            <table style="width:100%;text-align:center">
                <tr>
                    <td style="width:30%;height:30px;font-size:16px">名字</td>
                    <td style="width:50%;height:30px;font-size:16px">书名</td>
                    <td style="width:20%;height:30px;font-size:16px">分数</td>
                </tr>
                <asp:Repeater runat="server" ID="rptrecord">
                    <ItemTemplate>
                         <tr style="border-bottom:1px solid #ff6a00">
                            <td style="height:30px;font-size:16px;"><%#Eval("RealName") %></td>
                            <td style="height:30px;font-size:16px;"><%#Eval("name") %></td>
                            <td style="height:30px;font-size:16px;"><%#Eval("Point") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <script src="../js/jquery-1.7.2.min.js"></script>
            <script src="../js/bootstrap.min.js"></script>
    </form>
</body>
</html>
