<%@ Page Title="Questions" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Questions.aspx.cs" Inherits="Admin_Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" GridLines="None"
        OnRowCommand="gvQuestions_RowCommand" OnRowEditing="gvQuestions_RowEditing" OnRowDeleting="gvQuestions_RowDeleting"
        CssClass="mGrid" AlternatingRowStyle-CssClass="alt" DataKeyNames="QuestionId">
        <Columns>
            <asp:TemplateField HeaderText="Question ID" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblQuestionId" runat="server" Text='<%# Eval("QuestionId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Question" HeaderStyle-Width="300px">
                <ItemTemplate>
                    <asp:Label ID="lblQuestion" runat="server" Text='<%# Eval("Question") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Option" HeaderStyle-Width="300px">
                <ItemTemplate>
                    <asp:Label ID="lblOption" runat="server" Text='<%# Eval("QOption") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Manage" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="hlEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("QuestionId") %>'
                        CommandName="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No Data Found...
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
