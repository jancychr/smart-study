<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true"
    CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Welcome to Smart Study!</h1>
    <br />
    <asp:Label ID="lblNote1" runat="server"></asp:Label>
    <asp:LinkButton ID="lnkbtnNote" runat="server" Text="Click Here"></asp:LinkButton>
    <asp:LinkButton ID="lnkbtnTest" runat="server" Text="Click Here" OnClick="lnkbtnTest_Click"></asp:LinkButton><br />
    <br />
    <asp:Chart ID="chtUserAccuracy" runat="server" Width="800" BackColor="211, 223, 240"
        ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" borderlinestyle="Solid" backgradientendcolor="White"
        backgradienttype="TopBottom" BorderlineWidth="2" BorderlineColor="26, 59, 105">
        <Series>
            <asp:Series Name="chtMASeries1" ChartType="Bar" XValueType="Double" BorderWidth="1"
                BorderColor="180, 26, 59, 105">
            </asp:Series>
        </Series>
        <Titles>
            <asp:Title Text="User Accuracy Chart" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="1"
                Alignment="TopLeft" ForeColor="26, 59, 105">
            </asp:Title>
        </Titles>
        <Legends>
            <asp:Legend Enabled="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
                <Position Y="21" Height="22" Width="18" X="73"></Position>
            </asp:Legend>
        </Legends>
        <BorderSkin SkinStyle="Emboss"></BorderSkin>
        <ChartAreas>
            <asp:ChartArea Name="chtMAChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                BackGradientStyle="TopBottom">
                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Title="Accuracy">
                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                </AxisY>
                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Title="Topic">
                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
    <asp:Chart ID="ChtUserTiming" runat="server" Width="800" BackColor="211, 223, 240"
        ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" borderlinestyle="Solid" backgradientendcolor="White"
        backgradienttype="TopBottom" BorderlineWidth="2" BorderlineColor="26, 59, 105">
        <Series>
            <asp:Series Name="chtMASeries1" ChartType="Bar" XValueType="Double" BorderWidth="1"
                BorderColor="180, 26, 59, 105">
            </asp:Series>
        </Series>
        <Titles>
            <asp:Title Text="User Timing  Chart" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="1"
                Alignment="TopLeft" ForeColor="26, 59, 105">
            </asp:Title>
        </Titles>
        <Legends>
            <asp:Legend Enabled="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
                <Position Y="21" Height="22" Width="18" X="73"></Position>
            </asp:Legend>
        </Legends>
        <BorderSkin SkinStyle="Emboss"></BorderSkin>
        <ChartAreas>
            <asp:ChartArea Name="chtMAChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                BackGradientStyle="TopBottom">
                <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Title="Time">
                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                </AxisY>
                <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Title="Topic">
                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                    <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>
