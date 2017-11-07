<%@ Page Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Studyhours.aspx.cs"
    Inherits="Studyhours" Title="Study Hours" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" cellspacing="2">
        <tr>
            <td align="justify" width="140px">
                Exam Date
            </td>
            <td width="25px">
                :
            </td>
            <td align="left">
                <asp:TextBox ID="txtExamDate" runat="server" CssClass="sign-up sign-up-inner" ForeColor="Black"
                    align="center" Width="240px">
                </asp:TextBox>
                <asp:CalendarExtender ID="ceDate" TargetControlID="txtExamDate" runat="server" Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </td>
        </tr>
        <asp:Label ID="lblCalendarError" runat="server"></asp:Label>
        <tr>
            <td align="justify">
                Weekly Study Days
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:DropDownList ID="drpStudyDays" runat="server" ForeColor="Black" align="center"
                    Width="240px">
                    <asp:ListItem Value="-999999">Select Weekly Study Days</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Select Days
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:CheckBoxList ID="chkDays" runat="server">
                    <asp:ListItem Value="Monday">Monday</asp:ListItem>
                    <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                    <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                    <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                    <asp:ListItem Value="Friday">Friday</asp:ListItem>
                    <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                    <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td align="justify">
                Daily Study Hours
            </td>
            <td>
                :
            </td>
            <td align="left">
                <asp:DropDownList ID="drpStudyHours" runat="server" ForeColor="Black" align="center"
                    Width="240px">
                    <asp:ListItem Value="-999999"> Select per Day Study Hours</asp:ListItem>
                    <asp:ListItem Value="1"> 1 hours</asp:ListItem>
                    <asp:ListItem Value="2"> 2 hours</asp:ListItem>
                    <asp:ListItem Value="3"> 3 hours</asp:ListItem>
                    <asp:ListItem Value="4"> 4 hours</asp:ListItem>
                    <asp:ListItem Value="5"> 5 hours</asp:ListItem>
                    <asp:ListItem Value="6"> 6 hours</asp:ListItem>
                    <asp:ListItem Value="7"> 7 hours</asp:ListItem>
                    <asp:ListItem Value="8"> 8 hours</asp:ListItem>
                    <asp:ListItem Value="9"> 9 hours</asp:ListItem>
                    <asp:ListItem Value="10"> 10 hours</asp:ListItem>
                    <asp:ListItem Value="11"> 11 hours</asp:ListItem>
                    <asp:ListItem Value="12"> 12 hours</asp:ListItem>
                    <asp:ListItem Value="13"> 13 hours</asp:ListItem>
                    <asp:ListItem Value="14"> 14 hours</asp:ListItem>
                    <asp:ListItem Value="15"> 15 hours</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
            <td>
                <br />
                <asp:Button ID="btnNext" runat="server" Text="Save & Start Test" CssClass="btn-green btn-lg"
                    OnClick="btnNext_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblNote" runat="server" ForeColor="Red" Style="margin-top: 5px;"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
