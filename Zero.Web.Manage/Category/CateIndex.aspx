<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CateIndex.aspx.cs" Inherits="Zero.Web.Manage.Category.CateIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="~/css/base.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/zero.js"></script>
</head>
<body>
    <div class="z-right">
		<div class="z-right-title">用户管理</div>
		<div class="z-right-content">
			<table class="z-tb-header">
				<tr>
					<td><a onclick="reload()">刷新</a></td>
				</tr>
			</table>
            <form id="deleteForm" name="deleteForm" method="post">
                <input id="ids" type="hidden" runat="server" />
                <input id="action" type="hidden" runat="server" value="delete" />
            </form>
			<table class="z-tb-category">
				<thead>
					<tr>
						<td width="60">ID</td>
						<td class="tleft">类别</td>
						<td width="100">操作</td>
					</tr>
				</thead>
				<tbody>
					<%--<tr lid="1" rid="16" depth="1" child="2">
						<td>2006665</td>
						<td class="tleft"><div class="node">鞋子</div></td>
						<td>+ * -</td>
					</tr>
								
					<tr lid="4" rid="9" depth="2" child="2">
						<td>2006665</td>
						<td class="tleft"><div class="node">女鞋</div></td>
						<td>+ * -</td>
					</tr>
                    <tr lid="5" rid="6" depth="3" child="0">
						<td>2006665</td>
						<td class="tleft"><div class="node">女鞋</div></td>
						<td>+ * -</td>
					</tr>
                    <tr lid="7" rid="8" depth="3" child="0">
						<td>2006665</td>
						<td class="tleft"><div class="node">女鞋</div></td>
						<td>+ * -</td>
					</tr>
                    <tr lid="10" rid="15" depth="2" child="1" >
						<td>2006665</td>
						<td class="tleft"><div class="node">男鞋</div></td>
						<td>+ * -</td>
					</tr>
                    <tr lid="11" rid="14" depth="3" child="1" >
						<td>2006665</td>
						<td class="tleft"><div class="node">男鞋</div></td>
						<td>+ * -</td>
					</tr>
                    <tr lid="12" rid="13" depth="3" child="0" >
						<td>2006665</td>
						<td class="tleft"><div class="node">男鞋</div></td>
						<td>+ * -</td>
					</tr>--%>
                    <asp:Repeater ID="DataList" runat="server">
                        <ItemTemplate>
                            <tr lid="<%#Eval("Lid")%>" rid="<%#Eval("Rid")%>" depth="<%#Eval("Depth")%>" child="<%#Eval("ChildCount")%>">
						        <td><%#Eval("CateId")%></td>
						        <td class="tleft"><div class="node"><%#Eval("CateName")%></div></td>
						        <td>
                                    <a href="categoryEdit.aspx?pid=<%#Eval("CateId")%>" class="z-add"></a>
                                    <a href="categoryEdit.aspx?cateId=<%#Eval("CateId")%>" class="z-edit"></a>
                                    <a onclick="deleteItem(<%#Eval("CateId")%>)" class="z-delete"></a>
						        </td>
					        </tr>
                        </ItemTemplate>
                    </asp:Repeater>
				</tbody>
			</table>
            <asp:Literal ID="sysMessage" runat="server"></asp:Literal>           
            <script type="text/javascript">
                $(document).ready(function () {
                    $.zero.category();
                });
            </script>	
		</div>	
	</div>
</body>
</html>
