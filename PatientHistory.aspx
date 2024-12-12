<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientHistory.aspx.cs" Inherits="Healthcare_Alex_Fedor.PatientHistory" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Patient History</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Patient Information</h1>
        <p><strong>Name:</strong> <asp:Label ID="lblName" runat="server" Text="N/A"></asp:Label></p>
        <p><strong>Date of Birth:</strong> <asp:Label ID="lblDOB" runat="server" Text="N/A"></asp:Label></p>
        <p><strong>Address:</strong> <asp:Label ID="lblAddress" runat="server" Text="N/A"></asp:Label></p>
        <p><strong>Phone:</strong> <asp:Label ID="lblPhone" runat="server" Text="N/A"></asp:Label></p>

        <h2>Medical Records</h2>
        <asp:GridView ID="gvRecords" runat="server" AutoGenerateColumns="true">
        </asp:GridView>
    </form>
</body>
</html>
