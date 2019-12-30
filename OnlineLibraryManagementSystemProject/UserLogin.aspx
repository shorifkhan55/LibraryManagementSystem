<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="OnlineLibraryManagementSystemProject.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            // Initialize form validation on the registration form.
            // It has the name attribute "registration"
            $("#form1").validate({
                // Specify validation rules
                rules: {
                    // The key name on the left side is the name attribute
                    // of an input field. Validation rules are defined
                    // on the right side
                    emailTextBox: "required",
                    PasswordTextBox: "required"

                },
                // Specify validation error messages
                messages: {
                    emailTextBox: "Please Enter Your Email",
                    PasswordTextBox: "Please Enter Password"

                },

                // Make sure the form is submitted to the destination defined

                submitHandler: function (form) {
                    form.submit();
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Image/login.png" width="150" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="emailTextBox" name="emailTextBox" TextMode="Email" runat="server" placeholder="Email ID" CssClass="form-control"></asp:TextBox>
                                </div>
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox ID="PasswordTextBox" name="PasswordTextBox" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn btn-success btn-lg btn-block" OnClientClick="return validate();" OnClick="LoginButton_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="MemberSignUp.aspx">
                                        <input runat="server" value="Sign Up" class="btn btn-info btn-lg btn-block" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="Home.aspx"><< Back to Home</a><br />
                <br />
            </div>

        </div>
    </div>
</asp:Content>
