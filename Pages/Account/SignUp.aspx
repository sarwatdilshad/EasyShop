<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="EasyShop.Pages.Account.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h4>Register a new user</h4>
    <hr />
    <p>
        <asp:Literal runat="server" ID="litStatusMessage" />
    </p>

    User name:<br />
    <asp:TextBox runat="server" ID="txtUserName" CssClass="inputs" /><br />

    Password:
    <br />
    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="inputs" /><br />

    Confirm password:
    <br />
    <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="inputs" /><br />
    
    First Name:<br />
    <asp:TextBox runat="server" ID="txtFirstName" CssClass="inputs" /><br />
    
    Last Name:<br />
    <asp:TextBox runat="server" ID="txtLastName" CssClass="inputs" /><br />
    
    Address:<br />
    <asp:TextBox runat="server" ID="txtAddress" CssClass="inputs" /><br />
    
    Postal Code:<br />
    <asp:TextBox runat="server" ID="txtPostalCode" CssClass="inputs" MaxLength="5" /><br />
   
      Phone No:<br />
    <asp:TextBox runat="server" ID="txtPhone" CssClass="inputs" MaxLength="9" TextMode="Phone" /><br />

    
    Email:<br />
    <asp:TextBox runat="server" ID="txtEmail" CssClass="inputs" TextMode="Email" /><br />

    <p>
        <asp:Button ID="btnRegister" runat="server" Text="Sign Up" OnClick="btnRegister_Click" CssClass="button" Width="150px" />
    </p>
</asp:Content>
