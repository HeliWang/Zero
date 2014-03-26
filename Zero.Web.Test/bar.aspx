<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bar.aspx.cs" Inherits="Zero.Web.Test.bar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <style type="text/css">
            .defaultbar {
                margin-top: 10px;
                height: 5px;
                background-color: #FFFFE0;
                border: 1px solid #A9C9E2;
                position: relative;
            }
            .defaultbar .jquery-completed {
                height: 3px;
                background-color: #7d9edb;
                top: 1px;
                left: 1px;
                position: absolute;
            }
            .defaultbar .jquery-jslider {
                height: 15px;
                background-color: #E6E6FA;
                border: 1px solid #A5B6C8;
                top: -6px;
                left:50px;
                display: block;
                cursor: pointer;
                position: absolute;
            }
        </style>
        <div class="defaultbar">
          <div class="jquery-completed"> </div>
          <div class="jquery-jslider"> </div>
        </div>
    </div>
    </form>
</body>
</html>
