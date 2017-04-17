<%@ Page Title="录入试题" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Addtestqm.aspx.cs" Inherits="Exam_EnteringLibrary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/customer.css" />
    <script src="../ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../ueditor/ueditor.all.js" type="text/javascript"></script>
    <script src="../ueditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script> 
    <script type="text/javascript" src="../js/bootstrap.js"></script> 
    <script src="../layer/layer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="span9 setRigth">
      <div class="setRigthContent">
          <div class="title"><span style="color:#37CBBA">考试管理< </span><span style="color:#000000">组织考试<</span><span>录入试题</span></div>
               <div class="topSelDiv userImportMain">       
               
                   <div id="dandao" style="display:block">
                    <div id="divn" runat="server" class="divdd">
                        <a id="daoti" class="btndanti" runat="server" >单题导入</a>
                        <a id="piliang" class="btnduoti" runat="server" >多题批量导入</a>         	
                   </div>
                   <div class="title">试卷数据</div>   
                        <div style="margin-left:34px">
                            <span >选择题库：</span>&nbsp;&nbsp;
                            <a href="javascript:select()" style="text-decoration:none"><span style="color:#464d77;font-size:13px" id="selectdepartment">选择题库</span><img src="../images/icon6.gif" style="margin-bottom:2px;margin-left:5px"  /></a><br />
                            <input type="text" id="hiddepartment" value="" style="display:none" /><br />
                            <span >试题分类：</span>
                             <asp:DropDownList ID="ddlFirst" runat="server" style="width: 80px;font-size: 8px;margin-top: 10px;" AppendDataBoundItems="true" Height="24px">
                                  <asp:ListItem Value="1">单选</asp:ListItem>
                                  <asp:ListItem Value="2">多选</asp:ListItem>
                                  <asp:ListItem Value="3">判断</asp:ListItem>
                                  <asp:ListItem Value="4">填空</asp:ListItem>
                             </asp:DropDownList>       
                          <span style="margin-left:10px">选项数目：</span>
                         <asp:DropDownList ID="ddlnub" runat="server" Style="width: 50px;font-size: 8px;margin-top: 10px;" AppendDataBoundItems="true" Height="24px">
                                     <asp:ListItem Value="4"> </asp:ListItem>
                                     <asp:ListItem Value="1"> </asp:ListItem>
                                     <asp:ListItem Value="2"> </asp:ListItem>
                                     <asp:ListItem Value="3"> </asp:ListItem>
                                     <asp:ListItem Value="4"> </asp:ListItem>
                                     <asp:ListItem Value="5"> </asp:ListItem>
                                     <asp:ListItem Value="6"> </asp:ListItem>
                                     <asp:ListItem Value="7"> </asp:ListItem>
                                     <asp:ListItem Value="8"> </asp:ListItem>
                          </asp:DropDownList>
                          <span style="margin-left:10px">试题难度：</span>
                            <asp:DropDownList ID="ddlharder" runat="server" Style="width: 60px;font-size: 8px;margin-top: 10px;" AppendDataBoundItems="true" Height="24px">
                                    <asp:ListItem Value="0">简单</asp:ListItem>
                                    <asp:ListItem Value="1"> 困难</asp:ListItem>
                          </asp:DropDownList>                        
                          <span style="margin-left:10px">试题状态：</span>
                         <asp:DropDownList ID="ddlstatus" runat="server" Style="width: 70px;font-size: 8px;margin-top: 10px;" AppendDataBoundItems="true" Height="24px">
                                    <asp:ListItem Value="1"> 正常</asp:ListItem>
                                    <asp:ListItem Value="0"> 禁用</asp:ListItem>
                          </asp:DropDownList>
                       </div>  <br />
                    <div style="border-top:1px #827c7c dotted"></div>
                          <div class="title">试题描述</div>  
                              <div>  
                                 <script id="editorms" name="myContent" type="text/plain" style="width:574px;height:100px;margin-left:40px">
                                   </script>
                              </div> 
                          <div class="title">答案选项</div>
                               <%--单选--%> 
                               <div id="danxuan" style="display:block">
                                        <div id="A" style="display:block">                 
                                            <span style="margin-left:40px">A</span><asp:RadioButton ID="raidaA" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                            <script id="editordaxa" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div>
                                        <div id="B" style="margin-left:300px;margin-top:-162px;display:block">
                                                <span style="margin-left:40px">B</span><asp:RadioButton ID="raidaB" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                                <script id="editordaxb" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div>
                                        <div id="C" style="display:block">
                                            <span style="margin-left:40px">C</span><asp:RadioButton ID="raidaC" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                            <script id="editordaxc" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div> 
                                        <div id="D" style="margin-left:300px;margin-top:-162px;display:block">
                                            <span style="margin-left:40px">D</span><asp:RadioButton ID="raidaD" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                            <script id="editordaxd" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div>
                                        <div id="E" style="display:none">                 
                                            <span style="margin-left:40px">E</span><asp:RadioButton ID="raidaE" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                            <script id="editordaxe" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div>
                                        <div id="F" style="margin-left:300px;margin-top:-162px;display:none">
                                                <span style="margin-left:40px">F</span><asp:RadioButton ID="raidaF" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                                <script id="editordaxf" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div>
                                        <div id="G" style="display:none">
                                            <span style="margin-left:40px">G</span><asp:RadioButton ID="raidaG" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                            <script id="editordaxg" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div> 
                                        <div id="H" style="margin-left:300px;margin-top:-162px;display:none">
                                            <span style="margin-left:40px">H</span><asp:RadioButton ID="raidaH" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                            <script id="editordaxh" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                        </div>
                                </div>
                               <%--多选--%> 
                              <div id="duoxuan" style="display:none">
                                  <div id="AA" style="display:block">
                                      <span style="margin-left:40px">A</span><asp:CheckBox ID="ckdA" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                      <script id="editorduxa" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div> 
                                  <div id="BB" style="margin-left:300px;margin-top:-162px;display:block">
                                      <span style="margin-left:40px">B</span><asp:CheckBox ID="ckdB" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                      <script id="editorduxb" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div>
                                  <div id="CC" style="display:block">
                                      <span style="margin-left:40px">C</span><asp:CheckBox ID="ckdC" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                      <script id="editorduxc" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div>          
                                  <div id="DD" style="margin-left:300px;margin-top:-162px;display:block">
                                     <span style="margin-left:40px">D</span><asp:CheckBox ID="ckdD" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                     <script id="editorduxd" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div>
                                  <div id="EE" style="display:none">
                                      <span style="margin-left:40px">E</span><asp:CheckBox ID="ckdE" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                      <script id="editorduxe" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div> 
                                  <div id="FF" style="margin-left:300px;margin-top:-162px;display:none">
                                      <span style="margin-left:40px">F</span><asp:CheckBox ID="ckdF" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                      <script id="editorduxf" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div>
                                  <div id="GG" style="display:none">
                                      <span style="margin-left:40px">G</span><asp:CheckBox ID="ckdG" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                      <script id="editorduxg" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div>          
                                  <div id="HH" style="margin-left:300px;margin-top:-162px;display:none">
                                     <span style="margin-left:40px">H</span><asp:CheckBox ID="ckdH" GroupName="correct" runat="server" style="width:50px;margin-left:-10px" />
                                     <script id="editorduxh" name="myContent" type="text/plain" style="width:230px;height:100px;margin-left:80px;margin-top:-20px"></script>
                                  </div>
                              </div>
                               <%--判断--%>  
                               <div id="pandaun" style="display: none">
                                    <asp:RadioButton ID="raidzq" GroupName="correct" runat="server" style="width:50px;margin-left:40px;" /><span>正确</span>
                                    <asp:RadioButton ID="raidcw" GroupName="correct" runat="server" style="width:50px"/><span>错误</span>                          
                                </div>              
                               <%--填空--%>
                                 <div id="tiankong" style="display:none">  
                                  <asp:TextBox ID="txttk" runat="server" style="width:576px;margin-left:40px"></asp:TextBox>
                           <%-- <input type="text" id="txttk" value="" runat="server" style="width:576px;margin-left:40px" />--%>
                                  </div>   
                               <%--问答--%>
                                <div id="wenda" style="display:none">  
                                    <script id="editorxx" name="myContent" type="text/plain" style="width:574px;height:100px;margin-left:40px">
                                    </script>
                                </div>       
                          <div class="title">试题解析</div>  
                              <div style="margin-bottom: 10px;">  
                                
                                     <script id="editorjx" name="myContent1" type="text/plain" style="width:574px;height:100px;margin-left:40px">
                                   </script>
                              </div>     
                            <p class="buttonP">
                                <input type="button" value="导入" class="btnnsave" id="btnSave" />	
                            </p> 
                                 	      
                  </div>
                   <div id="pilaing" style="display:none">
                        <div id="divnn" runat="server"  class="divdd">
                            <a id="daoti2"  class="btndanti2" runat="server" >单题导入</a>
                            <a id="piliang2"  class="btnduoti2" runat="server" >多题批量导入</a>         	
                       </div>
                         <div class="title">试卷数据</div>  
                        <div style="margin-left:34px">
                            <span >选择题库：</span>&nbsp;&nbsp;
                            <a href="javascript:selectdx()" style="text-decoration:none"><span style="color:#464d77;font-size:13px" id="dx" >选择题库</span><img src="../images/icon6.gif" style="margin-bottom:2px;margin-left:5px"  /></a><br /> 
                            <input type="text" id="hiddepartmentdx" value="" style="display:none" /><br />
                            <asp:TextBox ID="txthid" runat="server" style="display:none"></asp:TextBox>
                            <br />
                            <span >试题分类：</span>
                                 <asp:DropDownList ID="ddlType" runat="server" style="width: 80px;" AppendDataBoundItems="true" Height="24px">
                                      <asp:ListItem Value="1">单选</asp:ListItem>
                                      <asp:ListItem Value="2">多选</asp:ListItem>
                                      <asp:ListItem Value="3">判断</asp:ListItem>
                                      <asp:ListItem Value="4">填空</asp:ListItem>
                                 </asp:DropDownList>
                             <span style="margin-left:10px">试题难度：</span>
                                <asp:DropDownList ID="ddlDiff" runat="server" Style="width: 60px" AppendDataBoundItems="true" Height="24px">
                                        <asp:ListItem Value="0">简单</asp:ListItem>
                                        <asp:ListItem Value="1"> 困难</asp:ListItem>
                              </asp:DropDownList>                          
                        </div>  <br /> 
                        <div style="border-top:1px #827c7c dotted"></div> 
                          <div class="title">例题示范</div> 
                        <div style="margin-left:34px">
                            <p style="color:red">题号和选项支持1.</p>
                            <p style="color:red">每个选项需要另起一行，最多支持8个选项</p>
                            <p>1.驾驶人.有下列哪种违法行为一次记6分?</p>
                            <p>A.使用其他车辆行驶证</p>
                            <p>B.饮酒后驾驶机动车 </p>
                            <p>C.车速超过规定时速50%以上</p>
                            <p>D.违法占用应急车道行驶</p>
                            <p>解析: 请仔细阅读交规<span style="color:red">(若无解析也必须填写“解析:”)</span></p>
                            <p>答案:D</p>
                            <p style="color:red">(如果为多选题，答案这样录入--答案:A,B,C,D)</p>
                            <p style="color:red">注:所有标点符号必须英文半角符号！</p>
                        </div>  <br /> 
                        <div style="border-top:1px #827c7c dotted"></div> 
                        <div style="margin-left:34px">
                           <asp:TextBox ID="txtAdvantages" runat="server" Style="height: 200px; width: 580px; margin-top: 5px; border-style: solid; border-radius: 5px; border-color: #a9a7a7 #a9a7a7 #a9a7a7 #a9a7a7" TextMode="MultiLine" placeholder="请将当前所选题型的所有试题复制到这里"></asp:TextBox>
                        </div>
                          <p class="buttonP">
                             <%-- <input type="button" value="导入" class="btnnsave" id="btndSave" />--%>
                              <asp:Button runat="server" ID="btnnsave" CssClass="btnnsave" Text="导入" OnClientClick="Save()" OnClick="btnnsave_Click" />
                            </p>    
                   </div>
              </div>
        </div>
        <input type="text" style="display:none" id="hid" />
     <asp:TextBox ID="hidid" style="display:none" runat="server"></asp:TextBox>
    </div>
     <script language="javascript" type="text/javascript">
         var editordaxa = UE.getEditor('editordaxa');
         var editordaxb = UE.getEditor('editordaxb');
         var editordaxc = UE.getEditor('editordaxc');
         var editordaxd = UE.getEditor('editordaxd');
         var editordaxe = UE.getEditor('editordaxe');
         var editordaxf = UE.getEditor('editordaxf');
         var editordaxg = UE.getEditor('editordaxg');
         var editordaxh = UE.getEditor('editordaxh');
         var editorduxa = UE.getEditor('editorduxa');
         var editorduxb = UE.getEditor('editorduxb');
         var editorduxc = UE.getEditor('editorduxc');
         var editorduxd = UE.getEditor('editorduxd');
         var editorduxe = UE.getEditor('editorduxe');
         var editorduxf = UE.getEditor('editorduxf');
         var editorduxg = UE.getEditor('editorduxg');
         var editorduxh = UE.getEditor('editorduxh');
         var editorms = UE.getEditor('editorms');
         var editorxx = UE.getEditor('editorxx');
         var editorjx = UE.getEditor('editorjx');
         function htmlEncode(str) {
             var s = "";
             if (str.length == 0) return "";
             s = str.replace(/&/g, "&amp;");
             s = s.replace(/</g, "&lt;");
             s = s.replace(/>/g, "&gt;");
             s = s.replace(/'/g, "&apos;");
             s = s.replace(/"/g, "&quot;");
             return s;
         };
         //富文本编辑款
         $("#btnSave").click(function () {
             
             if ($("#<%=ddlFirst.ClientID %>").val() == 1)
                 {                    
                     var questionId = "<%=questionid %>";
                     var typef = $("#<%=ddlFirst.ClientID%>").val(); //获取试题类型的
                     var department = $("#hiddepartment").val();//获取题库
                     var contentms = UE.getEditor('editorms').getContent();//获取描述内容
                     //单选
                     var contentdaxa = UE.getEditor('editordaxa').getContent();//获取A内容
                     var contentdaxb = UE.getEditor('editordaxb').getContent();//获取B内容
                     var contentdaxc = UE.getEditor('editordaxc').getContent();//获取C内容
                     var contentdaxd = UE.getEditor('editordaxd').getContent();//获取D内容
                     var contentdaxe = UE.getEditor('editordaxe').getContent();//获取E内容
                     var contentdaxf = UE.getEditor('editordaxf').getContent();//获取F内容
                     var contentdaxg = UE.getEditor('editordaxg').getContent();//获取G内容 
                     var contentdaxh = UE.getEditor('editordaxh').getContent();//获取H内容
                     var harder = $("#<%=ddlharder.ClientID%>").val(); //获取试题难度
                     var status = $("#<%=ddlstatus.ClientID%>").val(); //获取试题状态
                     var contentjx = UE.getEditor('editorjx').getContent();//获取解析内容  
                 //判断选中项
                     var flagA = document.getElementById("<%=raidaA.ClientID %>").checked;
                     var flagB = document.getElementById("<%=raidaB.ClientID %>").checked;
                     var flagC = document.getElementById("<%=raidaC.ClientID %>").checked;
                 var flagD = document.getElementById("<%=raidaD.ClientID %>").checked;
                 var flagE = document.getElementById("<%=raidaE.ClientID %>").checked;
                 var flagF = document.getElementById("<%=raidaF.ClientID %>").checked;
                 var flagG = document.getElementById("<%=raidaG.ClientID %>").checked;
                 var flagH = document.getElementById("<%=raidaH.ClientID %>").checked;
                 var dd = "";
                 if (flagA) {

                     dd = "A";
                 }
                 if (flagB) {
                     dd = "B";
                 }
                 if (flagC) {
                     dd = "C";
                 }
                 if (flagD) {
                     dd = "D";
                 }
                 if (flagE) {
                     dd = "E";
                 }
                 if (flagF) {
                     dd = "F";
                 }
                 if (flagG) {
                     dd = "G";
                 }
                 if (flagH) {
                     dd = "H";
                 }

                     contentms = htmlEncode(contentms);
                     contentdaxa = htmlEncode(contentdaxa);
                     contentdaxb = htmlEncode(contentdaxb);
                     contentdaxc = htmlEncode(contentdaxc);
                     contentdaxd = htmlEncode(contentdaxd);
                     contentdaxe = htmlEncode(contentdaxe);
                     contentdaxf = htmlEncode(contentdaxf);
                     contentdaxg = htmlEncode(contentdaxg);
                     contentdaxh = htmlEncode(contentdaxh);        
                     contentjx = htmlEncode(contentjx);
                     $.ajax({
                         url: '../Data/data.aspx',
                         type: 'POST',
                         data: {
                             type: "addtestqmda",
                             questionId: questionId,
                             department:department,
                             typef: typef,
                             contentms: contentms,
                             //单选
                             contentdaxa: contentdaxa,
                             contentdaxb: contentdaxb,
                             contentdaxc: contentdaxc,
                             contentdaxd: contentdaxd,
                             contentdaxe: contentdaxe,
                             contentdaxf: contentdaxf,
                             contentdaxg: contentdaxg,
                             contentdaxh: contentdaxh,
                             harder: harder,
                             status:status,
                             contentjx: contentjx,
                             dd:dd,
                    
                         },
                         success: function (result) {
                             if (result == 1) {
                                 alert("录入试题成功");
                                 window.location.href = "ListLibrary.aspx";
                             }
                             else if (result == 2) {
                                 alert("修改试题成功");
                                 window.location.href = "ListLibrary.aspx";
                             }
                         },
                         error: function () {
                             writeError("服务端错误，请联系管理员");
                         }

                     });              
                 }
             else if ($("#<%=ddlFirst.ClientID %>").val() == 2)
             {
                 var questionId = "<%=questionid %>";
                 var typef = $("#<%=ddlFirst.ClientID%>").val(); //获取试题类型的
                 var department = $("#hiddepartment").val();//获取题库
                 var contentms = UE.getEditor('editorms').getContent();//获取描述内容
                 //多选
                 var contentduxa = UE.getEditor('editorduxa').getContent();//获取AA内容
                 var contentduxb = UE.getEditor('editorduxb').getContent();//获取BB内容
                 var contentduxc = UE.getEditor('editorduxc').getContent();//获取CC内容
                 var contentduxd = UE.getEditor('editorduxd').getContent();//获取DD内容
                 var contentduxe = UE.getEditor('editorduxe').getContent();//获取EE内容
                 var contentduxf = UE.getEditor('editorduxf').getContent();//获取FF内容
                 var contentduxg = UE.getEditor('editorduxg').getContent();//获取GG内容 
                 var contentduxh = UE.getEditor('editorduxh').getContent();//获取HH内容
                 var harder = $("#<%=ddlharder.ClientID%>").val(); //获取试题难度
                 var status = $("#<%=ddlstatus.ClientID%>").val(); //获取试题状态
                 var contentjx = UE.getEditor('editorjx').getContent();//获取解析内容  
                 //判断选中项
                 var flagA = document.getElementById("<%=ckdA.ClientID %>").checked;
                 var flagB = document.getElementById("<%=ckdB.ClientID %>").checked;
                 var flagC = document.getElementById("<%=ckdC.ClientID %>").checked;
                 var flagD = document.getElementById("<%=ckdD.ClientID %>").checked;
                 var flagE = document.getElementById("<%=ckdE.ClientID %>").checked;
                 var flagF = document.getElementById("<%=ckdF.ClientID %>").checked;
                 var flagG = document.getElementById("<%=ckdG.ClientID %>").checked;
                 var flagH = document.getElementById("<%=ckdH.ClientID %>").checked;
                 var dd = "";
                 if (flagA) {

                     dd = "A"+",";
                 }
                 if (flagB) {
                     dd += "B" + ",";
                 }
                 if (flagC) {
                     dd += "C" + ",";
                 }
                 if (flagD) {
                     dd += "D" + ",";
                 }
                 if (flagE) {
                     dd += "E" + ",";
                 }
                 if (flagF) {
                     dd += "F" + ",";
                 }
                 if (flagG) {
                     dd += "G" + ",";
                 }
                 if (flagH) {
                     dd += "H";
                 }
                 contentms = htmlEncode(contentms);
                 contentduxa = htmlEncode(contentduxa);
                 contentduxb = htmlEncode(contentduxb);
                 contentduxc = htmlEncode(contentduxc);
                 contentduxd = htmlEncode(contentduxd);
                 contentduxe = htmlEncode(contentduxe);
                 contentduxf = htmlEncode(contentduxf);
                 contentduxg = htmlEncode(contentduxg);
                 contentduxh = htmlEncode(contentduxh);
                 contentjx = htmlEncode(contentjx);
                 $.ajax({
                     url: '../Data/data.aspx',
                     type: 'POST',
                     data: {
                         type: "addtestqmdd",
                         questionId: questionId,
                         department: department,
                         typef: typef,
                         contentms: contentms,
                         //多选
                         contentduxa: contentduxa,
                         contentduxb: contentduxb,
                         contentduxc: contentduxc,
                         contentduxd: contentduxd,
                         contentduxe: contentduxe,
                         contentduxf: contentduxf,
                         contentduxg: contentduxg,
                         contentduxh: contentduxh,
                         harder: harder,
                         status: status,
                         contentjx: contentjx,
                         dd: dd,

                     },
                     success: function (result) {
                         if (result == 1) {
                             alert("录入试题成功");
                             window.location.href = "ListLibrary.aspx";
                         }
                         else if (result == 2) {
                             alert("修改试题成功");
                             window.location.href = "ListLibrary.aspx";
                         }
                     },
                     error: function () {
                         writeError("服务端错误，请联系管理员");
                     }

                 });
             }
             else if ($("#<%=ddlFirst.ClientID %>").val() == 3)
             {
                 var questionId = "<%=questionid %>";
                 var typef = $("#<%=ddlFirst.ClientID%>").val(); //获取试题类型的
                 var department = $("#hiddepartment").val();//获取题库
                 var contentms = UE.getEditor('editorms').getContent();//获取描述内容
                 var harder = $("#<%=ddlharder.ClientID%>").val(); //获取试题难度
                 var status = $("#<%=ddlstatus.ClientID%>").val(); //获取试题状态
                 var contentjx = UE.getEditor('editorjx').getContent();//获取解析内容 
                 var flagzq = document.getElementById("<%=raidzq.ClientID %>").checked;
                 var flagcw = document.getElementById("<%=raidcw.ClientID %>").checked;
                 var pd = "";
                 if (flagzq) {
                     pd = "1";                 
                 }
                 if (flagcw) {
                     pd = "0";
                 } 
                 contentms = htmlEncode(contentms);
                 contentjx = htmlEncode(contentjx);
                
                 $.ajax({
                     url: '../Data/data.aspx',
                     type: 'POST',
                     data: {
                         type: "addtestqmpd",
                         questionId: questionId,
                         department: department,
                         typef: typef,
                         contentms: contentms,
                         harder: harder,
                         status: status,
                         contentjx: contentjx,
                         pd: pd,
                     
                     },
                     success: function (result) {
                         if (result == 1) {
                             alert("录入试题成功");
                             window.location.href = "ListLibrary.aspx";
                         }
                         else if (result == 2) {
                             alert("修改试题成功");
                             window.location.href = "ListLibrary.aspx";
                         }
                     },
                     error: function () {
                         writeError("服务端错误，请联系管理员");
                     }

                 });
             }
             else if ($("#<%=ddlFirst.ClientID %>").val() == 4)
             {
                 
                 var questionId = "<%=questionid %>";
                 var typef = $("#<%=ddlFirst.ClientID%>").val(); //获取试题类型的
                 var department = $("#hiddepartment").val();//获取题库
                 var contentms = UE.getEditor('editorms').getContent();//获取描述内容
                 var harder = $("#<%=ddlharder.ClientID%>").val(); //获取试题难度
                 var status = $("#<%=ddlstatus.ClientID%>").val(); //获取试题状态
                 var contentjx = UE.getEditor('editorjx').getContent();//获取解析内容 
                 var txttk = $("#<%=txttk.ClientID %>").val();//获取答案
                 contentms = htmlEncode(contentms);
                 contentjx = htmlEncode(contentjx);
                
                 $.ajax({
                     url: '../Data/data.aspx',
                     type: 'POST',
                     data: {
                         type: "addtestqmtk",
                         questionId: questionId,
                         department: department,
                         typef: typef,
                         contentms: contentms,                  
                         harder: harder,
                         status: status,
                         contentjx: contentjx,
                         txttk: txttk,
                         
                     },
                     success: function (result) {
                         if (result == 1) {
                             alert("录入试题成功");
                             window.location.href = "ListLibrary.aspx";
                         }
                         else if (result == 2) {
                             alert("修改试题成功");
                             window.location.href = "ListLibrary.aspx";
                         }
                     },
                     error: function () {
                         writeError("服务端错误，请联系管理员");
                     }

                 });
             }
             
         })
      
        </script>                
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=ddlFirst.ClientID %>").bind("change", function () {
                if ($(this).val() == 1) {
                    $("#danxuan").css("display", "block");
                    $("#duoxuan").css("display", "none");
                    $("#pandaun").css("display", "none");
                    $("#tiankong").css("display", "none");
                    $("#<% =ddlnub.ClientID%>").attr("disabled", false);//可用
                }
                else if ($(this).val() == 2) {
                    $("#danxuan").css("display", "none");
                    $("#duoxuan").css("display", "block");
                    $("#pandaun").css("display", "none");
                    $("#tiankong").css("display", "none");
                    $("#<% =ddlnub.ClientID%>").attr("disabled", false);//可用
                }
                else if ($(this).val() == 3) {
                    $("#danxuan").css("display", "none");
                    $("#duoxuan").css("display", "none");
                    $("#pandaun").css("display", "block");
                    $("#tiankong").css("display", "none");
                    $("#<% =ddlnub.ClientID%>").attr("disabled", true);//不可用
                }
                else if ($(this).val() == 4) {
                    $("#danxuan").css("display", "none");
                    $("#duoxuan").css("display", "none");
                    $("#pandaun").css("display", "none");
                    $("#tiankong").css("display", "block");
                    $("#<% =ddlnub.ClientID%>").attr("disabled", true);//不可用
                }
            }
          )
            $("#<%=ddlnub.ClientID %>").bind("change", function () {
                if ($(this).val() == 1) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "none");
                    $("#BB").css("display", "none");
                    $("#C").css("display", "none");
                    $("#CC").css("display", "none");
                    $("#D").css("display", "none");
                    $("#DD").css("display", "none");
                    $("#E").css("display", "none");
                    $("#EE").css("display", "none");
                    $("#F").css("display", "none");
                    $("#FF").css("display", "none");
                    $("#G").css("display", "none");
                    $("#GG").css("display", "none");
                    $("#H").css("display", "none");
                    $("#HH").css("display", "none");
                }
                else if ($(this).val() == 2) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "block");
                    $("#BB").css("display", "block");
                    $("#C").css("display", "none");
                    $("#CC").css("display", "none");
                    $("#D").css("display", "none");
                    $("#DD").css("display", "none");
                    $("#E").css("display", "none");
                    $("#EE").css("display", "none");
                    $("#F").css("display", "none");
                    $("#FF").css("display", "none");
                    $("#G").css("display", "none");
                    $("#GG").css("display", "none");
                    $("#H").css("display", "none");
                    $("#HH").css("display", "none");
                }
                else if ($(this).val() == 3) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "block");
                    $("#BB").css("display", "block");
                    $("#C").css("display", "block");
                    $("#CC").css("display", "block");
                    $("#D").css("display", "none");
                    $("#DD").css("display", "none");
                    $("#E").css("display", "none");
                    $("#EE").css("display", "none");
                    $("#F").css("display", "none");
                    $("#FF").css("display", "none");
                    $("#G").css("display", "none");
                    $("#GG").css("display", "none");
                    $("#H").css("display", "none");
                    $("#HH").css("display", "none");
                }
                else if ($(this).val() == 4) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "block");
                    $("#BB").css("display", "block");
                    $("#C").css("display", "block");
                    $("#CC").css("display", "block");
                    $("#D").css("display", "block");
                    $("#DD").css("display", "block");
                    $("#E").css("display", "none");
                    $("#EE").css("display", "none");
                    $("#F").css("display", "none");
                    $("#FF").css("display", "none");
                    $("#G").css("display", "none");
                    $("#GG").css("display", "none");
                    $("#H").css("display", "none");
                    $("#HH").css("display", "none");
                }
                else if ($(this).val() == 5) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "block");
                    $("#BB").css("display", "block");
                    $("#C").css("display", "block");
                    $("#CC").css("display", "block");
                    $("#D").css("display", "block");
                    $("#DD").css("display", "block");
                    $("#E").css("display", "block");
                    $("#EE").css("display", "block");
                    $("#F").css("display", "none");
                    $("#F").css("display", "none");
                    $("#G").css("display", "none");
                    $("#GG").css("display", "none");
                    $("#H").css("display", "none");
                    $("HH").css("display", "none");
                }
                else if ($(this).val() == 6) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "block");
                    $("#BB").css("display", "block");
                    $("#C").css("display", "block");
                    $("#CC").css("display", "block");
                    $("#D").css("display", "block");
                    $("#DD").css("display", "block");
                    $("#E").css("display", "block");
                    $("#EE").css("display", "block");
                    $("#F").css("display", "block");
                    $("#FF").css("display", "block");
                    $("#G").css("display", "none");
                    $("#GG").css("display", "none");
                    $("#H").css("display", "none");
                    $("#HH").css("display", "none");
                }
                else if ($(this).val() == 7) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "block");
                    $("#BB").css("display", "block");
                    $("#C").css("display", "block");
                    $("#CC").css("display", "block");
                    $("#D").css("display", "block");
                    $("#DD").css("display", "block");
                    $("#E").css("display", "block");
                    $("#EE").css("display", "block");
                    $("#F").css("display", "block");
                    $("#FF").css("display", "block");
                    $("#H").css("display", "none");
                    $("#HH").css("display", "none");
                }
                else if ($(this).val() == 8) {
                    $("#A").css("display", "block");
                    $("#AA").css("display", "block");
                    $("#B").css("display", "block");
                    $("#BB").css("display", "block");
                    $("#C").css("display", "block");
                    $("#CC").css("display", "block");
                    $("#D").css("display", "block");
                    $("#DD").css("display", "block");
                    $("#E").css("display", "block");
                    $("#EE").css("display", "block");
                    $("#F").css("display", "block");
                    $("#FF").css("display", "block");
                    $("#H").css("display", "block");
                    $("#HH").css("display", "block");
                }
            })
        })
       
        </script>
    <script type="text/javascript">
        $(function () {
            $("#<%=daoti.ClientID%>").click(function () {
                $("#dandao").css("display", "block");
                $("#pilaing").css("display", "none");          
            });
            $("#<%=piliang.ClientID%>").click(function () {
                $("#dandao").css("display", "none");
                $("#pilaing").css("display", "block");
            });
            $("#<%=daoti2.ClientID%>").click(function () {
                $("#dandao").css("display", "block");
                $("#pilaing").css("display", "none");
            });
            $("#<%=piliang2.ClientID%>").click(function () {
                $("#dandao").css("display", "none");
                $("#pilaing").css("display", "block");
            });
        });
        //单选
        function select() {
            layer.open({
                area: ['800px', '500px'],
                title: '选择题库',
                type: 2,
                content: "QuestionManage.aspx?id=-1",
                //关掉之后
                end: function () {
                   
                }
            })
        }
        //多选
        function selectdx() {
            layer.open({
                area: ['800px', '500px'],
                title: '选择题库',
                type: 2,
                content: "QuestionManage.aspx?id=-2",
                //关掉之后
                end: function () {
                    var id = window.parent.document.getElementById("hiddepartmentdx").value;
                    $("#<%=txthid.ClientID %>").val(id);
                }
            })
        }
        $(function () {
            //试题描述
            editorms.ready(function () {
                editorms.setContent("<%=contenms %>");
            });
            //单选
            editordaxa.ready(function () {
                editordaxa.setContent("<%=contenA %>");
            });
            editordaxb.ready(function () {
                editordaxb.setContent("<%=contenB %>");
            });
            editordaxc.ready(function () {
                editordaxc.setContent("<%=contenC %>");
            });
            editordaxd.ready(function () {
                editordaxd.setContent("<%=contenD %>");
            });
            editordaxe.ready(function () {
                editordaxe.setContent("<%=contenE %>");
            });
            editordaxf.ready(function () {
                editordaxf.setContent("<%=contenF %>");
            });
            editordaxg.ready(function () {
                editordaxg.setContent("<%=contenG %>");
            });
            editordaxh.ready(function () {
                editordaxh.setContent("<%=contenH %>");
            });
            //多选
            editorduxa.ready(function () {
                editorduxa.setContent("<%=contenAA %>");
            });
            editorduxb.ready(function () {
                editorduxb.setContent("<%=contenBB %>");
            });
            editorduxc.ready(function () {
                editorduxc.setContent("<%=contenCC %>");
            });
            editorduxd.ready(function () {
                editorduxd.setContent("<%=contenDD %>");
            });
            editorduxe.ready(function () {
                editorduxe.setContent("<%=contenEE %>");
            });
            editorduxf.ready(function () {
                editorduxf.setContent("<%=contenFF %>");
            });
            editorduxg.ready(function () {
                editorduxg.setContent("<%=contenGG %>");
            });
            editorduxh.ready(function () {
                editorduxh.setContent("<%=contenHH %>");
              });
          
            //试题解析
            editorjx.ready(function () {
                editorjx.setContent("<%=contenjx %>");
            });
        })
        
    </script>
    <script>
        window.onload = function () {
            var id = "<%=questionclsid %>";
            if (id != 0) {
                $("#hiddepartment").val(id);
                document.getElementById("selectdepartment").innerHTML = ("<%=name%>");
            }
            var temp = $("#<%=hidid.ClientID%>").val();
            if (temp != "")
            {
                if (temp == "1"){

                }
                else if (temp == "2"){
                    $("#<%=ddlFirst.ClientID%>").change();
                }
                else if (temp == "3") {
                    $("#<%=ddlFirst.ClientID%>").change();
                }
                else if (temp == "4") {
                    $("#<%=ddlFirst.ClientID%>").change();
                }
            }
        }
        //保存
        function Save() {
            //题库ID
            var questionid = $("#<%=txthid.ClientID %>").val();
            //试题分类
            var type = $("#<%=ddlType.ClientID %>").val();
            //试题难度
            var diff = $("#<%=ddlDiff.ClientID %>").val();
            //试题内容
            var Advantages = $("#<%=txtAdvantages.ClientID %>").val();
            if (questionid == "") {
                alert("请选择题库!");
                event.returnValue = false;
            }

        }

    </script>
</asp:Content>

