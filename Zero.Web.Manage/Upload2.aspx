<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload2.aspx.cs" Inherits="Zero.Web.Manage.Upload2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>图片上传</title>
    <link type="text/css" rel="stylesheet" href="css/base.css"/>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.form.js"></script>
    <script type="text/javascript" src="js/zero.js"></script>
    <style type="text/css">
        .z-img{margin:20px auto;width:790px;}
        .z-img-select .tab-heads{position:relative;z-index: 10;}
        .z-img-select .tab-heads li{float:left;margin-right:5px;width:80px;height:30px;text-align:center;line-height:30px;border:1px solid #CCC;cursor: pointer;}
        .z-img-select .tab-heads .focus{border-bottom:none;height:31px;background-color:white;}
        .z-img-select .tab-bodys{border:1px solid #CCC;position:relative;top:-1px;padding:10px;}
        .z-img-select .loading{position:absolute;top:60px;left:50%;}
        .z-img-select .select-list{margin-bottom:10px;padding-left:15px;}
        .z-img-select .select-list li{float:left;margin-top:10px;margin-right:10px;width:82px;height:77px;line-height:75px;display:table-cell;overflow:hidden;border:1px solid #CCC;vertical-align: middle;text-align:center;}
        .z-img-select .select-list li:hover {border:1px solid  #FF7300;}
        .z-img-select .select-list li img{vertical-align:middle;max-width:80px;max-height:75px;}
        .z-img-select .select-list .selected{border:1px solid  #FF7300;}
        .z-img-select .upload-title{text-align:center;}
        .z-img-select .upload-info{margin:auto;width:300px;}
        .z-img-select .upload-info p{margin-top:10px;text-align:left;}
        .z-img-select .upload-tip{margin-top:10px;text-align:center;}

        .z-img-insert{margin-top:5px;border:1px solid #CCC;}
        .z-img-insert .insert-header{height:25px;border-bottom:1px solid #CCC;text-align:left;line-height:25px;padding-left:15px;}
        .z-img-insert .insert-list{padding-left:25px;}
        .z-img-insert .insert-list li{float:left;margin-top:10px;margin-right:10px;width:82px;height:75px;line-height:77px;border: dotted 1px #D9D9D9;background-color:#F7F7F7;font-size:18px;font-family:'Arial';font-style:italic;color: #E1E1E1;vertical-align: middle;text-align:center;}
        .z-img-insert .insert-list li a{display:table-cell;width:82px;height:75px;overflow:hidden;vertical-align: middle;text-align:center;}
        .z-img-insert .insert-list li img{max-width:80px;max-height:75px;}
        .z-img-insert .insert-botton{height:25px;padding-top:5px;vertical-align: middle;text-align:center;}
    </style>
</head>
<body>
    <div class="z-img">
        <div class="z-img-select">
            <ul class="tab-heads clearfix">
                <li class="focus">在线图库</li>
                <li>本地上传</li>
                <li>网络图片</li>         
            </ul>
            <div class="tab-bodys">
                <div class="tab-panle">
                    <div>请选择图片插入</div>
                    <img id="listLoading" class="loading hidden" src="images/loading.gif"/>
                    <ul class="select-list clearfix">
                        <%--<li><a href="javascript:void(0)"><img src="<%#Zero.Core.Web.ImageHelper.GetPhotoUrl(Eval("Url").ToString(),150,150,0)%>"/></a></li>--%>
                    </ul>
                    <div id="paging" class="z-paging clearfix"></div>
                </div>
                <div class="tab-panle hidden">
                   <form id="uploadForm" name="uploadForm" action="ImageList.aspx" method="post" enctype="multipart/form-data">
                   <div class="upload-title">如果您不希望上传的图片在相册中公开展示，建议将图片上传到不公开相册中</div>
                   <div class="upload-info">
                        <p>选择目录：
                            <select name="cate">
                                <option value="1">资讯频道</option>
                                <option value="2">品牌频道</option>
                                <option value="3">产品频道</option>
                            </select>
                        </p>
                        <p>选择图片：<input type="file" name="file"/></p>
                        <p>上传图片：<input type="submit" id="uploadButton" value=" 确认 "/><img id="uploadLoading" class="hidden" width="18" height="18" src="images/loading.gif"/></p>                    
                        <p>其他选项：
                            &nbsp;<input type="checkbox" id="hasCompress" name="has_compress"/><label for="hasCompress">是否需要压缩</label>
                            &nbsp;<input type="checkbox" id="hasWatermark" name="has_watermark"/><label for="hasWatermark">是否需要加盖水印</label>
                        </p>
                   </div>
                   <div class="upload-tip">提示：您可以上传 <span id="allowCount2">0</span> 张图片，选择的图片单张大小不超过5MB，支持jpg,jpeg,gif,bmp,png。</div>
                   </form>
                </div>
            </div>
        </div>
        <div class="z-img-insert">
            <input type="hidden" id="allowCount" value="3"/>
            <input type="hidden" id="photoUrl"  value=""/>
            <div class="insert-header">插入的图片</div>
            <div class="insert-content">
                <ul class="insert-list clearfix">
                </ul>
            </div>
            <div class="insert-botton"><input id="insertBotton" type="button" value=" 确认插入 "/></div>
        </div>
    </div>

    <script type="text/javascript">
        (function ($) {   
            var img = function () {
                var size = 8;
                var count = 0;
                var init = function () {
                    initTab();
                    initPaging();
                    initInsertList();
                    initUpload();
                }
                var initTab = function () {
                    //初始化tab
                    $(".tab-heads li").click(function () {
                        var index = $(this).index();
                        $(this).addClass("focus").siblings().removeClass("focus");
                        $(".tab-panle").eq(index).show().siblings().hide();
                    })
                }
                var initPaging = function () {
                    $("#paging div").remove();
                    //加载分页控件的时候，并异步调用图片列表
                    $.zero.paging({
                        renderTo: "#paging"
                        , pageSize: size
                        , button: { visible: [false, true] }
                        , switchPage: getSelectList
                    });
                }
                var getSelectList = function (index) {
                    //异步调用图片列表 
                    $.ajax({
                        type: "get"
                        , cache: false
                        , async: false
                        , data: { pageSize: size, page: index } //与获取数据保持一致
                        , url: "ImageList.aspx"
                        , success: initSelectList
                        , beforeSend: function () {
                            $("#listLoading").removeClass("hidden");
                        }
                    });
                    return count;
                }
                var initSelectList = function (data) {
                    var dataObj = eval("(" + data + ")");//异步返回的图片数据
                    count = dataObj.count;
                    var photoUrl = $("#photoUrl").val();//图片列表(1.jpg|2.jpg)

                    //加载图片列表
                    var li = [];
                    var img = [];
                    $.each(dataObj.list, function (i, item) {
                        li[i] = $("<li></li>");
                        img[i] = $("<img/>").attr("src", item.src);
                        li[i].append(img[i]);
                        li[i].click(function () {
                            //初始化插入图片列表
                            var li = $(this);
                            if (li.hasClass("selected")) {
                                removeInsertPhoto(item.src);
                                li.removeClass("selected");
                                initInsertList();//重新加载
                            }
                            else {
                                if (addInsertPhoto(item.src)) {
                                    li.addClass("selected");
                                    initInsertList();//重新加载
                                }
                            }
                        });
                        if (photoUrl.indexOf(item.src) > -1) {
                            li[i].addClass("selected");
                        }
                    });

                    $(".select-list li").remove();
                    $(".select-list").append(li);
                    $("#listLoading").addClass("hidden");
                }
                var removeInsertPhoto = function (url) {
                    var photoList = [];
                    var photoUrl = $("#photoUrl").val();//图片列表(1.jpg|2.jpg)
                    var allowCount = $("#allowCount").val();//允许选择的图片总数

                    //indexOf返回-1，就是未找到
                    if (photoUrl.indexOf("|" + url) > -1) {
                        photoUrl = photoUrl.replace("|" + url, "");
                    }
                    else if (photoUrl.indexOf(url + "|") > -1) {
                        photoUrl = photoUrl.replace(url + "|", "");
                    }
                    else if (photoUrl.indexOf(url) > -1) {
                        photoUrl = photoUrl.replace(url, "");
                    }
                    
                    $("#photoUrl").val(photoUrl);
                }
                var addInsertPhoto = function (url) {
                    var photoList = [];
                    var photoUrl = $("#photoUrl").val();//图片列表(1.jpg|2.jpg)
                    var allowCount = $("#allowCount").val();//允许选择的图片总数

                    if (photoUrl.length > 0) {
                        photoList = photoUrl.split("|");
                    }
                    if (photoUrl.indexOf(url) > 0) {
                        alert("已存在该图片");
                        return false;//已包含该图片
                    }
                    photoList[photoList.length] = url;

                    if (photoList.length > allowCount) {
                        alert("最多能插入" + allowCount + "张图片，请先删除。");
                        return false;
                    }
                    $("#photoUrl").val(photoList.join("|"));
                    return true;
                }
                var initInsertList = function () {
                    var li = [];
                    var img = [];
                    var photoList = "";
                    var photoUrl = $("#photoUrl").val();//图片列表(1.jpg|2.jpg)
                    var allowCount = $("#allowCount").val();//允许选择的图片总数
                    if (photoUrl.length > 0) {
                        photoList = photoUrl.split("|");
                    }
                    //初始化，取默认数值列表
                    for (var i = 0; i < allowCount; i++) {
                        li[i] = $("<li></li>").text(i + 1);
                    }
                    //初始化，取已选中的插入图片列表
                    for (var i = 0; i < photoList.length; i++) {
                        img[i] = $("<img/>").attr("src", photoList[i]);
                        li[i].text("").append(img[i]);
                        li[i].click(function () {
                            //插入列表删除图片，再初始化插入列表
                            var url = $(this).find("img").attr("src");
                            removeInsertPhoto(url);
                            initInsertList();
                            $(".select-list img[src='" + url + "']").parent().removeClass("selected");
                        });
                    }
                    $(".insert-list li").remove();
                    $(".insert-list").append(li);
                }
                var initUpload = function () {
                    $("#uploadForm").submit(function () {
                        $(this).ajaxSubmit({
                            beforeSubmit: showRequest
                            , success: showResponse
                        });
                        return false;
                    });

                    function showRequest(formData, jqForm, options) {
                        var cate = $("input[name=cate]").fieldValue()[0];
                        $("#uploadButton").addClass("hidden");
                        $("#uploadLoading").removeClass("hidden");
                        return true;
                    }

                    function showResponse(responseText, statusText, xhr, $form) {
                        $("#uploadButton").removeClass("hidden");
                        $("#uploadLoading").addClass("hidden");

                        if (responseText.length > 0) {
                            if (responseText.indexOf("div") > 0) {
                                alert("网络异常，请联系技术员");
                            }
                            else {
                                var obj = eval("(" + responseText + ")");
                                if (obj.error.length > 0) {
                                    alert(obj.error);
                                }
                                else {
                                    alert("上传成功");
                                    addInsertPhoto(obj.item);
                                    initPaging();//初始化分页
                                    alert(obj.item);
                                }
                            }
                            //$("#btnSubmit").removeAttr("disabled");
                        }
                        else {
                            alert("无返回信息！");
                        }
                    }
                }

                { init() };
            }

            img();
        })(jQuery);
    </script>
</body>
</html>
