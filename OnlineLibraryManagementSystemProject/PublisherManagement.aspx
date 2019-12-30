<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PublisherManagement.aspx.cs" Inherits="OnlineLibraryManagementSystemProject.PublisherManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Publisher Details</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Image/login.png" width="110" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="publisherIdTextBox" runat="server" placeholder="ID" CssClass="form-control"></asp:TextBox>
                                        <asp:Button ID="goButton" runat="server" CssClass="btn btn-primary" Text="Go" OnClick="goButton_OnClick"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="publisherNameTextBox" runat="server" placeholder="Publisher Name" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button ID="AddButton" runat="server" Text="Add" CssClass="btn btn-success btn-block btn-lg " OnClick="AddButton_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="UpdateButton" runat="server" Text="Update" CssClass="btn btn-info btn-block btn-lg" OnClick="UpdateButton_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="btn btn-danger btn-block btn-lg" OnClick="DeleteButton_Click" />

                            </div>

                        </div>
                    </div>
                </div>
                <a href="Home.aspx"><< Back to Home</a><br />
                <br />
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Publisher List</h3>
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                         <div class="col">
                                <center>
                                    <hr/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="publisherGridView" class="table table-striped table-bordered" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
