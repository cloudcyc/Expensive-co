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
                            <div class="col-lg-6 mb-0 d-flex align-items-center">
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
                    <h1 class="h1">Categories of The Month</h1>
                    <p>
                        Choose Your Favourite Category
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-4 p-5 mt-3">
                    <a href="#"><img src="../Assets/img/clothes.jpg" class="rounded-circle img-fluid border"></a>
                    <h5 class="text-center mt-3 mb-3">Clothes</h5>
                    <p class="text-center"><a class="btn btn-success">Go Shop</a></p>
                </div>
                <div class="col-12 col-md-4 p-5 mt-3">
                    <a href="#"><img src="../Assets/img/shoe.jpg" class="rounded-circle img-fluid border"></a>
                    <h2 class="h5 text-center mt-3 mb-3">Shoes</h2>
                    <p class="text-center"><a class="btn btn-success">Go Shop</a></p>
                </div>
                <div class="col-12 col-md-4 p-5 mt-3">
                    <a href="#"><img src="../Assets/img/glass.jpg" class="rounded-circle img-fluid border"></a>
                    <h2 class="h5 text-center mt-3 mb-3">Accessories</h2>
                    <p class="text-center"><a class="btn btn-success">Go Shop</a></p>
                </div>
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
                    <div class="col-12 col-md-4 mb-4">
                        <div class="card h-100">
                            <a href="#">
                                <img src="../Assets/img/ADLV.jpg" class="card-img-top" alt="...">
                            </a>
                            <div class="card-body">
                                <ul class="list-unstyled d-flex justify-content-between">
                                    <li>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-muted fa fa-star"></i>
                                    </li>
                                    <li class="text-muted text-right">RM 250.00</li>
                                </ul>
                                <a href="#" class="h2 text-decoration-none text-dark">ADLV Oversized Tee</a>
                                <p class="card-text">
                                    The Classic Oversized Tee of ADLV.
                                </p>
                                <p class="text-muted">Reviews (24)</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-4 mb-4">
                        <div class="card h-100">
                            <a href="#">
                                <img src="../Assets/img/nikeairjordan.jpg"" class="card-img-top" alt="...">
                            </a>
                            <div class="card-body">
                                <ul class="list-unstyled d-flex justify-content-between">
                                    <li>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-muted fa fa-star"></i>
                                        <i class="text-muted fa fa-star"></i>
                                    </li>
                                    <li class="text-muted text-right">RM 1250.00</li>
                                </ul>
                                <a href="#" class="h2 text-decoration-none text-dark">Nike Air Jordan Low </a>
                                <p class="card-text">
                                    Inspired by the original that debuted in 1985, the Air Jordan 1 Low offers a clean, classic look that's familiar yet always fresh. It's made for casual mode, with an iconic design that goes with everything and never goes out of style.
                                </p>
                                <p class="text-muted">Reviews (48)</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-4 mb-4">
                        <div class="card h-100">
                            <a href="#">
                                <img src="../Assets/img/nike77.jpg"" class="card-img-top" alt="...">
                            </a>
                            <div class="card-body">
                                <ul class="list-unstyled d-flex justify-content-between">
                                    <li>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                        <i class="text-warning fa fa-star"></i>
                                    </li>
                                    <li class="text-muted text-right"> RM 360.00</li>
                                </ul>
                                <a href="#" class="h2 text-decoration-none text-dark">Nike Blazer Mid 77 Infinite Rubberized Crimson </a>
                                <p class="card-text">
                                    Nike Blazer Shoes Offer a Classic Style That Just Gets Better With Age.
                                </p>
                                <p class="text-muted">Reviews (74)</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Featured Product -->

        <!-- Start Script -->
        <script src="../Assets/Bootstrap/js/jquery-1.11.0.min.js"></script>
        <script src="../Assets/Bootstrap/js/jquery-migrate-1.2.1.min.js"></script>
        <script src="../Assets/Bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="../Assets/Bootstrap/js/templatemo.js"></script>
        <script src="../Assets/Bootstrap/js/custom.js"></script>
        <!-- End Script -->
</asp:Content>

