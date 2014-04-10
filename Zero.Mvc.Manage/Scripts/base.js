function openParentTab(plugin, url) {
    window.parent.openTab(plugin,url);
}

function openParentTabLinkButton(plugin, url, id) {
    return "<a href=\"javascript:void(0)\" onclick=\"openParentTab('" + plugin + "-" + id + "', '" + url + "')\">" + plugin + "</a>";
}


//1.3.5�汾������޷���ȡ����
function submitForm1() {
    //$.messager.progress();
    $('#Form').form('submit', {
        url: '/Cate/CateAddPost',
        onSubmit: function () {
            var isValid = $(this).form('validate');
            if (!isValid) {
                $.messager.progress('close');	// hide progress bar while the form is invalid
            }
            return isValid;	// return false will stop the form submission
        },
        success: function (data) {
            $.messager.progress('close');
            if (data.indexOf('Status') > 0) {
                var data = eval('(' + data + ')');  // change the JSON string to javascript object
                $.messager.alert('����', data.Message);
            }
            else {
                alert(data);
            }
        }
    });
}

//juqery.ajax
function ajaxSubmitForm3(form, url) {
    $.ajax({
        url: url,
        type: "Post",
        data: $(form).serialize(),
        dataType: "json",
        beforeSend: function () {
            if (!$(form).form('validate')) return false;
            return true;
        },
        success: function (data) {

            alert(data.Message);
        },
        error: function () {
            //$.messager.alert('����', 'ϵͳ�쳣�������Ի���ϵ����');
            alert('ϵͳ�쳣�������Ի���ϵ����');
        }
    });
}

//jquery.form�ύ��ʽ
function ajaxSubmitForm2(form) {
    //if (!$.validatebox.valid()) return;

    var options = {
        //target: '#output2',   // target element(s) to be updated with server response 
        //beforeSubmit: showRequest,  // pre-submit callback 
        //success: showResponse  // post-submit callback 

        // other available options: 
        //url:       url         // override for form's 'action' attribute 
        //type:      type        // 'get' or 'post', override for form's 'method' attribute 
        //dataType:  null        // 'xml', 'script', or 'json' (expected server response type) 
        //clearForm: true        // clear all form fields after successful submit 
        //resetForm: true        // reset the form after successful submit 

        // $.ajax options can be used here too, for example: 
        //timeout:   3000 
    };

    $(form).ajaxSubmit({
        beforeSubmit: function (formData, jqForm, options) {
            if (!$(form).form('validate')) return false;
            return true;
        },
        success: function (responseText, statusText, xhr, $form) {
            $.messager.alert('����', responseText.Message);
        },
        error: function () {
            $.messager.alert('����', 'ϵͳ�쳣�������Ի���ϵ����');
        }
    });
}

//��ȡ����
function getQuery(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function clearForm(form) {
    $(form).form('clear');
}

function timeFormat(value, row, index) {
    if (value == null) return "";
    var dateTime = eval("new " + value.replace("/", "").replace("/", ""));
    return dateTime.format("yyyy-MM-dd hh:mm:ss");
}

// ��Date����չ���� Date ת��Ϊָ����ʽ��String 
// ��(M)����(d)��Сʱ(h)����(m)����(s)������(q) ������ 1-2 ��ռλ���� 
// ��(y)������ 1-4 ��ռλ��������(S)ֻ���� 1 ��ռλ��(�� 1-3 λ������) 
// ���ӣ� 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18
Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month 
        "d+": this.getDate(),    //day 
        "h+": this.getHours(),   //hour 
        "m+": this.getMinutes(), //minute 
        "s+": this.getSeconds(), //second 
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter 
        "S": this.getMilliseconds() //millisecond 
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
      RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}