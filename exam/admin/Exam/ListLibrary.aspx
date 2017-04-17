<%@ Page Title="题库管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListLibrary.aspx.cs" Inherits="Exam_ListLibrary" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="span9 setRigth">
      <div class="setRigthContent">
            <div class="title"><span style="color:#37CBBA">考试管理< </span><span>题库管理</span></div>
           <div class="topSelDiv userImportMain">
               <div class="title"> 试题搜索 </div>
                <div class="kaoshicx">
                           <span>试题分类：</span> 
                                 <a href="javascript:select()" style="text-decoration:none"><span style="color:#464d77;font-size:13px;margin-left:-3px" id="selectdepartment">选择试题</span>&nbsp;<img src="../images/icon6.gif" style="margin-bottom:2px;"  /></a> 
                                 <input type="text" id="hiddepartment" value="" style="display:none" /><asp:TextBox ID="hid" style="display:none"   runat="server"></asp:TextBox>&nbsp;&nbsp;
                           <span>试题类型：</span> 
                               <asp:DropDownList ID="dlltype" runat="server" Style="width: 64px;margin-top:10px;font-size:8px" AppendDataBoundItems="true" Height="24px">
                                   <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">单选</asp:ListItem>
                                    <asp:ListItem Value="2">多选</asp:ListItem>
                                    <asp:ListItem Value="3">判断</asp:ListItem>
                                    <asp:ListItem Value="4">填空</asp:ListItem>
                               </asp:DropDownList> &nbsp;&nbsp;                
                            <span>试题难度：</span>
                                <asp:DropDownList ID="dllharde" runat="server" Style="width: 64px;margin-top:10px;font-size:8px" AppendDataBoundItems="true" Height="24px">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="0"> 简单</asp:ListItem>
                                    <asp:ListItem Value="1">困难</asp:ListItem>
                                </asp:DropDownList>&nbsp;&nbsp;
                            <span>试题状态：</span>
                                <asp:DropDownList ID="dllstatus" runat="server" Style="width: 64px;margin-top:10px;font-size:8px" AppendDataBoundItems="true" Height="24px">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">正常</asp:ListItem>
                                    <asp:ListItem Value="0">禁用</asp:ListItem>
                                </asp:DropDownList>
                         
                          
                       </div>
                            <p class="buttonP">
                                <asp:Button ID="btnSave" class="btnnsave" runat="server" Text="确定" style="margin-left:-30px" OnClick="btnSave_Click" />      	
                            </p>

               <hr />
                   <div class="title">试题列表</div>
                 <table class="table table-condensed table-hover customerTab">
                     <thead>
                        <tr>
                        <th><input type="checkbox" name="checkpx" class="ckqx" style="width:20px" /></th>
                        <th>题型</th>
                        <th>状态</th>
                        <th>分类</th>
                        <th>试题内容</th>
                        <th style="width:30px">难度</th>
                        <th >创建时间</th>
                        <th>操作</th>
                        </tr>
                    </thead>
                     <%if(i==1){ %>
                        <tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到试题分类的相关数据！</th></tr>
                     <%}else{ %>
                    <asp:Repeater ID="rptQuestion" runat="server" OnItemCommand="rptexampaper_ItemCommand">             
                        <ItemTemplate>              
                            <tr >
                            <td><input type="checkbox" name="check" value='<%#Eval("questionid") %>' style="width:20px" /></td>
                            <td><%#type(int.Parse(Eval("type").ToString())) %></td>
                            <td><%#int.Parse(Eval("status").ToString())==1?"启用":"禁用" %></td>
                            <td><%#Eval("name") %></td>
                            <td style="width:240px"><%#content(Eval("title").ToString()) %></td>
                            <td><%#int.Parse(Eval("isdifficulty").ToString())==0?"简单":"困难" %></td>
                            <td><%#Eval("addtime") %></td>
                            <td>
                                <asp:ImageButton ID="imgedit" runat="server"  ImageUrl="../images/edit.png" CommandName="edit" CommandArgument='<%#Eval("questionid") %>' />
                                <asp:ImageButton ID="imgdelete" runat="server"  ImageUrl="../images/delete.png" CommandName="delete" CommandArgument='<%#Eval("questionid") %>'  />                                     
                            </td>
                            </tr>
                        </ItemTemplate>                                             
                    </asp:Repeater>
                    <%} %>            
            </table>
                 <%if(i==1){ %>
                <%}else{ %>
                  <input id="btn_del" type="button" class="btncx" style="margin-left:10px;float:left" value="删除" />
                  <asp:Button ID="btnexcel" runat="server" CssClass="btncx" style="margin-left:10px;float:left" Text="导出" OnClick="btnexcel_Click" />
                      <asp:GridView ID="gvlistbrary" runat="server" ></asp:GridView>
                  <div class="das_pages" style="text-align:right;margin-right:18px;margin-bottom:10px" >       
                      <webdiyer:AspNetPager ID="pager1" CssClass="paginator" CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True"
                          FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="10" PrevPageText="上一页"
                          ShowInputBox="Never" OnPageChanged="AspNetPager1_PageChanged" CustomInfoTextAlign="Left" ShowPageIndexBox="Never"  >
                      </webdiyer:AspNetPager>
                        </div>
                
                 <%} %>     
            </div>
          </div>
      </div>
    <asp:TextBox ID="txtnamet" runat="server" style="display:none"></asp:TextBox>
    <script>
        function select() {
            layer.open({
                area: ['800px', '500px'],
                title: '选择题库',
                type: 2,
                content: "QuestionManage.aspx?id=-3",
                //关掉之后
                end: function () {
                    var id = $("#hiddepartment").val();
                    var name = document.getElementById("selectdepartment").innerText;
                    $("#<%=txtnamet.ClientID %>").val(name);
                    $("#<%=hid.ClientID %>").val(id);
                }
            })
        }
        $(function () {
            var names = $("#<%=txtnamet.ClientID %>").val();
            if (names != "") {
                document.getElementById("selectdepartment").innerHTML = names;
            }
        })
        var tiid = "";
        //全选
        $(".ckqx").change(function () {
            var flag = $(this).is(":checked");
            if (flag) {
                $("input:checkbox[name = 'check']").each(function () {
                    $(this).attr("checked", flag);
                    tiid += $(this).val() + ",";
                })
            }
            else {
                $("input:checkbox[name = 'check']").each(function () {
                    $(this).attr("checked", false);
                })
                tiid = "";
            }
        })
        $("[name=check]").change(function () {
            var flag = $(this).is(":checked");
            $(".ckqx").attr("checked", false);
            if (flag == false) {
                var tid = $(this).val() + ",";
                tiid = tiid.replace(tid, "");
            }
            else {
                tiid += $(this).val()+",";
            }
        })
        //删除试题
        $("#btn_del").click(function () {
            if (tiid == "") {
                alert("请选择删除试题！");
                return;
            }
            else {
                $.ajax({
                    url: '../Data/data.aspx',
                    type: 'POST',
                    data: {
                        type: "delti",
                        tiid: tiid
                    },
                    success: function (result) {
                        if (result == "1") {
                            alert("删除成功！");
                            location.reload();
                        }
                    }
                })
            }
        })
    </script>
</asp:Content>

