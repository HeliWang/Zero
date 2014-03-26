<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderExcel.aspx.cs" Inherits="Zero.Web.Test.OrderExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:TextBox ID="OrderIDs" runat="server"></asp:TextBox>
        <asp:Button id="sub" runat="server" OnClick="sub_Click" Text="交行"/>
        <asp:Button id="sub2" runat="server" OnClick="sub2_Click" Text="招商"/>
    </div>
    </form>
</body>
</html>
