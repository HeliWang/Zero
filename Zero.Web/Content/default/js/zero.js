(function ($) {
    $.zero = {};

    $.extend($.zero, {
        paging: function (option) {
            var setting = {
                renderTo: "paging",
                pageIndex: 1,
                pageSize: 10,
                recordCount: 0,
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
                control.num.append(control.prve);

                //加上前后放置的数量，包括前面的第一页和空白省略和最后一页和空白省略
                if (setting.pageCount < setting.showPageCount + 2) {
                    for (var i = 0; i < setting.pageCount; i++) {
                        var page = $("<a></a>").text(i + 1);
                        control.num.append(page);
                    }
                }
                else {
                    var splitPoint = parseInt(setting.showPageCount / 2);//分割线

                    if (setting.pageIndex <= splitPoint + 2) {
                        for (var i = 0; i < setting.showPageCount; i++) {
                            var page = $("<a></a>").text(i + 1);
                            control.num.append(page);
                        }

                        control.num.append(control.lastEllipsis).append(control.last);
                    }
                    else if (setting.pageIndex > (setting.pageCount - splitPoint - 2)) {

                        control.num.append(control.first).append(control.firstEllipsis);

                        for (var i = 0; i < setting.showPageCount; i++) {
                            var page = $("<a></a>").text(i + setting.pageCount - setting.showPageCount + 1);
                            control.num.append(page);
                        }
                    }
                    else {
                        control.num.append(control.first).append(control.firstEllipsis);

                        for (var i = 0; i < setting.showPageCount; i++) {
                            var page = $("<a></a>").text(i + setting.pageIndex - splitPoint);
                            control.num.append(page);
                        }

                        control.num.append(control.lastEllipsis).append(control.last);
                    }
                }

                control.num.append(control.next);
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

})(jQuery);