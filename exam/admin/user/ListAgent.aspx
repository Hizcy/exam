<%@ Page Title="代理商管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListAgent.aspx.cs" Inherits="user_ListAgent" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/customer.css" />
        <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
      <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
              <div class="title"><span style="color:#37CBBA">用户管理<</span><span> 代理商管理</span></div>
                   <div class="topSelDiv userImportMain">
                       <div class="chaxun">
                           <span>用户名</span> 
                           <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                            <span style="font-size:8px">状态</span>
                                <asp:DropDownList ID="ddlstatus" runat="server" Style="width: 85px;margin-top: 6px;font-size:8px" AppendDataBoundItems="true" Height="24px">
                                    <asp:ListItem Value="1"> 正常</asp:ListItem>
                                    <asp:ListItem Value="0"> 禁用</asp:ListItem>
                                </asp:DropDownList>
                           
                           <asp:Button ID="btncx" runat="server" CssClass="btncx" Text="查询" style="float:right;margin-right:24px;margin-top: 8px;font-size:8px" OnClick="btncx_Click" />
                       </div>
                        <table class="table table-condensed table-hover customerTab">
                            <thead>
                                <tr>
                                           
                                <th>名称</th>
                                <th>用户名</th>
                                <th>邮箱</th>
                                <th style="width:60px">学校个数</th>
                                <th style="width:30px">性别</th>
                                <th style="width:30px">状态</th>
                                <th>操作</th>
                                </tr>
                            </thead>  
                              <%if(i==1){ %>
                        <tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到相关用户名的数据！</th></tr>
                     <%}else{ %>                                        
                             <asp:Repeater ID="rptResultsList" runat="server">
                                 <ItemTemplate>             
                                      <tr >
                                        
                                        <td><%#Eval("name") %></td>
                                        <td><%#Eval("realname") %></td>
                                        <td><%#Eval("Mail") %></td>
                                        <td><%#Eval("schoolnum") %></td>
                                        <td><%#int.Parse(Eval("sex").ToString()) == 1?"男":"女" %></td>
                                        <td><%#int.Parse(Eval("status").ToString())==1?"正常":"禁用"  %></td>
                                        <td> 
                                            <a href="AddAgent.aspx?userid=<%#Eval("UserId") %>"><img src="../images/edit.png" /></a> 
                                            <a class="del" href="javascript:void(0);"id="<%#DataBinder.Eval(Container.DataItem, "UserId")%>"><img src="../images/delete.png" /></a>        
                                        </td>
                                      </tr>
                               </ItemTemplate>                                                         
                            </asp:Repeater>
                             <%} %>
                        </table>
                        <%if(i==1){ %>
                      <%}else{ %>
                        <div class="das_pages" style="text-align:right;margin-right:18px;margin-bottom:10px" >       
                            <webdiyer:AspNetPager ID="pager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
                            FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="15" PrevPageText="上一页"   
                            ShowInputBox="Never" onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left"   >
                            </webdiyer:AspNetPager>
                        </div>
                        <%} %>
                   </div> 
             </div>
     </div>
    <script type="text/javascript">
        $(function () {
            $(".del").click(function () {
                var result = confirm("是否删除？");
                if (result) {
                    $.ajax({
                        url: "../data/data.aspx",
                        type: "POST",
                        data: {
                            type: "delagent",
                            userid: $(this).attr("id")
                        },
                        success: function (v) {
                            location.reload();

                        }
                    });
                }
            });
        });
        </script>  
        <input type="text" style="display:none" id="selectdepartment" />
    <input type="text" style="display:none" id="hiddepartment" />

</asp:Content>

