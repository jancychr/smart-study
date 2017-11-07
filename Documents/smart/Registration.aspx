<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs"
    Inherits="Registration" Title="Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1 align="center" class="h1">
        <b>Register Here!</b></h1>
    <br />
    <table align="center" cellspacing="2">
        <tr>
            <td align="justify" width="130px">
                First Name
            </td>
            <td width="25px">
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="sign-up sign-up-inner" ForeColor="Black"
                    align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Last Name
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="sign-up sign-up-inner" ForeColor="Black"
                    align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Email
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="sign-up sign-up-inner" ForeColor="Black"
                    align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Password
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="sign-up sign-up-inner"
                    ForeColor="Black" align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Confirm Password
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="sign-up sign-up-inner"
                    ForeColor="Black" align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Contact No.
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtContact" runat="server" CssClass="sign-up sign-up-inner" ForeColor="Black"
                    MaxLength="10" align="center" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Select Course
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:DropDownList ID="drpCategory" runat="server" AppendDataBoundItems="true" Width="240px">
                    <asp:ListItem Value="-999999">Select Course</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td>
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Sign Up" CssClass="btn-green btn-lg"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblNote" runat="server" Style="margin-top: 5px;"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
