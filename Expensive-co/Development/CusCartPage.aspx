<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="CusCartPage.aspx.cs" Inherits="Expensive_co.Development.CusCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid bg-light py-5">
        <div class="col-md-6 m-auto text-center">
            <h1 class="h1">Your Cart</h1>   
            <p>
                Check Out Your Goods Here
                
            </p>
        </div>
    </div>
    

    <div class="container py-5">
    <div class="row py-5">
    <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="white-box">
                            <div class="table-responsive">
                                <table class="table text-nowrap">
                                    <thead>
                                        <tr>
                                            <asp:Label ID="currentCartID" runat="server" Text="NoCartID" class="d-none"></asp:Label>
                                            <th class="border-top-0">Product</th>
                                            <th class="border-top-0">Product Name</th>
                                            <th class="border-top-0">Product Price</th>
                                            <th class="border-top-0">Qauntity</th>
                                            <th class="border-top-0">Description</th>
                                            <th class="border-top-0">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                          <td></td>
                                          <td>Total Amount:</td>
                                          <td>RM <asp:Label ID="TotalAmount" runat="server" Text="TotalAmount"></asp:Label></td>
                                          <td></td>
                                          <td></td>
                                          <td></td>
                                            
                                        </tr>
                                    </tfoot>

                                    

                                </table>

                                <br /><br /><br />

                                

                            </div>
                        </div>
                    </div>
                </div>
            </div>

                <div class="row">
                    <form runat=server>
                        
                        <div class="col text-end mt-2">
                            <asp:Button ID="CheckOutBtn" runat="server" Text="Check Out" class="btn btn-success btn-lg btn-block" OnClick="CheckOutBtn_Click"/>     
                        </div>
                    </form>
                </div>

        </div>
        </div>


</asp:Content>
