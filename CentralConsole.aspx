<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CentralConsole.aspx.cs" Inherits="HealthCentre.CentralConsole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/CentralConsole.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="superContainer">
            <div id="formContainer">
                <div class="formDoctor">
                    <asp:Label ID="Label1" CssClass="sectionTitle" runat="server" Text="Search patient by ID: "></asp:Label><br />
                    <asp:TextBox ID="searchPatient" runat="server">PIN</asp:TextBox><asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" /><br />
                    <asp:Button ID="deleteButton" runat="server" Text="DELETE PATIENT" OnClick="deleteButton_Click" /><br /><br />

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
                    <asp:Label ID="errorLabel" runat="server" Text=""></asp:Label><br />
                    <asp:Button ID="saveButton" runat="server" Text="SAVE PATIENT INFO" OnClick="saveButton_Click" />
                </div>

                <div>
                    <asp:Label ID="Label9" CssClass="sectionTitle" runat="server" Text="Create Patient: "></asp:Label><br /><br />

                    <asp:Label ID="Label10" runat="server" Text="PIN: "></asp:Label>
                    <asp:TextBox ID="createPin" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Label11" runat="server" Text="Password: "></asp:Label>
                    <asp:TextBox ID="createPassword" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Label12" runat="server" Text="Email: "></asp:Label>
                    <asp:TextBox ID="createEmail" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Label13" runat="server" Text="First Name: "></asp:Label>
                    <asp:TextBox ID="createFirst" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Label14" runat="server" Text="Last Name: "></asp:Label>
                    <asp:TextBox ID="createLast" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Label15" runat="server" Text="Date of birth: "></asp:Label>
                    <asp:TextBox ID="createDate" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Label16" runat="server" Text="Address: "></asp:Label>
                    <asp:TextBox ID="createAddress" runat="server"></asp:TextBox><br />

                    <asp:Label ID="Label17" runat="server" Text="Phone: "></asp:Label>
                    <asp:TextBox ID="createPhone" runat="server"></asp:TextBox><br /><br />

                    <asp:Label ID="createErrorLabel" runat="server" Text=""></asp:Label><br />
                    <asp:Button ID="createButton" runat="server" Text="CREATE PATIENT" OnClick="createButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
