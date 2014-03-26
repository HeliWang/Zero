<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CateAttrEdit.aspx.cs" Inherits="Zero.Web.Manage.Category.CateAttrEdit" %>

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
					<th>所属类别：</th>
					<td>
                        <select id="cateList" runat="server"></select>
					</td>
				</tr>
				<tr>
					<th>所属属性：</th>
					<td>
                        <input type="hidden" id="attrId"  runat="server"/>
                        <input type="text" id="attr"  class="z-text2" runat="server" />
					</td>
				</tr>
				<tr>
					<th>属性类型：</th>
					<td>
                        <select id="type" runat="server">
                            <option value="0">枚举单选</option>
                            <option value="1">枚举多选</option>
                            <option value="2">枚举可输入单选</option>
                            <option value="3">枚举可输入多选</option>
                            <option value="4">非枚举可输入</option>
                        </select>
					</td>
				</tr>
                <tr>
					<th>是否必填：</th>
					<td>
                        <select id="isMust" runat="server">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
					</td>
				</tr>
                <tr>
					<th>是否销售属性：</th>
					<td>
                        <select id="isSale" runat="server">   
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
					</td>
				</tr>
                <tr>
					<th>是否关键属性：</th>
					<td>
                        <select id="isKey" runat="server">   
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
					</td>
				</tr>
<%--                <tr>
					<th>当前状态：</th>
					<td>
                        <select id="status" runat="server"></select>
					</td>
				</tr>--%>
				<tr>
					<td class="bt" colspan="2"><input type="submit" value="保存" /> <input type="button" value="重置" /></td>
				</tr>
			</table>
		</div>
	</div>
    </form>
</body>
</html>