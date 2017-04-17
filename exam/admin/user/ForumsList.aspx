<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForumsList.aspx.cs" Inherits="user_ForumsList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" type="text/css" href="../css/customer.css" />
     <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
             <div class="title"><span style="color: #37CBBA">用户管理<</span><span> 评论设置</span></div>
             <div class="topSelDiv userImportMain">
               
                 <table class="table table-condensed table-hover customerTab">
                    <thead>
                        <tr >
                            <th style="text-align:center;width:80px;">评论人</th>
                            <th style="text-align:center;width:90px;">评论书</th>
                            <th style="text-align:center;width:240px;">评论内容</th>
                            <th style="text-align:center;width:60px;">评论状态</th>
                            <th style="text-align:center;width:70px;">评论时间</th>
                            <th style="text-align:center;">操作</th>
                        </tr>
                    </thead> 
                     <%--<tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到相关部门的数据！</th></tr>--%>
                    <asp:Repeater ID="rptForumsList" runat="server">
                        <ItemTemplate>             
                            <tr >
                            <td style="text-align:center;"><%#Eval("RealName").ToString() %></td>
                            <td style="text-align:center;"><%#Eval("name").ToString().Length>5?Eval("name").ToString().Substring(0,5)+"……":Eval("name") %></td>
                            <td style="text-align:center;"><%#Eval("Content").ToString().Length>17?Eval("Content").ToString().Substring(0,10)+"……":Eval("Content") %></td>
                            <td style="text-align:center;"><%#int.Parse(Eval("Status").ToString()) == 1?"启用":"停用" %></td>
                            <td style="text-align:center;"><%#Eval("addtime").ToString().Substring(0,Eval("addtime").ToString().IndexOf(' ')) %></td>
                            <td style="text-align:center"> 
                                <a class="del" href="javascript:deletead(<%#Eval("id") %>);" ><img src="../images/delete.png" /></a> 
                            </td>
                            </tr>
                         </ItemTemplate>                                                         
                    </asp:Repeater>
                 </table>
             </div>
             <div class="das_pages" style="text-align:right;margin-right:18px;margin-bottom:10px" >       
                <webdiyer:AspNetPager ID="pager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
                FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="15" PrevPageText="上一页"   
                ShowInputBox="Never" onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left"   >
                </webdiyer:AspNetPager>
            </div>
         </div>
     </div>
    <script>
        //--删除
        function deletead(id) {
            var flag = confirm("确定屏蔽此评论！");
            if (!flag)
                return;
            $.ajax({
                url: "../data/data.aspx",
                type: "POST",
                data: {
                    type: "deleteforums",
                    id: id
                },
                success: function (result) {
                    if (result == 1) {
                        location.reload();
                    }
                    else if (result == 2)
                        alert("删除失败！");
                }
            })
        }
    </script>
</asp:Content>

