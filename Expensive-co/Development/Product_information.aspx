<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Product_information.aspx.cs" Inherits="Expensive_co.Development.Product_information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <!-- Open Content -->
    <section class="bg-light">
        <div class="container pb-5">
            <div class="row">
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <div class="col-lg-5 mt-5">
                    <div class="card mb-3">
                        <asp:Image ID="Image1" runat="server" class="card-img img-fluid" />
                        
                    </div>
                </div>
                <!-- col end -->
                <div class="col-lg-7 mt-5">
                    <div class="card">
                        <div class="card-body">
                            <asp:Label ID="Label1" runat="server" Text="Label" class="h2"></asp:Label>
                            <%--<h1 class="h2">LV Casual White Shoe</h1>--%>
                            <br />
                            <Label class="h3">RM </Label> <asp:Label ID="Label2" runat="server" Text="Label" class="h3"></asp:Label>
                            <%--<p class="h3 py-2">RM8888888</p>--%>
                            <ul class="list-inline">
                                <li class="list-inline-item">
                                    <h6>Brand:</h6>
                                </li>
                                <li class="list-inline-item">
                                    <asp:Label ID="Label3" runat="server" Text="Label" class="text-muted"></asp:Label>
                                    <%--<p class="text-muted"><strong>LV</strong></p>--%>
                                </li>
                            </ul>

                            <h6>Description:</h6>
                            <asp:Label ID="Label4" runat="server" Text="Label" class="h6"></asp:Label>
                            

                            
                            <form id="form1" runat="server">
                                <input type="hidden" name="product-title" value="Activewear">
                                <div class="row">
                                    <div class="col-auto">
                                        <ul class="list-inline pb-3">
                                            <li class="list-inline-item">Size :
                                                <asp:Label ID="Label5" runat="server" Text="Free Size"></asp:Label>
                                                <input type="hidden" name="product-size" id="product-size" value="S">
                                            </li>
                                            <asp:DropDownList ID="DropDownList1" runat="server" >
                                                <asp:ListItem Selected="True" class="list-inline-item">Select Size</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">7</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">8</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">9</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">10</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">11</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">12</asp:ListItem>
                                             </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                                <asp:ListItem class="list-inline-item" Selected="True">Select Size</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">S</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">M</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">L</asp:ListItem>
                                                <asp:ListItem class="list-inline-item">XL</asp:ListItem>
                                             </asp:DropDownList>
                                            
                                        </ul>
                                    </div>
                                    <div class="col-auto">
                                        <ul class="list-inline pb-3">
                                            <li class="list-inline-item text-right">
                                                Quantity
                                                <input type="hidden" name="product-quanity" id="product-quanity" value="1">
                                            </li>

                                            <li class="list-inline-item"><a id="MinusQuantity" onserverclick="MinusQuantity_Click" runat="server"><span class="btn btn-success" id="btn-minus">-</span></a></li>
                                            <li class="list-inline-item">
                                                <asp:Label ID="QuantityNumber" runat="server" Text="1" class="badge bg-secondary"></asp:Label>
                                               

                                            </li>
                                            <li class="list-inline-item"><a id="AddQuantity" onserverclick="AddQuantity_Click" runat="server"><span class="btn btn-success" id="btn-plus">+</span></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="row pb-3">
                                    <asp:Button ID="AddToCartBtn" class="btn btn-success btn-lg" runat="server" Text="Add To Cart" OnClick="AddToCartBtn_Click" />
                                    
                                    <div class="col d-grid">                                        
                                    </div>
                                </div>
                            </form>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Close Content -->

</asp:Content>
