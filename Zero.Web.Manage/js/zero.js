function divideExactly(exp1, exp2) {
    var n1 = Math.round(exp1); //四舍五入
    var n2 = Math.round(exp2); //四舍五入
    var rslt = n1 / n2; //除
    if (rslt >= 0) {
        rslt = Math.floor(rslt); //返回值为小于等于其数值参数的最大整数值。
    }
    else {
        rslt = Math.ceil(rslt); //返回值为大于等于其数字参数的最小整数。
    }
    return rslt;
}

function checkAction(name) {
    $(".z-tb-footer tr[id]").addClass("hidden");
    $(name).removeClass("hidden");
}

function deleteItem(id) {
    if (confirm("确定删除？")) {
        $("#ids").val(id);
        $("#deleteForm").submit();
    }
}

function reload() {
    document.location = location.href;
}

(function ($) {
    $.zero = {};
    //分页
    $.extend($.zero, {
        paging: function (setting) {
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

    //网格
    $.extend($.zero, {
        grid: function (setting) {
            var tr = $(".z-tb-grid tbody tr");
            tr.mouseenter(function () {
                $(this).addClass("over");
            });

            tr.mouseleave(function () {
                $(this).removeClass("over");
            });

            tr.click(function () {
                $(this).toggleClass("slected");
                $(this).find(":checkbox").each(function () {
                    this.checked = !this.state;
                    this.state = this.checked;
                })
            });

            $(".checkAll").click(function () {
                if (this.checked) {
                    tr.find(":checkbox").each(function () {
                        this.checked = true;
                        this.state = true;
                        $(this).parents("tr").addClass("slected");
                    })
                    $(".checkAll").each(function () {
                        this.checked = true;
                    })
                }

                else {
                    tr.find(":checkbox").each(function () {
                        this.checked = false;
                        this.state = false;
                        $(this).parents("tr").removeClass("slected");
                    })
                    $(".checkAll").each(function () {
                        this.checked = false;
                    })
                }
            });
        }
    });

    //类目
    $.extend($.zero, {
        category: function (setting) {
            var tr = $(".z-tb-category tbody tr");
            tr.mouseenter(function () {
                $(this).addClass("over");
            });

            tr.mouseleave(function () {
                $(this).removeClass("over");
            });

            tr.each(function () {
                var depth = parseInt($(this).attr("depth"));
                var child = parseInt($(this).attr("child"));
                var lid = parseInt($(this).attr("lid"));
                var rid = parseInt($(this).attr("rid"));

                //根据深度，添加间距
                if (depth > 1) {
                    $(this).find(".node").css("margin-left", depth * 10 + "px");
                    $(this).addClass("hidden");
                }

                //包含子节点
                if (child > 0) {
                    $(this).click(function () {
                        var node = $(this).find(".node");
                        node.toggleClass("end");
                        $(this).nextAll().each(function () {
                            nextLid = parseInt($(this).attr("lid"));
                            nextRid = parseInt($(this).attr("rid"));
                            nextDepth = parseInt($(this).attr("depth"));
                            nextChild = parseInt($(this).attr("child"));
                            nextNode = $(this).find(".node");
                            if (nextLid > lid && nextRid < rid) {
                                if (node.hasClass("end")) {
                                    if (nextDepth == depth + 1) {
                                        $(this).removeClass("hidden");
                                    }
                                }
                                else {
                                    if (nextNode.hasClass("end") && nextChild > 0) {
                                        nextNode.removeClass("end");
                                    }
                                    $(this).addClass("hidden");
                                }
                            }
                        })

                    })
                }
                else {
                    $(this).find(".node").addClass("end");
                }
            });
        }
    });

    //弹出框
    $.extend($.zero, {
        popUpBox: function (option) {
            var opt = {
                title: "",
                content: "",
                width: 300,
                height: 150,
                ok: { name: "确定", enable: true, click: null },
                cancel: { name: "取消", enable: true, click: null }
            }
            $.extend(opt, option);
            opt.width -= 4;//左右边框
            opt.height -= 6;//上中下边框

            var popUpBox = {};
            popUpBox.box = $('<div class="PopUpBox"></div>');
            popUpBox.boxHead = $('<div class="PopUpBox-head"></div>');
            popUpBox.boxcontent = $('<div class="PopUpBox-content"></div>');
            popUpBox.boxButton = $('<div class="PopUpBox-button"></div>');
            popUpBox.boxHeadTitle = $('<div class="PopUpBox-head-title"></div>');
            popUpBox.boxHeadClose = $('<div class="PopUpBox-head-close">X</div>');
            popUpBox.boxButtonOk = $('<button class="PopUpBox-button-ok"></button>');
            popUpBox.boxButtonCancel = $('<button class="PopUpBox-button-cancel"></button>');
            popUpBox.boxHead.append(popUpBox.boxHeadTitle).append(popUpBox.boxHeadClose);
            popUpBox.boxButton.append(popUpBox.boxButtonOk).append(popUpBox.boxButtonCancel);
            popUpBox.box.append(popUpBox.boxHead).append(popUpBox.boxcontent).append(popUpBox.boxButton);
            $("body").append(popUpBox.box);

            popUpBox.boxHeadTitle.text(opt.title);
            popUpBox.box.width(opt.width);
            popUpBox.box.height(opt.height);
            popUpBox.boxcontent.text(opt.content);
            popUpBox.boxButtonOk.text(opt.ok.name).css("display", opt.ok.enable ? "auto" : "none").click(opt.ok.click);
            popUpBox.boxButtonCancel.text(opt.cancel.name).css("display", opt.cancel.enable ? "auto" : "none").click(opt.cancel.click);

            popUpBox.boxHeadTitle.width(opt.width - 15);//给关闭按钮留空
            popUpBox.boxcontent.height(opt.height - popUpBox.boxHead.outerHeight() - popUpBox.boxButton.outerHeight());//设置内容的高
            popUpBox.boxHeadClose.click(function () { popUpBox.box.css("display", "none") });
            popUpBox.boxButtonOk.click(function () { popUpBox.box.css("display", "none") });
            popUpBox.boxButtonCancel.click(function () { popUpBox.box.css("display", "none") });

            popUpBox.box.css("top", ($(window).height() - opt.height) / 2);
            popUpBox.box.css("left", ($(window).width() - opt.width) / 2);
        }
    });
})(jQuery);


