(function(){
			//自动加载自身内容，防止出现空白
		    $("#big-slide-ul").append($("#big-slide-ul").html());
		    $("#big-slide-ul").append($("#big-slide-ul").html());

			var reg = /slide-r/;   //用来判断是左右哪一个按钮点击
			var l_now;             //用来存储大图滚动的参数
			var SlideMovie = function(obj)
			{
			  	var l = parseInt($("#big-slide-ul").css('left'));
			    //防止客户连续快速点击
			    if(l%750 != 0) return;
		        //判断当前是否是右测按钮，还是测的按钮或者是自动滑动
			    if(reg.test(obj.attr('class')))
			    {
			       l_now = l + 750;
			    }else{
			       l_now = l - 750;
			    }

				$("#big-slide-ul").animate({left:l_now+'px'},'normal',function(){
			        $(".slide-p span").eq((((-l_now)/750)%3)).addClass('slide-checked').siblings('span').removeClass('slide-checked');
					if(l_now == -4500 || l_now ==0){$("#big-slide-ul").css('left',-2250+'px');}
				});
			}
		    //初始化事件定时参数
		    var slideTimer = setInterval(SlideMovie,5000);
			$(".big-slide").hover(
			    function(){
			    	clearInterval(slideTimer);
			    	$('.slide-btn').css('display','block');
			    	$(".slide-l").animate({left:'5px'},'normal');
			    	$(".slide-r").animate({right:'5px'},'normal');
			    },
				function(){
					slideTimer = setInterval(SlideMovie,5000);
					$(".slide-l").animate({left:'-38px'},'normal');
			    	$(".slide-r").animate({right:'-38px'},'normal',function(){
			    		$('.slide-btn').css('display','none');
			    	});
				}
			);
			// 点击事件
		    $('.slide-btn').click(function(){var obj = $(this);SlideMovie(obj);});
		    //左右按钮悬停效果
		    $('.slide-btn').hover(
			    function(){$(this).addClass('slide-hover');},
			    function(){$(this).removeClass('slide-hover');}
		    );
		    //地步三个圆点按钮的点击事件
		    $(".slide-p span").click(function(){
		   	  var l_now = -($(this).index()+3)*750;
		   	  var n_now = $(this);
		   	  $("#big-slide-ul").animate({left:l_now+'px'},'normal',function(){n_now.addClass('slide-checked').siblings().removeClass('slide-checked');});
		    });
		})()