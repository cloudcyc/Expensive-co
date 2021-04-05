<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Expensive_co.Development.Login" %>
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
            <form id="form1" class="col-md-9 m-auto" runat="server">
                
                <div class="mb-3">
                   <label for="inputsubject">Username</label>
                   <%--<input type="Email" class="form-control mt-1" id="Email" name="Email" placeholder="Email" runat="server">--%>
                    <asp:TextBox class="form-control mt-1" ID="Email" runat="server" TextMode="Email"></asp:TextBox> 
                </div>

                <div class="mb-3">
                    <label for="inputsubject">Password</label>
                    <%--<input type="password" class="form-control mt-1" id="Password" name="Password" placeholder="Password">--%>
                    <asp:TextBox class="form-control mt-1" ID="Password" runat="server" TextMode="Password"></asp:TextBox> 
                </div>
                
                <div class="row">
                    <div class="col text-end mt-2">
                        <%--<button type="submit" class="btn btn-success btn-lg px-3" onclick="">Login</button>--%>
                        <asp:Button ID="LoginBtn" class="btn btn-success btn-lg px-3" runat="server" Text="Login" OnClick="LoginBtn_Click" />
                    </div>    
                </div>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                
            </form>
        </div>
    </div>
    <!-- Login Form -->

</asp:Content>