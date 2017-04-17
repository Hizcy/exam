<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="forum_Forum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta name="description" content=""/>
<meta name="author" content=""/>
<meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate"/>
<meta http-equiv="Pragma" content="no-cache"/>
<meta http-equiv="Expires" content="0"/>
    <title>评论</title>
    <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
     <link href="../css/forum.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header id="header" style="z-index: 999;background-color: #464d77;position: relative;height: 3rem;display: block;">
                  <div class="header_l header_return">  </div>
                  <h1 style="color: #fff;font-size: 1.2rem;line-height: 3rem;text-align: center;font-weight: normal;"> <%=forumname %></h1>
            </header>
            <div>
                <table style="width:100%;margin-bottom:100px">
                    <asp:Repeater runat="server" ID="rptforum">
                        <ItemTemplate>
                            <tr>
                                <td style="width:30%"><%#Eval("UserId") %></td>
                                <td style="width:70%"><%#Eval("Content") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                </table>
            </div>
        </div>


         <!--吸低  -->
     <div class="js-navmenu js-footer-auto-ele shop-nav nav-menu nav-menu-1 has-menu-3">
        <div class="nav-item">
            <textarea name="a" id="txtconten" style="width:100%;height:53px;border:0;" placeholder="请输入评论的内容！"></textarea>
            <input id="btn_down" type="button" style="width:100%;height:35px;border:0;color:#fff;background-color:#464d77;margin-top:10px;border-radius:0px" value="发送" />
        </div>
    </div>
    </form>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script>
        $("#btn_down").click(function () {
            var txtconten = $("#txtconten").val().trim();//评论内容
            if (txtconten == "") {
                alert("请填写评论的内容！");
                window.event.returnValue = false;
                return;
            }
            var clsid = "<%=clsid%>";
            alert(clsid);
            $.ajax({
                url: "../data/data.aspx",
                type: "POST",
                data: {
                    type: "addconten",
                    txtconten: txtconten,
                    clsid: clsid
                },
                success: function (result) {
                    if (result == 1)
                        alert("提交评论成功！");
                    else
                        alert("提交评论失败！");
                }
            })
        })

    </script>
</body>
</html>
