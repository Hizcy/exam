<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Answer.aspx.cs" Inherits="exam_Answer" %>

<!DOCTYPE html>
<!-- saved from url=(0047)http://www.kaoshixing.com/exam/exam_start/10568 -->
<html>
    <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <meta charset="utf-8"/>
    <title>评测平台</title>
        <link rel="icon" sizes="any" mask href="http://kqd.webf.com.cn/images/kuai.png"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="renderer" content="webkit"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="../css/style.css"/>
    </head>

<body class="main-page">
    <form runat="server">
<div id="wrap">
    <div id="header">
    	<div id="top">
        	<div id="logo" style="display: block;"><a href="javascript:void(0)">
                <img src="../images/logo.png" width="221" height="60" style="width:221px; height:60px;"></a></div>
            <div id="accout">
            	<span></span>
            </div>
        </div>
    </div>
    
    <div id="content" class="clearfix">
        <div class="paper">
            <h3 otop="110" style="position: static; top: 0px;">
             <div class="l">
             	<span class="time">
                     <span class="timeDown" data-seconds="3642">

                     </span>
             	</span>
                <%--<span class="card"><em></em><a href="javascript:void(0)" class="hasShowCardLink">答题卡</a></span>--%>
             </div>
             <div class="r">
             	<span class="conf"><em></em><a href="javascript:void(0)" class="examEndBtn">交卷</a></span>
             </div>
            </h3>
            <div class="cont">
            	<h4><%=Name %></h4>
    
                 <%=body %>

            </div>
        </div>
    </div>
    
    <!--答题卡-->
    
    
</div>
<!-- Modal -->
<div style="padding:100px" id="examEndModal">
        <div class="examDialog">
            <h3><em></em>评测结果</h3>
            <div class="cont">
                <p class="cont_main">
                <b><span class="examScore"></span></b><br/><br/>
                <span class="examStatus"></span>
                </p>
                <div class="btn-div">
                    <button type="button" class="btn btn-default examEndJumpBtn">确认</button>
                </div>
            </div>
        </div>
 </div>

<div id="maskDiv" style="padding-top: 250px; top: 0px; width: 100%; height: 100%; position: fixed; z-index: 10000; text-align: center; opacity: 0.5; display: none; background-color: rgb(0, 0, 0);">
</div>
<script type="text/javascript" src="../js/jquery.min.js"></script>
<script type="text/javascript" src="../js/kkcountdown.min.js"></script>
<script type="text/javascript">
    (function ($) {
        $(document).ready(function () {
            if ($.isFunction($.bootstrapIE6)) $.bootstrapIE6($(document));
        });
    })(jQuery);

    $(function () {
        var ie6 = document.all;
        var dv = $('.paper h3'), st;
        dv.attr('otop', dv.offset().top); //存储原来的距离顶部的距离 
        $(window).scroll(function () {
            st = Math.max(document.body.scrollTop || document.documentElement.scrollTop);
            if (st > parseInt(dv.attr('otop'))) {
                if (ie6) {//IE6不支持fixed属性，所以只能靠设置position为absolute和top实现此效果 
                    dv.css({ position: 'absolute', top: st });
                } else if (dv.css('position') != 'fixed') dv.css({ 'position': 'fixed', top: 0 });
            } else if (dv.css('position') != 'static') dv.css({ 'position': 'static' });
        });
    });

    var answer_time = "<%=Mm %>";
    
    //var exam_info_id = "10568"; //考试ID
    //var exam_results_id = "138738"; //考试关联ID
