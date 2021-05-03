<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Development/LayoutAdmin.Master" CodeBehind="EditProduct.aspx.cs" Inherits="Expensive_co.Development.EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Edit Product</h4> 
                                                
                    </div>
                </div>
            </div>
            

                    <div class="container py-5">
                     <div class="row py-5">
                        <form id="form1" class="col-md-9 m-auto" runat="server">
                            <div class="row">

                                <div class="form-group col-md-6 mb-3">
                                    <label for="inputname">Product Name:</label>
                                
                                    <asp:TextBox ID="productname" runat="server" class="form-control mt-1" name="productname" placeholder="Product Name"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6 mb-3">
                                    <label for="inputemail">Product Price (RM):</label>                        
                                    <asp:TextBox ID="productprice" runat="server" class="form-control mt-1" name="productprice" placeholder="Product Price"></asp:TextBox>
                                </div>

                            </div>

                            <div class="mb-3">
                                <label for="inputsubject">Product Brand:</label>    
                                <asp:DropDownList ID="productbrand" runat="server" class="form-control mt-1">
                                    <asp:ListItem Selected="True">Select a brand</asp:ListItem>
                                    <asp:ListItem>Nike</asp:ListItem>
                                    <asp:ListItem>LV</asp:ListItem>
                                    <asp:ListItem>ADLV</asp:ListItem>
                                    <asp:ListItem>Supreme</asp:ListItem>
                                    <asp:ListItem>Adidas</asp:ListItem>
                                </asp:DropDownList>
                         
                            </div>

                            <div class="mb-3">
                                <label for="inputsubject">Product Image:</label>
                                <asp:FileUpload ID="productimage" runat="server" />
                                <asp:Image ID="currentproductImage" Class="card-img rounded-0 h-50" runat="server" />
                            </div>

                            <div class="mb-3">
                                <label for="inputsubject">Product Categories:</label>  
                                <asp:DropDownList ID="productcategories" runat="server" name="productcategories" class="form-control mt-1">
                                    <asp:ListItem Selected="True">Select Category</asp:ListItem>
                                    <asp:ListItem>T-Shirt</asp:ListItem>
                                    <asp:ListItem>Pants</asp:ListItem>
                                    <asp:ListItem>Accessory</asp:ListItem>
                                    <asp:ListItem>Shoe</asp:ListItem>
                                    <asp:ListItem>Hoodie</asp:ListItem>
                                </asp:DropDownList>                  
                          
                            </div>

                            <div class="mb-3">
                                <label for="inputmessage">Product Description:</label>
                                <asp:TextBox ID="productdescription" runat="server" class="form-control mt-1" style="resize:none;" placeholder="Product Description" Rows="8" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                            
                            </div>

                             <div class="row">
                                <%--this is the invalid warning--%>
                                <div class="col mt-2 ">
                                    <asp:Panel ID="InvalidPanel" visible="false" class="alert alert-danger" runat="server">
                                        <asp:Label ID="InvalidError" class="" runat="server" Text="asd"></asp:Label>
                                    </asp:Panel>
                        
                                </div>
                                <div class="col text-end mt-2">
                                    <asp:Button ID="EditBtn" class="btn btn-success btn-lg px-3" runat="server" Text="Edit Product" OnClick="EditBtn_Click" />
                           
                                </div>
                            </div>
               
                        </form>
                    </div>
                     
    </div>
        </div>

</asp:Content>