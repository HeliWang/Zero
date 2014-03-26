<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Zero.Web.Manage.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="css/base.css"/>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <style type="text/css">
        .box{margin:20px auto;width:790px;}
        .box_1{}
        .tab_heads{position:relative;z-index: 10;}
        .tab_heads li{float:left;margin-right:5px;width:80px;height:30px;text-align:center;line-height:30px;border:1px solid #CCC;cursor: pointer;}
        .tab_heads .focus{border-bottom:none;height:31px;background-color:white;}
        .tab_bodys{border:1px solid #CCC;position:relative;top:-1px;padding:10px;}
        
        .select-list{padding-left:15px;}
        .select-list li{float:left;margin-top:10px;margin-right:10px;width:82px;height:77px;border: solid 1px white;}
        .select-list li a{display:table-cell;width:82px;height:77px;line-height:77px;overflow:hidden;border:1px solid #CCC;vertical-align: middle;text-align:center;}
        .select-list li a:hover {border:1px solid  #FF7300;}
        .select-list li img{max-width:80px;max-height:75px;}
        .select-list .selected{border:1px solid  #FF7300;}
             
        .upload_title{}
        .upload_info{margin:auto;width:300px;}
        .upload_info p{margin-top:10px;text-align:left;}
        .upload_tip{margin-top:10px;}

        .box_2{margin-top:5px;border:1px solid #CCC;}
        .insert-header{height:25px;border-bottom:1px solid #CCC;text-align:left;line-height:25px;padding-left:15px;}
        .insert-list{padding-left:25px;}
        .insert-list li{float:left;margin-top:10px;margin-right:10px;width:82px;height:75px;line-height:77px;border: dotted 1px #D9D9D9;background-color:#F7F7F7;font-size:18px;font-family:'Arial';font-style:italic;color: #E1E1E1;}
        .insert-list li a{display:table-cell;width:82px;height:75px;overflow:hidden;vertical-align: middle;text-align:center;}
        .insert-list li img{max-width:80px;max-height:75px;}
        .insert-botton{height:25px;padding-top:5px;}
    </style>
    <script type="text/javascript">
        //解决跨域问题，以后将此页面搬迁到调用此页面的项目中。
        //document.domain = "zero.com";
    </script>
</head>

<body>
    <div class="box">
        <!--box1{ -->
        <div class="box_1">
            <ul class="tab_heads clearfix">
                <li class="focus">在线图库</li>
                <li>本地上传</li>
                <li>网络图片</li>         
            </ul>
            <div class="tab_bodys">
                <div class="tab_panle">
                    <div>请选择图片插入</div>
                    <ul class="select-list clearfix">
                        <asp:Repeater ID="PhotoList" runat="server">
                            <ItemTemplate>
                                <li><a href="javascript:void(0)"><img src="<%#Zero.Core.Web.Images.GetPhotoUrl(Eval("Url").ToString(),150,150,0)%>"/></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="pager clearfix">
                       
                    </div>
                </div>
                <div class="tab_panle hidden">
                   <form id="Form1" name="form1" runat="server" method="post" enctype="multipart/form-data">
                   <div class="upload_title">如果您不希望上传的图片在相册中公开展示，建议将图片上传到不公开相册中</div>
                   <div class="upload_info">
                        <p>选择目录：<select name="cate"><option value="1">资讯频道</option><option value="2">品牌频道</option><option value="3">产品频道</option></select></p>
                        <p>选择图片：<input type="file" name="file"/></p>
                        <p>上传图片：<input type="submit" value=" 确认 "/></p>                        
                        <p>其他选项：
                            &nbsp;<input type="checkbox" id="has_compress" name="has_compress"/><label for="has_compress">是否需要压缩</label>
                            &nbsp;<input type="checkbox" id="has_watermark" name="has_watermark"/><label for="has_watermark">是否需要加盖水印</label>
                        </p>
                   </div>
                   <div class="upload_tip">提示：您可以上传 <span id="allowCount2">0</span> 张图片，选择的图片单张大小不超过5MB，支持jpg,jpeg,gif,bmp,png。</div>
                   </form>
                </div>
                <div class="tab_panle hidden">
                    
                </div>
            </div>
        </div>
        <!-- box1 } -->

        <!-- box2 { -->
        <div class="box_2">
            <input type="hidden" id="allowCount" value="1"/>
            <input type="hidden" id="photoUrl"/>
            <div class="insert-header">插入的图片</div>
            <div class="insert-content">
                <ul class="insert-list clearfix">
                    <li>1</li>
                    <li>2</li>
                    <li>3</li>
                </ul>
            </div>
            <div class="insert-botton"><input id="insertBotton" type="button" value=" 确认插入 "/></div>
        </div>
        <!-- box2 }-->
    </div>
    <script type="text/javascript">
        $(function () {
            var url = "http://img.zero.com/";

            $(".tab_heads li").click(function () {
                var index = $(this).index();
                $(this).addClass("focus").siblings().removeClass("focus");
                $(".tab_panle").eq(index).show().siblings().hide();
            })

            $(".select-list a").click(function () {
                var a = $(this);
                if (a.hasClass("selected")) {
                    removeImg(a.children().attr("src"));
                    a.removeClass("selected");
                }
                else {
                    if (addImg(a.children().attr("src"))) {
                        a.addClass("selected");
                    }
                }
            })

            $("#insertBotton").click(function () {
                var photoUrl = $("#photoUrl").val();
                var photoList = photoUrl.split(',');
                if (photoUrl == "insert-list") { alert("请至少选择一张图片插入"); return; }
                parent.document.getElementById("photoUrl").value = photoUrl;
                parent.document.getElementById("insert-img").src = url + photoUrl;
                parent.win.hide();

            });

            onLoad();
        });

        //初始化
        function onLoad() {
            var allowCount = $("#allowCount").val();
            var photoUrl = $("#photoUrl").val();
            var photoList = photoUrl.split(',');
            if (photoUrl == "") photoList.length = 0;
            //初始化待选的列表
            for (var i = 0; i < photoList.length; i++) {
                $(".select-list img[src='" + photoList[i] + "']").parent().addClass("selected");
            }
            //初始化插入的列表(优化下）
            var count = allowCount - photoList.length;
            var insertList = "";
            if (allowCount > 0 && count >= 0) {
                for (var i = 0; i < photoList.length; i++) {
                    insertList += "<li><a href=\"javascript:void(0)\" ><img onclick=\"removeSelectedImg(this)\" src=\"" + photoList[i] + "\"></a></li>";
                }
                for (i = photoList.length; i < allowCount; i++) {
                    insertList += "<li>" + (i + 1) + "</li>";
                }
                $(".insert-list").html(insertList);
            }
            else {
                for (var i = 0; i < allowCount; i++) {
                    insertList += "<li><a href=\"javascript:void(0)\" ><img onclick=\"removeSelectedImg(this)\" src=\"" + photoList[i] + "\"></a></li>";
                }
            }
            $(".insert-list").html(insertList);
            $("#allowCount2").html(allowCount);
        }

        //添加图片
        function addImg(src) {
            var allowCount = $("#allowCount").val();
            var photoUrl = $("#photoUrl").val();
            var currentCount = 0;
            if (photoUrl != "") currentCount = photoUrl.split(',').length;
            //判断是否超出规定的总数，如果超过，就不添加，也不该修改选择列表的样式。
            if (currentCount < parseInt(allowCount)) {
                var img = "<a href=\"javascript:void(0)\" ><img onclick=\"removeSelectedImg(this)\" src=\"" + src + "\"></a>";
                if (currentCount == 0) {
                    photoUrl = src;
                }
                else {
                    photoUrl += "," + src;
                }
                $(".insert-list").children().eq(currentCount).html(img).css({ border: "solid 1px #E6E5E3", background: "white" });
                $("#photoUrl").val(photoUrl);
                return true;
            }
            return false;
        }

        function removeSelectedImg(obj) {
            var src = obj.getAttribute("src");
            removeImg(src);
            $(".select-list img[src='" + src + "']").parent().removeClass("selected");
        }

        //移除图片
        function removeImg(src) {
            var allowCount = $("#allowCount").val();
            var photoList = $("#photoUrl").val().split(',');
            var newUrl = "";
            var exist = false;
            if (photoUrl == "") photoList.length = 0;
            //判断是插入列表是否存在此路径的图片，存在的话移除，并把后面的图片向前移动
            for (var i = 0; i < photoList.length; i++) {
                if (photoList[i] == src) {
                    exist = true;
                }
                else {
                    newUrl += photoList[i] + ",";
                }
                if (exist) {
                    if (i + 1 != photoList.length) {
                        var img = "<a href=\"javascript:void(0)\" ><img onclick=\"removeSelectedImg(this)\" src=\"" + photoList[i + 1] + "\"></a>";
                        $(".insert-list").children().eq(i).html(img);
                    }
                    else {
                        $(".insert-list").children().eq(i).html(i + 1).css({ border: "border: dotted 1px #D9D9D9;", background: "#F7F7F7" });
                    }
                }
            }
            if (exist) {
                $("#photoUrl").val(newUrl.substring(0, newUrl.length - 1));
            }
        }

	</script>
</body>
</html>
