<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="Zero.Web.Manage.Product.ProductEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="~/css/base.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/zero.js"></script>
    <script type="text/javascript">
        //选中的产品属性 
        //var productAttr = [{
        //    aid: '1',
        //    attr:'颜色',
        //    vid: '1',
        //    value:'白色'
        //}]

        

    </script>
    
    <style type="text/css">
        .z-attr-base{padding:10px 0; width:600px; border:1px solid #99bbe8;}
        .z-attr-base th{width:100px; height:30px; text-align:right; }
        .z-attr-base td{text-align:left; padding-left:10px;}

        .z-attr-sale{width:600px; border:1px solid #99bbe8;}
        .z-attr-sale div{margin-top:10px; padding-left:10px;}
        .z-attr-sale span{height:20px;line-height:20px;}
        .z-attr-sale li{float:left;margin-left:10px;}

        .z-sku{margin-top:10px; border-width:0px; border-collapse:collapse; border-left:1px solid #99bbe8;}
        .z-sku td{border:1px solid #99bbe8;height:22px; text-align:center; padding:5px 10px;}
        .z-sku input{height:20px;width:80px;}
        .z-sku .code input{width:160px;}

        .z-sku-image{margin-top:10px; border-width:0px; border-collapse:collapse; border-left:1px solid #99bbe8;}
        .z-sku-image td{border:1px solid #99bbe8;height:22px; text-align:center; padding:5px 10px;}
        .z-sku-image li{float:left;margin:5px;}
        .z-sku-image li  .img{ height:80px; width:80px; border:1px solid #99bbe8; }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div class="z-right">
		<div class="z-right-title"><asp:Literal ID="tab" runat="server"></asp:Literal></div>
		<div class="z-right-content">
			<table class="z-tb-header">
				<tr>
					<td><a onclick="reload()">刷新</a> | <a href="attrIndex.aspx">返回</a></td>
				</tr>
			</table>
            <script type="text/javascript" src="../js/attr.js"></script>
            <script type="text/javascript">
                $(function () {
                    $.zero.attr("#attrBase", "#attrSale");
                });
            </script>
			<table class="z-tb-form">
                <tr>
                    <th>产品分类：</th>
                    <td><select id="cateList" runat="server"></select></td>
                </tr>
                <tr>
					<th>产品属性：</th>
					<td>
                        <%--<table class="z-attr-base">
                            <tr>
                                <th>功能：</th>
                                <td>
                                    <select>
                                        <option>磨砂</option>
                                        <option>液化</option>
                                    </select>
                                </td>
                                <td>
                                    请输入功能名称
                                </td>
                            </tr>
                            <tr>
                                <th>风格：</th>
                                <td>
                                    <input type="checkbox" name="1-1" /><label for="1-1">韩流</label>
                                    <input type="checkbox" name="1-2" /><label for="1-2">中国风</label>
                                </td>
                                <td>
                                    请输入功能名称
                                </td>
                            </tr>
                            <tr>
                                <th>来源：</th>
                                <td>
                                    <input type="text" />
                                </td>
                                <td>
                                    请输入功能名称
                                </td>
                            </tr>
                        </table>--%>
                        <div id="attrBase"></div>
					</td>
				</tr>
                <tr>
					<th>产品名称：</th>
					<td><input type="text" id="productName"  class="z-text2" runat="server" /></td>
				</tr>
                <tr>
					<th>销售规格：</th>
					<td>
                        <div id="attrSale"></div>
                        <%--<div class="z-attr-sale">
                            <div>
                                <span>颜色</span>
                                <ul class="clearfix">
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">白色</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">黑色</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">红色</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">蓝色</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">全选</label></li>
                                </ul>
                            </div>
                            <div>
                                <span>尺码</span>
                                <ul class="clearfix">
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">35/L</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">36/XL</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">37/XXL</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">38/XXXL</label></li>
                                    <li><input type="checkbox" name="1-1" /><label for="1-1">全选</label></li>
                                </ul>
                            </div>
                        </div>--%>
                        <%--<table class="z-sku">
                            <thead>
                                <tr>
                                    <td>颜色</td>
                                    <td>尺码</td>
                                    <td>价格</td>
                                    <td>库存</td>
                                    <td>已售</td>
                                    <td>条形码</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td rowspan="2">白色</td>
                                    <td>32</td>
                                    <td><input type="text" value="$10" /></td>
                                    <td><input type="text" value="30" /></td>
                                    <td>10</td>
                                    <td class="code"><input type="text" value="2013202115" /></td>
                                </tr>
                                <tr>
                                    <td>33</td>
                                    <td><input type="text" value="$10" /></td>
                                    <td><input type="text" value="30" /></td>
                                    <td>10</td>
                                    <td class="code"><input type="text" value="2013202115" /></td>
                                </tr>
                                <tr>
                                    <td rowspan="2">黑色</td>
                                    <td>32</td>
                                    <td><input type="text" value="$10" /></td>
                                    <td><input type="text" value="30" /></td>
                                    <td>10</td>
                                    <td class="code"><input type="text" value="2013202115" /></td>
                                </tr>
                                <tr>
                                    <td>33</td>
                                    <td><input type="text" value="$10" /></td>
                                    <td><input type="text" value="30" /></td>
                                    <td>10</td>
                                    <td class="code"><input type="text" value="2013202115" /></td>
                                </tr>
                            </tbody>
                        </table>--%>
                        <%--<table class="z-sku-image">
                            <thead>
                                <tr>
                                    <td>颜色</td>
                                    <td>组图（200px*300px）</td>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>白色<br />默认</td>
                                    <td>
                                        <ul class="clearfix">
                                            <li>
                                                <div class="img">正面</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                            <li>
                                                <div class="img">背面</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                            <li>
                                                <div class="img">左侧面</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                            <li>
                                                <div class="img">右侧面</div>
                                                <div><input type="button" value="上传" /></div>
                                                
                                            </li>
                                            <li>
                                                <div class="img">细节</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <td>黑色</td>
                                    <td>
                                        <ul class="clearfix">
                                            <li>
                                                <div class="img">正面</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                            <li>
                                                <div class="img">背面</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                            <li>
                                                <div class="img">左侧面</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                            <li>
                                                <div class="img">右侧面</div>
                                                <div><input type="button" value="上传" /></div>
                                                
                                            </li>
                                            <li>
                                                <div class="img">细节</div>
                                                <div><input type="button" value="上传" /></div>
                                            </li>
                                        </ul>
                                    </td>
                                </tr>
                            </tbody>
                        </table>--%>
					</td>
				</tr>
				<tr>
					<td class="bt" colspan="2"><input type="submit" value="保存" /> <input type="button" value="重置" /></td>
				</tr>
			</table>
		</div>
	</div>
    </form>
</body>
</html>
