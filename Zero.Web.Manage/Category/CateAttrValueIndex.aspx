<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CateAttrValueIndex.aspx.cs" Inherits="Zero.Web.Manage.Category.CateAttrValueIndex" %>

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
                    <th>分类：</th>
                    <td>
                        <select id="cateList" runat="server"></select>&nbsp;&nbsp;
                        <input type="submit" value="查看" class="z-button2" />
                    </td>
                </tr>
                <asp:Repeater ID="attrList" runat="server">
                    <ItemTemplate>
                       <tr>
					        <th><%#Eval("Attr")%>：</th>
					        <td>
                                <asp:Repeater ID="valueList" runat="server">
                                    <ItemTemplate>
                                        <input type="checkbox" id="<%#Eval("AttrId")%>_<%#Eval("ValueId")%>"  name="action" value="<%#Eval("ValueId")%>" />
                                        <label for="<%#Eval("AttrId")%>_<%#Eval("ValueId")%>"><%#Eval("Value")%></label>&nbsp;
                                    </ItemTemplate>
                                </asp:Repeater>
					        </td>
				        </tr> 
                    </ItemTemplate>
                </asp:Repeater>
                <%--<tr>
					<th>颜色：</th>
					<td>
                        <input type="checkbox" id="action_0"  name="action" value="12" /><label for="action_0">白色</label>	
                        <input type="checkbox" id="Radio1"  name="action" value="12" /><label for="action_0">蓝色</label>
					</td>
				</tr>
                <tr>
					<th>尺码：</th>
					<td>
                        <input type="checkbox" id="Checkbox1"  name="action" value="12" /><label for="action_0">32</label>	
                        <input type="checkbox" id="Checkbox2"  name="action" value="12" /><label for="action_0">33</label>
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
