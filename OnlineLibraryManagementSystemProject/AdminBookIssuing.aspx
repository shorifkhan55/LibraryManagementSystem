<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuing.aspx.cs" Inherits="OnlineLibraryManagementSystemProject.AdminBookingIssuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Book Issuing</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Image/feature3.jpg" width="70" />
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
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                        <asp:TextBox ID="memberIdTextBox" runat="server" placeholder="Member Id" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="bookIdTextBox" runat="server" placeholder="Book Id" CssClass="form-control"></asp:TextBox>
                                        <asp:Button ID="goButton" runat="server" CssClass="btn btn-primary" Text="Go" OnClick="goButton_Click" />
                                    </div>
                                        </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="memberNameTextBox" ReadOnly="True" runat="server" placeholder="Member Name" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="bookNameTextBox" ReadOnly="True" runat="server" placeholder="Book Name" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="startDateTextBox" TextMode="Date" runat="server" placeholder="Start Date" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="returnDateTextBox" TextMode="Date" runat="server" placeholder="End Date" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button ID="IssueButton" runat="server" Text="Issue" CssClass="btn btn-primary btn-block btn-lg " OnClick="IssueButton_Click" />
                            </div>
                            <div class="col-md-6">
                                <asp:Button ID="ReturnButton" runat="server" Text="Return" CssClass="btn btn-success btn-block btn-lg" OnClick="ReturnButton_Click" />
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
                                    <h3>Issued Book List</h3>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [BookIssuedView]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="MemberId" HeaderText="Member Id" SortExpression="MemberId" />
                                        <asp:BoundField DataField="full_name" HeaderText="Member Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="BookId" HeaderText="Book ID" SortExpression="BookId" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" />
                                        <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" SortExpression="ReturnDate" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
