(function ($) {
    $.zero = {};
    //分页
    $.extend($.zero, {
        pages: function (setting) {
            var option = {
                name: "paging"//控件名称
                , renderTo: "body"//要呈现到的父元素，jQuery可用的选择符
                , pageIndex: 1//当前页号
                , pageSize: 10//每页记录数
                , recordCount: 0//总记录数
                , showPageCount: 10//可见的页号数
                , urlMode: ""//url模式如sample-{page}.html，将用当前页号替换{page}
                , switchPage: function () { }//翻页事件
                , button: { name: ["第一页", "上一页", "下一页", "最末页"], visible: [true/*第一页和最末页*/, true/*上一页和下一页*/] }//换页按钮设置
                , goto: { text: ["跳转到", "页", "Go"], visible: true }//跳转区设置
                , pageInfo: { text: "，共有{recordCount}条记录，当前显示{pageIndex}/{pageCount}页", visible: true }//分页信息设置，{paramName}为参数名将被option中的数据替换
            }

            //以后修改,会不会重复调用
            if (typeof (setting.switchPage) == "function") {
                setting.recordCount = setting.switchPage(option.pageIndex);
            }

            $.extend(true, option, setting);
            option.renderTo = typeof option.renderTo == "string" ? $(option.renderTo) : option.renderTo;
            option.pageCount = divideExactly(option.recordCount, option.pageSize) + (option.recordCount % option.pageSize > 0 ? 1 : 0);//总页数
            option.showPageCount = Math.min(option.showPageCount, option.pageCount);//实际要显示的页号数量

            option.currentPageNumber = [];//当前显示的页号
            var control = {};//用于访问各Html部件
            //初始化各Html部件
            var init = function () {
                control.paging = $("<div></div>");
                control.first = $("<a></a>").text(option.button.name[0]).click(function () { switchPage(1); });
                control.prve = $("<a></a>").text(option.button.name[1]).click(function () { switchPage(option.pageIndex - 1); });
                control.head = $("<a>1</a>").click(function () { switchPage(1); });
                control.headEtc = $("<span>...</span>");
                control.pages = [];
                control.footEtc = $("<span>...</span>");
                control.foot = $("<a></a>").text(option.pageCount).click(function () { switchPage(option.pageCount); });
                control.next = $("<a></a>").text(option.button.name[2]).click(function () { switchPage(option.pageIndex + 1); });
                control.last = $("<a></a>").text(option.button.name[3]).click(function () { switchPage(option.pageCount); });
                control.goto = $('<span>' + option.goto.text[0] + '<input type="text" class="text" />' + option.goto.text[1] + '<input type="button" class="button" value="' + option.goto.text[2] + '" /></span>');
                control.info = $("<span></span>");
                //计算要动态显示的页号数量
                for (var i = 0, count = option.showPageCount - 2; i < count; i++) {//count:动态呈现的页数，扣除头尾两页
                    control.pages[i] = $("<a></a>").click(function () {
                        switchPage($(this).attr("pageNumber"));
                    });
                }
                //设置跳转按钮事件
                control.goto.find(":text").keydown(function () {
                    var e = event;
                    return !(e.keyCode == 32);
                }).keyup(function () {
                    var val = $(this).val();
                    if (val == "") { return; }
                    var reg = new RegExp("^[0-9]*$");
                    if (reg.test(val)) {
                        val = parseInt(val);
                        if (val < 1) {
                            val = 1;
                        } else if (val > option.pageCount) {
                            val = option.pageCount;
                        }
                        $(this).attr("oldVal", val);
                    }
                    $(this).val($(this).attr("oldVal"));
                });
                control.goto.find(":button").click(function () {
                    var val = control.goto.find(":text").val();
                    if (val == "") { return; }
                    var reg = new RegExp("^[0-9]*$");
                    if (reg.test(val)) {
                        option.pageIndex = parseInt(val);
                        calculate();
                        render();
                    }
                });
                //组装部件
                control.paging.appendTo(option.renderTo).append(control.first).append(control.prve).append(control.head).append(control.headEtc);
                for (var i = 0; i < control.pages.length; i++) {
                    control.paging.append(control.pages[i]);
                }
                control.paging.append(control.footEtc).append(control.foot).append(control.next).append(control.last).append(control.goto).append(control.info);
                if (!option.button.visible[0]) {
                    control.first.hide();
                    control.last.hide();
                }
                if (!option.button.visible[1]) {
                    control.prve.hide();
                    control.next.hide();
                }
                if (!option.goto.visible) {
                    control.goto.hide();
                }
                if (!option.pageInfo.visible) {
                    control.info.hide();
                }
            }
            //计算要呈现的页号
            var calculate = function () {
                var start = option.pageIndex - (divideExactly(option.showPageCount, 2) + option.showPageCount % 2) + 1;
                start = Math.max(1, start);
                for (var i = 0; i < option.showPageCount; i++) {
                    option.currentPageNumber[i] = start++;
                }
                if (option.currentPageNumber[option.currentPageNumber.length - 2] >= option.pageCount) {
                    start = option.pageCount;
                    for (var i = option.currentPageNumber.length - 1; i >= 0; i--) {
                        option.currentPageNumber[i] = start--;
                    }
                }
            }
            //呈现
            var render = function () {
                control.head.hide();
                control.headEtc.hide();
                for (var i = 0; i < control.pages.length; i++) {
                    control.pages[i].hide();
                }
                control.footEtc.hide();
                control.foot.hide();
                if (option.currentPageNumber.length == 1) {
                    control.head.show();
                }
                if (option.currentPageNumber.length == 2) {
                    control.head.show();
                    control.foot.show();
                }
                if (option.currentPageNumber.length > 2) {
                    control.head.show();
                    if (option.currentPageNumber[1] - 1 > 1) {
                        control.headEtc.show();
                    }
                    for (var i = 1 ; i < option.currentPageNumber.length - 1; i++) {
                        control.pages[i - 1].text(option.currentPageNumber[i])
                            .attr("pageNumber", option.currentPageNumber[i]).show();
                    }
                    if (option.pageCount - option.currentPageNumber[option.currentPageNumber.length - 2] > 1) {
                        control.footEtc.show();
                    }
                    control.foot.show();
                }
                control.paging.find("a").each(function () {
                    $(this).removeClass("selected");
                });
                control.paging.find("a").each(function () {
                    if ($(this).text() == option.pageIndex) {
                        $(this).addClass("selected");
                    }
                });
                if (option.urlMode != "") {
                    control.head.attr("href", option.urlMode.replace("{page}", 1));
                    for (var i = 0; i < control.pages.length; i++) {
                        control.pages[i].attr("href", option.urlMode.replace("{page}", control.pages[i].attr("pageNumber")));
                    }
                    control.foot.attr("href", option.urlMode.replace("{page}", option.pageCount));
                }
                control.info.text(option.pageInfo.text.replace("{recordCount}", option.recordCount).replace("{pageIndex}", option.pageIndex).replace("{pageCount}", option.pageCount));
            }
            var switchPage = function (pageIndex) {
                if (pageIndex < 1) {
                    option.pageIndex = 1;
                } else if (pageIndex > option.pageCount) {
                    option.pageIndex = option.pageCount;
                } else {
                    option.pageIndex = pageIndex;
                }
                calculate();
                if (option.pageIndex == option.currentPageNumber[0]
                    || option.pageIndex == option.currentPageNumber[option.currentPageNumber.length - 1]) {
                    calculate();
                }
                render();
                option.switchPage(option.pageIndex);
            }
            //从地址栏获取urlMode
            var getUrlMode = function () {
                var page = "?page={page}";
                var path = window.location.pathname + window.location.search;
                var temp = path.split("?");
                if (temp.length > 1) {
                    page = "&page={page}";
                    path = temp[0] + "?";
                    temp = temp[1].split("&");
                    var r = new RegExp("^page=");
                    for (var i = 0; i < temp.length; i++) {
                        if (r.test(temp[i])) {
                            temp[i] = "page={page}";
                            page = "";
                        }
                        path += temp[i];
                        if (temp.length - 1 != i) {
                            path += "&";
                        }
                    }
                }
                return path + page;
            }
            if (!(typeof (setting.urlMode) == "string") && !(typeof (setting.switchPage) == "function")) {
                option.urlMode = getUrlMode();
            }

            { init(); calculate(); render(); }
        }
    });

    $.extend($.zero, {
        paging: function (option) {
            var setting = {
                renderTo: "paging",
                pageIndex: 1,
                pageSize: 10,
                recordCount: 0,
                showPageCount: 5,
                visible: { all: true/*所有*/, total: true/*汇总*/, goto: true/*跳转*/, size: true/*页数*/ }
            }
            $.extend(setting, option);

<<<<<<< HEAD
            var control = {};
            var init = function () {
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

                setting.renderTo = typeof setting.renderTo == "string" ? $(setting.renderTo) : setting.renderTo;
                setting.pageCount = parseInt(setting.recordCount / setting.pageSize);
                setting.pageCount = setting.recordCount % setting.pageSize == 0 ? setting.pageCount : setting.pageCount + 1;

                control.body = $("<div class=\"p-warp\"></div>");
                control.num = $("<span class=\"p-num\"></span>");
                control.prve = $("<a>上一页</a>");
                control.next = $("<a>下一页</a>");
                control.ellipsis = $("<b>...</b>");
                control.pages = [];
                control.skip = $("<span class=\"p-skip\"></span>");
                control.total = $("<em>共<b>0</b>条</em>");
                control.goto = $("<em>到第&nbsp<input />&nbsp;页</em><a>确定</a>");

                control.total.find("b").text(setting.recordCount);

                control.num.append(control.pages);
                control.skip.append(control.total).append(control.goto);
                control.body.append(control.num).append(control.skip);
                setting.renderTo.append(control.body);
            }
            var calculate = function () {
                
            }

            { init(); calculate(); }


            $.extend(true, option, setting);
            return this;
        }
    });

})(jQuery);