<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CentralConsole.aspx.cs" Inherits="HealthCentre.CentralConsole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Search patient by ID: "></asp:Label><br />
                <asp:TextBox ID="searchPatient" runat="server">PIN</asp:TextBox><asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" /><br />
                <asp:Button ID="deleteButton" runat="server" Text="DELETE PATIENT" /><br /><br />

                <asp:Label ID="Label2" runat="server" Text="Pin: "></asp:Label>
                <asp:TextBox ID="pinEdit" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="emailEdit" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label4" runat="server" Text="First name: "></asp:Label>
                <asp:TextBox ID="firstEdit" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label5" runat="server" Text="Last name: "></asp:Label>
                <asp:TextBox ID="lastEdit" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label6" runat="server" Text="Date of birth: "></asp:Label>
                <asp:TextBox ID="dateEdit" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label7" runat="server" Text="Address: "></asp:Label>
                <asp:TextBox ID="addressEdit" runat="server"></asp:TextBox>
                <br />

                <asp:Label ID="Label8" runat="server" Text="Phone: "></asp:Label>
                <asp:TextBox ID="phoneEdit" runat="server"></asp:TextBox>
                <br /><br />

                <asp:Button ID="saveButton" runat="server" Text="SAVE PATIENT INFO" />
            </div>
        </div>
    </form>
</body>
</html>
