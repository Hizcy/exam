<%@ Page Title="发布考试" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Release.aspx.cs" Inherits="Exam_Release" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.7.2.min.js"></script>
     <script src="../layer/layer.js"></script>
     <script src="../js/My97DatePicker/WdatePicker.js"  type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth">
         <div class="setRigthContent">
             <div class="title"><span style="color:#37CBBA">考试管理< </span><span style="color:#000000">组织考试<</span><span>发布考试</span></div>
                 <div class="topSelDiv userImportMain">
          
          <div class="title">引用试卷</div>
          <input type="button" value="选择试卷" style="border:none;background-color:#464d77;color:white;width:80px;height:25px" onclick="selectexam()" />               
          <table class="table table-condensed table-hover customerTab">
            <thead>
              <tr>
                <th>名称</th>
                <th>组卷方式</th>
                <th>总分</th>
                <th>试题数量</th>
                <th>创建人</th>
                <th>创建时间</th>
                <th>操作</th>
              </tr>
            </thead>
            <tbody class="paperList">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="paper_name"><%#Eval("name") %></td>
                            <td class="paper_type"><%#Eval("type") %></td>
                            <td class="total_score"><%#Eval("total") %></td>
                            <td class="test_count"><%#Eval("num") %></td>
                            <td class="create_user_name"><%#Eval("founder") %></td>
                            <td class="created_time"><%#Eval("addtime") %></td>
                            <td><asp:ImageButton ID="imgdelete" runat="server"  ImageUrl="../images/delete.png" /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
          </table>
          <div style="border-top:1px #827c7c dotted"></div>
          
         <div class="title">考试设置</div>
              <div class="topContent">
                  <div style="height:30px;">考试名称：
                     <asp:TextBox ID="txtname" runat="server" style="width:200px;"></asp:TextBox>
                      <%-- <span style="margin-left:30px">考试时间：</span><asp:TextBox ID="dateForm" runat="server" onfocus="WdatePicker({dateFmt:&#39;yyyy-MM-dd HH:mm&#39;,isShowClear:false,readOnly:true,minDate:&#39;%y-%M-%d %H:%m:%s&#39;})" style="width:100px;" placeholder="点击选择开始时间" original-title="请输入任务的开始时间"></asp:TextBox>                
                             到&nbsp;&nbsp;<asp:TextBox ID="dateTo" runat="server" onfocus="WdatePicker({dateFmt:&#39;yyyy-MM-dd HH:mm&#39;,isShowClear:false,readOnly:true,minDate:&#39;#F{$dp.$D(\&#39;StartTime\&#39;)}&#39;})" style="width:100px;"  placeholder="点击选择结束时间" original-title="请输入任务的结束时间" ></asp:TextBox>       
                  </div>  <br />                                 
            <div>考试分类：
                    <asp:DropDownList ID="DropDownList1" runat="server" Style="width: 100px" AppendDataBoundItems="true" Height="30px">
                    </asp:DropDownList> --%>         
              <span style="margin-left:30px">考试状态</span>
              <asp:DropDownList ID="ddlstatus" runat="server" Style="width: 60px" AppendDataBoundItems="true" Height="30px">
                                    <asp:ListItem Value="1">正常</asp:ListItem>
                                    <asp:ListItem Value="0">禁用</asp:ListItem>
              </asp:DropDownList>             
              <span style="margin-left:30px"> 及格分数：</span>
              <asp:TextBox ID="txtscore" runat="server" style="width:50px;"></asp:TextBox>    
              分 </div>
        
            <div style="margin-top:10px"> 答卷时长：
              <asp:TextBox ID="txtlength" runat="server" style="width:50px;"></asp:TextBox>        
              <span id="exam_timeText">分钟</span>
              <%--<span style="margin-left:30px">参考次数：</span>
               <asp:DropDownList ID="DropDownList2" runat="server" Style="width: 100px" AppendDataBoundItems="true" Height="30px">
                                    <asp:ListItem Value="1">不限 </asp:ListItem>
                                    <asp:ListItem Value="0"> 限制每人参加的次数</asp:ListItem>
              </asp:DropDownList>             
            <asp:TextBox ID="txtnumber" runat="server" style="width:50px;height:22px"></asp:TextBox>        
              次--%> </div>
              </div>
           <div style="border-top:1px #827c7c dotted"></div>
        <%--  <div class="title">指定考试对象</div>
                      <div class="fabuks">
                               <div style="width:400px;margin-left:20px"> <a href="javascript:select()" style="text-decoration:none"><asp:Label ID="labdepartment" style="color:#464d77;font-weight:bold;margin-left:5px"  runat="server" Text="选择部门"></asp:Label>
                                    <img src="../images/icon6.gif" />
                                </a>
                                <asp:HiddenField ID="hiddepartmentId" runat="server" />
                                <asp:HiddenField ID="hiddepartmentName" runat="server" />
                             <span style="margin-left:10px">(如果需要选择全部人员，请勾选根级部门。)</span></div>
                      </div> --%> 
                       <p class="buttonP">
                           <asp:Button ID="btnSave" class="btnnsave" runat="server" Text="确定" OnClick="btnSave_Click"   />
                       </p>        
          </div>     
      </div>
    </div>
    <asp:TextBox ID="txthid" style="display:none" runat="server"></asp:TextBox><!--试题ID-->
    <input type="text" style="display:none" id="id" /><!--试题ID-->
    <input type="text" style="display:none" id="selectdepartment" />
    <input type="text" style="display:none" id="hiddepartment" />
    <script>
       <%-- function select() {
            layer.open({
                area: ['800px', '500px'],
                title: '选择部门',
                type: 2,
                content: "../user/AddDepartment.aspx",
                end: function () {
                    var id = document.getElementById("hiddepartment").value;
                    document.getElementById("<%=hiddepartmentId.ClientID %>").value = id;
                    document.getElementById("<%=labdepartment.ClientID %>").innerHTML = document.getElementById("selectdepartment").innerText;
                    document.getElementById("<%=hiddepartmentName.ClientID %>").value = document.getElementById("selectdepartment").innerText;
                }
            })
        }--%>
        function selectexam() {
            layer.open({
                area: ['1000px', '600px'],
                title: '选择部门',
                type: 2,
                content: "provideexampaper.aspx",
                end: function () {
                    var id = document.getElementById("id").value;
                    document.getElementById("<%=txthid.ClientID %>").value = id;
                }
            })
        }
    </script>
</asp:Content>

