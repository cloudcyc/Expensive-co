<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Expensive_co.Development.Register" %>
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

    <!-- Register Form -->
    <div class="container py-5">
        <div class="row py-5">
            <form class="col-md-9 m-auto" method="post" role="form" runat="server">

                <div class="row">
                    <div class="form-group col-md-6 mb-3">
                        <label for="inputname">First Name</label>
                        
                        <asp:TextBox ID="FirstName" runat="server" class="form-control mt-1" name="First" placeholder="First Name"></asp:TextBox>       
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="inputemail">Last Name</label>
                        
                        <asp:TextBox ID="LastName" runat="server" class="form-control mt-1" name="Last" placeholder="Last Name"></asp:TextBox>
                    </div>
                </div>
                
                <div class="mb-3">
                    <label for="inputsubject">Email</label>
                    
                    <asp:TextBox ID="Email" runat="server" placeholder="Email" TextMode="Email" class="form-control mt-1"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Phone Number</label>
                    
                    <asp:TextBox ID="Phone" runat="server" name="Phone" placeholder="Phone Number" TextMode="Phone" class="form-control mt-1"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Date of Birth</label>
                   
                    <asp:TextBox ID="DOB" runat="server" name="DOB" placeholder="Select Date" TextMode="Date" class="form-control mt-1"></asp:TextBox>
                </div>

                 <div class="mb-3">
                    <label for="inputsubject">Address</label>
                    <asp:TextBox ID="Address" runat="server" name="Address" placeholder="Address" TextMode="MultiLine" class="form-control mt-1"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Password</label>
                    
                    <asp:TextBox ID="Password" runat="server" name="Password" placeholder="Insert Your Password" TextMode="Password" class="form-control mt-1" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters"></asp:TextBox>
                    <i class="fa fa-info-circle" data-toggle="tooltip" data-placement="right" title="At least 1 Upper and 1 Lower case, 1 Number, and 1 Special Character">Password Requirements</i>

                </div>

                <div class="mb-3">
                    <label for="inputsubject">Confirm Password</label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" name="Password" placeholder="Confirm Password" TextMode="Password" class="form-control mt-1"></asp:TextBox>
                </div>

                <div class="row">
                    <%--this is the invalid warning--%>
                    <div class="col mt-2 ">
                        <asp:Panel ID="InvalidPanel" visible="false" class="alert alert-danger" runat="server">
                            <asp:Label ID="InvalidError" class="" runat="server" Text="asd"></asp:Label>
                        </asp:Panel>
                        
                    </div>
                    <div class="col text-end mt-2">
                        <asp:Button ID="RegisterBtn" class="btn btn-success btn-lg px-3" runat="server" Text="Create an Account" OnClick="RegisterBtn_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-- Register Form -->

</asp:Content>