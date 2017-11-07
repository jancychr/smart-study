<%@ Page Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Test.aspx.cs"
    Inherits="Test" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .btn-lg
        {
            padding: 3px 8px !important;
            font-size: 13px !important;
            margin: 0px !important;
        }
        .test
        {
            border: 1px solid #999;
            max-width: 650px;
            width: 100%;
            font-family: arial,helvetica,sans-serif;
            color: #444;
            position: relative;
            min-height: 200px;
            box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            -moz-box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            -webkit-box-shadow: -2px 2px 5px 2px rgba(0,0,0,0.2);
            background-color: white;
            padding: 20px;
        }
        input[type=radio]
        {
            margin: 10px 10px 10px 0px !important;
        }
        .totalquestion
        {
            margin-top: -10px;
            margin-bottom: 10px;
            font-size: 14px;
        }
    </style>
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.templates/beta1/jquery.tmpl.min.js"></script>
    <script id="sectiontmpl" type="text/html">
    <div id="${QuestionID}">
        <table width='100%'>
            <tr>
                <td align='right'>
                    <div class='totalquestion'>
                    </div>
                </td>
            </tr>
            <tr>
                <td align='left' style='font-size:18px'>
                    {{html Question}}
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                      {{if Opt.length}}
                        <ol style='margin:0px;padding:2px;'>
                            {{each(i,optiontext) Opt}}
                                <li style='list-style-type:none;border-bottom: 1px solid #ccc;'>                                                
                                    <input type="radio" value="${OptionID}_${Answer}" id='rdbOption${OptionID}' name="${QuestionID}"/>${Options}
                                </li> 
                            {{/each}}
                        </ol>
                    {{/if}}                                                            
                </td>
            </tr>
            <tr>
                <td align='center'>
                    <br/>
                    <input class="btn-green btn-lg" type="button" id="btnNext" value="Save & Continue" onclick="next(${QuestionID})" />
                </td>
            </tr>        
        </table>  
    </div>        
    </script>
    <script language="javascript" type="text/javascript">
        var nextIndex = 0;
        var TotalQuestions = 0;
        var CategoryID = "<%= CategoryID%>";
        var UserId = "<%= UserId%>";
        var que = 0;

        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "Test.asmx/GetTest",
                data: "{CategoryID: " + CategoryID + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var questions = response.d;
                    TotalQuestions = questions[0].TotalQuestion;
                    $("#sectiontmpl").tmpl(questions).appendTo("#divTest");
                    LoadDiv(0);
                }
            });
        });

        function LoadDiv(iIndex) {
            var allDiv = $("#divTest>div");
            $(allDiv).attr("style", "display:none");
            var currentDiv = $(allDiv).eq(iIndex).attr("style", "display:block");

            nextIndex = iIndex + 1;

            $('.totalquestion').html(nextIndex + ' of ' + TotalQuestions);
        }

        function next(QuestionID) {

            var Data = $('input[name="' + QuestionID + '"]:checked').val();
            var arr = Data.split('_');
            var OptionID = arr[0];
            var Point = arr[1];

            if (Point == 'True') {
                Point = 100;
            } else {
                Point = 0;
            }

            que = que + 1;

            saveUserData(QuestionID, OptionID, Point);
            LoadDiv(nextIndex);

            if (TotalQuestions == que + 1) {
                $('#btnNext').val(' Finish ');
            }
        }

        function saveUserData(QuestionID, OptionID, Point) {
            $.ajax({
                type: "POST",
                url: "Test.asmx/SaveTest",
                data: "{UserID: " + UserId + ", QuestionID: " + QuestionID + ", OptionID: " + OptionID + ", Point: " + Point + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var questions = response.d;

                    if (que == TotalQuestions) {
                        window.location.href = 'DispalyAccu.aspx?CId=' + CategoryID + '';
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="divTest" class="test">
    </div>
</asp:Content>
