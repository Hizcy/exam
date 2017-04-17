var answered_multi = {"questionsId":"","keyList":""};
$(document).ready(function() {
	//交卷后跳转按钮
	$(".examEndJumpBtn").click(function(e) {
		e.stopPropagation();
		e.preventDefault();
		window.location.href = "/exam/listexam.aspx"; 
    });
});
//倒计时
function timeDown(time) {
	var hasShowDay = false;
	var dayText = "";
	if(time>86400){
		hasShowDay = true;
		dayText = "天";
	}
	$("#timeDown").attr('data-seconds', time).kkcountdown({
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


//创建试题DOM
function createQuestionsDom(data){
	var html = "";
	if(data.type=="1"){
		try{
			if(data.answer1!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key1" />A. '+data.answer1+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer2!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key2" />B. '+data.answer2+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer3!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key3" />C. '+data.answer3+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer4!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key4" />D. '+data.answer4+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer5!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key5" />E. '+data.answer5+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer6!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key6" />F. '+data.answer6+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer7!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key7" />G. '+data.answer7+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer8!=undefined){
				html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key8" />H. '+data.answer8+'</div>';
			}
		}catch(e){}
	}
	if(data.type=="2"){
		try{
			if(data.answer1!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key1" answerName="key1" />A. '+data.answer1+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer2!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key2" answerName="key2" />B. '+data.answer2+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer3!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key3" answerName="key3" />C. '+data.answer3+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer4!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key4" answerName="key4" />D. '+data.answer4+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer5!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key5" answerName="key5" />E. '+data.answer5+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer6!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key6" answerName="key6" />F. '+data.answer6+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer7!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key7" answerName="key7" />G. '+data.answer7+'</div>';
			}
		}catch(e){}
		try{
			if(data.answer8!=undefined){
				html += '<div class="answers"><input type="checkbox" class="radioOrCheck" questionsType="'+data.type+'" name="key8" answerName="key8" />H. '+data.answer8+'</div>';
			}
		}catch(e){}
	}
	if(data.type=="3"){
		try{
			html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key1" value="1" /> 正确</div>'
		}catch(e){}
		try{
			html += '<div class="answers"><input type="radio" class="radioOrCheck" questionsType="'+data.type+'" name="keyChk_questions" answerName="key2" value="0" /> 错误</div>'
		}catch(e){}
	}
	if(data.type=="4"){
		try{
			if(data.answer1!=undefined){
				html += '<div class="answers"><input name="key1" questionsType="'+data.type+'" class="keyFill" style="width:80%" value="'+data.test_ans1+'"></div>';
			}
		}catch(e){}
		try{
			if(data.answer2!=undefined){
				html += '<div class="answers"><input name="key2" questionsType="'+data.type+'" class="keyFill" style="width:80%" value="'+data.test_ans2+'"></div>';
			}
		}catch(e){}
		try{
			if(data.answer3!=undefined){
				html += '<div class="answers"><input name="key3" questionsType="'+data.type+'" class="keyFill" style="width:80%" value="'+data.test_ans3+'"></div>';
			}
		}catch(e){}
		try{
			if(data.answer4!=undefined){
				html += '<div class="answers"><input name="key4" questionsType="'+data.type+'" class="keyFill" style="width:80%" value="'+data.test_ans4+'"></div>';
			}
		}catch(e){}
		/*try{
			html += '<div class="answers"><input name="key1" questionsType="'+data.type+'" class="keyFill" style="width:80%" value="'+data.test_ans+'"></div>'
		}catch(e){}*/
	}
	if(data.type=="5"){
		try{
			html += '<div class="answers"><textarea name="key1" questionsType="'+data.type+'" style="width:80%" class="keyCloze">'+data.test_ans+'</textarea></div>'
		}catch(e){}
	}
	var answerHtml = '<div class="exam-title questions">'+data.question+'</div>'+
				'<div class="exam-main answers">'+html+
				'</div>';
	$(".exam-content").html(answerHtml);
	loadingShowOrHide("");
	
	//判断是否答过，标记答案
	var list = "";
	if(data.test_ans!=""&&data.type!="4"&&data.type!="5"){
		list = data.test_ans.split(",");
		var checkInput = $(".questionsContent").find("input.radioOrCheck");
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
				
	//单选、多选、判断答案存储
	$(".radioOrCheck").on("click", function(e) {
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
			saveAnswerFn(questionsId , keyList );
		}else if(questionsType=="2"){ //多选		
			$(parentDiv.find(".radioOrCheck")).each(function(index, element) {
                if($(this).is(":checked")){
					keyList += $(this).attr("answerName")+",";
				}
            });
			//多选保存答案延迟调用
			answered_multi = {"questionsId":questionsId,"keyList":keyList};
			/*setTimeout(
				function(){
					saveAnswerFn(questionsId , keyList );
				},3000
			);*/
		}else if(questionsType=="3"){ //判断
			$(parentDiv.find(".radioOrCheck")).each(function(index, element) {
                if($(this).is(":checked")){
					keyList = $(this).attr("answerName")+",";
				}
            });
			saveAnswerFn(questionsId , keyList );
		}		
    });
	//填空答案存储
	$(".keyFill ").on("blur", function(e) {
		var parentDiv = $(this).parents(".questionsContent");
		var questionsId = parentDiv.attr("questionsId");
		var keyFillDom = parentDiv.find(".keyFill");
		var keyList = "";
		
		if(keyFillDom.length==1){
			saveAnswerFn(questionsId , $(this).val() );
		}else{
			keyFillDom.each(function(index, element) {
				if(index+1!=keyFillDom.length){
					keyList += $(this).val()+"||";
				}else{
					keyList += $(this).val();
				}
                
            });
			saveAnswerFn(questionsId , keyList );
		}
		
		if(keyList!=""){
			//saveAnswerFn(questionsId , keyList );
		}
		e.stopPropagation();
		e.preventDefault();
    });
	//问答答案存储
	$(".keyCloze").on("blur", function(e) {
		var parentDiv = $(this).parents(".questionsContent");
		var questionsId = parentDiv.attr("questionsId");
		var keyList = $(this).val();
		if(keyList!=""){
			saveAnswerFn(questionsId , keyList );
		}
		e.stopPropagation();
		e.preventDefault();
    });
	
}
//数据加载中显示loading图标
function loadingShowOrHide(has){
	if(has=="hide"){
		$(".exam-content").hide();
		$(".exam-loading").show();
		return;
	}
	$(".exam-content").show();
	$(".exam-loading").hide();
}

//获取单类试题总数及当前试题排位
function setQuestionsIndex(questionsId,index){
	//判断是否第一题或最后一题，因此上一题下一题按钮，0为第一题，1为最后一题
	if(index===0){
		$("#preQuestions").hide();
		$("#nextQuestions").show();
	}else if(index===1){
		$("#preQuestions").show();
		$("#nextQuestions").hide();
	}else{
		$("#preQuestions").show();
		$("#nextQuestions").show();
	}
	$(".questionsContent").attr("questionsId", questionsId);
	$("#preQuestions").attr("nowId", questionsId);
	$("#nextQuestions").attr("nowId", questionsId);
	$(".iconBoxNum").each(function(index, element) {
        if($(this).attr("questionsId")==questionsId){
			var title = $(this).parents(".box").find(".boxTitle").text();
			var totle = $(this).parent("div").find(".iconBox").length;
			var num = $(this).text();
			$("#examPanelTitle").text(title);
			$("#questionsNum").text(num+"/"+totle);
			return false;
		}
    });
}
//答题后提交后台异步保存fn
function saveAnswerFn(questionsId,keyList){
	var dataForm = "exam_results_id="+exam_results_id+"&exam_info_id="+exam_info_id+"&test_id="+questionsId+"&test_ans="+keyList;
	$.ajax({
		type: "POST",
		dataType: "json",
		url: "/exam/exam_start_ing",
		data: dataForm,
		success: function(msg){
			if(msg.success=="True"){
				$(".leftNav a.questions_"+questionsId).removeClass("icon_answer_no").addClass("icon_answer_answered");
/*				$(".questionsContent").each(function(index, element) {
                    if($(this).attr("questionsId")==questionsId){
						$(this).attr("hasAnswered","true");
					}
                });*/
			}else if(msg.success=="answered"){
				alert("本次考试已结束！");
				window.location.href = "/exam/m_exam_history/";	
			}else{
				alert("操作失败，请联系管理员！");
			}
		}
	});
}
//交卷提交后台异步保存fn
function saveExamFn(){
	//多选保存答案延迟调用
	if(answered_multi.questionsId!=""){
		saveAnswerFn(answered_multi.questionsId , answered_multi.keyList );
	}
	setTimeout(
		function(){
			var dataForm = "exam_info_id="+exam_info_id+"&exam_results_id="+exam_results_id;
			$.ajax({
				type: "POST",
				dataType: "json",
				url: "/exam/exam_ending",
				data: dataForm,
				success: function(msg){
					if(msg.msg=="True"){
						if(msg.release_info==""){
							$("#examEndModal .examScore").text(msg.score);
							$("#examEndModal .examStatus").text(msg.is_pass);
						}else{
							$("#examEndModal .modal-body").html('<div>'+msg.release_info+'</div>');
						}
						$('#examEndModal').modal({
							backdrop:"static",
							keyboard:false
						});
					}else{
						alert("操作失败，请联系管理员！");
					}
				}
			});
		},1000
	);
}