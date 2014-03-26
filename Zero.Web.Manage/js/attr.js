/*======类目属性======*/

var attrs = [{
    aid: 1,
    name: '颜色',
    type: 'multiCheck',
    isMust: '0',
    isKey: '0',
    isSale: '1',
    isAllowAlias: '0',
    hasImage:'1',
    values: [{
        vid: 1,
        name: '白色'
    },
    {
        vid: 2,
        name: '黑色'
    }]
},
  {
      aid: 2,
      name: '尺码',
      type: 'multiCheck',
      isMust: '0',
      isKey: '0',
      isSale: '1',
      isAllowAlias: '0',
      hasImage: '0',
      values: [{
          vid: 3,
          name: '34'
      },
      {
          vid: 4,
          name: '35'
      }]
  }
  ,
  {
      aid: 3,
      name: '种类',
      type: 'optionalText',
      isMust: '0',
      isKey: '0',
      isSale: '0',
      isAllowAlias: '0',
      hasImage: '0',
      values: [{
          vid: 5,
          name: '天然'
      },
      {
          vid: 7,
          name: '人工'
      }
      ,
      {
          vid: 6,
          name: '化疗'
      }]
  }
  ,
  {
      aid: 3,
      name: '产地',
      type: 'text',
      isMust: '0',
      isKey: '0',
      isSale: '0',
      isAllowAlias: '0',
      hasImage: '0',
      values: []
  }
  ,
  {
      aid: 3,
      name: '品牌',
      type: 'multiCheckText',
      isMust: '0',
      isKey: '0',
      isSale: '0',
      isAllowAlias: '0',
      hasImage: '0',
      values: [{
          vid: 5,
          name: '匹克'
      },
      {
          vid: 7,
          name: '安踏'
      }
      ,
      {
          vid: 6,
          name: '阿迪'
      }]
  }
];

