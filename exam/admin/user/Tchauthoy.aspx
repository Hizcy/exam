<%@ Page Title="教师权限" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Tchauthoy.aspx.cs" Inherits="user_Tchauthoy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/customer.css" />
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../layer/layer.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 10%;
            height: 34px;
        }
        .auto-style2 {
            width: 60%;
            height: 34px;
        }
        .auto-style3 {
            width: 30%;
            height: 34px;
        }
        .auto-style4 {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="span9 setRigth" style="float: left">
        <div class="setRigthContent">
            <div class="title"><span style="color: #37CBBA">用户管理<</span><span> 配置管理</span><<span> 教师权限</span></div>
            <div class="topSelDiv userImportMain">
                <div class="jiansuo">
                    <span>选择老师</span>
                    <asp:DropDownList ID="ddlname" runat="server" Style="width: 85px; margin-top: 6px; font-size: 8px" AppendDataBoundItems="true" Height="24px" AutoPostBack="True" OnSelectedIndexChanged="ddlname_SelectedIndexChanged" ></asp:DropDownList>
                    <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                            <a href="javascript:select()" style="text-decoration:none"><span style="color:#464d77;font-size:8px;margin-left:-5px" id="selectdClass">选择年级</span><img src="../images/icon6.gif" style="margin-bottom:2px;margin-left:-2px"  /></a>
                            <input type="text" id="hid" style="display:none"  />

                    <asp:Button ID="btncx" runat="server" CssClass="btncx" Text="查询" Style="float: right; margin-right: 24px; margin-top: 8px; font-size: 8px" OnClick="btncx_Click" />
                </div>
                <table class="table table-condensed table-hover customerTabjs">
                     <thead>
                        <tr>
                            <th style="width:1%;text-align:right"><input type="checkbox" class="radioOrCheck checkSimple" id="ckqx" value="" /> </th>
                            <th style="width:69%">班级名称</th>
                            <th style="width:30%">所属班级</th>
                        </tr>
                    </thead>
                     <%--  <%if(i==1){ %>--%>
                        <tr><th colspan="8" style="font-size:20px;text-align:center;height:30px;line-height:50px;">暂无找到该老师的相关数据！</th></tr>
                    <%-- <%}else{ %>   --%>
                    <asp:Repeater ID="rptclass" runat="server" >
                            <ItemTemplate>
                                <tr>
                                    <td style="width:10%;text-align:right"><input type="checkbox" class="radioOrCheck checkSimple" name="chkItem" id="<%#Eval("DepartmentId") %>" value="<%#Eval("DepartmentId") %>" ></td>
                                    <td style="width:60%"><%#Eval("name") %></td>
                                    <td style="width:30%"><%#Eval("parentname") %></td>
                                </tr>
                            </ItemTemplate>                                                         
                    </asp:Repeater>
                      <%-- <%} %>--%>
                 </table>
              <%--   <%if(i==1){ %>
                      <%}else{ %>--%>
                  <p class="buttonjs" style="margin-top:10px;">
                      <asp:Button ID="btn_qd" runat="server" Text="确定" class="button1"  OnClick="Button1_Click" />
            	&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" class="button2" runat="server" Text="取消" />
            </p>
                <%-- <%} %>--%>
              </div> 
        </div>
     </div>
    <%-- 选择班级所选项id --%>
    <asp:TextBox ID="hidselect"  style="display:none" runat="server"></asp:TextBox>
    <%-- 班级名：用于固定选择班级名 --%>
    <asp:TextBox ID="hidname" style="display:none" runat="server"  ></asp:TextBox>
    <%-- 所有班级修改/选中id 用来付初始值 --%>
    <asp:TextBox ID="hidclassid"  style="display:none" runat="server" ></asp:TextBox>
    <script>
        
       $(function () {
           var classname = $("#<%=hidname.ClientID %>").val();
           if (classname != "") {
               document.getElementById("selectdClass").innerHTML = classname;
           }
           var classid = $("#<%=hidclassid.ClientID%>").val();
           if (classid != "")
           {
               classid = "," + classid + ",";
               $("table .radioOrCheck").each(function () {
                   if (classid.indexOf("," + $(this).val() + ",") >= 0) {
                       $(this).attr("checked", "checked");
                   }
               });
           }
        })
       //选择班级
        function select() {
            layer.open({
                area: ['600px', '350px'],
                title: '可批量选择班级：按住Ctrl鼠标点击',
                type: 2,
                content: "AddClass.aspx",
                //关掉之后
                end: function () {
                    var id = document.getElementById("hid").value;
                    var classname = document.getElementById("selectdClass").innerText;
                    $("#<%=hidselect.ClientID %>").val(id);
                    $("#<%=hidname.ClientID %>").val(classname);
                }
            })
        }
        //当前教师所教班级
        var DepartmentId = $("#<%=hidclassid.ClientID %>").val();
        //加","方便对比
        if (DepartmentId != "") {
            DepartmentId =  DepartmentId + ",";
        }
        //全选
        $("#ckqx").bind("click", function () {
            //当前显示的所有班级数组
            var arr = $("[name = chkItem]");
            if ($(this).is(":checked")) {
                //给所有显示班级添加选中状态
                $("[name = chkItem]:checkbox").attr("checked", true);
                DepartmentId = "," + DepartmentId;
                //遍历当前显示的所有班级
                arr.each(function () {
                    //当前checked 的Value值
                    var id = "," + $(this).val() + ",";
                    //查找是否存在
                    if (DepartmentId.indexOf(id) < 0)
                        DepartmentId += $(this).val() + ",";//全选后所有的Departmentid 值
                });
                $("#<%=hidclassid.ClientID %>").val(DepartmentId);
            }
            else {
                $("[name = chkItem]:checkbox").attr("checked", false);
                arr.each(function () {
                    var tid = $(this).val() + ",";
                    DepartmentId = DepartmentId.replace(tid, "");
                });
                //if (DepartmentId.length == 1) {
                //    DepartmentId = "";
                //}
                $("#<%=hidclassid.ClientID %>").val(DepartmentId);
            }
        });
        //去掉全选 同时去掉相应id/添加相应id
        $("[name=chkItem]").change(function () {
            $("#ckqx").attr("checked", false);
            var flag = $(this).is(":checked");
            //去掉相应id
            if (flag == false) {
                var id = $(this).val() + ",";
                DepartmentId = DepartmentId.replace(id, "");
                $("#<%=hidclassid.ClientID %>").val(DepartmentId);
            }
            else {
                //天加相应id
                var tid = $(this).val() + ",";
                DepartmentId += tid ;
                $("#<%=hidclassid.ClientID %>").val(DepartmentId);
            }
        })
    </script>
</asp:Content>

