<%@ Page Title="Create Discussion" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true"
    CodeFile="CreateDiscussion.aspx.cs" Inherits="CreateDiscussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td align="justify" width="70px">
                Title
            </td>
            <td width="25px">
                :
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input-short" ForeColor="Black"
                    Width="240px" align="left"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Discussion
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox ID="txtDiscussion" runat="server" CssClass="input-short" ForeColor="Black"
                    Width="240px" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td>
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-green btn-lg"
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
