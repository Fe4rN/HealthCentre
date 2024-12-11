<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HealthCentre.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/Login.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please Log In to proceed to the console"></asp:Label><br />
            <div class="LoginBox">
                <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="userInput" runat="server"></asp:TextBox>
            </div>
            <div class="LoginBox">
                <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="passInput" TextMode="Password" runat="server" ></asp:TextBox>
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="LOG IN" OnClick="LoginButton_Click" />
            <asp:Label ID="error" runat="server" Text="Username or password is not correct"></asp:Label>




        </div>
    </form>
</body>
</html>
