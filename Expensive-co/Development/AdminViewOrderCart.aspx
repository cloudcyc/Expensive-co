<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Development/LayoutAdmin.Master" CodeBehind="AdminViewOrderCart.aspx.cs" Inherits="Expensive_co.Development.AdminViewOrderCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Sales History</h4> 
                                                
                    </div>                    
                </div>
            </div>

            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="white-box">
                            <div class="table-responsive">
                                <table class="table text-nowrap">
                                    <thead>
                                        <tr>
                                            <th class="border-top-0">Product</th>
                                            <th class="border-top-0">Product Name</th>
                                            <th class="border-top-0">Product Price</th>
                                            <th class="border-top-0">Qauntity</th>
                                            <th class="border-top-0">Description</th>
                                            
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
                                          
                                            
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

         </div>
</asp:Content>


