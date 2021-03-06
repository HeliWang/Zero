﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttrValueEdit.aspx.cs" Inherits="Zero.Web.Manage.Category.AttrValueEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="~/css/base.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/zero.js"></script>
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
			<table class="z-tb-form">
				<tr>
					<th>属性值：</th>
					<td><input type="text" id="value"  class="z-text2" runat="server" /></td>
				</tr>
                <tr>
					<th>所属属性：</th>
					<td>
                        <input type="hidden" id="attrId"  runat="server"/>
                        <input type="text" id="attr"  class="z-text2" runat="server" />
					</td>
				</tr>
                <tr>
					<th>排序编号：</th>
					<td><input type="text" id="oid" class="z-text2" runat="server" value="0" /></td>
				</tr>
                <tr>
					<th>当前状态：</th>
					<td>
                        <select id="status" runat="server"></select>
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
