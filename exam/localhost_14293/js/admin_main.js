$(document).ready( function() {
	//读取用户自定义LOGO
	if($("#logo").length>0){
		$.ajax({
			type: "GET",
			cache : false,
			//headers: { "cache-control": "no-cache" },
			dataType: "json",
			url: "/admin/modify_get_logo",
			success: function(msg){
				if(msg.msg=="True"){
					var logo_url = msg.logo_url;
					var img = '<img src="'+msg.logo_url+'?'+Math.random()+'" width="221" height="60" style="width:221px; height:60px;" />';
					$("#logo a").html(img);
					$("#logo").show();
					$("a#logoutBtn").attr("href","/account/logout/"+msg.company_id);
				}else{
					//alert("操作失败，请稍候再试！");
				}
			}
		});
	}
	
});

