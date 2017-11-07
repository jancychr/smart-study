<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="AddSurveyQuestion.aspx.cs" Inherits="Admin_AddSurveyQuestion" Title="Add Survey Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0">
        <tr>
            <td>
                <asp:Label ID="lblQue" runat="server" Text="Question Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpType_SelectedIndexChanged">
                    <asp:ListItem Value="-999999">Select Type</asp:ListItem>
                    <asp:ListItem Value="1">True/False</asp:ListItem>
                    <asp:ListItem Value="2">M.C.Q</asp:ListItem>
                    <asp:ListItem Value="3">TextRich</asp:ListItem>
                    <asp:ListItem Value="4">Radio Button</asp:ListItem>
                    <asp:ListItem Value="5">Polling</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="pnlSurveyQuestion" runat="server" Visible="False">
                    <table>
                        <tr>
                            <td>
                                Select Exam :
                            </td>
                            <td>
                                <asp:DropDownList ID="drpCourse" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Value="-999999">Select Exam</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Question :
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Options :
                            </td>
                            <td>
                                <asp:TextBox ID="txtOptions" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Add Question" OnClick="btnSubmit_Click">
                                </asp:Button>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
