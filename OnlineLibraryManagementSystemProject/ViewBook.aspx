<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBook.aspx.cs" Inherits="OnlineLibraryManagementSystemProject.ViewBook" %>
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
               <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                    
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Book Inventory List</h3>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [View_Book]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" >
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="book_id" >
                                       
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                       
                                        <asp:TemplateField>

                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" Font-Bold="True" Font-Size="X-Large" runat="server" Text='<%# Eval("book_name") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Author-
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("authorName") %>' Font-Bold="True" Font-Italic="True"></asp:Label>
                                                                    |Genre-
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    |Languag-
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="False" Text='<%# Eval("language") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Publisher-
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="False" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    |Publish Date-
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="False" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    |Pages-
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="False" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    |Edition-
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Price-
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    | Actual stock-
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    |Available-
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                                <div class="col-12">
                                                                    Description-
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("book_dscription") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image ID="Image1" Class="img-fluid" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                       
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
