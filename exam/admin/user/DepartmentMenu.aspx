<%@ Page Title="部门配置" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepartmentMenu.aspx.cs" Inherits="book_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/stacks.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.2.min.js">  </script>
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
              <div class="title"><span style="color:#37CBBA">配置管理<</span><span> 配置管理</span><<span>部门配置</span></div>
                   <div class="topSelDiv userImportMain">
                      <%-- <div class="guanli">
                        <input type="text" style=" float:left;font-size:8px;width:200px;height:20px" id='menu' placeholder="在此添加一级菜单"  />
                        <input type="button" value="添加"  style="width:50px;font-size:8px;height:24px;border-radius:4px; border:0px;background-color:#464d77;color:white;margin-left:8px;margin-right:-10px" onclick="Add(0)" />  
                       </div>                    
               --%>
                     <table class="table table-condensed table-hover customerTab" style="margin-top:0px">
                                        <thead>
                                          <tr>
                                            <th style=" width:66%;">主菜单名称</th>
		                                    <th class="norightborder" style=" width:34%;">操作</th>
                                          </tr>
                                        </thead>                                                         
                        </table>
                              <%=TableCss(schoolId) %> 
                         </div>
                   </div>
        </div>




<%-- <div class="contentbox">
       <div style="margin-top:20px;margin-bottom:10px"><span style="color:#37CBBA;margin-left:44px;font-size:14px;font-family:Microsoft YaHei"><b>配置管理<</b></span><span style="font-size:14px;font-family:Microsoft YaHei"><b>添加用户</b></span></div>
   
      <div class="msgWrap form">   
            <div style="border:1px solid #d3d3d3;width:667px;margin-right:71px;float:right;">
         <div style="margin:10px">
                <input type="text" style=" margin-left:40px;float:left;font-size:8px;width:200px;height:20px" id='menu' placeholder="在此添加一级菜单"  />
                <input type="button" value="添加"  style="width:50px;font-size:8px;height:24px;border-radius:4px; border:0px;background-color:#464d77;color:white;margin-left:8px;margin-right:-10px" onclick="Add(0)" />
     
         </div>
   </div>
        <table  cellspacing="0" cellpadding="0" border="0" class="ListProduct" style="margin-left:230px;border-left:#d3d3d3 1px solid;width:668px;"> 
	        <thead>
	            <tr>
		            <th style=" width:66%;">主菜单名称</th>
		            <th class="norightborder" style=" width:34%;">操作</th>
	            </tr>
	       </thead>
            </table>
        <%=TableCss(schoolId) %>
      
	</div>
 </div>--%>
   <script>
       //修改节点
       function Endit(departmentid) {

           layer.open({
               title: '修改节点',
               content: '<input type="text" id="text" />',
               yes: function () {
                   var menuname = $("#text").val();
                   if (menuname != "") {
                       $.ajax({
                           url: '../data/data.aspx',
                           type: "POST",
                           data: {
                               type: "enditmenu",
                               departmentid: departmentid,
                               name: menuname
                           },
                           error: function () {
                               writeError("编辑失败！");
                           },
                           success: function (result) {
                               if (result == 1) {
                                   location.reload(true);
                               }
                           }
                       });
                   }
               }
           });
       }
       //添加
       function Add(departmentid) {
           if (departmentid == -1) {
               alert("最多三级");
               return;
           }
           if (departmentid == 0) {
               var menu = $("#menu").val();
               if (menu == "") {
                   alert("不能为空值！");
                   return;
               }
               $.ajax({
                   url: '../data/data.aspx',
                   type: "POST",
                   data: {
                       type: "addmenu",
                       departmentid: departmentid,
                       name: menu
                   },
                   error: function () {
                       writeError("添加失败！");
                   },
                   success: function (result) {
                       if (result == 1) {
                           location.reload(true);
                       }
                   }
               })
           }
           else {
               layer.open({
                   title: "添加子节点",
                   content: '<input type="text" id="text" />',
                   yes: function () {
                       var menu = $("#text").val();
                       if (menu != "") {
                           $.ajax({
                               url: '../data/data.aspx',
                               type: "POST",
                               data: {
                                   type: "addmenu",
                                   departmentid: departmentid,
                                   name: menu
                               },
                               error: function () {
                                   writeError("添加失败！");
                               },
                               success: function (result) {
                                   if (result == 1) {
                                       location.reload(true);
                                   }
                               }
                           });
                       }
                   }
               });
           }
       }
       //删除
       function Delete(departmentid) {
           $.ajax({
               url: '../data/data.aspx',
               type: "POST",
               data: {
                   type: "deletemenu",
                   departmentid: departmentid
               },
               error: function () {
                   writeError("删除失败！");
               },
               success: function (result) {
                   if (result == 1) {
                       location.reload(true);
                   }
               }
           });
       }
    </script>
</asp:Content>

