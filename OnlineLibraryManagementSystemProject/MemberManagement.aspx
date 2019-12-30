<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="OnlineLibraryManagementSystemProject.MemberManagement" %>
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
                                    <h3>Member Details</h3>
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
                            <div class="col-md-3  col-sm-3 ">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="memberIdTextBox" runat="server" placeholder="Member Id" CssClass="form-control"></asp:TextBox>
                                        <asp:LinkButton ID="searchLinkButton" CssClass="btn btn-primary mr-1" runat="server" OnClick="searchLinkButton_OnClick"><i class="fas fa-check-circle"></i></asp:LinkButton>

                                        </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                   
                                    <asp:TextBox ID="fullNameTextBox" runat="server" ReadOnly="True" placeholder="Full Name" CssClass="form-control"></asp:TextBox>
                                     </div>
                                       
                            </div>
                            <div class="col-md-5 col-sm-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="accountStatusTextBox" runat="server" ReadOnly="True" placeholder="Account Status" CssClass="form-control"></asp:TextBox>
                                        <asp:LinkButton ID="ActiveLinkButton" CssClass="btn btn-primary " runat="server" OnClick="ActiveLinkButton_OnClick"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="PandingLinkButton" CssClass="btn btn-warning " runat="server" OnClick="PandingLinkButton_OnClick"><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="DeactiveLinkButton" CssClass="btn btn-danger " runat="server" OnClick="DeactiveLinkButton_OnClick"><i class="fas fa-times-circle"></i></asp:LinkButton>

                                        </div>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox ID="DOBTextBox" ReadOnly="True" runat="server" placeholder="Date of Birth" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox ID="contactNoTextBox" ReadOnly="True" runat="server" placeholder="Contact Number" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="emailTextBox" ReadOnly="True" runat="server" placeholder="Email ID" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>District</label>
                                <div class="form-group">
                                    <asp:TextBox ID="stateTextBox" ReadOnly="True" runat="server" placeholder="District" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Thana</label>
                                <div class="form-group">
                                    <asp:TextBox ID="cityTextBox" ReadOnly="True" runat="server" placeholder="Thana" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Postal Code</label>
                                <div class="form-group">
                                    <asp:TextBox ID="pinCodeTextBox" ReadOnly="True" runat="server" placeholder="Postal Code" CssClass="form-control"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                        <div class="row">
                          <div class="col-md-12">
                              <label>Full Postal Address</label>
                              <div class="form-group">
                                  <asp:TextBox ID="fullAddressTextBox" TextMode="MultiLine" ReadOnly="True" runat="server" placeholder="Full Postal Address" CssClass="form-control"></asp:TextBox>
                                       
                              </div>
                          </div>

                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="btn btn-danger btn-block btn-lg " OnClick="DeleteButton_Click" />
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
                                    <h3>Member List</h3>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="table table-bordered table-striped" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Full Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                                        <asp:BoundField DataField="state" HeaderText="District" SortExpression="state" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
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
