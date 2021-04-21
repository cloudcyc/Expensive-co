<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Development/LayoutAdmin.Master" CodeBehind="ProductList.aspx.cs" Inherits="Expensive_co.Development.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Product List</h4>                                 
                    </div>

                    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
                        <div class="d-md-flex">
                            <ol class="breadcrumb ms-auto"></ol>
                            <a class="btn btn-success text-white">Add New Products</a>
                        </div>
                    </div>
                    
                </div>
            </div>
        

    <form id="form1" runat="server">
    <section class="container py-5">
        
        <div class="row">

            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            </div>
    </section>
    </form>

    </div>

</asp:Content>