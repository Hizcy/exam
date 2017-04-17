<%@ Page Title="批量导入用户" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ImportName.aspx.cs" Inherits="user_ImportName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
              <div class="title"><span style="color:#37CBBA">用户管理<</span><span> 批量导入用户</span></div>
                   <div class="topSelDiv userImportMain">
                       <div class="xuanze">
                      <%--   <span style="font-size:15px;font-weight:bold;">选择部门:</span>&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:select()" style="text-decoration:none"><span style="color:#464d77;font-size:13px" id="selectdepartment">选择部门</span><img src="../images/icon6.gif" style="margin-bottom:2px;margin-left:5px"  /></a><br />
                           <input type="text" id="hiddepartment" value="" style="display:none" /><br />--%>
                         <span  style="font-size:15px;font-weight:bold;">选择文件:</span><input id="btnxz" type="button" onclick="fs()"  class="btnxz"  style="text-align:center;color:white;height:20px;" value="选择文件" />&nbsp;&nbsp;<span style="color:red" id="file" >(必须使用提供模板导入)</span><br />
                           <asp:FileUpload ID="uploadInput" runat="server" style="display:none" />
                           <%--<span style="font-size:15px;font-weight:bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;角色:</span>
                            &nbsp;&nbsp;<asp:DropDownList ID="dlljs" runat="server" style="width:100px">
                                <asp:ListItem Value="1">管理员</asp:ListItem>
                                <asp:ListItem Value="2">老师</asp:ListItem>
                                <asp:ListItem Value="3">学生</asp:ListItem>
                            </asp:DropDownList>--%>
                       </div>
                       
                         <hr />
                        <div class="import">
                            <img src="../images/leading.png" />&nbsp;&nbsp;导入说明：
                            <p>1、如果用户名已经存在，不导入这个用户，返回未成功用户列表。 </p>
                            <p>2、请选择用户列表文件： 选择文件 (必须使用提供的模板导入)。</p>
                            <p>3、点击下载 <a class="button" href="../images/template-for-user-add.xls" id="" ><b>模板文件</b></a> 后，按以下格式进行填写，填写完毕后保存上传即可。</p>                                                            
                       </div>
                       <hr />
                        <div class="memo">
                                <img src="../images/attention.png" />&nbsp;&nbsp;注意：
                                <p>1.用户名（必填）：长度不超过64位字符，包括字母、数字、下划线、横线，不区分大小写 </p>
                                <p>2.密码（必填）：长度6-20位字符，至少两类字符（字母、数字、特殊符号）,区分大小写</p>
                                <p>3.姓名（必填）：不超过20位字符，只支持字母和数字，不支持特殊符号</p>
                                <p>4.性别（必填）：男或者女</p>
                                <p>5.电子邮箱：长度不超过64位字符，包括字母、数字、下划线、横线，不区分大小写</p>
                                <p>6.证件号码：长度不超过64位字符，包括字母、数字、下划线、横线，不区分大小写</p>
                                <p>7.手机号码：长度不超过20位</p>                                        
                            </div>
                                <p class="buttonP">
                                    <asp:Button ID="btnSave" runat="server"  class="button1" Text="保存" OnClick="Button1_Click" />
                                </p>
                         </div>
                   </div>
        </div>
    <input type="text" style="display:none" id="hid" runat="server" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <script>
        $("#btnxz").click(function () { $("#<%=uploadInput.ClientID %>").click(); })
        $("#<%=uploadInput.ClientID %>").bind("change", function () {
            $("#file").css("color", "rgb(0,0,0) ");
            $("#file").html($("#<%=uploadInput.ClientID %>").val());
        })
        function select() {
            layer.open({
                area: ['800px', '500px'],
                title: '选择部门',
                type: 2,
                content: "AddDepartment.aspx",
                //关掉之后
                end: function () {
                    var department = $("#hiddepartment").val();
                    if (department != "") {
                        $("#<%=hid.ClientID %>").val(department);
                    }
                }
            })
        }
    </script>
</asp:Content>

