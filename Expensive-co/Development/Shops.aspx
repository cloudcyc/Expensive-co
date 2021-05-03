<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Shops.aspx.cs" Inherits="Expensive_co.Development.Shops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    

    <form id="form1" runat="server">
    <section class="container py-5">
        <div class="col-md-6 m-auto text-center">
            <div class="input-group">
                <asp:TextBox ID="Searchbar" runat="server" class="form-control" placeholder="Search ..."></asp:TextBox>
                
                <div class="input-group-text">
                    
                    <asp:LinkButton ID="SearchBtn" runat="server" OnClick="SearchBtn_Click"><i class="fa fa-fw fa-search" onclick="SearchBtn_Click"></i></asp:LinkButton>
                    
                </div>
            </div>

        </div>
        <br />
        <div class="row">
             
            
   
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
       
            
        </div>
    </section>
    </form>
    <br />


</asp:Content>