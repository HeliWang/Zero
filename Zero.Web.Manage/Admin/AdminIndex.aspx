<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="Zero.Web.Manage.Admin.AdminIndex" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="~/css/base.css" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/zero.js"></script>
    <script type="text/javascript">
        $(function () {
            $.zero.grid();

            //$.zero.paging({
            //    renderTo: "#paging",
            //    name: "test",
            //    recordCount: 200,
            //    showPageCount: 7,
            //    urlMode: "adminIndex.aspx?page={page}",
            //    botton: { visible: [false/*第一页和最末页*/, true/*上一页和下一页*/] }
            //});  

            //$(function () {
            //    $.zero.popUpBox({
            //        title: "这是弹出框的标题",
            //        context: "这里是内容",
            //        width: 500,
            //        height: 250,
            //        ok: { name: "确定", enable: false, click: function () { alert("ok"); } },
            //        cancel: { name: "取消", enable: true, click: function () { alert("cancel"); } }
            //    });
            //});
        })
    </script>
    
</head>
<body>
    <div class="z-right">
	    <div class="z-right-title">用户管理</div>
	    <div class="z-right-content">
		    <table class="z-tb-header">
		    <tr>
			    <td width="300"><asp:Literal ID="searchStatus" runat="server"></asp:Literal></td>
			    <td><a href="adminEdit.aspx">新增</a> | <a onclick="reload()">刷新</a></td>
                <td>
                    <form id="searchform" name="searchform" method="get">
                        状态：<asp:Literal ID="selectStatus" runat="server"></asp:Literal>
                        关键字：
                        <select id="keytype" runat="server">
                            <option value="">请选择</option>
                            <option value="adminId">用户编号</option>
                            <option value="adminName">用户名称</option>
                        </select> 
                        <input id="keyword"  class="z-text1" runat="server" />
                        <input type="submit" class="z-button1" value="查看"/>
                    </form>
                </td>
		    </tr>
		    </table>
            <form id="deleteForm" name="deleteForm" method="post">
                <input id="ids" type="hidden" runat="server" />
                <input id="action" type="hidden" runat="server" value="delete" />
             </form>
            <form id="operateForm" name="operateForm" method="post">
		    <table class="z-tb-grid">
			    <thead>
				    <tr>
					    <td width="50">ID</td>
					    <td width="30"><input type="checkbox" class="checkAll" /></td>
					    <td class="tleft">用户名称</td>
                        <td width="50">状态</td>
                        <td width="130">创建时间</td>
                        <td width="130">更新时间</td>
					    <td width="80">操作</td>
				    </tr>
			    </thead>
			    <tbody>  
				<asp:Repeater ID="DateList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("AdminId")%></td>
					        <td><input name="ids" type="checkbox" value="<%#Eval("AdminId")%>" /></td>
					        <td class="tleft"><%#Eval("AdminName")%></td>
                            <td><%#Zero.Core.Web.BaseStatusCtrl.GetStatus((int)Eval("Status"))%></td>
                            <td><%#Convert.ToDateTime(Eval("CreateTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
                            <td><%#Convert.ToDateTime(Eval("UpdateTime")).ToString("yyyy-MM-dd HH:mm:ss")%></td>
					        <td>
                                <a href="adminEdit.aspx?adminId=<%#Eval("AdminId")%>" class="z-edit"></a>
                                <a onclick="deleteItem(<%#Eval("AdminId")%>)" class="z-delete"></a>
					        </td>
                        </tr>
                    </ItemTemplate>
				</asp:Repeater>
			    </tbody>
			    <tfoot>
				    <tr>
					    <td colspan="7">  
                            <asp:Literal ID="paging" runat="server"></asp:Literal>
					    </td>
				    </tr>
			    </tfoot>
		    </table>
		    <table class="z-tb-footer">
			    <tr id="audit" class="hidden">
				    <th>审批信息：</th>
				    <td>
					    <asp:Literal ID="targetStatus" runat="server"></asp:Literal>
				    </td>
			    </tr>
                <tr id="selectCategory" class="hidden">
				    <th>审批信息：</th>
				    <td>
					    <select>
                            <option>鞋子</option>
                            <option>鞋子</option>
					    </select>
				    </td>
			    </tr>
			    <tr>
				    <th>批量操作：</th>
				    <td>
				    <input type="checkbox" id="checkAll" class="checkAll" /><label for="checkAll">全选</label>	
				    <input type="radio" id="action_0"  name="action" value="audit" onclick="checkAction('#audit')" /><label for="action_0">审核</label>	
				    <input type="radio" id="action_1" name="action" value="selectCategory" onclick="checkAction('#selectCategory')" /><label for="action_1">分类</label>
                    <input type="radio" id="action_2" name="action" value="delete" onclick="checkAction('#delete')" /><label for="action_2">删除</label>
				    <input type="submit" class="z-button3" value="执行操作" />
				    </td>
			    </tr>
		    </table>
            <asp:Literal ID="sysMessage" runat="server"></asp:Literal>
            </form>
	    </div>	
    </div>
</body>
</html>
