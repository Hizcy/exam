<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adList.aspx.cs" Inherits="user_adList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="../css/customer.css" />
        <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
             <div class="title"><span style="color: #37CBBA">用户管理<</span><span> 广告配置</span></div>
             <div class="topSelDiv userImportMain">
                <div class="chaxun">
                    <span style="margin-left:22px">广告语：</span> <input type="text" id="txtContent" style="width:565px;height:25px" />
                    <span >广告链接：</span> <input type="text" id="url" style="width:565px;height:25px" />
                    <input type="text" id="txtid" style="display:none" />
                    <input type="button" id="btn_sever" class="btncx" style="float:right;margin:5px 13px 10px auto;font-size:8px" value="确定" />
                </div>
                 <table class="table table-condensed table-hover customerTab">
                    <thead>
                        <tr >
                        <%--<th>&nbsp;&nbsp;<input id="checkselect" type="checkbox" style="width:18px" />全选</th>   --%>
                            <th style="text-align:center;width:80px">角色</th>
                            <th style="text-align:center;width:70px">学校名</th>
                            <th style="text-align:center;width:90px">姓名</th>
                            <th style="text-align:center;width:140px">广告内容</th>
                            <th style="text-align:center;width:60px">广告图片</th>
                            <th style="width:30px;text-align:center;width:30px">状态</th>
                            <th style="width:30px;text-align:center;width:70px">添加时间</th>
                            <th style="text-align:center">操作</th>
                        </tr>
                    </thead> 
                     <%--<tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到相关部门的数据！</th></tr>--%>
                    <asp:Repeater ID="rptResultsList" runat="server">
                        <ItemTemplate>             
                            <tr >
                            <%--<td style="border:1px solid;width:50px">&nbsp;&nbsp;<input id='<%#Eval("id") %>' name="check" type="checkbox" class="check" style="width:18px" /></td>--%>
                            <td style="text-align:center"><%#rodeName(int.Parse(Eval("RoleId").ToString())) %></td>
                            <td style="text-align:center"><%#Eval("name").ToString() %></td>
                            <td style="text-align:center"><%#Eval("RealName") %></td>
                            <td style="text-align:center"><%#Eval("AdContent").ToString().Length>7?Eval("AdContent").ToString().Substring(0,7)+"……":Eval("AdContent") %></td>
                            <td style="text-align:center">暂未启用</td>
                            <td style="text-align:center"><%#int.Parse(Eval("Status").ToString()) == 1?"启用":"停用" %></td>
                            <td style="text-align:center"><%#Eval("addtime").ToString().Substring(0,Eval("addtime").ToString().IndexOf(' ')) %></td>
                            <td> 
                                <a href="javascript:updatead(<%#Eval("id") %>)"><img src="../images/edit.png" /></a> 
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
        //----------添加广告语 /修改 $("#txtid").val(); 值为"" 说明 添加
        $("#btn_sever").click(function () {
            var adContent = $("#txtContent").val();
            if(adContent=="")
            {
                alert("请填写要添加的广告语！");
                return;
            }
            var adLink = $("#url").val();
            if (adLink == "") {
                alert("请填写广告链接！");
                return;
            }
            var adId = $("#txtid").val();
            $.ajax({
                url: "../data/data.aspx",
                type: "POST",
                data: {
                    type: "addad",
                    adcontent: adContent,
                    adLink: adLink,
                    adid: adId
                },
                success: function (result) {
                    if (result == 1)
                        location.reload();
                    else if (result == 2)
                        alert("添加失败！");
                    else if (result == 3)
                        alert("修改失败！");
                }
            })
        })
        //--------修改赋值
        function updatead(id) {
            $.ajax({
                url: "../data/data.aspx",
                type: "POST",
                data: {
                    type: "updatead",
                    id: id
                },
                success: function (result) {
                    if (result != "") {
                        var arr = result.split('+');
                        $("#txtContent").val(arr[0]);
                        $("#url").val(arr[1]);
                        $("#txtid").val(id);
                    }
                }
            })
        }
        //--删除
        function deletead(id) {
            $.ajax({
                url: "../data/data.aspx",
                type: "POST",
                data: {
                    type: "deletead",
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

