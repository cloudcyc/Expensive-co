<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Development/LayoutAdmin.Master" CodeBehind="AdminViewFeedback.aspx.cs" Inherits="Expensive_co.Development.AdminViewFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Feedback</h4> 
                                                
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
                                            <th class="border-top-0">Feedback ID</th>
                                            <th class="border-top-0">Feedback</th>
                                            <th class="border-top-0">Date</th>
                                            <th class="border-top-0">Respondent's Name</th>
                                            <th class="border-top-0">Respondent's Email</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

         </div>

</asp:Content>
