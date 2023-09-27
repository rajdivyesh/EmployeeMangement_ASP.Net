<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebFormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            top: 0px;
            left: 3px;
            z-index: 1;
            width: 192px;
            height: 56px;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style2">
            <asp:Button ID="ButtonConnectDB" runat="server" CssClass="auto-style1" OnClick="Button1_Click" Text="Connect Database"/>
        </div>
    </form>
</body>
</html>
