<%@ Page Title="检测设置" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Formed.aspx.cs" Inherits="Exam_Formed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="span9 setRigth">
      <div class="setRigthContent">
          <div class="title"><span style="color:#37CBBA">考试管理< </span><span style="color:#000000">题库信息<</span><span>检测设置</span></div>
               <div class="topSelDiv userImportMain">
                   <div class="title">试卷数据</div>
                  <span style="margin-left:35px">试卷分类：</span>
                  <a href="javascript:select1()" style="text-decoration:none"><span style="color:#464d77;font-size:13px" id="selectdepartment">选择书库</span><img src="../images/icon6.gif" style="margin-bottom:2px;margin-left:5px"  /></a><br />
                            <input type="text" id="hiddepartment" value="" style="display:none"  /><asp:TextBox ID="txthid"  style="display:none"  runat="server"></asp:TextBox><asp:TextBox ID="txtcontent" style="display:none" runat="server"></asp:TextBox><br />
                          <span style="margin-left:34px;">试卷名称：</span>
                          <asp:TextBox ID="txtname" runat="server" style="width:200px;margin-top: 10px;font-size: 8px;" Enabled="false"></asp:TextBox>    
                  `          <asp:TextBox ID="txthidname" runat="server" style="display:none"></asp:TextBox>
                          <span style="margin-left:10px">试卷状态：</span>
                         <asp:DropDownList ID="ddlstatus" runat="server" Style="width: 56px;margin-top: 10px;font-size: 8px;" AppendDataBoundItems="true" Height="24px">
                                    <asp:ListItem Value="1">正常</asp:ListItem>
                                    <asp:ListItem Value="0">禁用</asp:ListItem>
                          </asp:DropDownList>
                          <span style="margin-left:10px">组卷方式：</span>
                            <asp:DropDownList ID="ddltype" runat="server" Style="width: 100px;margin-top: 10px;font-size: 8px;" AppendDataBoundItems="true" Height="24px">
                                    <asp:ListItem Value="0"> 随机组卷</asp:ListItem>
                          </asp:DropDownList>   
                         
                           <span style="margin-left:35px">答卷时长：</span>
                          <asp:TextBox ID="txttime" runat="server" style="width:50px;margin-top: 10px;font-size: 8px;"></asp:TextBox>        
                          <span id="exam_timeText">分钟</span>  
                        <span style="margin-left:30px"> 及格分数：</span>
                          <asp:TextBox ID="txtscore" runat="server" style="width:50px;margin-top: 10px;font-size: 8px;"></asp:TextBox>    
                          分
                     
                        <br />
                    <div style="border-top:1px #827c7c dotted"></div>
                          <div class="title">题型设置</div>
                          <ul class="addIconUl">
                            <li ><a id="a1dx" style="text-decoration:none"><img src="../images/add.png" />单选</a></li>
                            <li ><a id="a2dx" style="text-decoration:none"><img src="../images/add.png" />多选</a></li>
                            <li ><a id="a3pd" style="text-decoration:none"><img src="../images/add.png" />判断</a></li>
                            <li ><a id="a4tk" style="text-decoration:none"><img src="../images/add.png" />填空</a></li>
                          </ul>
                       

          <!--选题组卷-->
          <table class="table table-condensed table-hover customerTab tab3">
            <thead>
              <tr>
                <th>排序</th>
                <th>题型</th>
                <th>数量</th>
                <th class="contentTh">题型标题</th>
                <th>每题分数</th>
                <th>试题分类</th>
                <th>抽取数量</th>
              </tr>
            </thead>
            <tbody class="typeTabBody">
                <%=tempstr %>
            </tbody> 
          </table>
          <p class="buttonP" style="margin-top:10px"> 
          <asp:Button ID="btnSave" class="btnnbc" runat="server" Text="保存" OnClientClick="check()" OnClick="btnSave_Click" />    	
          </p>
      </div>
    </div>
    <asp:TextBox ID="hid" style="display:none" runat="server"></asp:TextBox>
    
  <script>
      var id = 0;
      $(function () {
          id =  $(".tr").length;
      })
      $("#a1dx").click(function () {
          id++;
          $(".typeTabBody").append("<tr class=\"tr\" id=\"tr"+id+"\">"
                                    +"<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                    + "<td ><input id=\"txttype" +id+"\" type=\"text\"  style=\"display:none\" value=\"1\" /><span>单选</span></td>"
                                    + "<td ><span id=\"num" +id+"\">0</span></td>"
                                    + "<td ><input id=\"txttile" + id + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" type=\"text\" style=\"width:50px\" /></td>"
                                    + "<td><a href=\"javascript:selectExam("+id+")\" style=\"text-decoration:none\"><span id=\"select"+id+"\">选择试题</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" id=parentid"+id+" /> </td>"
                                    + "<td><a href=\"javascript:extractNum(1," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\"  style=\"display:none\" id=hid" + id + " /></td></tr>");
      })
      $("#a2dx").click(function () {
          id++;
          $(".typeTabBody").append("<tr class=\"tr\" id=\"tr" + id + "\">"
                                    + "<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                    + "<td ><input id=\"txttype" + id + "\" type=\"text\"  style=\"display:none\" value=\"2\" /><span>多选</span></td>"
                                    + "<td ><span id=\"num" + id + "\">0</span></td>"
                                    + "<td ><input id=\"txttile" + id + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" type=\"text\" style=\"width:50px\" /></td>"
                                    + "<td><a href=\"javascript:selectExam(" + id + ")\" style=\"text-decoration:none\"><span id=\"select" + id + "\">选择试题</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" id=parentid" + id + " /> </td>"
                                    + "<td><a href=\"javascript:extractNum(2," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\"  style=\"display:none\" id=hid" + id + " /></td></tr>");
      })
      $("#a3pd").click(function () {
          id++;
          $(".typeTabBody").append("<tr class=\"tr\" id=\"tr" + id + "\">"
                                    + "<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                    + "<td ><input id=\"txttype" + id + "\" type=\"text\"  style=\"display:none\" value=\"3\" /><span>判断</span></td>"
                                    + "<td ><span id=\"num" + id + "\">0</span></td>"
                                    + "<td ><input id=\"txttile" + id + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" type=\"text\" style=\"width:50px\" /></td>"
                                    + "<td><a href=\"javascript:selectExam(" + id + ")\" style=\"text-decoration:none\"><span id=\"select" + id + "\">选择试题</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" id=parentid" + id + " /> </td>"
                                    + "<td><a href=\"javascript:extractNum(3," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\"  style=\"display:none\" id=hid" + id + " /></td></tr>");
      })
      $("#a4tk").click(function () {
          id++;
          $(".typeTabBody").append("<tr class=\"tr\" id=\"tr" + id + "\">"
                                    + "<td ><img src=\"../images/substract.png\" onclick=\"deleteTxt(" + id + ")\" /></td>"
                                    + "<td ><input id=\"txttype" + id + "\" type=\"text\"  style=\"display:none\" value=\"4\" /><span>填空</span></td>"
                                    + "<td ><span id=\"num" + id + "\">0</span></td>"
                                    + "<td ><input id=\"txttile" + id + "\" type=\"text\" style=\"width:200px\" /></td><td ><input id=\"txtnum" + id + "\" type=\"text\" style=\"width:50px\" /></td>"
                                    + "<td><a href=\"javascript:selectExam(" + id + ")\" style=\"text-decoration:none\"><span id=\"select" + id + "\">选择试题</span><img src=\"../images/icon6.gif\" style=\"margin-bottom:2px;margin-left:5px\"  /></a><input type=\"text\" style=\"display:none\" id=parentid" + id + " /> </td>"
                                    + "<td><a href=\"javascript:extractNum(4," + id + ")\" style=\"text-decoration:none\">抽取数量</a> <input type=\"text\"  style=\"display:none\" id=hid" + id + " /></td></tr>");
      })
      //上移暂不用
      function up(num) {
          var num1 = num - 1;
          if (num > 1) {
              var node1 = $("#style table[id=table"+num+"]")[0];
              var node2 = $("#style table[id=table" + num1 + "]")[0];
              var nodeTmp = node1.outerHTML;
              node1.outerHTML = node2.outerHTML;
              node2.outerHTML = nodeTmp;
          }
      }
      //删除元素
      function deleteTxt(num) {
          //var num = document.getElementById("num" + id + "").innerHTML;//当前个数
          //alert(num);
          $("table tbody tr").remove("#tr" + num + "");
      }
      //抽取数量type单多判填id唯一标
      function extractNum(type,id) {
          var questionclsid = $("#parentid" + id + "").val();//取出id值根据id查询题数
          if (questionclsid == "") {
              alert("请选择试题！");
              return;
          }
          layer.open({
              area: ['450px', '200px'],
              title: '抽取数量',
              type: 2,
              content: "ExtractNumber.aspx?questionclsid=" + questionclsid + "&type=" + type + "&id=" + id,
              //关掉之后
              end: function () {
                  //var num = document.getElementById("num" + id + "").innerHTML;
              }
          })
      }
      //选择试题
      function selectExam(id) {
          var tkid = $("#<%=txthid.ClientID %>").val();
          if (tkid == "") {
              alert("请选择书库");
              return;
          }
          layer.open({
              area: ['300px', '190px'],
              title: '选择题库',
              type: 2,
              content: "QuestionManage3.aspx?id=" + id + "&tkid=" + tkid,
              //关掉之后
              end: function () {
                 document.getElementById("hid" + id + "").value = "";//添加完成之后付空值
              }
          })
      }
      var str = "";//不能去掉会报错
      function check() {
          var tname = $("#<%=txtname.ClientID %>").val();
          if (tname == "")
          {
              alert("试卷名称不能为空");
              event.returnValue = false;
          }
          var str = "";//不能去掉会报错
          str += "[";
          $(".tr").each(function () {
              str += "{"
              $(this).find("input").each(function () {
                  if (this.id.indexOf("txttype") >= 0)
                  {
                      str += "\"type\":\"" + $(this).val() + "\",";
                  }
                  else if (this.id.indexOf("txttile") >= 0)
                  {
                      str += "\"title\":\"" + $(this).val() + "\",";
                  }
                  else if (this.id.indexOf("txtnum") >= 0) {
                      str += "\"score\":\"" + $(this).val() + "\",";
                  }
                  else if (this.id.indexOf("parentid")>=0) {
                      str += "\"clsid\":\"" + $(this).val() + "\",";
                  }
                  else if (this.id.indexOf("hid") >= 0) {
                      str += $(this).val() ;
                  }
              });
              str += "},";
          });
          str = str.substr(0,str.length-1);
          str += "]";
          //alert(str);
          $("#<%=hid.ClientID %>").val(str);
          //event.returnValue = false;
      }
      //选择试题
      function select() {
          layer.open({
              area: ['800px', '500px'],
              title: '选择题库',
              type: 2,
              content: "QuestionManage.aspx?sole=1",
              //关掉之后
              end: function () {
                  var  test = window.parent.document.getElementById("selectdepartment").innerText;
                  var id = $("#hiddepartment").val();
                  $("#<%=txthid.ClientID %>").val(id);
                  $("#<%=txtcontent.ClientID %>").val(test);
              }
          })
      }
      //选择书库
      function select1() {
          layer.open({
              area: ['600px', '350px'],
              title: '选择书库',
              type: 2,
              content: "QuestionManage2.aspx?sole=1",
              //关掉之后
              end: function () {
                  var test = window.parent.document.getElementById("selectdepartment").innerText;
                  var bookname = document.getElementById("selectdepartment").innerHTML;
                  var id = $("#hiddepartment").val();
                  $("#<%=txtname.ClientID %>").val(bookname);
                  $("#<%=txthidname.ClientID %>").val(bookname);
                  $("#<%=txthid.ClientID %>").val(id);
                  $("#<%=txtcontent.ClientID %>").val(test);
              }
          })
      }
      $(function () {
          var name = "<%=namek %>";
          if (name != "") {
              window.parent.document.getElementById("selectdepartment").innerHTML = name;
              $("#<%=txtname.ClientID %>").val(name);
              $("#<%=txthidname.ClientID %>").val(name);
          }
          var content = $("#<%=txtcontent.ClientID %>").val();
          if (content != "") {
              window.parent.document.getElementById("selectdepartment").innerHTML = content;
              $("#<%=txtname.ClientID %>").val(content);
              $("#<%=txthidname.ClientID %>").val(content);
          }
      })
  </script>
</asp:Content>

