<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplitPath.aspx.cs" Inherits="Expensive_co.Development.SplitPath" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EXPENSIVE.co</title>
    <link rel="apple-touch-icon" href="../asset/img/apple-icon.png">
    <link rel="shortcut icon" type="image/x-icon" href="../Assets/img/favicon.ico">
    <link rel="stylesheet" href="../Assets/Bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../Assets/Bootstrap/css/templatemo.css">   
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;200;300;400;500;700;900&display=swap">
    <link rel="stylesheet" href="../Assets/Bootstrap/css/fontawesome.min.css">
    <link rel="stylesheet" href="../Assets/Ex-personal.css">
    <link rel="stylesheet" href="../Assets/Bootstrap/css/style.min.css">
    <link rel="canonical" href="https://www.wrappixel.com/templates/ample-admin-lite/">
    <link rel="stylesheet" href="../Assets/Bootstrap/css/chartist.min.css">
    <link rel="stylesheet" href="../Assets/Bootstrap/css/chartist-plugin-tooltip.css">
    <script src="../Assets/Bootstrap/Ex-personal.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center d-flex justify-content-center align-items-center">
            <div class="col-md-12">
            <div>
            <h1>Thanks for purchasing with NAME</h1>
            <h3>Would you like to review our services?</h3>
            </div>
            <div>
            <asp:Button ID="Path1" runat="server" Text="Yes" OnClick="Path1_Click" />
            <asp:Button ID="Path2" runat="server" Text="No" OnClick="Path2_Click" />
            </div>
            </div>
        </div>
    </form>
</body>
</html>
