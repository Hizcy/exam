<%@ Page Title="试卷管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListTest.aspx.cs" Inherits="Exam_ListTest" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.7.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth">
      <div class="setRigthContent">
            <div class="title"><span style="color:#37CBBA">考试管理< </span><span>试卷管理</span></div>
           <div class="topSelDiv userImportMain">
               <div class="title">试卷搜索</div>
                <div class="kaoshicx">
                            <span>试卷名称</span> 
                              <asp:TextBox ID="txtname" runat="server" style="width:210px;margin-top: 10px;font-size:8px"></asp:TextBox>
                            
                            <span style="margin-left:10px">考试状态</span>
                            <asp:DropDownList ID="ddlstatus" runat="server" Style="width:70px;margin-top:10px;font-size:8px" AppendDataBoundItems="true" Height="24px">
                                <asp:ListItem Value="-1">请选择</asp:ListItem>
                                <asp:ListItem Value="1">正常</asp:ListItem>
                                <asp:ListItem Value="0">禁用</asp:ListItem>
                            </asp:DropDownList><br />
                       <div style="text-align:center">
                           <asp:Button ID="btnSave" class="btnnsave" runat="server" Text="确定" style="margin-top: 10px;width:80px;height:26px;text-align:center;border-radius:4px;border:0px;color:white;background-color:#464d77" OnClick="btnSave_Click"  />    
                       </div>
                    </div>
               <hr /> 
                   <div class="title">试卷列表</div>              
                 <table class="table table-condensed table-hover customerTab"> 
                                        <thead>
                                          <tr>
                                            <th>名称</th>
                                            <th>状态</th>
                                            <th>组卷方式</th>
                                            <th>总分</th>
                                            <th>试题总数</th>
                                            <th>创建人</th>
                                            <th>创时间</th>
                                            <th>操作</th>
                                          </tr>
                                        </thead>
                     <%if(i==1){ %>
                        <tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到相关试卷名称的数据！</th></tr>
                     <%}else{ %>
                             <asp:Repeater ID="rptexampaper" runat="server" OnItemCommand="rptexampaper_ItemCommand">                               
                                 <ItemTemplate>              
                                      <tr >
                                        <td><%#Eval("name") %></td>
                                        <td><%#int.Parse(Eval("status").ToString())==1?"正常":"禁用" %></td>
                                        <td><%#Eval("type") %></td>
                                        <td><%#Eval("total") %></td>
                                        <td><%#Eval("num") %></td>
                                        <td><%#Eval("founder") %></td>
                                        <td><%#Eval("addtime") %></td>
                                        <td>
                                            <asp:ImageButton ID="imgedit" runat="server"  ImageUrl="../images/edit.png" CommandName="edit" CommandArgument='<%#Eval("exampaperid") %>'  />
                                            <asp:ImageButton ID="imgdelete" runat="server"  ImageUrl="../images/delete.png"  CommandName="delete" CommandArgument='<%#Eval("exampaperid") %>'   />                                     
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
                            FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="10" PrevPageText="上一页"   
                            ShowInputBox="Never" onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left"   >
                            </webdiyer:AspNetPager>
                        </div>
                 <%} %>
            </div>
          </div>
      </div>
</asp:Content>

