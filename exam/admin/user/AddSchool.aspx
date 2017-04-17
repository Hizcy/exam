<%@ Page Title="添加学校" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddSchool.aspx.cs" Inherits="user_AddSchool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <div class="span9 setRigth" style="float:left">
      <div class="setRigthContent">
          <div class="title"><span style="color:#37CBBA">用户管理<</span><span> 添加学校</span></div>
          <div class="row examManagerRow">
            <div class="span3 userAddRowLeft"> 
              <br/>
                <div id="divym">
                    <label class="placeholder" for="surname">域名</label>  
                        <asp:TextBox ID="txtdomain" runat="server" CssClass="inputtextym color9" style="color:#707070;width:110px" BorderColor="#bfbfbf"></asp:TextBox>
                       <asp:DropDownList ID="ddldomain" runat="server" placeholder="将作为账号后缀" CssClass="inputtextymlb color9"  BorderColor="#bfbfbf"  style="width:60px;height:35px">
                            <asp:ListItem Value=".com">.com</asp:ListItem>
                            <asp:ListItem Value=".cn">.cn</asp:ListItem>
                            <asp:ListItem Value=".net">.net</asp:ListItem>
                            <asp:ListItem Value=".org">.org</asp:ListItem>
                            <asp:ListItem Value=".so">.so</asp:ListItem>
                            <asp:ListItem Value=".com.cn">.com.cn</asp:ListItem>
                            <asp:ListItem Value=".gov.cn">.gov.cn</asp:ListItem>
                            <asp:ListItem Value=".edu.cn">.edu.cn</asp:ListItem>
                            <asp:ListItem Value=".co">.co</asp:ListItem>
                            <asp:ListItem Value=".me">.me</asp:ListItem>
                        </asp:DropDownList>
                    <%--<label class="placeholder" for="user_name">域名</label>
                    <asp:TextBox ID="txtdomain" runat="server" style="width:166px" placeholder="只能添加，不能修改！" ></asp:TextBox>               
                    <br/>--%>
                 </div>
                 <label class="placeholder" for="surname">学校</label>
                <asp:TextBox ID="txtname" runat="server" style="width:172px"></asp:TextBox>
              <br/> 
                 <label style="color:#707070">地区</label>
                                    <select id="ddlprovince" runat="server" style="width:172px;height:35px" ></select><br />
                                    <select id="ddlcity" runat="server" style="width:172px;height:35px;margin-left: 108px;" >
                                        <option value="0">市</option>
                                    </select><br />
                                    <select id="ddleurozone" runat="server" style="width:172px;height:35px;margin-left: 108px;" >
                                        <option value="0">县/区</option>
                                    </select>
                                	<br />
              <label class="placeholder" for="status" >状态</label>
                <asp:DropDownList ID="ddlstatus" style="height:35px" runat="server">
                    <asp:ListItem Value="1">正常</asp:ListItem>
                    <asp:ListItem Value="0">禁用</asp:ListItem>
                </asp:DropDownList>
              <br/>
                <label class="placeholder" for="status" >代理商</label>
                <asp:DropDownList ID="dllagent" style="height:35px" runat="server">
                </asp:DropDownList>
              <br/>
                <label class="placeholder" for="surname">姓名</label>
                <asp:TextBox ID="txtrealname" runat="server" style="width:172px"></asp:TextBox>
              <br/> 
                <%if(schoolId==0) {%>
                <label class="placeholder" for="surname">性别</label>
                <asp:RadioButton ID="male" runat="server"  GroupName="sex" style="margin-left:18px;width:30px" Width="50px"  /><span style="margin-left:20px;color:#707070">男</span>
                <asp:RadioButton ID="female"  GroupName="sex" runat="server" style="margin-left:30px"/><span style="margin-left:20px;color:#707070">女</span>
              <br/> <p></p><%} %>
                 <label class="placeholder" for="surname">电话</label>
                <asp:TextBox ID="txtphone" runat="server" style="width:172px"></asp:TextBox>
              <br/> 

              <label class="placeholder" for="email">电子邮件</label>
                <asp:TextBox ID="txtemail" runat="server" style="width:172px"></asp:TextBox>          
              <br/>          
            <div style="margin-top:20px;margin-bottom:50px" class="buttonP">
                <asp:Button ID="btnSave" class="button1" runat="server" Text="确定" OnClick="btnSave_Click" OnClientClick="btnSave()"/>
            	&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" class="button2" runat="server" Text="取消" />
            	
            </div>
                </div>
          </div>
      </div> 
        
    <asp:TextBox ID="selectcity" runat="server" OnLoad="selectcity_Load" style="display:none"  ></asp:TextBox>
    <asp:TextBox ID="selecteurozone" runat="server" OnLoad="selecteurozone_Load" style="display:none" ></asp:TextBox>
        <script>
            function btnSave() {
                //域名
                var domain = $("#<%=txtdomain.ClientID %>").val();
                //学校名
                var school = $("#<%=txtname.ClientID %>").val();
                //地区
                var city = $("#<%=ddlcity.ClientID %>").val();
                //姓名
                var name = $("#<%=txtrealname.ClientID %>").val();
                //姓别
                var sex = -1;
                if ($("#<%=male.ClientID %>").is(":checked")) {
                    sex = 1;
                }
                else if($("#<%=female.ClientID %>").is(":checked")){
                    sex = 0;
                }
                //电话
                var phone = $("#<%=txtphone.ClientID %>").val();
                //邮件
                var mail = $("#<%=txtemail.ClientID %>").val();
                if (domain == "") {
                    alert("请填写域名!");
                    event.returnValue = false;
                    return;
                }
                if (school == "") {
                    alert("请填写学校名！");
                    event.returnValue = false;
                    return;
                }
                if (parseInt(city) == 0) {
                    alert("请选择地区！");
                    event.returnValue = false;
                    return;
                }
                if (name == "") {
                    alert("请填写用户名！");
                    event.returnValue = false;
                    return;
                }
                var schoolid = "<%=schoolId %>";
                if (parseInt(schoolid) == 0) {
                    if (sex != 0 && sex != 1) {
                        alert("请选选择性别！");
                        window.event.returnValue = false;
                        return;
                    }
                }
                if (phone == "") {
                    alert("请填写电话号码！");
                    event.returnValue = false;
                    return;
                }
                if (mail == "") {
                    alert("请填写邮箱");
                    event.returnValue = false;
                    return;
                }
            
            }
            $("#<%=ddlcity.ClientID %>").change(function () {
                var id = $(this).val();
                $.ajax({
                    url: '../Data/data.aspx',
                    type: 'POST',
                    data: {
                        type: "selectdepartment",
                        locationid: id,
                        tmp: 0
                    },
                    success: function (result) {
                        $("#<%=ddleurozone.ClientID %>").html(result);
                        //放置id
                        var city = $("#<%=ddlcity.ClientID %>").val();
                        $("#<%=selectcity.ClientID %>").val(city);
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
                        type: "selectdepartment",
                        locationid: id,
                        tmp: 0
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
                                    type: "selectdepartment",
                                    locationid: tid,
                                    tmp: 1
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

