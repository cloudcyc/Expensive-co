<%@ Page Title="" Language="C#" MasterPageFile="~/Development/Layout.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Expensive_co.Development.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- Start Content Page -->
    <div class="container-fluid bg-light py-5">
        <div class="col-md-6 m-auto text-center">
            <h1 class="h1">Contact Us</h1>
            <p>
                Feel Free To Give Us A Feedback
            </p>
        </div>
    </div>

    <!-- Start Map -->
    <div class="mapouter"><div class="gmap_canvas"><iframe width="100%" height="400" id="gmap_canvas" src="https://maps.google.com/maps?q=3.1492146,%20101.7135288&t=&z=15&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe><a href="https://fmovies2.org">fmovies</a><br>
    <style>.mapouter{position:relative;text-align:right;height:400px;width:100%;}
    </style><a href="https://www.embedgooglemap.net">adding google maps to wordpress</a>
    <style>.gmap_canvas {overflow:hidden;background:none!important;height:400px;width:100%;}</style></div></div>
    <!-- Ena Map -->

    <!-- Start Contact -->
    <div class="container py-5">
        <div class="row py-5">
            <form class="col-md-9 m-auto" runat="server">
                <div class="row">
                    <div class="form-group col-md-6 mb-3">
                        <label for="inputname">Name</label>
                        <asp:TextBox ID="name" runat="server" class="form-control mt-1"></asp:TextBox>
                        
                    </div>
                    <div class="form-group col-md-6 mb-3">
                        <label for="inputemail">Email</label>
                        <asp:TextBox ID="email" runat="server" class="form-control mt-1" TextMode="Email"></asp:TextBox>
                        
                    </div>
                </div>
                <div class="mb-3">
                    <label for="inputsubject">Feedback</label>
                    <asp:TextBox ID="Feedback" runat="server" TextMode="MultiLine" style="resize:none;" class="form-control mt-1" Rows="5"></asp:TextBox>
                    
                </div>
                
                <div class="row">
                    <div class="col text-end mt-2">
                        <asp:Button ID="FeedbackBtn" runat="server" Text="Submit Feedback" class="btn btn-success btn-lg px-3" OnClick="FeedbackBtn_Click" />
                        
                    </div>
                </div>
            </form>
        </div>
    </div>
    <!-- End Contact -->




</asp:Content>