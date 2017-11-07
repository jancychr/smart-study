<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="slider">
        <div class="flex-container">
            <div class="flexslider">
                <ul class="slides">
                    <li>
                        <img src="Images/slide-2.jpg" />
                        <div class="caption-wrap hidden-xs">
                            <div class="caption-content animated fadeInRight">
                                <h2 class="tagline">
                                    <b>learning today, leading tomorrow</b>
                                </h2>
                                <h3 class="subline">
                                    These activities work great with your
                                    <br />
                                    SMART brains or interactive whiteboard
                                </h3>
                            </div>
                        </div>
                    </li>
                    <li>
                        <img src="Images/slide-1.png" />
                        <div class="caption-wrap hidden-xs animated fadeIn">
                            <div class="caption-content animated fadeInRight">
                                <h2 class="tagline">
                                    <b>Your potential, our passion</b>
                                </h2>
                                <h3 class="subline">
                                    Choose from fun, educational, interactive games and simulations for
                                    <br />
                                    math, English language arts, science, general knowledge, brainteasers, and more!
                                </h3>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
   
</asp:Content>
