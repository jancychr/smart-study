<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs"
    Inherits="Login" Title="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 align="center" class="h1">
        <b>Login Here!</b></h1>
    <br />
    <table align="center" cellspacing="2">
        <tr>
            <td align="justify" width="70px">
                Email
            </td>
            <td width="25px">
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="sign-up sign-up-inner" ForeColor="Black"
                    align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="sign-up sign-up-inner"
                    ForeColor="Black" align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td>
                <br />
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="btn-green btn-lg" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblNote" runat="server" Style="margin-top: 5px;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <br />
                <asp:HyperLink ID="hlForgotPassword" runat="server" Text="Forgot Password?" NavigateUrl="~/ForgotPassword.aspx"></asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
