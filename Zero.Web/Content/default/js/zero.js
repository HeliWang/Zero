﻿(function ($) {
    $.zero = {};



   
    $.extend($.zero, {
        paging: function (option) {
            var setting = {
                renderTo: "paging",
                pageIndex: 1,
                pageSize: 10,
                recordCount: 0,
                digit: 1,//前后显示的位数
                showPageCount: 5,//奇数
                visible: { all: true/*所有*/, total: true/*汇总*/, goto: true/*跳转*/, size: true/*页数*/ }
            }
            $.extend(setting, option);

            var control = {};
            var init = function () {
                function aa()
                {
                    //<div class="p-warp">
                    //    <span class="p-num">
                    //        <a>上一页</a>
                    //        <a>1</a>
                    //        <b>...</b>
                    //        <a>4</a>
                    //        <a>5</a>
                    //        <a class="current">6</a>
                    //        <a>7</a>
                    //        <a>8</a>
                    //        <b>...</b>
                    //        <a>1011</a>
                    //        <a>下一页</a>
                    //    </span>
                    //    <span class="p-skip">
                    //        <em>
                    //            共<b>100</b>条
                    //        </em>
                    //        <em>
                    //            到第&nbsp<input />&nbsp;页
                    //        </em>
                    //        <a>确定</a>
                    //    </span>
                    //</div>
                }

                setting.renderTo = typeof setting.renderTo == "string" ? $(setting.renderTo) : setting.renderTo;
                setting.pageCount = parseInt(setting.recordCount / setting.pageSize);
                setting.pageCount = setting.recordCount % setting.pageSize == 0 ? setting.pageCount : setting.pageCount + 1;
                setting.spaceCount = setting.digit + 1;//位数+省略号

                control.body = $("<div class=\"p-warp\"></div>");
                control.num = $("<span class=\"p-num\"></span>");
                control.prve = $("<a>上一页</a>");
                control.next = $("<a>下一页</a>");
                control.first = $("<a></a>").text(1);
                control.last = $("<a></a>").text(setting.pageCount);
                control.firstEllipsis = $("<b>...</b>");
                control.lastEllipsis = $("<b>...</b>");
                control.pages = [];
                control.skip = $("<span class=\"p-skip\"></span>");
                control.total = $("<em>共<b>0</b>条</em>");
                control.goto = $("<em>到第&nbsp<input />&nbsp;页</em><a>确定</a>");

                control.total.find("b").text(setting.recordCount);

                control.skip.append(control.total).append(control.goto);
                control.body.append(control.num).append(control.skip);
                setting.renderTo.append(control.body);

                calculate();
            }
            var calculate = function () {

                /*
                左边位数=前面数字位数+省略位数
                中间位数=显示位数（如果显示靠前，或显示靠后，需要除2，加上左右边位数）
                右边位数=省略位数+后面数字位数
                */

                control.num.append(control.prve);

                //最大可以一排显示多少位数
                if (setting.pageCount < setting.showPageCount + setting.spaceCount) {
                    for (var i = 0; i < setting.pageCount; i++) {
                        var page = $("<a></a>").text(i + 1);
                        control.num.append(page);
                    }
                }
                else {
                    var splitPoint = parseInt(setting.showPageCount / 2);//分割线

                    if (setting.pageIndex <= splitPoint + setting.spaceCount) {
                        for (var i = 0; i < setting.showPageCount; i++) {
                            var page = $("<a></a>").text(i + 1);
                            control.num.append(page);
                        }
                         
                        appendAfter();
                    }
                    else if (setting.pageIndex > setting.pageCount - (splitPoint + setting.spaceCount)) {

                        appendBefore();

                        for (var i = 0; i < setting.showPageCount; i++) {
                            var page = $("<a></a>").text(i + setting.pageCount - setting.showPageCount + 1);
                            control.num.append(page);
                        }
                    }
                    else {
                        
                        appendBefore();

                        for (var i = 0; i < setting.showPageCount; i++) {
                            var page = $("<a></a>").text(i + setting.pageIndex - splitPoint);
                            control.num.append(page);
                        }

                        appendAfter();
                    }
                }

                control.num.append(control.next);
            }
            var appendBefore = function () {
                for (var i = 0; i < setting.digit; i++) {
                    var page = $("<a></a>").text(i + 1);
                    control.num.append(page);
                }
                control.num.append(control.firstEllipsis);
            }
            var appendAfter = function () {
                control.num.append(control.lastEllipsis);
                for (var i = setting.digit ; i > 0; i--) {
                    var page = $("<a></a>").text(setting.pageCount + 1 - i);
                    control.num.append(page);
                }
            }
            var appendPage = function (count, startValue) {
                for (var i = 0; i <= count; i++) {
                    var page = $("<a></a>").text(startValue + i);
                    control.num.append(page);
                }
            }

            { init();  }


            $.extend(true, option, setting);
            return this;
        }
    });

    $.extend($.zero, {
        Query: function () {
            var paramList = [{ name: 'page', value: '1' }, {name:'site',value:'abc'}];
            var init = function () {
                var url = document.location.search;
                if (url.indexOf("?") != -1) {
                    var path = url.substr(0);
                    var paramStr = url.substr(1);
                    var paramArray = paramStr.split("&");
                    for (var i = 0; i < paramArray.length; i++) {
                        var param = paramArray[i].split("=");
                        paramList[i] = { key: param[0], value: param[1] };
                    }
                }
            }
            var set = function (name, value) {
                for (var i = 0; i < paramList.length; i++) {
                    if (paramList[i].key == name) {
                        return paramList.splice(i, 1, { key: name, value: value });
                    }
                }
            }
            var add = function (name, value) {
                paramList[paramList.length] = { key: name, value: value };
            }
            var remove = function (name) {
                for (var i = 0; i < paramList.length; i++) {
                    if (paramList[i].key == name) {
                         return paramList.splice(i, 1);
                    }
                }
            }
            var get = function (name) {
                for (var i = 0; i < paramList.length; i++) {
                    if (paramList[i].key == name) {
                        return paramList[i].value;
                    }
                }
                return "";
            }
            var clear = function () {
            }
            init();
            return this;
        }
    });

})(jQuery);