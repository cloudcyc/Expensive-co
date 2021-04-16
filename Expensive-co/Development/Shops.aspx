<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="Expensive_co.Development.Shops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <form id="form1" runat="server">
            <div class="row">
                    <div class="col-md-4">
                        <div class="card mb-4 product-wap rounded-0">
                            <div class="card rounded-0">
                                <div class="card-body">

            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                    </div>
                                </div>
                             </div>
                        </div>
                    </div>

    </form>
    <br />


</asp:Content>