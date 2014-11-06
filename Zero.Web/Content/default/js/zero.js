(function ($) {
    $.zero = {};
    //��ҳ
    $.extend($.zero, {
        pages: function (setting) {
            var option = {
                name: "paging"//�ؼ�����
                , renderTo: "body"//Ҫ���ֵ��ĸ�Ԫ�أ�jQuery���õ�ѡ���
                , pageIndex: 1//��ǰҳ��
                , pageSize: 10//ÿҳ��¼��
                , recordCount: 0//�ܼ�¼��
                , showPageCount: 10//�ɼ���ҳ����
                , urlMode: ""//urlģʽ��sample-{page}.html�����õ�ǰҳ���滻{page}
                , switchPage: function () { }//��ҳ�¼�
                , button: { name: ["��һҳ", "��һҳ", "��һҳ", "��ĩҳ"], visible: [true/*��һҳ����ĩҳ*/, true/*��һҳ����һҳ*/] }//��ҳ��ť����
                , goto: { text: ["��ת��", "ҳ", "Go"], visible: true }//��ת������
                , pageInfo: { text: "������{recordCount}����¼����ǰ��ʾ{pageIndex}/{pageCount}ҳ", visible: true }//��ҳ��Ϣ���ã�{paramName}Ϊ����������option�е������滻
            }

            //�Ժ��޸�,�᲻���ظ�����
            if (typeof (setting.switchPage) == "function") {
                setting.recordCount = setting.switchPage(option.pageIndex);
            }

            $.extend(true, option, setting);
            option.renderTo = typeof option.renderTo == "string" ? $(option.renderTo) : option.renderTo;
            option.pageCount = divideExactly(option.recordCount, option.pageSize) + (option.recordCount % option.pageSize > 0 ? 1 : 0);//��ҳ��
            option.showPageCount = Math.min(option.showPageCount, option.pageCount);//ʵ��Ҫ��ʾ��ҳ������

            option.currentPageNumber = [];//��ǰ��ʾ��ҳ��
            var control = {};//���ڷ��ʸ�Html����
            //��ʼ����Html����
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
                //����Ҫ��̬��ʾ��ҳ������
                for (var i = 0, count = option.showPageCount - 2; i < count; i++) {//count:��̬���ֵ�ҳ�����۳�ͷβ��ҳ
                    control.pages[i] = $("<a></a>").click(function () {
                        switchPage($(this).attr("pageNumber"));
                    });
                }
                //������ת��ť�¼�
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
                //��װ����
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
            //����Ҫ���ֵ�ҳ��
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
            //����
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
            //�ӵ�ַ����ȡurlMode
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
                renderTo: "page",
                pageIndex: 1,
                pageSize: 10,
                recordCount: 0,
                showPageCount: 5,
                visible: { all: true/*����*/, total: true/*����*/, goto: true/*��ת*/, size: true/*ҳ��*/ }
            }

            $.extend(true, option, setting);


        }
    });

})(jQuery);