<%@ Page Title="考试管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Listexam.aspx.cs" Inherits="Exam_Listexam" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.7.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth">
      <div class="setRigthContent">
            <div class="title"><span style="color:#37CBBA">考试管理< </span><span>考试管理</span></div>
           <div class="topSelDiv userImportMain">
               <div style="margin:20px">
                       <img src="../images/search.png" /><span>试题搜索</span>
                   </div>
                <div class="kaoshicx">
                            <span>试题状态</span>
                                <asp:DropDownList ID="ddlstatus" runat="server" Style="width: 70px" AppendDataBoundItems="true" Height="30px">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">正常</asp:ListItem>
                                    <asp:ListItem Value="0">禁用</asp:ListItem>
                                </asp:DropDownList>
                    <asp:Button ID="Button1" class="btnnsave" runat="server" Text="确定" style="width:50px;height:26px;float:right;border-radius:10px;border:0px;color:white;background-color:#464d77" OnClick="Button1_Click"  />    
                       </div>

               <hr />
                   <div style="margin-left:20px">
                       <img src="../images/p-lib.png" /><span>试题列表</span>
                   </div>
              
                 <table class="table table-condensed table-hover customerTab">
                     <thead>
                        <tr>
                        <th>考试名称</th>
                        <th>及格分数</th>
                        <th>考试时长</th>
                        <th>状态</th>
                        <th >创建人</th>
                        <th >添加时间</th>
                        <th>操作</th>
                        </tr> 
                    </thead>
                       <%if(i==1){ %>
                        <tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到试题搜索的相关数据！</th></tr>
                     <%}else{ %>
                            <asp:Repeater ID="rptExam" runat="server" OnItemCommand="rptexampaper_ItemCommand">               
                                <ItemTemplate>        
                                    <tr >
                                    <td><%#Eval("name") %></td>
                                    <td><%#Eval("pass") %></td>
                                    <td><%#Eval("duration") %></td>
                                    <td><%#int.Parse(Eval("status").ToString())==1?"正常":"禁用" %></td>
                                    <td><%#Eval("founder") %></td>
                                    <td><%#Eval("addtime") %></td>
                                    <td>
                                        <asp:ImageButton ID="imgedit" runat="server"  ImageUrl="../images/edit.png" CommandArgument='<%#Eval("ExamClsId") %>' CommandName="edit" />
                                        <asp:ImageButton ID="imgdelete" runat="server"  ImageUrl="../images/delete.png" CommandArgument='<%#Eval("ExamClsId") %>' CommandName="delete" />                                     
                                    </td>
                                    </tr>
                            </ItemTemplate>                                                         
                        </asp:Repeater>
                      <%} %>     
                    </table>
                  <%if(i==1){ %>
                <%}else{ %>
                    <div class="das_pages" style="text-align:right;margin-right:18px" >  
                             
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

