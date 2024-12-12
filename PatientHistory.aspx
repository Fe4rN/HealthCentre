<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientHistory.aspx.cs" Inherits="Healthcare_Alex_Fedor.PatientHistory" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Patient History</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="card shadow-sm">
                <div class="card-body">
                    <h1 class="card-title">Patient Information</h1>
                    <hr>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <p><strong>Name:</strong> <asp:Label ID="lblName" runat="server" Text="N/A"></asp:Label></p>
                        </div>
                        <div class="col-md-6">
                            <p><strong>Date of Birth:</strong> <asp:Label ID="lblDOB" runat="server" Text="N/A"></asp:Label></p>
                        </div>
                        <div class="col-md-6">
                            <p><strong>Address:</strong> <asp:Label ID="lblAddress" runat="server" Text="N/A"></asp:Label></p>
                        </div>
                        <div class="col-md-6">
                            <p><strong>Phone:</strong> <asp:Label ID="lblPhone" runat="server" Text="N/A"></asp:Label></p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card mt-4 shadow-sm">
                <div class="card-body">
                    <h2 class="card-title">Medical Records</h2>
                    <hr>
                    <asp:ListBox ID="recordList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="recordList_SelectedIndexChanged"></asp:ListBox>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Appointment date: "></asp:Label><asp:Label ID="appDate" runat="server" Text="N/A"></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" Text="Doctor: "></asp:Label><asp:Label ID="appDoc" runat="server" Text="N/A"></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text="Diagnosis: "></asp:Label><asp:Label ID="appDiagnosis" runat="server" Text="N/A"></asp:Label><br />
                        <asp:Label ID="Label4" runat="server" Text="Treatment: "></asp:Label><asp:Label ID="appTreatment" runat="server" Text="N/A"></asp:Label><br />
                        <asp:Label ID="Label6" runat="server" Text="Notes: "></asp:Label><asp:Label ID="appNotes" runat="server" Text="N/A"></asp:Label><br />
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
