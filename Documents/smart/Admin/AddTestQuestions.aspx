<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="AddTestQuestions.aspx.cs" Inherits="Admin_AddTestQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                Select Category:
            </td>
            <td>
                <asp:DropDownList ID="drpCategory" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                    OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
                    <asp:ListItem Value="-999999">Select Category</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Select Subject:
            </td>
            <td>
                <asp:DropDownList ID="drpSubject" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                    OnSelectedIndexChanged="drpSubject_SelectedIndexChanged">
                    <asp:ListItem Value="-999999">Select Subject</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Select Topic:
            </td>
            <td>
                <asp:DropDownList ID="drpTopic" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value="-999999">Select Topic</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Add Questions:
                <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Add Options:
            </td>
            <td>
                <asp:TextBox ID="txtOpt1" runat="server">
                </asp:TextBox>
                <asp:RadioButton ID="rbOpt1" runat="server" GroupName="Options" />
            </td>
            <td>
                <asp:TextBox ID="txtOpt2" runat="server">
                </asp:TextBox>
                <asp:RadioButton ID="rbOpt2" runat="server" GroupName="Options" />
            </td>
            <td>
                <asp:TextBox ID="txtOpt3" runat="server">
                </asp:TextBox>
                <asp:RadioButton ID="rbOpt3" runat="server" GroupName="Options"/>
            </td>
            <td>
                <asp:TextBox ID="txtOpt4" runat="server">
                </asp:TextBox>
                <asp:RadioButton ID="rbOpt4" runat="server" GroupName="Options" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
