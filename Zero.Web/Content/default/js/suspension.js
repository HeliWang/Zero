var str = '<style type="text/css">.suspension { position: fixed; z-index: 55; right: 10px; bottom: 10px; width: 80px; height: 204px; }.suspension-box { position: relative; float: right; }.suspension-box a { display: block; width: 50px; height: 50px; background-color: #B5B5B5; margin-bottom: 1px; cursor: pointer; }.suspension-box a.back_top { background-color: #797979; }.suspension-box a.qq:hover,.suspension-box a.tel:hover,.suspension-box a.code:hover { opacity: 0.8; filter: alpha(opacity=80); }.suspension-box a.back_top:hover { background-color: #FC7878; }.suspension-box a i { display: block; float: left; width: 25px; margin-left: 15px; margin-top: 15px; background-image: url(http://www.ecmoban.com/content/themes/ecmoban2014/images/suspension-bg.png); background-repeat: no-repeat; text-indent: -9999px; }.suspension-box a.qq i { background-position: 0 0; }.suspension-box a.tel i { background-position: -25px 0; }.suspension-box a.code i { background-position: 0 -25px; }.suspension-box a.back_top i { background-position: -28px -25px; }.suspension-box div.code { position: absolute; left: -196px; *left: -207px; top: 0; display: none; width: 178px; height: 198px; padding-left: 10px; padding-top: 10px; background-color: #fff; border: 1px solid #D9D9D9; }.suspension-box div.code p { width: 155px; margin-top: 5px; text-align: center; }.suspension-box div.code i { width: 8px; height: 15px; position: absolute; top: 118px; right: -8px; background-image: url(http://www.ecmoban.com/content/themes/ecmoban2014/images/trangle-right-suspension.png); background-repeat: no-repeat; }.suspension-box div.tel { position: absolute; left: -197px; top: 48px; display: none; width: 177px; height: 85px; background-color: #fff; border: 1px solid #D7D7D7; }.suspension-box div.tel i { width: 8px; height: 15px; position: absolute; top: 20px; right: -8px; background-image: url(http://www.ecmoban.com/content/themes/ecmoban2014/images/trangle-right-suspension.png); background-repeat: no-repeat; }.suspension-box div.tel strong { display: block; margin-left: 17px; margin-top: 16px; font-size: 16px; font-weight: normal; }.suspension-box div.tel p { margin-left: 17px; font-size: 23px; font-family: arial; color: #FD696D; }.icon { margin-top:-5px; }.nav a.cart-title-name { color: #000; text-decoration: none; line-height: normal; }.nav a.cart-title-name:hover { color: #ef353d; text-decoration: underline; line-height: normal; }.nav a font { padding: 8px 15px; background:#fd7878; border-radius: 5px; }.nav a font:hover { padding: 8px 15px; background:#ea5050; border-radius: 5px; }</style><div class="suspension"><div class="suspension-box"><a href="http://wpa.b.qq.com/cgi/wpa.php?ln=1&key=XzgwMDAwNzE2N18zNzUzN184MDAwMDcxNjdfMl8" target="_blank" class="qq"><i>qq</i></a><a class="tel j-icon"><i>tel</i></a><a class="code j-icon"><i>code</i></a><a class="back_top j-back-top"><i>back_top</i></a><div class="tel j-box"><strong>服务热线：</strong><p>4000-021-758</p><i></i></div><div class="code j-box"><img src="http://www.ecmoban.com/content/themes/ecmoban2014/images/suspension-code.png" alt=""><p>扫一扫，微信关注模板堂</p><i></i></div></div></div>';
//加载字符串
$("body").append(str);
// 效果
$(".suspension").find(".j-icon").mouseover(
    function(){
        $(".suspension").find(".j-box").eq($(this).index()-1).show().siblings(".j-box").hide();
    }
);
//判断ie浏览器
	
	if(navigator.appVersion.match(/11./i) == '11.' || navigator.appVersion.match(/10./i) == '10.') {
		$(".suspension").css("right","30px");
	}

$(".suspension .j-back-top").hide()

$(window).scroll(function(){
    if($(window).scrollTop() > 100){
        $(".suspension .j-back-top").fadeIn()
    }else {
        $(".suspension .j-back-top").fadeOut()
    }
});
// 效果
$(".suspension").mouseleave(function(event){
    event.preventDefault();
    $(".suspension").find(".j-box").hide();
});

$(".j-back-top").click(function(){
    $("html,body").animate({scrollTop:0},500);
});