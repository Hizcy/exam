<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListExam.aspx.cs" Inherits="exam_ListExam" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
    <script src="../layer/layer.js"></script>
    <style> 
        .jxks {width:294px; height:96px;margin:0 auto;margin-top: -100px;}
        .jxks a, .jxks  .now span{display:none; text-decoration:none;border:0}
        .jxks:hover{cursor:pointer;} 
        /*.jxks:hover a.now{cursor:pointer; position:absolute; top:0; width:50%; height:100%;z-index:100; left:0; display:block;}
        .jxks:hover  .now{ display:block;position:absolute; bottom:0; left:0;color:#FFF;width:204px; text-align:center;
        z-index:10;height:96px; line-height:96px;font-size:20px; background:#000;filter:alpha(opacity=60);-moz-opacity:0.5;opacity: 0.5;}*/
        .jxks:hover div.now {cursor:pointer; position:absolute; top:0; width:100%; height:100%;z-index:100; left:0; display:block;float:left}
        .jxks:hover div.now a{cursor:pointer; position:absolute; top:0; z-index:100; left:0; display:block;background:#000;color:#fff}
        .jxks:hover  .now { display:block;position:absolute; bottom:0; left:0;color:#FFF;width:204px; text-align:center;
        z-index:10;height:96px; line-height:96px;font-size:20px; background:#000;filter:alpha(opacity=60);-moz-opacity:0.5;opacity: 0.5;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
             
    <div class="span9 setRigth" style="float:left">
         <div class="da" style="border-left:#bec2c5 solid 1px;border-right:#bec2c5 solid 1px;border-top:#bec2c5 solid 1px;background-color:#eeeeee;width:666px;margin-left:40px;line-height:4px"><br />
                    <span style="margin:20px">试题分类</span> 
                        <asp:DropDownList ID="dllLevel" runat="server" style="height: 24px;font-size: 12px;margin-top: 4px;"></asp:DropDownList>
                    <asp:Button ID="btn_qd" class="btnnsave" runat="server" Text="确定" style="width:50px;height:26px;float:right;border-radius:4px;border:0px;color:white;background-color:#464d77;margin-right:20px" OnClick="Button1_Click"   />    
         </div>   
      <div class="setRigthContent">
          <div class="row examManagerRow">
             <div class="span3 userAddRowLeft" > 
                 <div class="cont-area clearfix" >
            	   <ul class="listUl">
                       <asp:Repeater runat="server" ID="rptlist">
                           <ItemTemplate>
                             <li>
                                <div class="t-block" >
                                   <h4 >
                                        <span class="l"><%#Eval("name") %></span>                                
                                        <span class="r">
                                            <em class="s2"><%#GetResult(int.Parse(Eval("ExampaperId").ToString())) %></em>
                                        </span>    
                                   </h4>
                                   <div class="conte" >
                                        <span class="t">评测时长：</span>
                                        <span class="c"><%#Eval("Duration") %> 分</span>
                                        <span style="float:right"><%#int.Parse(Eval("IsMust").ToString())==0?"选读":"必读" %></span>
                                   </div>
                                   <div class="jxks" > 
                                       <div class="now"> 
                                           <a href="Answer.html?id=<%#Eval("ExampaperId") %>&UserId=<%=UserId %>&schoolid=<%=schoolId %>&clsid=<%#Eval("ExampaperClsId") %>&school=<%=school %>" style="margin-top:10px;margin-left:60px"  role="button">
                                           <%--<a href='Answer.aspx?id=<%#Eval("ExampaperId") %>&clsid=<%#Eval("ExampaperClsId") %>'>--%><b style="color:#fff">开始评测</b></a>
                                           <a href='../forum/Forum.aspx?clsid=<%#Eval("ExampaperClsId") %>' target="_blank" style="margin-left:180px;margin-top:10px"><b style="color:#fff">评论</b></a>
                                       </div>
                                   </div>
                                </div>
                             </li>
                           </ItemTemplate>
                       </asp:Repeater>
                   </ul>                    
                 </div>                  
             </div>
          </div>
      </div>
        
    <div class="das_pages" style="text-align:right;margin-right:18px;width: 710px;" >  
        <webdiyer:AspNetPager ID="pager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
        FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="8" PrevPageText="上一页"   
        ShowInputBox="Never" onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left"   >
        </webdiyer:AspNetPager>
    </div>
</div>
</asp:Content>

