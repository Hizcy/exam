<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionManage3.aspx.cs" Inherits="Exam_QuestionManage3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快去读</title>
    <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
     <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../layer/layer.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <span style="width:100%; text-align:center;display:-moz-inline-box; display:inline-block;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-- <table style="height:100px;margin:auto;margin-bottom:5px;" border="1">--%>
                    <%--<tr>
                        <td>--%>
                            <span style="margin-right:170px" ><%=name %>>></span><br />
                       <%-- </td>
                        <td>--%>
                             <asp:ListBox ID="listboxManage" style="margin-top:-20px" runat="server" Height="100px" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="listboxManage_SelectedIndexChanged"></asp:ListBox>
                       <%-- </td>
                    </tr>--%>
                <%--</table>--%>
                 <asp:TextBox ID="hid1" runat="server" Text="选择试题" style="display:none" ></asp:TextBox>
                 <asp:TextBox ID="hid2" runat="server" style="display:none"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        <span style="width:100%; text-align:center;display:-moz-inline-box; display:inline-block;margin-top:10px">
        <input type="button" id="btn_qd" value="确定" style="border:none;background-color:#464d77;color:white;width:50px;height:25px;margin-right:70px" />
        <input type="button" id="btn_qx" value="取消" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
        </span>
    </div>
    </form>
    <script>
        $("#btn_qd").click(function () {
            var id = "<%=id %>";//唯一标识
            var text1 = $("#<%=hid1.ClientID %>").val();
            var value1 = $("#<%=hid2.ClientID %>").val();
            window.parent.document.getElementById("select" + id + "").innerHTML = text1;
            window.parent.document.getElementById("parentid" + id + "").value = value1;
            var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
            parent.layer.close(index); //执行关闭
        })
        $("#btn_qx").click(function () {
            var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
            parent.layer.close(index); //执行关闭
        })
    </script>
</body>
</html>
