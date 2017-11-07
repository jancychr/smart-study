<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="algopage.aspx.cs" Inherits="Admin_algopage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                Enter Accuracy For Topic 1:
                <asp:TextBox ID="txtAc1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 2:
                <asp:TextBox ID="txtAc2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 3:
                <asp:TextBox ID="txtAc3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 4:
                <asp:TextBox ID="txtAc4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 5:
                <asp:TextBox ID="txtAc5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 6:
                <asp:TextBox ID="txtAc6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 7:
                <asp:TextBox ID="txtAc7" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 8:
                <asp:TextBox ID="txtAc8" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 9:
                <asp:TextBox ID="txtAc9" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Accuracy For Topic 10:
                <asp:TextBox ID="txtAc10" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter Total Hours:
                <asp:TextBox ID="txtTotalHours" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lbltopic1" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic2" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic3" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic4" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic5" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic6" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic7" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic8" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic9" runat="server"></asp:Label><br />
    <asp:Label ID="lbltopic10" runat="server"></asp:Label><br />
    <br />
    <asp:Label ID="lblTotalHoursByCal" runat="server"></asp:Label>
</asp:Content>
