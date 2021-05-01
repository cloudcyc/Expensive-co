<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Development/LayoutAdmin.Master" CodeBehind="AdminEditUser.aspx.cs" Inherits="Expensive_co.Development.AdminEditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-wrapper">
            <div class="page-breadcrumb bg-white">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
                        <h4 class="page-title">Admin Edit User Account</h4> 
                                                
                    </div> 
                </div>
            </div>

        <div class="container py-5">
                     <div class="row py-5">
                        <form id="form1" class="col-md-9 m-auto" runat="server">
                        <div class="row">
                                <div class="form-group col-md-6 mb-3">
                                    <label for="inputname">Full Name</label>
                                    <asp:TextBox ID="FullName" runat="server" class="form-control mt-1" name="First" placeholder="Full Name"></asp:TextBox>       
                            </div>
                            <div class="form-group col-md-6 mb-3">
                                <label for="inputsubject">Email</label>
                    
                                <asp:TextBox ID="Email" runat="server" placeholder="Email" TextMode="Email" class="form-control mt-1"></asp:TextBox>
                            </div>
                        </div>
                
                        
                        <div class="row">
                            <div class="form-group col-md-6 mb-3">
                                <label for="inputsubject">Phone Number</label>
                    
                                <asp:TextBox ID="Phone" runat="server" name="Phone" placeholder="Phone Number" TextMode="Phone" class="form-control mt-1"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-6 mb-3">
                                <label for="inputsubject">Date of Birth</label>
                   
                                <asp:TextBox ID="DOB" runat="server" name="DOB" placeholder="Select Date" TextMode="Date" class="form-control mt-1"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group mb-3">
                            <label for="inputsubject">Role</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control mt-0">
                                <asp:ListItem Selected="True">Select Role</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                                <asp:ListItem>Member</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                         <div class="mb-3">
                            <label for="inputsubject">Address</label>
                            <asp:TextBox ID="Address" runat="server" name="Address" placeholder="Address" TextMode="MultiLine" class="form-control mt-1"></asp:TextBox>
                        </div>

                        <div class="row">
                            <%--this is the invalid warning--%>
                            <div class="col mt-2 ">
                                <asp:Panel ID="InvalidPanel" visible="false" class="alert alert-danger" runat="server">
                                    <asp:Label ID="InvalidError" class="" runat="server" Text="asd"></asp:Label>
                                </asp:Panel>
                        
                            </div>
                            <div class="col text-end mt-2">
                                <asp:Button ID="UpdateUserProfileBtn" class="btn btn-success btn-lg px-3" runat="server" Text="Update User Profile" OnClick="UpdateUserProfileBtn_Click" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
</asp:Content>