<%@ Page Title="用户列表" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListName.aspx.cs" Inherits="user_ListName" %>
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
              <div class="title"><span style="color:#37CBBA">用户管理<</span><span> 用户列表</span></div>
                   <div class="topSelDiv userImportMain">
                       <div class="chaxun">
                           <span>所属部门</span> 
                                <a href="javascript:select()" style="text-decoration:none"><asp:Label ID="labdepartment" style="color:#464d77;font-weight:bold;margin-left:5px"  runat="server" Text="选择部门"></asp:Label>
                                    <img src="../images/icon6.gif" />
                                </a>
                           <asp:TextBox ID="hiddepartmentId" runat="server" style="display:none"></asp:TextBox>
                           <asp:TextBox ID="hiddepartmentName" runat="server" style="display:none"></asp:TextBox>
                             
                           <span>性别</span>
                               <asp:DropDownList ID="ddlsex" runat="server" Style="width:85px;margin-top: 6px;font-size:8px" AppendDataBoundItems="true" Height="24px">
                                   <asp:ListItem Value=""> 选择</asp:ListItem>
                                    <asp:ListItem Value="1"> 男</asp:ListItem>
                                    <asp:ListItem Value="0"> 女</asp:ListItem>
                               </asp:DropDownList>                        
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
                                <th>&nbsp;&nbsp;&nbsp;<input id="checkselect" type="checkbox" style="width:18px" />全选</th>   
                                <th>用户名</th>
                                <th>姓名</th>
                                <th>所属部门</th>
                                <th>电子邮件</th>
                                <th style="width:30px">性别</th>
                                <th style="width:30px">状态</th>
                                <th>操作</th>
                                </tr>
                            </thead> 
                               <%if(i==1){ %>
                        <tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到相关部门的数据！</th></tr>
                     <%}else{ %>                           
                             <asp:Repeater ID="rptResultsList" runat="server">
                                 <ItemTemplate>             
                                      <tr >
                                        <td><input id='<%#Eval("UserId") %>' name="check" type="checkbox" class="check" style="width:18px" /></td>
                                        <td><%#Eval("name") %></td>
                                        <td><%#Eval("realname") %></td>
                                        <td><%#Eval("departmentname") %></td>
                                        <td><%#Eval("mail") %></td>
                                        <td><%#int.Parse(Eval("sex").ToString()) == 1?"男":"女" %></td>
                                        <td><%#int.Parse(Eval("status").ToString())==1?"正常":"禁用"  %></td>
                                        <td> 
                                            <a href="AddName.aspx?userid=<%#Eval("UserId") %>"><img src="../images/edit.png" /></a> 
                                            <a class="del" href="javascript:void(0);"id="<%#DataBinder.Eval(Container.DataItem, "UserId")%>"><img src="../images/delete.png" /></a> 
                                            
                                        </td>
                                      </tr>
                               </ItemTemplate>                                                         
                            </asp:Repeater>
                             <%} %>
                        </table>
                         <%if(i==1){ %>
                      <%}else{ %>
                           <input id="btn_del" type="button" class="btncx" style="margin-left:10px;float:left" value="删除" />
                         <asp:Button ID="btnexcel" runat="server" CssClass="btndc" style="margin-left:10px;float:left" Text="导出" OnClick="btnexcel_Click" />
                      <asp:GridView ID="gvlistname" runat="server">
                      </asp:GridView>
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
                            type: "deluser",
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

    <script>
        //<span style="color:#464d77;font-weight:bold;float:left;margin-left:15px" id="selectdepartment">选择部门</span><img src="../images/icon6.gif" style="float:left;margin-top:2px;" />
        function select() {
            var userid = "<%=userid %>";
            layer.open({
                area: ['800px', '500px'],
                title: '选择部门',
                type: 2,
                content: "AddDepartment.aspx?userid="+userid,
                end: function () {
                    var id = document.getElementById("hiddepartment").value;
                    if (id != "") {
                        document.getElementById("<%=hiddepartmentId.ClientID %>").value = id;
                        document.getElementById("<%=labdepartment.ClientID %>").innerHTML = document.getElementById("selectdepartment").innerText;
                        document.getElementById("<%=hiddepartmentName.ClientID %>").value = document.getElementById("selectdepartment").innerText;
                    }
                }
            })
        }
        //全选
        var UserId = "";
        $("#checkselect").change(function () {
            var flag = $(this).is(":checked");
            $("input:checkbox[name = 'check']").each(function () {
                $(this).attr("checked", flag);
                UserId += $(this).attr("id") + ",";
            })
            if (flag == false) {
                UserId = null;
            }
        })
        $(".check").change(function () {
            $("#checkselect").attr("checked", false);
            var flag = $(this).is(":checked");
            if (flag) {
                UserId += $(this).attr("id")+",";
            }
            else {
                var tid = $(this).attr("id") + ",";
                UserId = UserId.replace(tid, "");
            }
        })
        //删除用户
        $("#btn_del").click(function () {
            if (UserId == "") {
                alert("请选择删除对象！");
                return;
            }
            else {
                $.ajax({
                    url: '../Data/data.aspx',
                    type: 'POST',
                    data: {
                        type: "delname",
                        userid:UserId
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