(function ($) {
    $.zero = {}
    $.extend($.zero, {
        attr: function (base, sale) {
            var saleAttr = [];
            var s = 0;
            var init = function () {
                var control = {};
                control.baseBox = $('<table class="z-attr-base"></table>');
                control.saleBox = $('<div class="z-attr-sale"></div>');
                for (var i = 0; i < attrs.length; i++) {
                    if (attrs[i].isSale == "0") {
                        //基本属性
                        control.baseBox.append(getBase(attrs[i]));
                    }
                    else {
                        //销售属性
                        control.saleBox.append(getSale(attrs[i]));
                        saleAttr[s] = attrs[i];
                        s++;
                    }
                }
                $(base).append(control.baseBox);
                $(sale).append(control.saleBox);
            }
            var getBase = function (attr) {
                var tr = $('<tr></tr>');
                var th = $('<th></th');
                var td = $('<td></td>');
                th.text(attr.name);
                td.append(getOption(attr));
                tr.append(th).append(td);
                return tr;
            }
            var getSale = function (attr) {
                var div = $('<div></div>');
                var span = $('<span></span>');
                var ul = $('<ul class="clearfix"></ul>');
                var li = $('<li></li>');
                span.text(attr.name);
                li.append(getOption(attr));
                ul.append(li);
                div.append(span).append(ul);
                return div;
            }
            var getOption = function (attr) {
                var option = {};
                option.box = $("<span></span>");
                option.radio = [];
                option.lable = [];
                option.checkbox = [];
                option.text = [];

                switch (attr.type) {
                    case "text":
                        //非枚举可输入
                        option.box = $('<input type="text"/>');
                        break;

                    case "optional":
                        //枚举单选
                        for (var j = 0; j < attr.values.length; j++) {
                            option.radio[j] = $('<input type="radio"/>');
                            option.lable[j] = $('<lable></lable>');
                            option.radio[j].attr({ id: "", name: "" });
                            option.lable[j].text(attr.values[j].name);
                            option.box.append(option.radio[j]).append(option.lable[j]);
                        }
                        break;

                    case "multiCheck":
                        //枚举多选                   
                        for (var j = 0; j < attr.values.length; j++) {
                            option.checkbox[j] = $('<input type="checkbox"/>');
                            option.lable[j] = $('<lable></lable>');
                            option.lable[j].text(attr.values[j].name);
                            option.box.append(option.checkbox[j]).append(option.lable[j]);
                            option.checkbox[j].change(function () {
                                initSku();
                                initImage();
                            });
                        }
                        break;

                    case "optionalText":
                        //枚举可输入单选
                        for (var j = 0; j < attr.values.length; j++) {
                            option.radio[j] = $('<input type="radio"/>');
                            option.text[j] = $('<input type="text"/>');
                            option.text[j].val(attr.values[j].name);
                            option.box.append(option.radio[j]).append(option.text[j]);
                        }
                        break;

                    case "multiCheckText":
                        //枚举可输入多选
                        for (var j = 0; j < attr.values.length; j++) {
                            option.checkbox[j] = $('<input type="checkbox"/>');
                            option.text[j] = $('<input type="text"/>');
                            option.text[j].val(attr.values[j].name);
                            option.box.append(option.checkbox[j]).append(option.text[j]);
                        }
                        break;
                }
                return option.box;
            }
            var initSku = function () {
                var skuBox = $('<table class="z-sku"></table>');
                var thead = $('<thead></thead>');
                var theadTr = $('<tr></tr>');
                var theadTd = [];
                var tbody = $('<tbody></tbody>');
                var tbodyTr = [];
                if (saleAttr.length == 0 && saleAttr.length > 2) {
                    return;
                }

                //sku头部
                for (var i = 0; i < saleAttr.length; i++) {
                    theadTd[i] = $('<td>' + saleAttr[i].name + '</td>');
                }
                theadTd[saleAttr.length] = $('<td>价格</td>');
                theadTd[saleAttr.length + 1] = $('<td>库存</td>');
                theadTd[saleAttr.length + 2] = $('<td>已售</td>');
                theadTd[saleAttr.length + 3] = $('<td>条形码</td>');
                thead.append(theadTr.append(theadTd));

                //sku内容
                var saleSpan = $(".z-attr-sale li span");
                var saleChecked = [];

                if (saleAttr.length == 1) {
                    saleChecked[0] = $(saleSpan[0]).find(":checked");
                    for (var a = 0; a < saleChecked[0].length; a++) {
                        var tbodyTd = [];
                        tbodyTd[0] = $('<td></td>').text($(saleChecked[0][a]).next().text());
                        tbodyTd[1] = $('<td><input type="text"/></td>');
                        tbodyTd[2] = $('<td><input type="text"/></td>');
                        tbodyTd[3] = $('<td>10</td>');
                        tbodyTd[4] = $('<td class="code"><input type="text"/></td>');
                        tbodyTr[a] = $('<tr></tr>').append(tbodyTd);
                    }
                }
                else if (saleAttr.length == 2) {
                    saleChecked[0] = $(saleSpan[0]).find(":checked");
                    saleChecked[1] = $(saleSpan[1]).find(":checked");
                    var t = 0;
                    for (var a = 0; a < saleChecked[0].length; a++) {
                        for (var b = 0; b < saleChecked[1].length; b++) {
                            var tbodyTd = [];
                            var length = 0;
                            if (b == 0) {
                                tbodyTd[0] = $('<td></td>').text($(saleChecked[0][a]).next().text());
                                if (saleChecked[1].length > 1) {
                                    tbodyTd[0].attr("rowspan", "2");
                                }
                                length++;
                            }
                            tbodyTd[length] = $('<td></td>').text($(saleChecked[1][b]).next().text());
                            tbodyTd[length + 1] = $('<td><input type="text"/></td>');
                            tbodyTd[length + 2] = $('<td><input type="text"/></td>');
                            tbodyTd[length + 3] = $('<td>10</td>');
                            tbodyTd[length + 4] = $('<td class="code"><input type="text"/></td>');
                            tbodyTr[t] = $('<tr></tr>').append(tbodyTd);
                            t++;
                        }
                    }
                }

                //var tbodyTrCount = 5;
                //for (var i = 0; i < tbodyTrCount; i++) {
                //    for (var j = 0; j < saleChecked.length; j++) {
                //        tbodyTd[j] = $('<td>测试</td>');
                //    }
                //    tbodyTd[saleSpan.length + 1] = $('<td><input type="text"/></td>');
                //    tbodyTd[saleSpan.length + 2] = $('<td><input type="text"/></td>');
                //    tbodyTd[saleSpan.length + 3] = $('<td>10</td>');
                //    tbodyTd[saleSpan.length + 4] = $('<td class="code"><input type="text"/></td>');
                //    tbodyTr[i] = $('<tr></tr>').append(tbodyTd);
                //}
                tbody.append(tbodyTr);

                //sku加载
                skuBox.append(thead).append(tbody);
                $(".z-sku").remove();
                $(sale).append(skuBox);
            }
            var initImage = function () {
                var imageBox = $('<table class="z-sku-image"></table>');
                var thead = $('<thead></thead>');
                var theadTr = $('<tr></tr>');
                var theadTd = [];
                var tbody = $('<tbody></tbody>');
                var tbodyTr = [];

                //sku内容
                var saleSpan = $(".z-attr-sale li span");
                var saleChecked = [];

                //图片头部
                for (var i = 0; i < saleAttr.length; i++) {
                    if (saleAttr[i].hasImage == "1") {
                        theadTd[0] = $('<td></td>').text(saleAttr[i].name);
                        theadTd[1] = $('<td>组图</td>');
                        saleChecked = $(saleSpan[i]).find(":checked");
                        break;
                    }
                }
                thead.append(theadTr.append(theadTd));

                //图片内容
                for (var i = 0; i < saleChecked.length; i++) {
                    var tbodyTd = [];
                    tbodyTd[0] = $("<td></td>").text($(saleChecked[i]).next().text());
                    tbodyTd[1] = $("<td></td>").append(setImage());
                    tbodyTr[i] = $("<tr></tr>").append(tbodyTd);
                }
                tbody.append(tbodyTr);

                //图片附加到指定地方
                imageBox.append(thead).append(tbody);
                $(".z-sku-image").remove();
                $(sale).append(imageBox);

            }
            var setImage = function () {
                var ul = $("<ul></ul>");
                var li = [];
                var divImg = [];
                var divInput = [];
                var count = 5;

                for (var i = 0; i < count; i++) {
                    li[i] = $('<li></li');
                    divImg[i] = $('<div class="img"></div>');
                    divInput[i] = $('<div class="input"><input type="button" value="上传" /></div>');
                    li[i].append(divImg[i]).append(divInput[i]);
                }
                divImg[0].text("正面");
                divImg[1].text("背面");
                divImg[2].text("左侧");
                divImg[3].text("右侧");
                divImg[4].text("细节");
                return ul.append(li);
            }
            { init(); }
        }
    });
})(jQuery);

