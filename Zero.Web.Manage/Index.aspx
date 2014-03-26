<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Zero.Web.Manage.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>index</title>
    <link rel="stylesheet" href="~/css/base.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/zero.js"></script>
</head>


<body>
    <div class="z-page">

        <div class="z-page-top">
            <div class="z-top">
			    <div class="z-top-logo">Logo</div>
			    <div class="z-top-menu">
				    <a>本地官网</a>
				    <a>对接平台</a>
				    <a>仓储管理</a>
			    </div>	
		    </div>
        </div>
        
        <div class="z-page-content">  
            <div class="z-page-left"> 
                <div class="z-left">
				    <div class="z-left-title">对接平台</div>
				    <dl class="z-left-menu">
					    <dt>后台管理</dt>
					    <dd>
						    <ul>
							    <li><a href="/admin/adminEdit.aspx" target="z-right">账户添加</a></li>
							    <li><a href="/admin/adminIndex.aspx" target="z-right">账户管理</a></li>
						    </ul>
					    </dd>
					    <dt>类目管理</dt>
					    <dd>
						    <ul>
							    <li><a href="/category/cateEdit.aspx" target="z-right">类目添加</a></li>
							    <li><a href="/category/cateIndex.aspx" target="z-right">类目管理</a></li>
                                <li><a href="/category/attrEdit.aspx" target="z-right">属性添加</a></li>
                                <li><a href="/category/attrIndex.aspx" target="z-right">属性管理</a></li>
                                <li><a href="/category/attrValueEdit.aspx" target="z-right">属性值添加</a></li>
                                <li><a href="/category/attrValueIndex.aspx" target="z-right">属性值管理</a></li>
                                <li><a href="/category/cateAttrEdit.aspx" target="z-right">类目属性添加</a></li>
							    <li><a href="/category/cateAttrIndex.aspx" target="z-right">类目属性管理</a></li>
                                <li><a href="/category/cateAttrValueIndex.aspx" target="z-right">类目属性值管理</a></li>
						    </ul>
					    </dd>
					    <dt>财务管理</dt>
					    <dd>
						    <ul>
							    <li><a>修改密码</a></li>
							    <li><a>账户管理</a></li>
						    </ul>
					    </dd>
				    </dl>
				    <script type="text/javascript">
					    $(document).ready(function () {
					        $(".z-left-menu dt").click(function () {
					            $(this).next().toggleClass("hidden");
					        });

					        var a = $(".z-left-menu li a");

					        a.mouseenter(function () {
					            $(this).addClass("over");
					        });

					        a.mouseleave(function () {
					            $(this).removeClass("over");
					        });

					        a.click(function () {
					            $(".z-left-menu li .selected").removeClass("selected");
					            $(this).addClass("selected");
					        });
					    });
				    </script>
			    </div>
            </div>
            <div class="z-page-right">
                <iframe id="z-right" name="z-right" src="/admin/adminIndex.aspx"  style="width:100%;height:100%; border:0;"></iframe>
            </div>
            </div>
    </div>
</body>
</html>
