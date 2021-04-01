<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Expensive_co.Development.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Start Content Page -->
    <div class="container-fluid bg-light py-5">
        <div class="col-md-6 m-auto text-center">
            <h1 class="h1">Login To Your Account</h1>
            <p>
                Log in to Expensive.co
            </p>
        </div>
    </div>

    <!-- Login Form -->
    <div class="container py-5">
        <div class="row py-5">
            <form class="col-md-9 m-auto" method="post" role="form">
                
                <div class="mb-3">
                    <label for="inputsubject">Username</label>
                    <input type="Email" class="form-control mt-1" id="Username" name="Username" placeholder="Username / Email">
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Password</label>
                    <input type="password" class="form-control mt-1" id="Password" name="Password" placeholder="Insert Your Password">
                </div>
                
                <div class="row">
                    <div class="col text-end mt-2">
                        <button type="submit" class="btn btn-success btn-lg px-3">Login</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-- Login Form -->

</asp:Content>