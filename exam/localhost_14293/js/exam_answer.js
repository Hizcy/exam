 var answered_num = 5; //已答未保存考题数量
 var answered_multi_all = []; //所以试题延时提交数据
 var answered_multi = {"questionsId":"","keyList":""}; //多选延时提交数据
 $(document).ready(function () {
     
	//显示答题卡
	/*$(".hasShowCardLink").click(function(e) {
        $("#numberCardDom").show();
		$("#maskDiv").show();
		$("html,body").animate({scrollTop:"0"},10);
		//$("#content").hide();
    });
	//隐藏答题卡
	$(".card-off").click(function(e) {
        $("#numberCardDom").hide();
		$("#maskDiv").hide();
		//$("#content").show();
    });
	//隐藏答题卡同时定位锚点
	$("a.iconBox").click(function(e) {
		e.stopPropagation();
		//e.preventDefault();
		//var pageId = $(this).attr("href");
        $("#numberCardDom").hide();
		$("#maskDiv").hide();
		//$("#content").show();
		
		//$("html,body").animate({scrollTop:$($(this).attr("href")).offset().top},200);
    });
	//试题内容第一个P标签加样式
	$(".answers").each(function(index, element) {
        $($(this).find("p")[0]).css("display","inline");
    });
	$(".questions").each(function(index, element) {
        $($(this).find("p")[0]).css("display","inline");
    });
	//判断是否答过，标记为已答
	$("a.iconBox").each(function(index, element) {
        if($(this).attr("hasAnswered")=="true"){
			$(this).removeClass("icon_answer_no").addClass("icon_answer_answered");
			$(this).parent("dd").removeClass("s1").addClass("s2");
		}
    });
	//判断是否答过，标记答案
	$(".questionsContent").each(function(index, element) {
		if($(this).find("input[name=questionsType]").val()=="1"||$(this).find("input[name=questionsType]").val()=="2"||$(this).find("input[name=questionsType]").val()=="3"){
			if($(this).attr("hasAnswered")=="true"){
				var list = $(this).find("input[name=questionsAnswered]").val();
				list = list.split(",");
				var checkInput = $(this).find("input.radioOrCheck");
				checkInput.each(function(index, element) {
					var obj = $(this);
                    var name = obj.attr("answerName");
					$.each(list, function(index, value) { 
						if(value == name){
							obj.prop("checked",true);
						}
					});
                });
			}
		}
    });*/
	//标记
	$(".mark").click(function(e) {
		e.stopPropagation();
		e.preventDefault();
		questionsMark(this);
	});
/*
	//单选、多选、判断答案存储
	$(".radioOrCheck").click(function (e) {
	    //alert(12);
		var questionsType = $(this).attr("questionsType");
		var parentDiv = $(this).parents(".questionsContent");
		var questionsId = parentDiv.attr("questionsId");
		var keyList = "";
		
		if(questionsType=="1"){ //单选
			$(parentDiv.find(".radioOrCheck")).each(function(index, element) {
                if($(this).is(":checked")){
					keyList = $(this).attr("answerName")+",";
					return;
				}
			});
			alert(keyList);
			return;
			//saveAnswerFn(questionsId , keyList );
			saveQuestionsCatch(questionsId , keyList );
			//多选保存答案延迟调用
			
			
		}else if(questionsType=="2"){ //多选
			$(parentDiv.find(".radioOrCheck")).each(function(index, element) {
                if($(this).is(":checked")){
					keyList += $(this).attr("answerName")+",";
				}
            });
			saveQuestionsCatch(questionsId , keyList );
			//多选保存答案延迟调用
			
			
		}else if(questionsType=="3"){ //判断
			$(parentDiv.find(".radioOrCheck")).each(function(index, element) {
                if($(this).is(":checked")){
					keyList = $(this).attr("answerName")+",";
				}
            });
			saveQuestionsCatch(questionsId , keyList );
			//saveAnswerFn(questionsId , keyList );
			//多选保存答案延迟调用
			
		}		
		
	});*/
     /*
	//填空、问答答案存储
	$(".keyFill , .keyCloze").blur(function(e) {
		var parentDiv = $(this).parents(".questionsContent");
		var questionsId = parentDiv.attr("questionsId");
		var keyList = $(this).val();
		if(keyList!=""){
			
			saveQuestionsCatch(questionsId , keyList );
			//saveAnswerFn(questionsId , keyList );
			//多选保存答案延迟调用
			
		}
		e.stopPropagation();
		e.preventDefault();
	});*/
     /*
	//交卷
	$(".examEndBtn").click(function(e) {
		if(checkForm()){
			$(this).remove();
			saveExamFn();
			e.stopPropagation();
			e.preventDefault();
			$("#numberCardDom").hide();
			$("#maskDiv").hide();
			//$("#content").show();
		}else{
			if(confirm("有试题尚未答题，是否现在交卷？")){
				$(this).remove();
				saveExamFn();
				e.stopPropagation();
				e.preventDefault();
				$("#numberCardDom").hide();
				$("#maskDiv").hide();
				//$("#content").show();
			}
		}
    });*/
	//交卷后跳转按钮
	$(".examEndJumpBtn").click(function(e) {
		e.stopPropagation();
		e.preventDefault();
		window.location.href = "/exam/listexam.aspx";
    });
	//问答题初始化编辑器
	/*$("textarea[class=keyCloze]").each(function(index, element) {
        var id = $(this).attr("id");
		var parentDiv = $(this).parents(".questionsContent");
		var questionsId = parentDiv.attr("questionsId");
		UE.getEditor(id, {
			toolbars:[['insertimage']],
			wordCount:false, //关闭字数统计
			elementPathEnabled:false, //关闭elementPath
			autoHeightEnabled:false,
			initialFrameHeight:80,
			lang:'zh-cn' //语言
		}).addListener('blur',function(editor){
			var keyList = this.getContent();
			if(keyList!=""){
				saveQuestionsCatch(questionsId , keyList );
			}
		}); 
    });*/
});
//倒计时
function timeDown(time){
	var hasShowDay = false;
	var dayText = "";
	if(time>86400){
		hasShowDay = true;
		dayText = "天";
	}
	$(".timeDown").attr('data-seconds', time).kkcountdown({
		daysText    : dayText,
		hoursText   : ':',
		minutesText : ':',
		secondsText : '',
		displayZeroDays : hasShowDay,
		textAfterCount: '考试结束',
		warnSeconds : 10,
		//warnClass   : 'alert',
		callback : function(){
			alert("考试时间到！");
			saveExamFn();
		}
	});
}
timeDown(answer_time);
/*
//标记考题fn
function questionsMark(obj){
	var num = $(obj).attr("num");
	var hasMarked = $(obj).hasClass("marked");
	if(!hasMarked){
		$(obj).addClass("marked");
		$(".iconBox").each(function(index, element) {
			var iconNum = $(this).attr("num");
            if(iconNum == num){
				$(this).addClass("icon_answer_mark");
				$(this).parent("dd").addClass("s4");
				return;
			}
        });
	}else{
		$(obj).removeClass("marked");
		$(".iconBox").each(function(index, element) {
			var iconNum = $(this).attr("num");
            if(iconNum == num){
				$(this).removeClass("icon_answer_mark");
				$(this).parent("dd").removeClass("s4");
				return;
			}
        });
	}
}

//答题后提交后台异步保存fn
function saveAnswerFn(questionsId,keyList){
	var dataForm = "exam_results_id="+exam_results_id+"&exam_info_id="+exam_info_id+"&test_id="+questionsId+"&test_ans="+keyList;
	$.ajax({
		type: "POST",
		dataType: "json",
		url: "/exam/exam_start_ing",
		data: dataForm,
		processData: false,
		success: function(msg){
			if(msg.success=="True"){
				$("#numberCardDom a.questions_"+questionsId).removeClass("icon_answer_no").addClass("icon_answer_answered");
				$("#numberCardDom a.questions_"+questionsId).parent("dd").removeClass("s1").addClass("s2");
				$(".questionsContent").each(function(index, element) {
                    if($(this).attr("questionsId")==questionsId){
						$(this).attr("hasAnswered","true");
					}
                });
			}else{
				alert("操作失败，请联系管理员！");
			}
		}
	});
}*/
//交卷提交后台异步保存fn

