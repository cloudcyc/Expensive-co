<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Development/LayoutAdmin.Master" CodeBehind="AdminManageUser.aspx.cs" Inherits="Expensive_co.Development.AdminManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Manage User Account</h4> 
                                                
                    </div>                    
                </div>
            </div>
        
        

    <form id="form1" runat="server">
    <section class="container py-5">    
        <div class="col-md-6 m-auto text-center">
            <div class="input-group">
                <input type="text" class="form-control" id="inputMobileSearch" placeholder="Search ...">
                <div class="input-group-text">
                    <i class="fa fa-fw fa-search"></i>
                </div>
            </div>

        </div>
        <br />
            <div class="row">

                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            </div>
    </section>
    </form>

    </div>

</asp:Content>