 <%@ Page Title="配置管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CanReadBookList.aspx.cs" Inherits="user_CanReadBookList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../layer/layer.js"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="span9 setRigth" style="float: left">
        <div class="setRigthContent">
            <div class="title"><span style="color: #37CBBA">题库管理<</span><span> 配置管理</span></div>
            <div class="topSelDiv userImportMain">
               
                <table class="table table-condensed table-hover customerTabbj" style="margin-top:0px">
                    <thead>
                        <tr>
                            <td style="width:400px;background-color:#dcdcdc;"><span style="display:-moz-inline-box; display:inline-block;margin-left:95px;font-weight:700;">所属书库</span></td>
                            <th>状态</th>
                        </tr>
                    </thead>
                    <asp:Repeater ID="rptResultsList" runat="server" OnItemDataBound="rptResultsList_ItemDataBound" OnItemCommand="rptResultsList_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><span style="display:-moz-inline-box; display:inline-block;margin-left:95px;"><%#Eval("Name") %><asp:Button ID="btn"  runat="server" Text="▲" style="border:0px;background-color:white;" CommandArgument='<%#Eval("QuestionClsId") %>' CommandName="show" /></span></td>
                                <td style="text-align:center">
                                    <span style="display:-moz-inline-box; display:inline-block;margin-left:10px;"><%#Eval("pass").ToString().Equals("") || Eval("pass").ToString().Equals("0")?"<a class='cls"+Eval("QuestionClsId")+"' href='javascript:set("+Eval("QuestionClsId")+")'>设置过关积分</a>":"<a class='cls"+Eval("QuestionClsId")+"' href='javascript:set("+Eval("QuestionClsId")+")'>过关积分:"+Eval("pass")+"</a>" %></span>
                                    <!--<asp:Label ID="labpass" CssClass='<%#Eval("QuestionClsId") %>' runat="server" Text="Label"></asp:Label>-->
                                    <input type="checkbox" name="hidcheck" style="display:none" value='<%#Eval("QuestionClsId") %>' />

                                    <asp:TextBox ID="hidpass" CssClass='<%#Eval("QuestionClsId") %>'  runat="server" style="display:none"></asp:TextBox>
                                </td>
                                
                            </tr>
                            <asp:Repeater ID="rptResults2" runat="server">
                                <ItemTemplate>
                                    <tr><td ><span style="display:-moz-inline-box; display:inline-block;margin-left:120px"></span><%#Eval("Name") %>---<span style="color:red">积分:<%#Eval("score") %></span>&nbsp;&nbsp;<%#Eval("reads").ToString()=="0"?"(选读)":"" %><%#Eval("reads").ToString()=="1"?"<span style='color:red'>(必读)</span>":"" %></td>
                                        <td style="text-align:center;">
                                            <span style="display:-moz-inline-box; display:inline-block;margin-left:10px;">
                                                <select class="status" style="width:70px">
                                                    <option value="<%#Eval("relationid") %>,2">禁用</option>
                                                    <option value='<%#Eval("QuestionClsId") %>,0' <%#Eval("reads").ToString()=="0"?"selected":"" %> >选读</option>
                                                    <option value='<%#Eval("QuestionClsId") %>,1' <%#Eval("reads").ToString()=="1"?"selected":"" %>>必读</option>
                                                </select>
                                            </span>
                                        </td>
                                     </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>                                                         
                    </asp:Repeater>
                 </table>
              </div> 
        </div>
     </div>
    <script>
        $(".status").change(function () {
            var str = $(this).val().toString().split(',');
            $.ajax({
                url: '../data/data.aspx',
                type: "POST",
                data: {
                    type: "addconreadbook",
                    id: str[0],
                    status: str[1]
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
        });
        function set(id) {
            layer.open({
                title: '积分设置',
                content: '积分：<input type="text" id="text" />',
                yes: function () {
                    var pass = $("#text").val();
                    $.ajax({
                        url: '../data/data.aspx',
                        type: "POST",
                        data: {
                            type: "passset",
                            id: id,
                            pass: pass
                        },
                        error: function () {
                            writeError("编辑失败！");
                        },
                        success: function (result) {
                            if (result == 1) {
                                $(".cls" + id).html("过关积分:" + pass);
                                $("." + id).val("过关积分:" + pass);
                                layer.open({
                                    time: 2
                                });
                            }
                        }
                        
                    });
                }
            })
        }
        $(function () {
            var arr = $("[name=hidcheck]");
            arr.each(function () {
                var id = $(this).val();
                var pass = $("." + id).val();
                if (pass != "") {
                    $(".cls" + id).html(pass);
                }
                
            })
        })
    </script>
</asp:Content>