/*
//验证是否有未答试题
function checkForm(){
	var hasCheck = true;
	$(".questionsContent").each(function(index, element) {
		if($(this).attr("hasAnswered")!="true"){
			hasCheck = false;
			return false;
		}
	});
	return hasCheck;
}
//延时答题后提交后台异步保存fn
function saveAnswerFn_timeout(overExam){
	var exam_test_list = answered_multi_all;
	answered_multi_all = [];
	exam_test_list = JSON.stringify(exam_test_list); 
	var dataForm = "exam_test_list="+exam_test_list;
	$.ajax({
		type: "POST",
		dataType: "json",
		url: "/exam/exam_start_ing_multi",
		data: dataForm,
		processData: false,
		success: function(msg){
			if(msg.success=="True"){
				if(overExam==true){
					saveExamFn();
				}
			}else{
				alert("操作失败，请联系管理员！");
			}
		},
		error:function(jqXHR, textStatus, errorThrown){
			asynSubTimeoutFn(exam_test_list);
		}
	});
}
//缓存已答未提交考题数据
function saveQuestionsCatch(questionsId,keyList,overExam){
	if(overExam==true){ //交卷操作时还有未保存的考题
		saveAnswerFn_timeout(overExam);
		return;
	}
	var hasSave = false; //是否保存过
	$.each(answered_multi_all,function(index,value){
		if(value.test_id==questionsId){
			value.test_ans = keyList;
			hasSave = true;
			return;
		}
	});
	if(!hasSave){
		var questionsData = {"test_id":questionsId,"test_ans":keyList,"exam_results_id":exam_results_id,"exam_info_id":exam_info_id};
		answered_multi_all.push(questionsData);
		$("#numberCardDom a.questions_"+questionsId).removeClass("icon_answer_no").addClass("icon_answer_answered");
		$("#numberCardDom a.questions_"+questionsId).parent("dd").removeClass("s1").addClass("s2");
		$(".questionsContent").each(function(index, element) {
			if($(this).attr("questionsId")==questionsId){
				$(this).attr("hasAnswered","true");
			}
		});
	}
	if(answered_multi_all.length==answered_num){
		saveAnswerFn_timeout();
	}
} 
//异步提交答案超时FN
function asynSubTimeoutFn(data){
	var jsonData = eval(data);
	$.each(jsonData,function(index,value){
		var questionsId = value.test_id;
		$("#numberCardDom a.questions_"+questionsId).removeClass("icon_answer_answered").addClass("icon_answer_no");
		$("#numberCardDom a.questions_"+questionsId).parent("dd").removeClass("s2").addClass("s1");
	});
	alert("由于您网络问题，导致已答的部分试题没有保存成功，请根据左侧答题卡信息重新选择作答。");
}

*/

