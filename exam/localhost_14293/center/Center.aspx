<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Center.aspx.cs" Inherits="center_Center" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.7.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
              
    <div class="span9 setRigth" style="float:left">
      <div class="setRigthContentg">
          <div class="row examManagerRowr">
            <div class="span3 userAddRowLeft" >
                <div class="cont-arear clearfix"  id="jiben" >
            	   <ul class="listUl">
                            <li>
                                <div class="t-blockxinxi" >
                                   <h4 >
                                        <span class="l" style="border-bottom:2px solid #2FC6B5;margin-bottom:5px;color:#2FC6B5">&nbsp;&nbsp;个人基本信息&nbsp;&nbsp;</span>      
                                   </h4>
                                   <div class="cont">
                       		            <p>
                                        <span class="t">账号：</span>
                                        <span class="c"><%=user %></span>
                                        </p>
                                         <p>
                                        <span class="t">姓名：</span> 
                                        <span class="c"><%=name %></span>
                                        </p>
                                        <p>
                                        <span class="t">部门：</span> 
                                        <span class="c"><%=position %></span>
                                        </p>
                                       <p>
                                        <span class="t">性别：</span>
                                        <span class="c"><%=sex %></span>
                                        </p>
                                       <p>
                                        <span class="t">手机：</span>
                                        <span class="c"><%=phone %></span>
                                        </p>
                                       <p>
                                        <span class="t">邮箱：</span>
                                        <span class="c"><%=mail %></span>
                                        </p>
                                        <p>
                                        <span class="t">班级：</span>
                                        <span class="c"><%=description %></span>
                                        </p>
                                  
                                   </div>
                                </div>
                            </li>
                   </ul>                    
               </div> 
                   <div class="cont-arear clearfix" style="display:none" id="xiugai" >
            	   <ul class="listUl">
                            <li>
                                <div class="t-blockxinxi" >
                                   <h4 >
                                        <span class="l" style="border-bottom:2px solid #2FC6B5;margin-bottom:5px;color:#2FC6B5">&nbsp;&nbsp;修改密码&nbsp;&nbsp;</span>      
                                   </h4>
                                   <div class="cont">
                       		            <p>
                                        <span class="t">原始密码：</span>
                                            <asp:TextBox ID="txtpass" runat="server" style="width:190px;height:24px" TextMode="Password"></asp:TextBox>
                                        </p>
                                         <p>
                                        <span class="t">新的密码：</span>
                                            <asp:TextBox ID="txtnewpass" runat="server" style="width:190px;height:24px" TextMode="Password"></asp:TextBox>
                                        </p>
                                        <p>
                                        <span class="t">确认密码：</span>
                                           <asp:TextBox ID="txtpasswordSafe" runat="server" style="width:190px;height:24px" TextMode="Password"></asp:TextBox>
                                        </p>
                                       <div style="text-align:center">
                                            <asp:Button ID="btnSave" runat="server" Text="保存" style="width:100px;height:24px;border:0;color:#fff;background-color:#2FC6B5" OnClick="btnSave_Click"/>
                                       </div>
                                   </div>
                                </div>
                            </li>
                   </ul>                    
               </div>                    
            </div>
               <div class="span3 userAddRowLeftr" >
                <div class="cont-arearb clearfix" >
                    <p id="btnin" style="width:120px;height:30px;border:0;line-height:30px;text-align:center;background-color:#2FC6B5;color:#fff">个人基本信息</p>
                    <p id="btnpass" style="width:120px;height:30px;border:0;margin-top:20px;line-height:30px;text-align:center;background-color:#898989;color:#fff">修改密码</p>
                </div>                  
            </div>
              
        </div>
    </div>
</div>
    <script>
        $(function () {
            $("#btnin").click(function () {
                $("#jiben").css("display", "block");
                $("#btnin").css("background-color", "#2FC6B5");
                $("#xiugai").css("display", "none");
                $("#btnpass").css("background-color", "#898989");
            });
            $("#btnpass").click(function () {
                $("#jiben").css("display", "none");
                $("#btnin").css("background-color", "#898989");
                $("#xiugai").css("display", "block");
                $("#btnpass").css("background-color", "#2FC6B5");
            });
        });

    </script>
</asp:Content>

