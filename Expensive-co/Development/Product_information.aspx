<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Product_information.aspx.cs" Inherits="Expensive_co.Development.Product_information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
  <div class="row">
    <div class="col-4">
     <div class="container">
         <h2> New Arrivals</h2>
         <div class="row">
         <div class="col-md-3">
         <div class="product-top">
             <img src="shoes.jpg" alt="Alternate Text" />
            <div class="overlay">
            <button type="button" class="btn btn secondary" 
                title="Quick shop"><i class="fa fa-eye"></i></button>
                <button type="button" class="btn btn secondary" 
                title="Add to Wishlist"><i class="fas fa-heart"></i></button>
                <button type="button" class="btn btn secondary" 
                title="Add to cart"><i class="fa fa-shopping-cart"></i></button>

            </div>

            </div>
             <div class="product-color-dot-bottom text-center">
                 <i class="fa fa-star"></i>
                 <i class="fa fa-star"></i>
                 <i class="fa fa-star"></i>
                 <i class="fa fa-star-half-o"></i>
                 <i class="fa fa-star-o"></i>
                    <h3>Fitness Shoes</h3>
                 <h5>$499.00</h5>
                 
                 
             </div>
            </div>
         </div>
     </div>
    </div>
    <div class="col-8">
     <h5>Discription</h5>
        <h5>Lather Shoes</h5>
        <div class="Discription">
            <p>the shoes are made up of original lather. we are giving two years warrenty of shoes.
                the waranty can be claimed on nike store. delivery time (5 working days)</p>

        </div>
    </div>
  </div>
</div>
</asp:Content>
