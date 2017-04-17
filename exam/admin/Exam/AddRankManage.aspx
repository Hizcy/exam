<%@ Page Title="添加用户" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRankManage.aspx.cs" Inherits="Exam_AddRankManage_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/stacks.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.7.2.min.js">  </script>
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
              <div class="title"><span style="color:#37CBBA">配置管理<</span><span> 添加用户</span></div>
                   <div class="topSelDiv userImportMain">
                       <div class="guanli">
                        <input type="text" style=" float:left;font-size:8px;width:200px;height:20px" id='menu' placeholder="在此添加一级菜单"  />
                        <input type="button" value="添加"  style="width:50px;font-size:8px;height:24px;border-radius:4px; border:0px;background-color:#464d77;color:white;margin-left:8px;margin-right:-10px" onclick="Add(0,0)" />  
                       </div>                    
               
                     <table class="table table-condensed table-hover customerTab">
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
   
    <script>
        //修改节点
        function Endit(num, parentId,ttname, pass, ismunt) {
            if (num == 1) {
                layer.open({
                    title: '修改节点',
                    content: '<input type="text" id="text" />',
                    yes: function () {
                        var menuname = $("#text").val().trim();
                        if (menuname != "") {
                            $.ajax({
                                url: '../data/data.aspx',
                                type: "POST",
                                data: {
                                    type: "enditquestionmenu",
                                    parentId: parentId,
                                    name: menuname,
                                    pass: 0,
                                    ismust: 0
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
            else {
                layer.open({
                    title: '修改节点',
                    content: "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名称：<input type=\"text\" value=\"" + ttname + "\" id=\"text\" /><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 积分：<input type=\"text\" value=\"" + pass + "\" id=\"txtjf\"/><br/>",
                    yes: function () {
                        var menuname = $("#text").val().trim();
                        var tpass = $("#txtjf").val().trim();
                        if (menuname != "") {
                            $.ajax({
                                url: '../data/data.aspx',
                                type: "POST",
                                data: {
                                    type: "enditquestionmenu",
                                    parentId: parentId,
                                    name: menuname,
                                    pass: tpass,
                                    ismust: 0
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
        }
        //添加
        function Add(num,parentId) {
            if (num == -1) {
                alert("最多三级");
                return;
            }
            if (parentId == 0) {
                var menu = $("#menu").val().trim();
                if (menu == "") {
                    alert("不能为空值！");
                    return;
                }
                $.ajax({
                    url: '../data/data.aspx',
                    type: "POST",
                    data: {
                        type: "addquestionmenu",
                        parentId: parentId,
                        name: menu,
                        pass: 0,
                        ismust: 0
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
                //添加二级
                if (num == 1) {
                    layer.open({
                        title: "添加子节点",
                        content: '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 名称：<input type="text" id="text" /><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 积分：<input type="text" id="txtjf"/><br/>',
                        yes: function () {
                            var menu = $("#text").val().trim();
                            var pass = $("#txtjf").val().trim();
                            if (menu == "") {
                                alert("请填写名称！");
                                ret;
                            }
                            if (isNaN(pass)) {
                                alert("积分请填写整数！");
                                ret;
                            }
                            $.ajax({
                                url: '../data/data.aspx',
                                type: "POST",
                                data: {
                                    type: "addquestionmenu",
                                    parentId: parentId,
                                    name: menu,
                                    pass: pass,
                                    ismust:0
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
                    });
                }
                //添加普通级别
                else {
                    layer.open({
                        title: "添加子节点",
                        content: '<input type="text" id="text" />',
                        yes: function () {
                            var menu = $("#text").val().trim();
                            if (menu != "") {
                                $.ajax({
                                    url: '../data/data.aspx',
                                    type: "POST",
                                    data: {
                                        type: "addquestionmenu",
                                        parentId: parentId,
                                        name: menu,
                                        pass: 0,
                                        ismust: 0
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
        }
        //删除
        function Delete(parentId) {
            var flag = confirm("确定删除！");
            if(flag){ 
                $.ajax({
                url: '../data/data.aspx',
                type: "POST",
                data: {
                    type: "deletequestionmenu",
                    parentId: parentId
                },
                error: function () {
                    writeError("删除失败！");
                },
                success: function (result) {
                    if (result == 1) {
                        location.reload(true);
                    }
                }});
             }
        }
    </script>
</asp:Content>

