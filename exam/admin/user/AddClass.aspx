<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddClass.aspx.cs" Inherits="user_AddClass" %>

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
        
        <span style="width:100%;text-align:center;display:-moz-inline-box; display:inline-block;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="height:250px;margin:auto;margin-bottom:10px">
                    <tr>
                        <td><asp:ListBox ID="listClass" runat="server" style="width:200px;height:250px;" SelectionMode="Multiple" ></asp:ListBox></td>
                    
                        <td>
                            <asp:ImageButton ID="imgright" runat="server"  OnClick="ImageButton2_Click" Height="30px" ImageUrl="~/images/right.png" /><p />
                            <asp:ImageButton ID="imgleft" runat="server" OnClick="imgleft_Click" Height="30px" ImageUrl="~/images/leght.png"/>
                        </td>
                        <td><asp:ListBox ID="listClass2" runat="server" style="width:200px;height:250px;" SelectionMode="Multiple" ></asp:ListBox></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
            <input type="button" id="btn_qd" value="确定" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
            <input type="button" id="btn_qx" value="取消" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
        </span>
    </div>
    </form>
    <script>
        $("#btn_qd").click(function () {
            var arr = $("#<%=listClass2.ClientID %> option");
            var str = "";
            var name = "";
            arr.each(function () {
                str += $(this).val() + ",";
                name += $(this).text() + ",";
            })
            
            if (name.length > 25) {
                name = name.substr(0,25) + "……";   
            }
            if (name == "") {
                window.parent.document.getElementById("selectdClass").innerHTML = "选择年级";
            }
            else {
                window.parent.document.getElementById("selectdClass").innerHTML = name.substr(0,name.length-1);
            }
            window.parent.document.getElementById("hid").value = str;
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
