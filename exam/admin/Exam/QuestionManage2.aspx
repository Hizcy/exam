<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionManage2.aspx.cs" Inherits="Exam_QuestionManage2" %>

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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <span style="width:100%; text-align:center;display:-moz-inline-box; display:inline-block;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="listMent" runat="server" style="width:200px;height:250px;" AutoPostBack="True" OnSelectedIndexChanged="listMent_SelectedIndexChanged"></asp:ListBox>
                <asp:ListBox ID="listMent2" runat="server" style="width:200px;height:250px;" AutoPostBack="True" OnSelectedIndexChanged="listMent2_SelectedIndexChanged"></asp:ListBox><p/>
                <asp:TextBox ID="hid1" runat="server" Text="选择试题" style="display:none"></asp:TextBox>
                <asp:TextBox ID="hid2" runat="server" style="display:none"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
            <input type="button" id="btn_qd" value="确定" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
            <input type="button" id="btn_qx" value="取消" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
        </span>
    </div>
    </form>
    <script>
        $("#btn_qd").click(function () {

            var text1 = $("#<%=hid1.ClientID %>").val();
            var value1 = $("#<%=hid2.ClientID %>").val();
            window.parent.document.getElementById("selectdepartment").innerHTML = text1;//给父窗体DOM赋值
            window.parent.document.getElementById("hiddepartment").value = value1;
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
