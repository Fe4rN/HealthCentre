<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CentralConsole.aspx.cs" Inherits="HealthCentre.CentralConsole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Central Console</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container py-5">
            <div class="row">
                <!-- Search and Edit Section -->
                <div class="col-lg-6 mb-4">
                    <div class="card shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title">Search Patient</h5>
                            <hr>
                            <div class="mb-3">
                                <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Search patient by ID:"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="searchPatient" runat="server" CssClass="form-control" Placeholder="Enter patient ID"></asp:TextBox>
                                    <asp:Button ID="searchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="searchButton_Click" />
                                </div>
                            </div>
                            <asp:Button ID="deleteButton" runat="server" Text="DELETE PATIENT" CssClass="btn btn-danger w-100 mb-3" OnClick="deleteButton_Click" />
                            
                            <h6 class="mt-4">Edit Patient Information</h6>
                            <div class="mb-2">
                                <asp:Label ID="Label2" runat="server" Text="Pin:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="pinEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label3" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="emailEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label4" runat="server" Text="First name:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="firstEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label5" runat="server" Text="Last name:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="lastEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label6" runat="server" Text="Date of birth:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="dateEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label7" runat="server" Text="Address:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="addressEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label8" runat="server" Text="Phone:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="phoneEdit" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Label ID="errorLabel" runat="server" Text="" CssClass="text-danger"></asp:Label>
                            <asp:Button ID="saveButton" runat="server" Text="SAVE PATIENT INFO" CssClass="btn btn-success w-100 mt-3" OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>

                <!-- Create Section -->
                <div class="col-lg-6">
                    <div class="card shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title">Create Patient</h5>
                            <hr>
                            <div class="mb-2">
                                <asp:Label ID="Label10" runat="server" Text="PIN:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createPin" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label11" runat="server" Text="Password:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createPassword" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label12" runat="server" Text="Email:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label13" runat="server" Text="First Name:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createFirst" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label14" runat="server" Text="Last Name:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createLast" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label15" runat="server" Text="Date of birth:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label16" runat="server" Text="Address:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-2">
                                <asp:Label ID="Label17" runat="server" Text="Phone:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Label ID="createErrorLabel" runat="server" Text="" CssClass="text-danger"></asp:Label>
                            <asp:Button ID="createButton" runat="server" Text="CREATE PATIENT" CssClass="btn btn-primary w-100 mt-3" OnClick="createButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="container py-5">
            <div class="row">
                <div class="col-lg-6">
                    <div class="card shadow-sm">
                        <div class="card-body">
                            <h5 class="card-title">Appointments</h5>
                            <hr>
                            <asp:ListBox ID="appointmentBox" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="appointmentBox_SelectedIndexChanged"></asp:ListBox>
                        </div>
                    </div>
                    <div class="card shadow-sm mt-4">
                        <div class="card-body">
                            <h5 class="card-title">Create Appointment</h5>
                            <hr>
                            <div class="mb-3">
                                <asp:Label ID="Label22" runat="server" Text="Appointment Date:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createAppDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label23" runat="server" Text="Diagnosis:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createDiagnosis" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label24" runat="server" Text="Treatment:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createTreatment" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label25" runat="server" Text="Notes:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="createNotes" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Label ID="createAppErrorLabel" runat="server" Text="" CssClass="text-danger"></asp:Label>
                            <asp:Button ID="createAppointment" runat="server" Text="Create Appointment" CssClass="btn btn-primary w-100 mt-3" OnClick="createAppointment_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card shadow-sm">
                         <div class="card-body">
                            <h5 class="card-title">Edit Appointment</h5>
                            <hr>
                            <div class="mb-3">
                                <asp:Label ID="Label9" runat="server" Text="Appointment Date:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="editAppDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label19" runat="server" Text="Diagnosis:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="editDiagnosis" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label20" runat="server" Text="Treatment:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="editTreatment" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="Label21" runat="server" Text="Notes:" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="editNotes" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:Label ID="errorAppLabel" runat="server" Text="" CssClass="text-danger"></asp:Label>
                            <div class="d-flex justify-content-between mt-3">
                                <asp:Button ID="saveAppInfo" runat="server" Text="Save Appointment Info" CssClass="btn btn-success" OnClick="saveAppInfo_Click" />
                                <asp:Button ID="deleteApp" runat="server" Text="Delete Appointment" CssClass="btn btn-danger" OnClick="deleteApp_Click" />
                            </div>
                        </div>
                    </div>
                </div>
              </div>
                            <div class="d-flex justify-content-end mb-4">
                <asp:Button ID="logoutButton" runat="server" Text="Logout" CssClass="btn btn-secondary" OnClick="LogoutButton_Click" />
            </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
