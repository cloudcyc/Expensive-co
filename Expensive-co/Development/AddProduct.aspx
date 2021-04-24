<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Development/LayoutAdmin.Master" CodeBehind="AddProduct.aspx.cs" Inherits="Expensive_co.Development.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Product List</h4> 
                                                
                    </div>
                </div>
            </div>
            

                    <div class="container py-5">
                     <div class="row py-5">
                        <form id="form1" class="col-md-9 m-auto" runat="server">
                        <div class="row">

                            <div class="form-group col-md-6 mb-3">
                                <label for="inputname">Product Name:</label>
                                <input type="text" class="form-control mt-1" id="productname" name="productname" placeholder="Product Name">
                            </div>

                            <div class="form-group col-md-6 mb-3">
                                <label for="inputemail">Product Price:</label>                        
                                <asp:TextBox ID="productprice" runat="server" class="form-control mt-1" name="productprice" placeholder="Product Price"></asp:TextBox>
                            </div>

                        </div>

                        <div class="mb-3">
                            <label for="inputsubject">Product Brand:</label>                    
                            <asp:TextBox ID="productbrand" runat="server" class="form-control mt-1" name="productbrand" placeholder="Product Brand"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="inputsubject">Product Image:</label>
                            <asp:FileUpload ID="productimage" runat="server" />
                        </div>

                        <div class="mb-3">
                            <label for="inputsubject">Product Categories:</label>                    
                            <asp:TextBox ID="productcategories" runat="server" class="form-control mt-1" name="productcategories" placeholder="Product Categories"></asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <label for="inputmessage">Product Description:</label>
                            <textarea class="form-control mt-1" id="productdescription" name="productdescription" placeholder="Product Description" rows="8"></textarea>
                        </div>

                         <div class="row">
                            <%--this is the invalid warning--%>
                            <div class="col mt-2 ">
                                <asp:Panel ID="InvalidPanel" visible="false" class="alert alert-danger" runat="server">
                                    <asp:Label ID="InvalidError" class="" runat="server" Text="asd"></asp:Label>
                                </asp:Panel>
                        
                            </div>
                            <div class="col text-end mt-2">
                                <button type="submit" class="btn btn-success btn-lg px-3">Add New Product</button>
                            </div>
                        </div>

                        </form>
                    </div>
                     
    </div>
        </div>

</asp:Content>