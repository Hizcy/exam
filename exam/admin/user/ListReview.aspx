<%@ Page Title="审核管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListReview.aspx.cs" Inherits="user_ListReview" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
            <div class="title"><span style="color: #37CBBA">代理商管理<</span><span> 审核管理</span></div>
                   <div class="topSelDiv userImportMain">
                        
                        <table class="table table-condensed table-hover customerTab">
                          <thead>
                                            <tr>  
                                            <th>用户名</th>
                                            <th>姓名</th>
                                            <th>学校</th>
                                            <th>电子邮件</th>
                                            <th>状态</th>
                                            <th>操作</th>
                                            </tr>
                                        </thead>
                               <%if(i==1){ %>
                        <tr><th colspan="8" style="font-size:20px;text-align:center">暂无要审核的相关数据！</th></tr>
                     <%}else{ %>
                              <asp:Repeater ID="rptlistreview" runat="server">
                                   <ItemTemplate>             
                                      <tr >
                                        <td><%#Eval("name") %></td>
                                        <td><%#Eval("realname") %></td>
                                        <td><%#Eval("schoolname") %></td>
                                        <td><%#Eval("mail") %></td>
                                        <td><%#int.Parse(Eval("status").ToString())==0?"待审核":"已审核"  %></td>
                                        <td>
                                            <a class="tongg" href="javascript:void(0);"id="<%#DataBinder.Eval(Container.DataItem, "UserID")%>">通过</a>     
                                            <a class="juej" href="javascript:void(0);"id="<%#DataBinder.Eval(Container.DataItem,"UserID")%>">拒绝</a> 
                                        </td>
                                      </tr>
                                  </ItemTemplate>                                                         
                            </asp:Repeater>
                             <%} %>
                        </table>
                       <%-- <%if (UserId == 0)
                            {%>--%>
                    <%--   <div id="divd" runat="server" style="text-align:center">没有要审核的数据！</div>--%>
                   <%--    <%} %>--%>
                   </div> 
             </div>
     </div>
      <script type="text/javascript">
          $(function () {
              $(".tongg").click(function () {
                  var result = confirm("确认通过？");

                  if (result) {

                      $.ajax({
                          url: "../data/userthrough.aspx?id=" + $(this).attr("id"),
                          type: "GET",
                          success: function () {
                              alert("审核通过");
                              location.reload();

                          }
                      });
                  }
              });
          });
          $(function () {
              $(".juej").click(function () {
                  var result = confirm("是否拒绝？");
                  if (result) {
                      $.ajax({
                          url: "../data/userdown.aspx?id=" + $(this).attr("id"),
                          type: "GET",
                          success: function () {
                              alert("用户被拒绝");
                              location.reload();
                          }
                      });
                  }
              });
          });
        </script>  
   
</asp:Content>

