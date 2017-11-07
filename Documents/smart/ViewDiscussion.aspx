<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true"
    CodeFile="ViewDiscussion.aspx.cs" Inherits="ViewDiscussion" %>

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
            background: lightyellow;
            padding: 10px;
        }
        .comment
        {
            margin-left: 200px;
            border: 1px solid #999;
            max-width: 650px;
            color: #444;
            min-height: 63px;
            margin-bottom: 6px;
            box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            -moz-box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            -webkit-box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            background: white;
            padding: 5px;
        }
        .comment:hover
        {
            background: lightyellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DataList ID="dlDiscussion" runat="server" Width="100%">
        <ItemTemplate>
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
        </ItemTemplate>
    </asp:DataList>
    <div class="clearfix">
        &nbsp;</div>
    <asp:DataList ID="dlDisucssionComment" runat="server" Width="100%">
        <ItemTemplate>
            <div class="comment">
                <div style="float: left; width: 50px;">
                    <asp:Image ID="imgUser" runat="server" Width="40px" Height="50px" ImageUrl='<%# String.Format("~/Images/UserPhoto/{0}", Eval("ProfilePhoto")) %>' />
                </div>
                <div style="display: block; text-align: left; margin-left: 10px;">
                    <div style="color: Gray; font-size: 12px; margin-top: -5px;">
                        <asp:Label ID="lblUserName" runat="server" Width="150px" Text='<%# Eval("Name") %>'></asp:Label>
                        <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                    </div>
                    <asp:Label ID="lblComment" runat="server" Font-Size="14px" Text='<%# Eval("Comment") %>'></asp:Label>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtComment" runat="server" CssClass="input-short" ForeColor="Black"
                    Width="240px" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn-green btn-lg"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNote" runat="server" Style="margin-top: 5px;"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
