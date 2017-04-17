<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProvideExamPaper.aspx.cs" Inherits="Exam_ProvideExamPaper" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快去读</title>
    <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
    <script src="../layer/layer.js"></script>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="../css/customer.css" />
    <style>
        .setRigth .setRigthContent {
            margin: 0 10px 10px;
        }
        .setRigthContent .title {
            height: 20px;
            line-height: 20px;
        }
        .iframeModal{width:350px;}
        .modal.fade.in {
            top: 70%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3>选择试卷</h3>
        <div style="margin-left:10px;margin-bottom:40px">
             <div style="font-weight:bold;font-size:20px">试卷搜索</div>
              <div style="background-color:#dcdcdc;width:99%; height:100px;line-height:50px">
                  <div style="height:30px;margin-left:5px">试卷名称：
                      <asp:TextBox ID="txtname" runat="server" style="width:300px;"></asp:TextBox><br />
                      <div style="text-align:center"><asp:Button ID="btnselect" runat="server" Text="搜索" style="border:none;background-color:#464d77;color:white;width:50px;height:25px"  /></div>
                  </div>
               </div>
          </div> 
          <div style="font-weight:bold;font-size:20px">试卷列表</div>
          <div style="float:right">共2个</div>
            <table class="table table-condensed table-hover customerTab">
                <thead>
                    <tr>
                    <th><!--<input type="checkbox" class="radioOrCheck" name="keyChk" />--></th>
                    <th>名称</th>
                    <th>组卷方式</th>
                    <th>总分</th>
                    <th>试题数量</th>
                    <th>创建人</th>
                    <th>创建时间</th>
                    </tr>
                </thead>
                    <tbody>
                        <asp:Repeater ID="rptexampaper" runat="server">
                            <ItemTemplate>
                                <tr>
                                <td><input type="radio" class="radioOrCheck" name="keyChk" value='<%#Eval("exampaperid") %>'/></td>
                                <td class="paper_name"><%#Eval("name") %></td>
                                <td class="paper_type"><%#Eval("type") %></td>
                                <td class="total_score"><%#Eval("total") %></td>
                                <td class="test_count"><%#Eval("num") %></td>
                                <td class="create_user_name"><%#Eval("founder") %></td>
                                <td class="created_time"><%#Eval("addtime") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
            </table>
            <div class="das_pages" style="text-align:right;text-align:center;margin-bottom:5px" >       
                <webdiyer:AspNetPager ID="pager1" CssClass="paginator"   CurrentPageButtonClass="cpb" runat="server" AlwaysShow="True" 
                FirstPageText="首页"  LastPageText="尾页" NextPageText="下一页"  PageSize="15" PrevPageText="上一页"   
                ShowInputBox="Never" onpagechanged="AspNetPager1_PageChanged"  CustomInfoTextAlign="Left"   >
                </webdiyer:AspNetPager>
            </div>
            <div style="text-align:center">
                <input type="button" id="btn_qd" value="确定" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
                <input type="button" id="btn_qx" value="取消" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
            </div>
  </form>
    <script>
        $("#btn_qd").click(function () {
            var value = $("table input.radioOrCheck:checked").val();//选中值
            if (value == null) {
                alert("请选择试题");
                return;
            }
            window.parent.document.getElementById("id").value = value;
            var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
            parent.layer.close(index); //执行关闭
        })
        $("#btn_qx").click(function () {
            var index = parent.layer.getFrameIndex(window.name); //获取当前窗体索引
            parent.layer.close(index); //执行关闭
        })
    </script>
</body>
</html>
