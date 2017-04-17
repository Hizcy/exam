 jQuery(function($) {
	$(document).ready( function() {
		//enabling stickUp on the '.navbar-wrapper' class
		//$(".navDiv").stickUp({
		  //enabling marginTop with the 'auto' setting 
		 // marginTop: 'auto'
		//});
	});
 });
 //日历多语言
 var datePikadayLang =  {
			previousMonth : '上一月',
			nextMonth     : '下一月',
			months        : ['一月','二月','三月','四月','五月','六月','七月','八月','九月','十月','十一月','十二月'],
			weekdays      : ['周日','周一','周二','周三','周四','周五','周六'],
			weekdaysShort : ['周日','周一','周二','周三','周四','周五','周六']
		};
 $(document).ready( function() {
	//初始化日历控件
	var $dateForm = $('#dateForm').pikaday({
        firstDay: 1,
		format: 'YYYY-MM-DD',
        minDate: new Date('2000-01-01'),
        maxDate: new Date('2020-12-31'),
        yearRange: [2000,2030],
		i18n: datePikadayLang
    });
	var $dateTo = $('#dateTo').pikaday({
        firstDay: 1,
		format: 'YYYY-MM-DD',
        minDate: new Date('2000-01-01'),
        maxDate: new Date('2020-12-31'),
        yearRange: [2000,2030],
		i18n: datePikadayLang
    });
	//开始考试
	$(".startExamBtn").click(function(e) {
		$("#maskDiv").show();
        var id = $(this).attr("examId");
		var time = parseInt(Math.random()*5+1); //延时触发时间
		$(this).unbind("click");
		setTimeout(function(){
			document.location.href = "/exam/exam_start/"+id;
		},1);
    });
	
	//查看通知
	$(".noticeBtn, .viewExamNoticeBtn").click(function(e) {
		var text = $(this).attr("notice");
        alert(text);
    });

    $(".searchBtn").click(function(e){
        $("#searchForm").submit();
    });
	
	//显示参加考试按钮
	$("div.t-block").on("mouseover mouseout", this, function(event){
		var dom = $(this).find(".mask , .btn-default");
		if(event.type=="mouseover"){
			dom.show();
		}else if(event.type=="mouseout"){
			dom.hide();
		}
	});
	
	//查看考试结果
	$(".viewExamBtn").click(function(e) {
		var exam_info_id = $(this).attr("exam_info_id");
		var exam_results_id = $(this).attr("exam_results_id");
		document.location.href = "/exam/exam_check?exam_info_id="+exam_info_id+"&exam_results_id="+exam_results_id;
    });
	//查看错题
	$(".viewExamErrorBtn").click(function(e) {
		var exam_info_id = $(this).attr("exam_info_id");
		var exam_results_id = $(this).attr("exam_results_id");
		document.location.href = "/exam/exam_error_check?exam_info_id="+exam_info_id+"&exam_results_id="+exam_results_id;
    });
	
});
