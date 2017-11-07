<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true"
    CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        td
        {
            text-align: left;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinkButton ID="lnkbtnChangePassword" runat="server" Text="Change Password" PostBackUrl="~/ChangePassword.aspx"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkbtnEdit" runat="server"
        Text="Edit Profile" PostBackUrl="~/EditProfile.aspx"></asp:LinkButton>
    <table>
        <tr>
            <td colspan="3">
                <div align="center" style="margin-bottom: 15px;">
                    <asp:Image ID="imgProfile" runat="server" Width="150px" Height="170px" />
                </div>
            </td>
        </tr>
        <tr>
            <th width="145px">
                First Name
            </th>
            <td width="10px">
                :
            </td>
            <td>
                <asp:Label ID="lblFirstName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Last Name
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lbLastName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Gender
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lblGender" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Birth Date
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Email
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                Contact Number
            </th>
            <td>
                :
            </td>
            <td>
                <asp:Label ID="lblContactNumber" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
