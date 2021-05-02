<%@ Page Title="" Language="C#" MasterPageFile="~/Development/LayoutAdmin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Expensive_co.Development.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                <li class="ms-auto">
                                    <span class="counter text-success">
                                        <asp:Label ID="TotalSales" runat="server" Text="Label" class="counter fw-bold"></asp:Label> 
                                     </span>

                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-12">
                        <div class="white-box analytics-info">
                            <h3 class="box-title">Total Users (Customer)</h3>
                            <ul class="list-inline two-part d-flex align-items-center mb-0">
                                <li>
                                    <div id="sparklinedash2"><canvas width="67" height="30"
                                            style="display: inline-block; width: 67px; height: 30px; vertical-align: top;"></canvas>
                                    </div>
                                </li>
                                
                                <li class="ms-auto">
                                    <asp:Label ID="TotalMemberCount" runat="server" Text="Label" class="counter text-purple fw-bold"></asp:Label>  
                                </li>

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
                                <li class="ms-auto">
                                    <asp:Label ID="TotalProductCount" runat="server" Text="Label" class="counter text-purple fw-bold"></asp:Label>                                   
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
                                <div class="container-fluid">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="white-box">
                                            <div class="table-responsive">
                                                <table class="table text-nowrap">
                                                    <thead>
                                                        <tr>
                                                            <th class="border-top-0">Order ID</th>
                                                            <th class="border-top-0">Cart ID</th>
                                                            <th class="border-top-0">User ID</th>
                                                            <th class="border-top-0">Total Sales</th>
                                                            <th class="border-top-0">Checked Out Date</th>
                                                            <th class="border-top-0">View Cart</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                        

            </div>

            </div>
        </div>
</asp:Content>
