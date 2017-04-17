<%@ Page Title="添加代理商" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddAgent.aspx.cs" Inherits="user_AddAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
    <script src="../layer/layer.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <div class="span9 setRigth" style="float:left">
      <div class="setRigthContent">
          <div class="title"><span style="color:#37CBBA">用户管理<</span><span> 添加代理商</span></div>
          <div class="row examManagerRow">
            <div class="span3 userAddRowLeft"> 
              <br/>
               <label class="placeholder" for="user_name">用户名</label>
                <asp:TextBox ID="txtname" runat="server" style="width:66px"></asp:TextBox><asp:TextBox ID="txtdomain" runat="server" style="width:100px" Text="" ></asp:TextBox>                    
              <br/>
                <%if(UserId>0) {%>
              <div class="ss">
                <span style="margin-left:-20px" >是否修改密码</span>   
            	    <input type="radio" name="radxg" class="endit" style="margin-left:20px;"  /><span style="margin-left:10px">修改</span>
                    <input type="radio" name="radxg" class="notendit" style="margin-left:10px;" checked="checked"  /> <span style="margin-left:10px">不修改</span>              
                </div>
              <br/>
                <%} %>
                <div id="div">
                <label class="placeholder" for="password">密码</label>
                        <asp:TextBox ID="txtpassword" runat="server" style="width:172px" TextMode="Password"></asp:TextBox>
                    <br/>
                    <label class="placeholder" for="passwordSafe">确认密码</label>
                    <asp:TextBox ID="txtpasswordSafe" runat="server" style="width:172px" TextMode="Password"></asp:TextBox>
                    <br/>
              </div>
                 <label class="placeholder" for="surname">姓名</label>
                <asp:TextBox ID="txtrealname" runat="server" style="width:172px"></asp:TextBox>
              <br/>
                <div class="ss">
                <span  style="margin-left:0px">性别</span>    
                    <input type="radio" name="sex"  class="man" value="1" style="margin-left:25px;"  /><span style="margin-left:10px">男</span>
                    <input type="radio" name="sex" class="nv" value="0" style="margin-left:10px;"  /> <span style="margin-left:10px">女</span>    
                </div>             
              <br/>
                <br />
                <label class="placeholder" for="position" >角色</label>
                <asp:DropDownList ID="ddlRole" runat="server" Height="35px" >
                    <asp:ListItem Value="5">代理商</asp:ListItem>
                    <asp:ListItem Value="2">老师</asp:ListItem>
                    <asp:ListItem Value="3">学生</asp:ListItem>
                    <asp:ListItem Value="1">管理员</asp:ListItem>
                </asp:DropDownList>
                <br />
              <label class="placeholder" for="status">用户状态</label>
                <asp:DropDownList ID="ddlstatus" runat="server" Height="35px">
                    <asp:ListItem Value="1">正常</asp:ListItem>
                    <asp:ListItem Value="0">禁用</asp:ListItem>
                </asp:DropDownList>
              
              <br/>
              <label class="placeholder" for="position">职位</label>
                <asp:TextBox ID="txtposition" runat="server" style="width:172px"></asp:TextBox>
                <br />
              <label class="placeholder" for="email">电子邮件</label>
                <asp:TextBox ID="txtemail" runat="server" style="width:172px"></asp:TextBox>          
              <br/>
              <label class="placeholder" for="identity_card">手机号码</label>
                <asp:TextBox ID="txtphone" runat="server" style="width:172px"></asp:TextBox>
              <br/>           
              <label class="placeholder" for="notice">备注</label>
                <asp:TextBox ID="txtnotice" runat="server" style="width:172px"></asp:TextBox>
              <br/>    
                <div style="margin-bottom:50px;margin-top:20px">
            <p class="buttonP">
                <input type="button" class="button1" value="确定" onclick="btnSave()" />
            	&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" class="button2" runat="server" Text="取消" />
            </p>
                    </div>       
                </div>
          </div>
      </div>
    </div>
    
    <script>
        $(".endit").change(function () {
            $("#div").css("display", "initial");
        });
        $(".notendit").change(function () {
            $("#div").css("display","none");
        })
       <%-- $(function () {
            var s = "<%=UserId %>";
            if (parseInt(s) > 0) {
                $(".ss:first").css("display", "block");
            }
            else {
                $(".ss:first").css("display", "none");
            }
        })--%>
        function btnSave() {
            //用户名
            var name = $("#<%=txtname.ClientID %>").val();
            //密码
            var password = $("#<%=txtpassword.ClientID %>").val();
            //确认密码
            var passwordSafe = $("#<%=txtpasswordSafe.ClientID %>").val();
            //姓名
            var realname = $("#<%=txtrealname.ClientID %>").val();
            //职位
            var position = $("#<%=txtposition.ClientID %>").val();
            //邮件
            var email = $("#<%=txtemail.ClientID %>").val();
            //电话
            var phone = $("#<%=txtphone.ClientID %>").val();
            //备注
            var notice = $("#<%=txtnotice.ClientID %>").val();
            //状态
            var status = $("#<%=ddlstatus.ClientID %> ").val();
            //角色
            var role = $("#<%=ddlRole.ClientID %>").val();
            //性别
            var sex = -1;
            $("input:radio[name='sex']").each(function () {
                if ($(this).is(":checked")) {
                    sex = $(this).val();
                }
            })
            var userid = "<%=UserId %>";
            if (parseInt(userid) == 0) {
                if (name == "") {
                    alert("用户名不能为空！");
                    return;
                }
                if (password == "") {
                    alert("密码不能为空！");
                    return;
                }
                if (passwordSafe == "" || passwordSafe != password) {
                    alert("两次密码不相同！");
                    return;
                }
                if (realname == "") {
                    alert("请填写真实姓名");
                    return;
                }
                if (sex == -1) {
                    alert("请选择性别！");
                    return;
                }
                if (position == "") {
                    alert("职位不能为空！");
                    return;
                }
                if (phone == "") {
                    alert("电话不能为空！");
                    return;
                }
            }
            else {
                var boolCheck = $('input:radio[class="endit"]').is(":checked");
                if (boolCheck) {
                    if (password == "") {
                        alert("密码不能为空！");
                        return;
                    }
                    if (passwordSafe == "" || passwordSafe != password) {
                        alert("两次密码不相同！");
                        return;
                    }
                }
                if (realname == "") {
                    alert("请填写真实姓名");
                    return;
                }
                if (position == "") {
                    alert("职位不能为空！");
                    return;
                }
                if (phone == "") {
                    alert("电话不能为空！");
                    return;
                }
            }
            $.ajax({
                url: '../Data/data.aspx',
                type: "POST",
                data:{
                    type: "addagent",
                    name: name,
                    password: password == "" ? 0 : password,
                    realname: realname,
                    sex: sex,
                    role: role,
                    status: status,
                    position: position,
                    email: email,
                    phone: phone,
                    notice: notice == "" ? 0 : notice,
                    userid: userid
                },
                success: function (v) {
                    if (v == "1") {
                        window.location.href = "ListAgent.aspx";
                    }
                    else if (v == "2") {
                        window.location.href = "ListAgent.aspx";
                    }
                }
            })
        }
        $(function () {
            var sex = "<%=sex %>";
            if (sex != -1) {
                if (parseInt(sex) == 1) {

                    $(".man").attr("checked", "checked");
                }
                else {
                    $(".nv").attr("checked", "checked");
                }
            }
            var id = "<%=UserId %>";
            if (parseInt(id) > 0) {
                $("#div").css("display", "none");
            }
        })
    </script>
</asp:Content>

