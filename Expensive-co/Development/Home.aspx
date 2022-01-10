<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Expensive_co.Development.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!-- Start Banner Hero -->
        <div id="template-mo-zay-hero-carousel" class="carousel slide" data-bs-ride="carousel">
        
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <div class="container">
                        <div class="row p-5">
                            <div class="mx-auto col-md-8 col-lg-6 order-lg-last">
                                <img class="img-fluid" src="../Assets/img/lv.jpg" alt="">
                            </div>
                            <div class="col-lg-6 mb-7 d-flex align-items-center">
                                <div class="text-align-left align-self-center">
                                    <h1 class="h1"><b>EXPENSIVE</b> .co</h1>
                                    <h3 class="h2">Buy Your Wearable Here</h3>
                                    <p>
                                        EXPENSIVE.co is an online wearable online shopping platform that provide our consumers with superior design, quality, and value.
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            
            </div>
        

        </div>
        <!-- End Banner Hero -->


        <!-- Start Categories of The Month -->
        <section class="container py-5">
            <div class="row text-center pt-3">
                <div class="col-lg-6 m-auto">
                    <h1 class="h1">Newest Product</h1>
                    <p>
                        Choose The Newest
                    </p>
                </div>
            </div>
            <div class="row">
                <asp:PlaceHolder ID="NewProduct" runat="server"></asp:PlaceHolder>
            </div>
        </section>
        <!-- End Categories of The Month -->


        <!-- Start Featured Product -->
        <section class="bg-light">
            <div class="container py-5">
                <div class="row text-center py-3">
                    <div class="col-lg-6 m-auto">
                        <h1 class="h1">Featured Product</h1>
                        <p>
                            The Best Seller of Our Store
                        </p>
                    </div>
                </div>
                <div class="row">
                    <asp:PlaceHolder ID="BestSeller" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </section>
        <!-- End Featured Product -->

        <!-- Start Script -->
        <script src="../Assets/Bootstrap/js/jquery-1.11.0.min.js"></script>
        <script src="../Assets/Bootstrap/js/jquery-migrate-1.2.1.min.js"></script>
        <%--<script src="../Assets/Bootstrap/js/bootstrap.bundle.min.js"></script>--%>
        <script src="../Assets/Bootstrap/js/templatemo.js"></script>
        <script src="../Assets/Bootstrap/js/custom.js"></script>
        <!-- End Script -->
</asp:Content>

