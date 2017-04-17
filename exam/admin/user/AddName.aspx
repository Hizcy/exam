<%@ Page Title="添加用户" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddName.aspx.cs" Inherits="user_AddName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <div class="span9 setRigth" style="float:left">
      <div class="setRigthContent">
          <div class="title"><span style="color:#37CBBA">用户管理<</span><span> 添加用户</span></div>
          <div class="row examManagerRow">
            <div class="span3 userAddRowLeft"> 
              <br/>
               <label class="placeholder" for="user_name">用户名</label>
                <asp:TextBox ID="txtname" runat="server" style="width:66px"></asp:TextBox><asp:TextBox ID="txtdomain" runat="server" style="width:100px" Text="" ></asp:TextBox>                    
              <br/>
              <div class="ss"> <%if(UserId>0){ %>
                <span >是否修改密码</span>                  
                <asp:RadioButton ID="radselect" CssClass="endit" runat="server"  GroupName="select" style="margin-left:10px;width:30px" Width="50px"  /><span style="margin-left:10px">修改</span>
                <asp:RadioButton ID="radselect2" CssClass="notendit" GroupName="select" runat="server" style="margin-left:30px"/><span style="margin-left:10px">不修改</span>
                <%} %></div>
                <br/>
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
                <span  style="margin-left:36px">性别</span>                  
                <asp:RadioButton ID="male" runat="server"  GroupName="sex" style="margin-left:18px;width:30px" Width="50px"  /><span style="margin-left:20px">男</span>
                <asp:RadioButton ID="female"  GroupName="sex" runat="server" style="margin-left:30px"/><span style="margin-left:20px">女</span>
                </div>             
              <br/>
                <table style="width:500px;margin-left:50px" >
                    <tr>
                        <td style="width:210px"><span style="float:right">所属部门</span></td>
                        <td  style="width:290px"> 
                            <a href="javascript:select()" style="text-decoration:none"><asp:Label ID="labdepartment" style="color:#464d77;font-weight:bold;float:left;margin-left:15px"  runat="server" Text="选择部门"></asp:Label>
                                <img src="../images/icon6.gif" style="float:left;margin-left:5px;margin-top:3px"/>
                            </a>
                            <asp:TextBox ID="hiddepartmentId" style="display:none" runat="server"></asp:TextBox>
                            <asp:TextBox ID="hidname" style="display:none" runat="server"></asp:TextBox>
                           <%-- <asp:HiddenField ID="hiddepartmentId" runat="server" />--%>
                        </td>
                    </tr>
                </table>
                <br />
                <label class="placeholder" for="position" >角色</label>
                <asp:DropDownList ID="ddlrole" runat="server">
                    <asp:ListItem Value="3">学生</asp:ListItem>
                    <asp:ListItem Value="2">老师</asp:ListItem>
                    <asp:ListItem Value="1">管理员</asp:ListItem>
                </asp:DropDownList>
                <br />
              <label class="placeholder" for="status">用户状态</label>
                <asp:DropDownList ID="ddlstatus" runat="server">
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
            <p class="buttonP">
                <asp:Button ID="btnSave" class="button1" runat="server" Text="确定" OnClientClick="btnSave()" OnClick="btnSave_Click" />
            	&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" class="button2" runat="server" Text="取消" />
            	
            </p>
                </div>
          </div>
      </div>
    </div>
    <input type="text" style="display:none" id="selectdepartment" />
    <input type="text" style="display:none" id="hiddepartment" />
    <script>
        $(".endit").change(function () {
            $("#div").css("display", "initial");
        });
        $(".notendit").change(function () {
            $("#div").css("display", "none");
        })
        //<span style="color:#464d77;font-weight:bold;float:left;margin-left:15px" id="selectdepartment">选择部门</span><img src="../images/icon6.gif" style="float:left;margin-top:2px;" />
        function select() {
            layer.open({
                area: ['800px', '500px'],
                title: '选择部门',
                type: 2,
                content: "AddDepartment.aspx",
                end: function () {
                    var id = document.getElementById("hiddepartment").value;
                    if(id != "")
                    {
                        document.getElementById("<%=hiddepartmentId.ClientID %>").value = id;
                        document.getElementById("<%=labdepartment.ClientID %>").innerHTML = document.getElementById("selectdepartment").innerText;
                        document.getElementById("<%=hidname.ClientID %>").value=document.getElementById("selectdepartment").innerText;;
                    }
                }
            })
        }
        $(function () {
            var s = "<%=UserId %>";
            if (parseInt(s) > 0)
           {
                $(".ss:first").css("display","block");
            }
            else
            {
                $(".ss:first").css("display","none");
            }
            var userid = "<%=UserId %>";
            if (parseInt(userid) > 0) {
                $("#div").css("display", "none");
                var id = $("#<%=hiddepartmentId.ClientID %>").val();
                $("#hiddepartment").val(id);
                document.getElementById("selectdepartment").innerHTML = document.getElementById("<%=labdepartment.ClientID %>").innerText;//班级名称 
            }
        })
        //保存
        function btnSave() {
            //用户名
            var name = $("#<%=txtname.ClientID %>").val();
            //密码
            var userid = "<%=UserId %>";
            var pwd = $("#<%=txtpassword.ClientID %>").val();
            var pwd2 = $("#<%=txtpasswordSafe.ClientID %>").val();
            //姓名
            var admin = $("#<%=txtrealname.ClientID%>").val();
            //性别
            var sex = -1;
            if ($("#<%=male.ClientID %>").is(":checked")) {
                sex = 1;
            }
            else if ($("#<%=female.ClientID %>").is(":checked")) {
                sex = 0;
            }
            //部门
            var departmentid = -1;
            if (document.getElementById("hiddepartment").value != "") {
                departmentid = document.getElementById("hiddepartment").value;
            }
            //部门名
            var departmentname = document.getElementById("selectdepartment").innerText;
            //角色
            var role = $("#<%=ddlrole.ClientID %>").select().val();
            if (name == "") {
                alert("请填写用户名！");
                window.event.returnValue = false;
                return;
            }
            if (userid == 0 || $("#<%=radselect.ClientID %>").is(":checked")) {
                if (pwd == "" || pwd2 == "") {
                    alert("请填写密码！");
                    window.event.returnValue = false;
                    return;
                }
                if (pwd != pwd2) {
                    alert("两次密码不同！");
                    window.event.returnValue = false;
                    return;
                }
            }
            if (admin == "") {
                alert("请选填写姓名！");
                window.event.returnValue = false;
                return;
            }
            if (sex != 0 && sex != 1) {
                alert("请选选择性别！");
                window.event.returnValue = false;
                return;
            }
            if (parseInt(role) == 3) {
                if (departmentid == -1) {
                    alert("请选择部门!");
                    window.event.returnValue = false;
                    return;
                }
                else if (departmentname.indexOf("1班") < 0 && departmentname.indexOf("2班") < 0 && departmentname.indexOf("3班") < 0 && departmentname.indexOf("4班") < 0 && departmentname.indexOf("5班") < 0 && departmentname.indexOf("6班") < 0 && departmentname.indexOf("7班") < 0 && departmentname.indexOf("8班") < 0 && departmentname.indexOf("9班") < 0) {
                    alert("角色与部门不匹配！");
                    window.event.returnValue = false;
                }
            }
            //取出部门第一个字 
            if ((parseInt(role) == 1 || parseInt(role) == 2) && departmentid != -1) {
                var tdepartmentname = departmentname.substring(0, 1);
                if (tdepartmentname.indexOf("一") >= 0 || tdepartmentname.indexOf("二") >= 0 || tdepartmentname.indexOf("三") >= 0 || tdepartmentname.indexOf("四") >= 0 || tdepartmentname.indexOf("五") >= 0 || tdepartmentname.indexOf("六") >= 0 || tdepartmentname.indexOf("七") >= 0 || tdepartmentname.indexOf("八") >= 0 || tdepartmentname.indexOf("九") >= 0) {
                    if (parseInt(role) == 1) {
                        alert("角色与部门不匹配!");
                        window.event.returnValue = false;
                        return;
                    }
                    else if (departmentname.indexOf("年级") >= 0) {
                        if (parseInt(role) == 2) {
                            alert("角色与部门不匹配!");
                            window.event.returnValue = false;
                            return;
                        }
                    }
                }
            }
        }
    </script>
</asp:Content>

