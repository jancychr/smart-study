<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="AddSubject.aspx.cs" Inherits="Admin_AddSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                Select Category:
            </td>
            <td>
                <asp:DropDownList ID="drpCategory" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value="-999999">Select Category</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Enter Subject:
            </td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server"> </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