</script> 
<script type="text/javascript" src="../js/exam_answer.js?v=10"></script>
        <script  language="Javascript">
            
            /*document.onkeydown=function() 
            { 
                if ( event.keyCode==116 || event.keyCode==8) 
                { 
                    event.keyCode = 0; 
                    event.cancelBubble = true; 
                    return false; 
                } 
            } 
            //禁止右键弹出菜单 
            document.oncontextmenu = function()
            { 
                return false; 
            }*/
            $(".radioOrCheck").click(function (e) {
                var questionsType = $(this).attr("questionsType");
                var parentDiv = $(this).parents(".questionsContent");
                var questionsId = parentDiv.attr("questionsId");
               
                var keyList = "";
                
                if (questionsType == "1") { //单选
                    $(parentDiv.find(".radioOrCheck")).each(function (index, element) {
                        if ($(this).is(":checked")) {
                            keyList = $(this).attr("answerName") + ",";
                            return;
                        }
                    });
                    parentDiv.find("[name='questionsAnswered']").val(keyList);
                }
                else if (questionsType == "2"){//多选
                    $(parentDiv.find(".radioOrCheck")).each(function (index, element) {
                        if ($(this).is(":checked")) {
                            keyList += $(this).attr("answerName") + ",";
                        }
                    });
                    parentDiv.find("[name='questionsAnswered']").val(keyList);
                }
                else if (questionsType == "3") { //判断
                    $(parentDiv.find(".radioOrCheck")).each(function (index, element) {
                        if ($(this).is(":checked")) {
                            keyList = $(this).attr("answerName") + ",";
                        }
                    });
                    parentDiv.find("[name='questionsAnswered']").val(keyList);
                }
                
            });
            /*$(".keyFill , .keyCloze").blur(function (e) {
                
                var parentDiv = $(this).parents(".questionsContent");
                var questionsId = parentDiv.attr("questionsId");
                var keyList = $(this).val();
                if (keyList != "") {
                    parentDiv.find("[name='questionsAnswered']").val(questionsId + ":" + keyList);
                }
               
            });*/
            //交卷
            $(".examEndBtn").click(function (e) {
                $(".keyFill , .keyCloze").each(function () {
                    var parentDiv = $(this).parents(".questionsContent");
                    var questionsId = parentDiv.attr("questionsId");
                    var keyList = $(this).val();
                    if (keyList != "") {
                        parentDiv.find("[name='questionsAnswered']").val(keyList);
                    }
                });
                var b = false;
                var dataForm = "";
                $(".questionsContent").each(function () {
                    var type = $(this).find("[name = 'questionsType']").val();
                    var val = $(this).find("[name = 'questionsAnswered']").val();
                    if (val == ""){
                        b = true;
                    }
                    dataForm += "{\"type\":\"" + type + "\",\"qid\":\"" + $(this).attr("questionsId") + "\",\"val\":\"" + val + "\",\"score\":\"" + $(this).attr("questionscore") + "\"},";

                });
                
                dataForm = "[" + dataForm.substr(0, dataForm.length - 1) + "]";
                //alert(1122);
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "../data/answer.ashx",
                    data: "exampaperid=" +<%=ExampaperId%> +"&clsid=" + <%=ClsId%> + "&data=" + dataForm,
                    processData: false,
                    success: function (msg) {
                        //alert(str.msg);
                        //var msg = JSON.parse(str);
                        //alert(msg.msg);
                        if (msg.msg == "True") {
                            $("#maskDiv").hide();
                            if (msg.release_info == "") {
                                $("#examEndModal .examScore").text(msg.score);
                                $("#examEndModal .examStatus").text(msg.is_pass);
                                if (msg.is_pass == "未通过") {
                                    $(".examDialog").addClass("pop-test1");
                                } else {
                                    $(".examDialog").addClass("pop-test2");
                                }
                            } else {
                                $("#examEndModal .cont_main").html('<p>' + msg.release_info + '</p>');
                                $(".examDialog").addClass("pop-test3");
                            }
                            $("#content").hide();
                            $('#examEndModal').show();
                        } else {
                            $("#maskDiv").hide();
                            alert("操作失败，请联系管理员！");
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        asynSubTimeoutFn(exam_test_list);
                    }
                });
            });
            function saveExamFn(){

	            //判断是否有未保存的考题
	            $(".keyFill , .keyCloze").each(function () {
	                var parentDiv = $(this).parents(".questionsContent");
	                var questionsId = parentDiv.attr("questionsId");
	                var keyList = $(this).val();
	                if (keyList != "") {
	                    parentDiv.find("[name='questionsAnswered']").val(keyList);
	                }
	            });
	            var b = false;
	            var dataForm = "";
	            $(".questionsContent").each(function () {
	                var type = $(this).find("[name = 'questionsType']").val();
	                var val = $(this).find("[name = 'questionsAnswered']").val();
	                if (val == ""){
	                    b = true;
	                }
	                dataForm += "{\"type\":\"" + type + "\",\"qid\":\"" + $(this).attr("questionsId") + "\",\"val\":\"" + val + "\",\"score\":\"" + $(this).attr("questionscore") + "\"},";

	            });
                
	            dataForm = "[" + dataForm.substr(0, dataForm.length - 1) + "]";
                //alert(1122);
	            $.ajax({
	                type: "POST",
	                dataType: "json",
	                url: "../data/answer.ashx",
	                data: "exampaperid=" +<%=ExampaperId%> +"&clsid=" + <%=ClsId%> + "&data=" + dataForm,
	                processData: false,
	                success: function (msg) {
	                   
	                    if (msg.msg == "True") {
	                        $("#maskDiv").hide();
	                        if (msg.release_info == "") {
	                            $("#examEndModal .examScore").text(msg.score);
	                            $("#examEndModal .examStatus").text(msg.is_pass);
	                            if (msg.is_pass == "未通过") {
	                                $(".examDialog").addClass("pop-test1");
	                            } else {
	                                $(".examDialog").addClass("pop-test2");
	                            }
	                        } else {
	                            $("#examEndModal .cont_main").html('<p>' + msg.release_info + '</p>');
	                            $(".examDialog").addClass("pop-test3");
	                        }
	                        $("#content").hide();
	                        $('#examEndModal').show();
	                    } else {
	                        $("#maskDiv").hide();
	                        alert("操作失败，请联系管理员！");
	                    }
	                },
	                error: function (jqXHR, textStatus, errorThrown) {
	                    asynSubTimeoutFn(exam_test_list);
	                }
	            });
            }
        </script>
        </form>
    </body>
    </html>