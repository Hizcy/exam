<%@ Page Title="分析人员成绩" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Personnel.aspx.cs" Inherits="count_Personnel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/customer.css" />
      <script src="http://localhost:14764/js/jquery-1.7.2.min.js">  </script>
      <script src="../layer/layer.js"></script>
        <link href="../css/prettify.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="../js/jquery.min.js"></script>
        <script type="text/javascript" src="../js/FusionCharts.js"></script>
        <script type="text/javascript" src="../js/prettify.js"></script>
        <script type="text/javascript" src="../js/json2.js"></script>
        <script type="text/javascript" src="../js/lib.js" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="span9 setRigth" style="float:left">
         <div class="setRigthContent">
              <div class="title"><span style="color:#37CBBA">统计管理<</span><span>分析人员成绩</span></div>
                   <div class="topSelDiv userImportMain">
      <div class="setRigthContent"  style="min-height:500px">
             <div >
                <span >选择考试：</span>&nbsp;&nbsp;
                <a href="javascript:select()" style="text-decoration:none"><asp:Label ID="labdepartment" style="color:#464d77;font-weight:bold;margin-left:5px"  runat="server" Text="选择部门"></asp:Label>
                    <img src="../images/icon6.gif" />
                </a>
               <asp:HiddenField ID="hiddepartmentId" runat="server" />
               <asp:HiddenField ID="hiddepartmentName" runat="server" />
          </div>
            
          <div class="topContent">
              <table width="100%" border="0"  style="background-color:#003264; color:#fff; font-size:12px; text-align:center; margin-top:10px; margin-bottom:10px; display:none " class="simpleUserTab">
                  <tr style="height:30px">
                    <td class="user_name"></td>
                    <td style=" background-color:#fff; width:1px"></td>
                    <td class="surname"></td>
                    <td style=" background-color:#fff; width:1px"></td>
                    <td class="department_name"></td>
                    <td style=" background-color:#fff; width:1px"></td>
                    <td class="sex"></td>
                  </tr>
                </table>
          </div>
          <div class="topSelDiv chartContent" style="display:none">
          	<a class="button toolbarBtn changeChart1" href="javascript:;" num="chart1" type="line" style="width:60px">线图</a>
            <a class="button toolbarBtn changeChart1" href="javascript:;" num="chart1" type="column" style="width:60px">柱图</a>
          	<div id="chart1" style="min-width:600px;height:400px"></div>
            <a class="button toolbarBtn addUser_chart1" href="javascript:;" num="chart1" style="width:80px">添加对比</a>
            <a class="button toolbarBtn addExam_chart1" href="javascript:;" num="chart1" style="width:80px">选择考试</a>
        
          </div>

      </div>
    </div>
  </div>
           </div>
     <input type="text" style="display:none" id="selectdepartment" />
        <input type="text" style="display:none" id="hiddepartment" />
      <script>
          function select() {
              layer.open({
                  area: ['800px', '500px'],
                  title: '选择部门',
                  type: 2,
                  content: "AddDepartment.aspx",
                  end: function () {
                      var id = document.getElementById("hiddepartment").value;
                      document.getElementById("<%=hiddepartmentId.ClientID %>").value = id;
                      document.getElementById("<%=labdepartment.ClientID %>").innerHTML = document.getElementById("selectdepartment").innerText;
                      document.getElementById("<%=hiddepartmentName.ClientID %>").value = document.getElementById("selectdepartment").innerText;
                  }
              })
          }


    </script>
</asp:Content>

