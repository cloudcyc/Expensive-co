<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Expensive_co.Development.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Start Content Page -->
    <div class="container-fluid bg-light py-5">
        <div class="col-md-6 m-auto text-center">
            <h1 class="h1">Register an account</h1>
            <p>
                Join us now for getting more privilege
            </p>
        </div>
    </div>

    <!-- Login Form -->
    <div class="container py-5">
        <div class="row py-5">
            <form class="col-md-9 m-auto" method="post" role="form">

                <div class="row">
                    <div class="form-group col-md-6 mb-3">
                        <label for="inputname">First Name</label>
                        <input type="text" class="form-control mt-1" id="First" name="First" placeholder="First Name">
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="inputemail">Last Name</label>
                        <input type="text" class="form-control mt-1" id="Last" name="Last" placeholder="Last Name">
                    </div>
                </div>
                
                <div class="mb-3">
                    <label for="inputsubject">Email</label>
                    <input type="email" class="form-control mt-1" id="Username" name="Username" placeholder="Username / Email">
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Phone Number</label>
                    <input type="tel" class="form-control mt-1" id="Phone" name="Phone" placeholder="Phone Number">
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Date of Birth</label>
                    <input type="date" class="form-control mt-1" id="DOB" name="DOB" placeholder="Select Date">
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Password</label>
                    <input type="password" class="form-control mt-1" id="Password" name="Password" placeholder="Insert Your Password">
                </div>
                
                <div class="row">
                    <div class="col text-end mt-2">
                        <button type="submit" class="btn btn-success btn-lg px-3">Create an account</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-- Login Form -->

</asp:Content>