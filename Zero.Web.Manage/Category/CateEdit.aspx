<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CateEdit.aspx.cs" Inherits="Zero.Web.Manage.Category.CateEdit" %>

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
					<td><a onclick="reload()">刷新</a> | <a href="adminIndex.aspx">返回</a></td>
				</tr>
			</table>
			<table class="z-tb-form">
				<tr>
					<th>所属分类：</th>
					<td><asp:Literal ID="cateList" runat="server"></asp:Literal></td>
				</tr>
				<tr>
					<th>分类名称：</th>
					<td><input type="text" id="cateName" class="z-text2" runat="server"/></td>
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
