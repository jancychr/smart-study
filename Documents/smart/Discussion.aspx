<%@ Page Title="Discussion" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true"
    CodeFile="Discussion.aspx.cs" Inherits="Discussion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .discussion
        {
            border: 1px solid #999;
            max-width: 850px;
            color: #444;
            min-height: 113px;
            margin-bottom: 10px;
            box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            -moz-box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            -webkit-box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            background-color: white;
            padding: 10px;
        }
        .discussion:hover
        {
            background: lightyellow;
        }
        .dis:hover
        {
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HyperLink ID="hlCreateDiscussion" runat="server" Text="Create Discussion" NavigateUrl="~/CreateDiscussion.aspx"></asp:HyperLink>
    <br />
    <br />
    <asp:DataList ID="dlDiscussion" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkbtnViewDiscussion" runat="server" CssClass="dis" PostBackUrl='<%# String.Format("ViewDiscussion.aspx?did={0}", Eval("DiscussionId")) %>'>
                <div class="discussion">
                    <div style="float: left; width: 100px;">
                        <asp:Image ID="imgUser" runat="server" Width="80px" Height="90px" ImageUrl='<%# String.Format("~/Images/UserPhoto/{0}", Eval("ProfilePhoto")) %>' />
                    </div>
                    <div style="display: block; text-align: left; margin-left: 10px;">
                        <div style="color: Gray; font-size: 12px; margin-top: -5px;">
                            <asp:Label ID="lblUserName" runat="server" Width="150px" Text='<%# Eval("Name") %>'></asp:Label>
                            <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                        </div>
                        <div style="font-weight: bold; font-size: 14px;">
                            <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        </div>
                        <asp:Label ID="lblDiscussion" runat="server" Font-Size="14px" Text='<%# Eval("Discussion") %>'></asp:Label>
                    </div>
                </div>
            </asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>