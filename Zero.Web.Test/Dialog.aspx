<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dialog.aspx.cs" Inherits="Zero.Web.Test.Dialog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body, div, address, blockquote, iframe, ul, ol, dl, dt, dd, li, dl, h1, h2, h3, h4, h5, h6, p, pre, table, caption, th, td, form, legend, fieldset, input, button, select, textarea {margin:0; padding:0; font-weight: normal;font-style: normal;font-size: 100%; font-family: inherit;}
        ol, ul ,li{list-style: none;}
        a{text-decoration:none; color:#000;cursor:pointer;}
        img {border: 0;}
        em{font-style:normal;}
        body {color:#000;background:#FFF; font: 12px/1.5 Arial, Helvetica, sans-serif;}
        .clearfix:after {clear:both; content:"."; display:block; height:0pt; visibility:hidden; overflow:hidden;}
        .clear{clear:both;height:1px; margin-top:-1px; width:100%;}
        .block{display:block;}
        .hidden{display:none;}
        h1 {font-size:18px;}
        h2 {font-size:16px;}
        h3 {font-size:14px;}
        h4 {font-size:12px;}
        h5 {font-size:12px;}
        h3 {font-size:12px;}
        h1, h2, h3, h4, h5, h6, strong {font-weight:bold;}
        html,body{height:100%; background:#FFF;}
    </style>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <style>
            .z-dialog{position:absolute;left: 300px;top: 300px; width:300px; height:300px; border: 1px solid #99bbe8;background:#efefef; z-index:99999;}
            .z-dialog-header{height:25px; line-height:25px; cursor:move;}
            .z-dialog-title{float:left;padding-left:10px;}
            .z-dialog-tool {float:right;margin-top:4px;height:16px;}
            .z-dialog-tool a{display:inline-block; margin-right:5px; width:16px;height:16px;}
            .z-dialog-min { background:url(../images/delete.gif) no-repeat center;}
            .z-dialog-max { background:url(../images/add.gif) no-repeat center;}
            .z-dialog-close { background:url(../images/error.gif) no-repeat center;}
            .z-dialog-content{padding:10px; border-top: 1px solid #99bbe8; border-bottom: 1px solid #99bbe8; background:#fff;}
            .z-dialog-footer{text-align:center;height:30px; line-height:30px;}
            .z-dialog-footer input{margin-right:10px;height:20px;line-height:20px; padding-left:5px; padding-right:5px; }
            .z-dialog .hidden { display:none;}
            .z-dialog-mask{width:100%; height:100%; position:absolute; left:0; top:0; background-color: #ccc;  filter:alpha(opacity=50); opacity:0.5; z-index:99998; border: 1px solid #99bbe8;}  
        </style>
        <%--<div class="z-dialog">
            <div class="z-dialog-header">
                <span class="z-dialog-title">弹出框</span>
                <span class="z-dialog-min">缩小</span>
                <span class="z-dialog-max">放大</span>
                <span class="z-dialog-close">关闭</span>
            </div>
            <div class="z-dialog-content">
                内容
            </div>
            <div class="z-dialog-footer">
                <input type="button" value="确定"/>
                <input type="button" value="取消"/>
            </div>
        </div>--%>

        <script type="text/javascript">
            (function ($) {
                $.zero = {}
                $.extend($.zero, {
                    dialog: function (option) {
                        var setting = {
                            id: 'dialog'
                            , title: '弹出框'
                            , content: '空白内容'
                            //, ok: { callback: '回调函数', enable: true, okVal: '确定' }//确定按钮
                            //, cancel: { callback: '回调函数', enable: true, cancelVal: '取消' }//取消按钮
                            , min: { enable: true }//是否显示缩小按钮
                            , max: { enable: true }//是否显示放大按钮
                            , button: [{ name: 'ok', callback: '回调函数', val: '确定' }, { name: 'ok', callback: '回调函数', val: '取消' }]//添加按钮
                            , size: { width: 300, height: 300, }//尺寸
                            , position: { fixed: true, left: 100, top: 100 }//位置相关,fixed：开启静止定位，是静止在浏览器某个地方不动，也不受滚动条拖动影响
                            , mutual: { resize: true, drag: true, mask: true, cache: true }//resize:是否可以调节尺寸;drag：是否可以拖动;drag是否遮罩;cache:是否缓存框架页
                            , time: 0//指定时间后关闭窗口
                            , iframe: ""//框架页
                        }
                        $.extend(true, setting, option);

                        var control = {};
                        //初始化
                        var init = function () {
                            control.box = $('<div class="z-dialog"></div>').width(setting.size.width).height(setting.size.height);
                            control.header = $('<div class="z-dialog-header clearfix"></div>');
                            control.title = $('<span class="z-dialog-title"></span>').text(setting.title);
                            control.tool = $('<span class="z-dialog-tool"></span>')
                            control.min = $('<a class="z-dialog-min"></a>');
                            control.max = $('<a class="z-dialog-max"></a>');
                            control.close = $('<a class="z-dialog-close"></a>');
                            control.content = $('<div class="z-dialog-content"></div>').text(setting.content);
                            control.footer = $('<div class="z-dialog-footer"></div>');
                            control.button = [];
                            control.mask = $('<div class="z-dialog-mask"></div>');
                            control.iframe = $('<iframe width="100%" height="100%"></iframe>');
                            //组装头部部件
                            control.header.append(control.title);
                            if (setting.min.enable) {
                                control.min.click(min);
                                control.tool.append(control.min);
                            }
                            if (setting.max.enable) {

                                control.max.click(max);
                                control.tool.append(control.max);
                            }
                            control.close.click(close);
                            control.tool.append(control.close);
                            if (setting.mutual.drag == true) {
                                drag();//拖拽
                            }
                            control.header.append(control.title).append(control.tool);
                            //组装中间内容
                            control.content.height(control.box.height() - 75);//减去头部和底部
                            if (setting.iframe != "") {
                                //框架页
                                control.iframe.attr("src", setting.iframe);
                                control.content.append(control.iframe);
                            }
                            else {
                                //简单内容
                                control.content.text(setting.content);
                            }
                            //组装底部部件
                            for (var i = 0; i < setting.button.length; i++) {
                                control.button[i] = $('<input type="button"/>').val(setting.button[i].val);
                                control.footer.append(control.button[i]);//按钮
                            }
                            //组装所有部件
                            control.box.append(control.header).append(control.content).append(control.footer);
                            if (setting.mutual.mask == true) {
                                $("body").append(control.mask);//遮罩
                            }
                            $("body").append(control.box);
                            //自动关闭
                            if (setting.time > 0) {
                                control.title.text(control.title.text() + ": " + setting.time + " 秒后将自动关闭");
                                setTimeout(close, setting.time * 1000);
                            }
                        }
                        //最大化
                        var max = function () {
                            control.box.height(500);
                            control.box.width(500);
                            control.content.height(control.box.height() - control.header.height() - control.footer.height() - 20);
                        }
                        //最小化
                        var min = function () {
                            control.box.height(setting.size.height);
                            control.box.width(setting.size.width);
                            control.content.height(control.box.height() - control.header.height() - control.footer.height() - 20);
                        }
                        //关闭或者隐藏
                        var close = function () {
                            if (setting.mutual.cache == true) {
                                control.box.hide()//隐藏并缓存原来的样式值
                                if (setting.mutual.mask == true) {
                                    control.mask.hide();
                                }
                            }
                            else {
                                control.box.remove();
                                if (setting.mutual.mask == true) {
                                    control.mask.remove();
                                }
                            }
                        }
                        //拖拽
                        var drag = function () {
                            var _move = false;
                            var _x, _y;
                            control.header.mousedown(function (e) {
                                _move = true;
                                _x = e.pageX - parseInt(control.box.css("left"));
                                _y = e.pageY - parseInt(control.box.css("top"));
                                control.box.fadeTo(20, 0.60);//点击后开始拖动并透明显示
                            });
                            $(document).mousemove(function (e) {
                                if (_move) {
                                    var x = e.pageX - _x;
                                    var y = e.pageY - _y;
                                    if (x < 0) x = 0;
                                    if (y < 0) y = 0;
                                    control.box.css({ top: y, left: x });//控件新位置
                                }
                            }).mouseup(function () {
                                _move = false;
                                control.box.fadeTo("fast", 1);//松开鼠标后停止移动并恢复成不透明
                            });
                        }

                        //var alert = function (content, callback, parent) {
                        //    //参数1：内容
                        //    //参数2：窗口关闭时执行的回调函数
                        //    //参数3：警告窗口的父窗口对象
                        //}
                        //var confirm = function (content, yes, no, parent) {
                        //    //参数1：内容
                        //    //参数2：确定按钮回调函数
                        //    //参数3：文本框默认值
                        //    //参数4：提问窗口的父窗口对象
                        //}
                        //var prompt = function (content, yes, value, parent) {
                        //    //参数1：内容
                        //    //参数2：确定按钮回调函数
                        //    //参数3：文本框默认值
                        //    //参数4：提问窗口的父窗口对象
                        //}
                        //var tips = function (content, time, icon, callback) {
                        //    //参数1：内容
                        //    //参数2：显示时间
                        //    //参数3：提示图标
                        //    //参数4：提示关闭时执行的函数
                        //}
                        { init(); }
                    }
                });
                $.zero.dialog.alert = function (c) {
                    $.zero.dialog({ title: "警告框", content: c, min: false, max: false });
                };
                $.zero.dialog.confirm = function (c) {
                    $.zero.dialog({ title: "确定框", content: c, min: false, max: false });
                };
                $.zero.dialog.tips = function (c) {
                    $.zero.dialog({ title: "提醒框", content: c, min: false, max: false });
                };
            })(jQuery);

            $(function () {
                //$.zero.dialog({ min: false });
                //$.zero.dialog.alert("请选择要操作的项目");
                $.zero.dialog.alert("操作成功", {});
            });
    </script>
        
        <%--<div class="z-dialog">
            <ul class="z-dialog-header clearfix">
                <li class="z-dialog-title">弹出框</li>
                <li class="z-dialog-min">缩小</li>
                <li class="z-dialog-max">放大</li>
                <li class="z-dialog-close">关闭</li>
            </ul>
            <div class="z-dialog-content clearfix">
                内容
            </div>
            <ul class="z-dialog-footer">
                <li><input type="button" value="确定"/></li>
                <li><input type="button" value="取消"/></li>
            </ul>
        </div>--%>
    </div>
    </form>
</body>
</html>
