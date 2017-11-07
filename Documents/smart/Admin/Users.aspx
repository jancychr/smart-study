<%@ Page Title="Users" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblNote" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label><br />
    <br />
    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" GridLines="None"
        CssClass="mGrid" AlternatingRowStyle-CssClass="alt" DataKeyNames="UserId">
        <Columns>
            <asp:TemplateField HeaderText="User ID" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="150px">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName").ToString() + " " + Eval("LastName").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="180px">
                <ItemTemplate>
                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contact Number" HeaderStyle-Width="140px">
                <ItemTemplate>
                    <asp:Label ID="lblContactNumber" runat="server" Text='<%# Eval("ContactNumber").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active User" HeaderStyle-Width="100px">
                <ItemTemplate>
                    <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active").ToString() %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No Data Found...
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
