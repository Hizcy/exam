<%@ Page Title="学校管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListSchool.aspx.cs" Inherits="user_ListSchool" %>
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
              <div class="title"><span style="color:#37CBBA">用户管理<</span><span> 学校管理</span></div>
                   <div class="topSelDiv userImportMain">
                       <div class="chaxun">
                               <span style="font-size:8px">地区</span>
                                    <select id="ddlprovince" runat="server" style="width:80px;height:24px" ></select>
                                    <select id="ddlcity" runat="server" style="width:80px;height:24px" >
                                        <option value="0">市</option>
                                    </select>
                                    <select id="ddleurozone" runat="server" style="width:80px;height:24px" >
                                        <option value="0">县/区</option>
                                    </select>
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
                                           
                                <th>学校名称</th>
                                <th>域名</th>
                                <th>密码</th>
                                <th>学校人数</th>
                                <th>代理商</th>
                                <th>状态</th>
                                <th>操作</th>
                                </tr>
                            </thead>  
                             <%if(i==1){ %>
                        <tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到该地区的相关数据！</th></tr>
                     <%}else{ %>                               
                             <asp:Repeater ID="rptResultsList" runat="server">
                                 <ItemTemplate>             
                                      <tr >
                                        
                                        <td><%#Eval("name") %></td>
                                        <td><%#Eval("domain") %></td>
                                          <td><%#Eval("pwd") %></td>
                                        <td><%#int.Parse(Eval("TeacherNum").ToString())+int.Parse(Eval("StudentNum").ToString()) %></td>
                                        <td><%#Eval("agentname") %></td>
                                        <td><%#int.Parse(Eval("status").ToString())==1?"正常":"禁用"  %></td>
                                        <td> 
                                            <a href="addschool.aspx?schoolid=<%#Eval("schoolid") %>"><img src="../images/edit.png" /></a> 
                                            <a class="del" href="javascript:void(0);"id="<%#DataBinder.Eval(Container.DataItem, "schoolid")%>"><img src="../images/delete.png" /></a> 
                                            
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
    <asp:TextBox ID="selectcity" runat="server" OnLoad="selectcity_Load" style="display:none" ></asp:TextBox>
    <asp:TextBox ID="selecteurozone" runat="server" OnLoad="selectcity_Load" style="display:none" ></asp:TextBox>

    <script type="text/javascript">
        $(function () {
            $(".del").click(function () {
                var result = confirm("是否删除？");
                if (result) {

                    $.ajax({
                        url: "../data/data.aspx",
                        type: "POST",
                        data: {
                            type: "delschool",
                            schoolid: $(this).attr("id")
                        },
                        success: function (v) {
                            location.reload();

                        }
                    });
                }
            });
        });
        $("#<%=ddlcity.ClientID %>").change(function () {
            var id = $(this).val();
            $("#<%=selectcity.ClientID  %>").val(id);
            $.ajax({
                url: '../Data/data.aspx',
                type: 'POST',
                data: {
                    type: "select",
                    locationid: id,
                    tmp:1
                },
                success: function (result) {
                    $("#<%=ddleurozone.ClientID %>").html(result);
                    //放置id
                    var eurozoneid = $("#<%=ddleurozone.ClientID %>").val();
                    $("#<%=selecteurozone.ClientID %>").val(eurozoneid);
                }
            })
        })
        $("#<%=ddlprovince.ClientID %>").bind("change", function () {
            var id = $(this).val();
            $.ajax({
                url: '../Data/data.aspx',
                type: 'POST',
                data: {
                    type: "select",
                    locationid: id,
                    tmp:0
                },
                success: function (result) {
                    if (result != "") {
                        $("#<%=ddlcity.ClientID %>").html(result);
                        //隐藏文本框放id
                        var cityid = $("#<%=ddlcity.ClientID %>").val();
                        $("#<%=selectcity.ClientID %>").val(cityid);
                        var tid = $("#<%=ddlcity.ClientID %>").select().val();
                        if (tid != "") {
                            $.ajax({
                                url: '../Data/data.aspx',
                                type: 'POST',
                                data: {
                                    type: "select",
                                    locationid: tid,
                                    tmp:1
                                },
                                success: function (result) {
                                    $("#<%=ddleurozone.ClientID %>").html(result);
                                    var eurozoneid = $("#<%=ddleurozone.ClientID %>").val();
                                    $("#<%=selecteurozone.ClientID %>").val(eurozoneid);
                                }
                            })
                        }
                    }
                }
            });
        });
        $("#<%=ddleurozone.ClientID %>").change(function () {
            var eurozoneid = $(this).val();
            $("#<%=selecteurozone.ClientID %>").val(eurozoneid);
        })
        </script>  
</asp:Content>
