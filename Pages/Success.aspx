<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="EasyShop.Pages.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h4>Thanks for your Order</h4><hr />
      <asp:Panel ID="pnlShoppingCart" runat="server">
    </asp:Panel>
        <table>
            <tr>
                <td>
                    <b>Total: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal>
                </td>
            </tr>

            <tr>
                <td>
                    <b>Tax: </b>
                </td>
                <td>
                    <asp:Literal ID="litVat" runat="server" Text="" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Shipping: </b>
                </td>
                <td>
                   Rs 150
                </td>
            </tr>

            <tr>
                <td>
                    <b>Total Amount: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotalAmount" runat="server" Text="" />
                </td>
            </tr>

            <tr>
                <td>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Index.aspx">Continue Shopping</asp:LinkButton> &nbsp;&nbsp;                  
            

                    <br />
                </td>
            </tr>

        </table>
</asp:Content>
