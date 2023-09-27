<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebFormEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99%;
            height: 353px;
        }
        .auto-style8 {
            width: 183px;
        }
        .auto-style9 {
            height: 26px;
            width: 183px;
        }
        .auto-style10 {
            width: 122px;
        }
        .auto-style11 {
            height: 26px;
            width: 122px;
        }
        .auto-style12 {
            font-size: x-large;
            color: #FF3300;
        }
        .auto-style13 {
            height: 792px;
        }
        .auto-style14 {
            margin-left: 0px;
        }
        .auto-style15 {
            margin-right: 0px;
        }
        .auto-style16 {
            width: 184px;
            margin-left: 80px;
        }
        .auto-style17 {
            width: 122px;
            height: 50px;
        }
        .auto-style18 {
            width: 183px;
            height: 50px;
        }
        .auto-style19 {
            width: 184px;
        }
        .auto-style20 {
            width: 184px;
            height: 50px;
        }
        .auto-style21 {
            height: 26px;
            width: 184px;
        }
    </style>
</head>
<body style="width: 952px; height: 360px">
    <form id="form1" runat="server" class="auto-style13" style="position: relative">
    <table class="auto-style1">
            <tr>&nbsp</tr>
        <tr>
            <td aria-multiline="True" class="auto-style12" colspan="2">
                <strong>Employee Mantenance</strong></td>
            <td class="auto-style19">
                &nbsp;</td>
        </tr>
        <tr>
            <td aria-multiline="True" class="auto-style17">
                <asp:Label ID="Label1" runat="server" Text="Employee ID"></asp:Label>
            </td>
            <td class="auto-style18">
                <asp:TextBox ID="TextBoxEmpID" runat="server" Height="30px" CssClass="auto-style14"></asp:TextBox>
            </td>
            <td class="auto-style20">
                <asp:Button ID="btnSave" runat="server" Text="Save" Height="40px" Width="140px" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td aria-multiline="True" class="auto-style10">
                <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBoxFName" runat="server" Height="30px"></asp:TextBox>
            </td>
            <td class="auto-style19">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Height="40px" Width="140px" OnClick="btnUpdate_Click" />
            </td>
        </tr>
        <tr>
            <td aria-multiline="True" class="auto-style10">
                <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:TextBox ID="TextBoxLName" runat="server" Height="30px"></asp:TextBox>
            </td>
            <td class="auto-style19">
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Height="40px" Width="140px" OnClick="btnDelete_Click" />
            </td>
        </tr>
        <tr>
            <td aria-multiline="True" class="auto-style11">
                <asp:Label ID="Label4" runat="server" Text="Job Title"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:TextBox ID="TextBoxJobTitle" runat="server" Height="30px"></asp:TextBox>
            </td>
            <td class="auto-style21">
                <asp:Button ID="btnLstAll" runat="server" Text="List All" Height="40px" Width="140px" OnClick="btnLstAll_Click" />
            </td>
        </tr>
        <tr>
            <td aria-multiline="True" class="auto-style10">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
        </tr>
        <tr>
            <td aria-multiline="True" class="auto-style11"></td>
            <td class="auto-style9"></td>
            <td class="auto-style21">
                <asp:Label ID="lblDisplay" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td aria-multiline="True" class="auto-style10">
                <asp:Label ID="Label5" runat="server" Text="Search By"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Text="EmployeeID" Value="EmployeeID"></asp:ListItem>
                    <asp:ListItem Text="First Name" Value="FirstName"></asp:ListItem>
                    <asp:ListItem Text="Last Name" Value="LastName"></asp:ListItem>
                    <asp:ListItem Text="Job Title" Value="JobTitle"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style16">
                <asp:TextBox ID="TextBoxSearchEmpID" runat="server" Height="30px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" Height="40px" Width="140px" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style15" Height="317px" Width="939px" OnRowCommand="GridView1_RowCommand" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="JobTitle" HeaderText="JobTitle" SortExpression="JobTitle" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
