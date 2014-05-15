// JavaScript Document
$(function(){
	$("#text").html($("#se-ul li").eq(0).html());
	$(".k_value").attr("value",'0');
	$("#text-input li").eq(0).show();
	$("#text").click(function(event){
		$("#se-ul").toggle();
		var text=$(this).html();
		for(var i=0; i<$("#se-ul li").length;i++){
			if($("#se-ul li").eq(i).html()==text){
				//$("#se-ul li").eq(i).hide();
				$("#se-ul li").eq(i).siblings().show();
			};
			event.stopPropagation();
			event.preventDefault();
		};
	
	});

	$(document).ready(function(){
		var val = $(".B_input").val();
		if(val == "")
		{
			$(".B_input").attr("value","请输入相关关键字..");
		}
	});

	$("#se-ul li").click(function(event){
		var idx=$(this).index();
		var val="";
		$("#text-input li").eq(idx).show().siblings("li").hide();
		$("#text").html($(this).html());
		$(this).parent("#se-ul").hide();
		$("#text").removeClass('otr').addClass('otr1');
		if(idx==0){
			//val="请输入相关关键字..";
			$(".k_value").attr("value",idx);
			$(".B_input").attr("value","请输入相关关键字..");
		}else if(idx==1){
			//val="请输入模板关键字..";
			$(".k_value").attr("value",idx);
			$(".B_input").attr("value","请输入模板关键字..");
		}else if(idx==2){
			//val="请输入插件关键字..";
			$(".k_value").attr("value",idx);
			$(".B_input").attr("value","请输入插件关键字..");
		}else if(idx==3){
			//val="请输入案例关键字..";
			$(".k_value").attr("value",idx);
			$(".B_input").attr("value","请输入案例关键字..");
		}
		else if(idx==4){
			//val="请输入教程关键字..";
			$(".k_value").attr("value",idx);
			$(".B_input").attr("value","请输入教程关键字..");
		}	
		event.stopPropagation();
		event.preventDefault();
	});
	$(document).click(function(){
		$("#se-ul").css({display:"none"});
	});

	$(".B_input").focus(function(){
		var val = $(".B_input").val();
		if(val == "请输入相关关键字..")
		{
			$(".B_input").attr("value", "");
		}
		else if(val == "请输入模板关键字..")
		{
			$(".B_input").attr("value", "");
		}
		else if(val == "请输入插件关键字..")
		{
			$(".B_input").attr("value", "");
		}
		else if(val == "请输入案例关键字..")
		{
			$(".B_input").attr("value", "");
		}
		else if(val == "请输入教程关键字..")
		{
			$(".B_input").attr("value", "");
		}
	});
});
