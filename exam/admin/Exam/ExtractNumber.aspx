<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExtractNumber.aspx.cs" Inherits="Exam_ExtractNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>快去读</title>
    <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script src="../layer/layer.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>抽取数量</h3>
        <span style="width:100%; text-align:center;display:-moz-inline-box; display:inline-block;">
            简单：<input type="text" id="txtjd" style="width:100px" value="0" />/<%=jdNum %>&nbsp;&nbsp;困难:<input type="text" id="txtKn" style="width:100px" value="0" />/<%=knNum %><p />
            <input type="button" id="btn_qd" value="确定" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
                <input type="button" id="btn_qx" value="取消" style="border:none;background-color:#464d77;color:white;width:50px;height:25px" />
        </span>
    </div>
    </form>
    <script>
        $("#btn_qd").click(function () {
            var jd = $("#txtjd").val();
            var kn = $("#txtKn").val();
            var jd2 = "<%=jdNum.ToString() %>";//简单总数
            var kn2 = "<%=knNum.ToString() %>";//困难总数
            var id = "<%=id %>";//唯一标识
            var num = 0;//总个数
            var type = "";
            if (jd != "") {
                type = "\"num1\":\"" + jd + "\",";
                if (parseInt(jd) > parseInt(jd2)) {
                    alert("简单题选取数过多");
                    return;
                }
            }
            if (kn != "") {
                type += "\"num2\":\"" + kn + "\"";
                if (parseInt(kn) > parseInt(kn2)) {
                    alert("复杂题选取数过多");
                    return;
                }
            }
            if (jd != "" && kn != "") {
                num = parseInt(jd) + parseInt(kn);
            }
            window.parent.document.getElementById("num" + id + "").innerHTML = num;//给父窗体DOM赋值总分
            window.parent.document.getElementById("hid" + id + "").value = type;//
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
