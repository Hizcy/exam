<%@ Page Title="分析人员成绩" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Count.aspx.cs" Inherits="count_Count" %>

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
              <div class="title"><span style="color:#37CBBA">统计分析<</span><span>分析人员成绩</span></div>
                   <div class="topSelDiv userImportMain">
      <div class="setRigthContent"  style="min-height:500px">
          <div>
              
                    <a href="javascript:select()" style="text-decoration:none"><asp:Label ID="labdepartment" style="color:#464d77;font-weight:bold;margin-left:5px"  runat="server" Text="选择班级"></asp:Label>
                        <img src="../images/icon6.gif" />
                    </a>
                <asp:TextBox ID="hiddepartmentId" runat="server" style="display:none"></asp:TextBox>
                <asp:TextBox ID="hidname" runat="server" style="display:none"></asp:TextBox>
             
                <asp:Button ID="btncx" runat="server" CssClass="btncx" Text="查询" style="float:right;margin-right:24px;font-size:8px" OnClick="btncx_Click"  />                      
          </div>
          <div class="topContent">
              <table border="0"  style="width:100%;background-color:#003264; color:#fff; font-size:12px; text-align:center; margin-top:10px; margin-bottom:10px; display:none " class="simpleExamTab">
                <tr style="height:30px">
                  <td class="exam_name"></td>
                  <td style=" background-color:#fff; width:1px"></td>
                  <td class="exam_style_name"></td>
                  <td style=" background-color:#fff; width:1px"></td>
                  <td class="exam_time"></td>
                </tr>
              </table>
          </div>
          <div class="topSelDiv chartContent" style="display:block;  height: 700px;">
			<ul class="nav nav-tabs" id="analysisTab" style="margin-bottom:10px;">
            <%--    <li class="active"><a href="#">成绩统计</a></li>--%>
               <%-- <li><a href="#">试题分析</a></li>--%>
			</ul>
                 
			<div class="tab-content">
                <div class="tab-pane active" id="home" style="height: 800px;">
                	<div style="padding:10px">
                      <div style="text-align:center; margin-bottom:5px; font-size:18px; font-weight:bold">成绩统计</div>
                      <table class="table table-condensed table-hover customerTab">
                        <tbody>
                              <tr>
                                <td>最高分</td>
                                <td class="max_score"><%=maxscore%></td>
                                <td>最低分</td>
                                <td class="min_score"><%=minscore %></td>
                                <td>平均分</td>
                                <td class="avg_score"><%=avgscore %></td>
                              </tr>
                        </tbody>
                      </table>
                      <hr style="border: 1px none; height: 2px; background-color:#999" />
                      <div class="topSelDiv chartContent" style="display:block">
                    <%--<a class="button toolbarBtn changeChart1" href="javascript:;" num="chart1" type="column" style="width:60px">柱图</a>--%>
                        <a class="button toolbarBtn changeChart1" href="javascript:;" num="chart1" type="line" style="width:60px">线图</a>
                          <%-- 柱状统计图 --%>
                        <div id="chartdiv" style="min-width:300px;height:300px"> </div>
                        <br />
                      </div>
          
                  </div>
                </div>
			</div>
          </div>
          <table class="table table-condensed table-hover customerTab">
                <tbody>
                        <tr>
                        <td>名字</td>
                        <td>成绩</td>
                        <td>积分</td>
                        <td>所属年级</td>
                        </tr>
                </tbody>                           
                             <asp:Repeater ID="rptCountList" runat="server">
                                 <ItemTemplate>             
                                      <tr >
                                           <td class="max_score"> <%#Eval("realname") %></td>
                                           <td class="min_score"><%#Eval("score") %></td>
                                           <td class="avg_score"><%#Eval("point") %></td>
                                           <td class="avg_score"><%#Eval("description") %></td>
                                      </tr>
                                 </ItemTemplate>
                             </asp:Repeater>
         </table>
      </div>
    </div>
  </div>
       
           <input type="text" style="display:none" id="selectdepartment" />
          <input type="text" style="display:none" id="hiddepartment" />
       </div>
         <script>
             function select() {
             
                       layer.open({
                           area: ['800px', '500px'],
                           title: '选择班级',
                           type: 2,
                           content: "AddDepartment.aspx",
                           end: function () {
                               var id = document.getElementById("hiddepartment").value;
                               if (id != "") {
                                   document.getElementById("<%=hiddepartmentId.ClientID %>").value = id;
                        document.getElementById("<%=labdepartment.ClientID %>").innerHTML = document.getElementById("selectdepartment").innerText;
                        document.getElementById("<%=hidname.ClientID %>").value = document.getElementById("selectdepartment").innerText;
                    }
                }
            })
        }
    </script>
      <script>
          //统计线图
          if (GALLERY_RENDERER && GALLERY_RENDERER.search(/javascript|flash/i) == 0) FusionCharts.setCurrentRenderer(GALLERY_RENDERER);
          var chart = new FusionCharts("../js/MSLine.swf", "ChartId", "100%", "500", "0", "0");
          chart.setJSONData({
              "chart": {
                  "canvaspadding": "10", "caption": "成绩统计", "yaxisname": "分数", "bgcolor": "F7F7F7, E9E9E9",
                "numvdivlines": "10", "divlinealpha": "30", "labelpadding": "10", "yaxisvaluespadding": "10", "showvalues": "1", "rotatevalues": "1",
                "valueposition": "auto"
            },
            "categories": [{
                "category": [ <%=realname%>]
            }], "dataset":
                [{ "seriesname": "分数", "color": "A66EDD", "data": [<%=score%>] }, { "seriesname": "积分", "color": "F6BD0F", "data": [<%=point%>] }]
        });
        chart.render("chartdiv");

    </script>
</asp:Content>

