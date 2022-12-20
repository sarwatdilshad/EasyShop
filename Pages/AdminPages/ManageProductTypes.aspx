 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageProductTypes.aspx.cs" Inherits="EasyShop.Pages.AdminPages.ManageProductTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table ID="Table1" >
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server" Text="Product Type"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
          <tr>
            <td>
               
            </td>
            <td>
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
