<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 align="center" class="h1">
        <b>Get your Password Here!</b></h1>
    <br />
    <table align="center" cellspacing="2">
        <tr>
            <td align="justify" width="45px">
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
            <td colspan="2">
            </td>
            <td>
                <br />
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                    CssClass="btn-green btn-lg" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblNote" runat="server" Style="margin-top: 5px;"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
