<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HealthCentre.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login - HealthCenter</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/Login.css" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container vh-100 d-flex justify-content-center align-items-center">
            <div class="card p-4 shadow-lg" style="max-width: 400px; width: 100%;">
                <div class="card-body">
                    <h3 class="card-title text-center mb-4">Please Log In</h3>
                    <asp:Label ID="Label1" runat="server" Text="" CssClass="text-danger d-block text-center mb-3"></asp:Label>
                    <div class="mb-3">
                        <asp:Label ID="Label2" runat="server" Text="Username:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="userInput" runat="server" CssClass="form-control" Placeholder="Enter your username"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="Label3" runat="server" Text="Password:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="passInput" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Enter your password"></asp:TextBox>
                    </div>
                    <div class="d-grid">
                        <asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="LoginButton_Click" CssClass="btn btn-primary"></asp:Button>
                    </div>
                    <asp:Label ID="error" runat="server" Text="" CssClass="text-danger d-block mt-3 text-center"></asp:Label>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
