<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="EasyShop.Pages.Account.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h4>Log In</h4><hr />
    <asp:Literal runat="server" ID="litErrorMsg" Text="Invalid username or password." Visible="false" />
    <asp:Label runat="server" AssociatedControlID="txtUserName">User name</asp:Label>
    <br />
    <asp:TextBox runat="server" ID="txtUserName" CssClass="inputs" />
    <br />
    <asp:Label runat="server" AssociatedControlID="txtPassword">Password</asp:Label>
    <br />
    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="inputs" />
    <br />
    <asp:Button ID="btnSignIn" runat="server" Text="Sign in" OnClick="btnSignIn_OnClick" CssClass="button"/>
</asp:Content>
