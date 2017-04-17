<%@ Page Title="班级配置" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClassDpy.aspx.cs" Inherits="user_ClassDpy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/customer.css" />
    <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth" style="float: left">
        <div class="setRigthContent">
            <div class="title"><span style="color: #37CBBA">用户管理<</span><span> 配置管理</span><<span>班级配置</span></div>
            <div class="topSelDiv userImportMain">
               
                <table class="table table-condensed table-hover customerTabbj" style="margin-top:0px">
                    <thead>
                        <tr>
                            <th >所属年级</th>
                            <th >状态</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="rptResultsList" runat="server" OnItemCommand="rptResultsList_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align:center"><%#Eval("Name") %><asp:Button ID="btn"  runat="server" Text="▲" style="border:0px;background-color:white;" CommandArgument='<%#Eval("DepartmentId") %>' CommandName="show" /> </td>
                                <td style="text-align:center">
                                    <asp:DropDownList ID="ddlstatus" runat="server" style="width:60px" >
                                        <asp:ListItem Value="1">正常</asp:ListItem>
                                        <asp:ListItem Value="0">禁用</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                
                            </tr>
                            <asp:Repeater ID="rptResults2" runat="server">
                                <ItemTemplate>
                                    <tr><td style="text-align:center;"><%#Eval("Name") %></td>
                                        <td style="text-align:center;">
                                            <a  href="javascript:status(<%#Eval("DepartmentId") %>)" style="text-decoration:none;">
                                                <%#Eval("status").ToString()=="1"?"<span>已启用</span>":"<span style='color:red'>已禁用</span>" %>
                                            </a>
                                        </td>
                                     </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>                                                         
                    </asp:Repeater>
                 </table>
                  <p class="buttonjs">
                <asp:Button ID="btnSave" class="button1" runat="server" Text="确定" OnClick="btnSave_Click"  />
            	&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" class="button2" runat="server" Text="取消" />
            	
            </p>
              </div> 
        </div>
     </div>
    <script>
        function status(num) {
            $.ajax({
                url: '../data/data.aspx',
                type: "POST",
                data:{
                    type: "classstatus",
                    id:num
                },
                error: function () {
                    writeError("失败！");
                },
                success: function (result) {
                    if (result == 1) {
                        location.reload(true);
                    }
                }
            })
        }
        function Save() {
            var topName = "";//第一个值
            var leng = 0;
            var status = "";
            var leng = document.getElementsByClassName("span");
            for (var i = 0; i < leng.length; i++) {
                topName = document.getElementById("" + 1 + "").innerText;
                status = document.getElementById("" + (i + 1) + "").innerText;
                if (status == biao) {
                    biao1 += 1;
                }
            }
            if (biao1 == leng.length) {
                if (biao == "已启用") {
                   // $("#").val(1);
                }
                else {
                   // $("#").val(2);
                }
            }
        }
        
    </script>
</asp:Content>

