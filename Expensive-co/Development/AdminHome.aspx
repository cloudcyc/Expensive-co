<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="AdminHome.aspx.cs" Inherits="Expensive_co.Development.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords"
        content="wrappixel, admin dashboard, html css dashboard, web dashboard, bootstrap 5 admin, bootstrap 5, css3 dashboard, bootstrap 5 dashboard, Ample lite admin bootstrap 5 dashboard, frontend, responsive bootstrap 5 admin template, Ample admin lite dashboard bootstrap 5 dashboard template">
    <meta name="description"
        content="Ample Admin Lite is powerful and clean admin dashboard template, inpired from Bootstrap Framework">
    <meta name="robots" content="noindex,nofollow">


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
</head>
<body>
    
    

    <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full" data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">

        <header class="topbar" data-navbarbg="skin5">
            <nav class="navbar top-navbar navbar-expand-md navbar-dark">
                <div class="navbar-header" data-logobg="skin6">
                    <!-- Logo -->
                    <a class="navbar-brand" href="AdminHome.aspx">
                        <!-- Logo icon -->
                        <b class="logo-icon">
                            <!-- Dark Logo icon -->
                           <img src="../Assets/img/test.png" class="EX-Logo"/>
                        </b>
                        <!--End Logo icon -->                        
                    </a>                    
                    
                </div>
                
                <!-- End Logo -->
                
                <ul class="navbar-nav ms-auto d-flex align-items-center">

                        <!-- User profile-->
                        <li>
                            Hi! <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </li>
                    </ul>

            </nav>
        </header>


        <aside class="left-sidebar" data-sidebarbg="skin6">
            <!-- Sidebar scroll-->
            <div class="scroll-sidebar">
                <!-- Sidebar navigation-->
                <nav class="sidebar-nav">
                    <ul id="sidebarnav">
                        <!-- User Profile-->
                        <li class="sidebar-item pt-2">
                            <a class="sidebar-link waves-effect waves-dark sidebar-link" href="AdminHome.aspx"
                                aria-expanded="false">
                                <i class="far fa-clock" aria-hidden="true"></i>
                                <span class="hide-menu">Dashboard</span>
                            </a>
                        </li>
                        <li class="sidebar-item">
                            <a class="sidebar-link waves-effect waves-dark sidebar-link" href="#"
                                aria-expanded="false">
                                <i class="fa fa-user" aria-hidden="true"></i>
                                <span class="hide-menu">Profile</span>
                            </a>
                        </li>
                        <li class="sidebar-item">
                            <a class="sidebar-link waves-effect waves-dark sidebar-link" href="#"
                                aria-expanded="false">
                                <i class="fa fa-table" aria-hidden="true"></i>
                                <span class="hide-menu">Manage User Account</span>
                            </a>
                        </li>
                         <li class="sidebar-item">
                            <a class="sidebar-link waves-effect waves-dark sidebar-link" href="#"
                                aria-expanded="false">
                                <i class="fa fa-table" aria-hidden="true"></i>
                                <span class="hide-menu">Sales History</span>
                            </a>
                        </li>
                        <li class="sidebar-item">
                            <a class="sidebar-link waves-effect waves-dark sidebar-link" href="#"
                                aria-expanded="false">
                                <i class="fa fa-table" aria-hidden="true"></i>
                                <span class="hide-menu">Manage Contacts</span>
                            </a>
                        </li>
                        <li class="text-center p-20 upgrade-btn">
                            <a href="Logout.aspx""
                                class="btn d-grid btn-danger text-white" target="Logout.aspx">Logout</a>
                        </li>
                    </ul>

                </nav>
                <!-- End Sidebar navigation -->
            </div>
            <!-- End Sidebar scroll-->
        </aside>

        <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Dashboard</h4>
                    </div>
                </div>
            </div>
        

        <div class="container-fluid">
            <div class="row justify-content-center">
                    <div class="col-lg-4 col-md-12">
                        <div class="white-box analytics-info">
                            <h3 class="box-title">Total Sales</h3>
                            <ul class="list-inline two-part d-flex align-items-center mb-0">                                
                                <li class="ms-auto"><span class="counter text-success">RM 1,000,000</span></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-12">
                        <div class="white-box analytics-info">
                            <h3 class="box-title">Total Users</h3>
                            <ul class="list-inline two-part d-flex align-items-center mb-0">
                                <li>
                                    <div id="sparklinedash2"><canvas width="67" height="30"
                                            style="display: inline-block; width: 67px; height: 30px; vertical-align: top;"></canvas>
                                    </div>
                                </li>
                                <li class="ms-auto"><span class="counter text-purple">888</span></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-12">
                        <div class="white-box analytics-info">
                            <h3 class="box-title">Total Products</h3>
                            <ul class="list-inline two-part d-flex align-items-center mb-0">
                                <li>
                                    <div id="sparklinedash3"><canvas width="67" height="30"
                                            style="display: inline-block; width: 67px; height: 30px; vertical-align: top;"></canvas>
                                    </div>
                                </li>
                                <li class="ms-auto"><span class="counter text-info">888</span>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>

            <!-- RECENT SALES -->
            <div class="row">
                    <div class="col-md-12 col-lg-12 col-sm-12">
                        <div class="white-box">
                            <div class="d-md-flex mb-3">
                                <h3 class="box-title mb-0">Recent sales</h3>
                            </div>
                        </div>
                    </div>
            </div>

            </div>
        </div>
        </div>







    <!--Java Script-->

    <script src="../Assets/Bootstrap/js/jquery.min.js"></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src="../Assets/Bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="../Assets/Bootstrap/js/app-style-switcher.js"></script>
    <script src="../Assets/Bootstrap/js/jquery.sparkline.min.js"></script>
    <!--Wave Effects -->
    <script src="../Assets/Bootstrap/js/waves.js"></script>
    <!--Menu sidebar -->
    <script src="../Assets/Bootstrap/js/sidebarmenu.js"></script>
    <!--Custom JavaScript -->
    <script src="../Assets/Bootstrap/js/custom.js"></script>
    <!--This page JavaScript -->
    <!--chartis chart-->
    <script src="../Assets/Bootstrap/js/chartist.min.js"></script>
    <script src="../Assets/Bootstrap/js/chartist-plugin-tooltip.min.js"></script>
    <script src="../Assets/Bootstrap/js/dashboard1.js"></script>

</body>
</html>
