<%@ Page Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="DisplayTimeTable.aspx.cs"
    Inherits="DisplayTimeTable" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/jquery-ui.min.css" type="text/css" rel="Stylesheet" />
    <link href="Styles/fullcalendar.css" type="text/css" rel="Stylesheet" />
    <link href="Styles/fullcalendar.print.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui.custom.min.js"></script>
    <script type="text/javascript" src="Scripts/fullcalendar.min.js"></script>
    <script type="text/javascript">
        var UserId = "<%= UserId%>";
        var CatId = "<%= CatId%>";

        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "Test.asmx/GetTimeTableData",
                data: "{UserId: " + UserId + ", CatId: " + CatId + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $('#calendar').fullCalendar({
                        theme: true,
                        header: {
                            left: 'prev,next today',
                            center: 'title',
                            right: 'month,agendaWeek,agendaDay'
                        },
                        editable: false,
                        events: $.map(response.d, function (item, i) {
                            var event = new Object();
                            event.start = new Date(item.StudyDate);
                            event.title = item.Topic + ' - ' + item.Time + ' hour';
                            return event;
                        })
                    });
                }
            });
        });

    </script>
    <style>
        body
        {
            margin-top: 40px;
            text-align: center;
            font-size: 13px;
            font-family: "Lucida Grande" ,Helvetica,Arial,Verdana,sans-serif;
        }
        #calendar
        {
            width: 900px;
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id='calendar'>
    </div>
</asp:Content>
