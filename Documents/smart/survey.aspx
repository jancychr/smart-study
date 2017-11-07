<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="survey.aspx.cs"
    Inherits="survey" Title="Survey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script id="survey" type="text/html">
        <div id="${QId}">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="result" class="">
            <tr>
                <td width="100%">
                    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" class="question typeD">
                        <tr id="q" class="questionContent">
                            <td id="quetext" align="left" valign="top" width="100%" class="sentence"> 
                                {{html QuestionText}}                                           
                             </td> 
                        </tr>                 
                        <tr>
                            <td id="optionChoice" align="left" valign="top" width="100%" class="choices">
                                {{if Options.length}}
                                    <ol style='margin:0px; padding:0px;'>
                                        {{each(i,optiontext) Options}}
                                            <li style='list-style-type:none;'>
                                                <a id='${QOptionsId}' name="${IsAnswered}" href="javascript:void(0);" onclick="javascript:submitResponse(${IsAnswered},${QOptionsId},${QId})" class="choice">{{html OptionText}} </a> 
                                            </li> 
                                        {{/each}}
                                    </ol>
                                {{/if}}
                            </td>
                        </tr>
                        <tr height="30px" valign="bottom">
                            <td>
                                <input class="nextQuestion" type="button" id="btnQueNext" value="NEXT QUESTION" onclick="javascript:nextquestion()" />
                            </td>
                        </tr>
                    </table>                  
                </td>
            </tr>
            </table>
        </div>
    </script>

    <script type="text/javascript">
    $(document).ready(function() {
        $("#<%=btnStartSurvey.ClientID %>").click(function() {
            
            var Exam = document.getElementById('<%=drpCourse.ClientID %>').value;
            var Name = document.getElementById('<%=txtName.ClientID %>').value;
            var Email = document.getElementById('<%=txtEmail.ClientID %>').value;
            
            if(Exam == '-999999'){
                $('#<%=lblError.ClientID%>').html("Please Select Exam.");
            }else if(Name.trim() == ''){
                $('#<%=lblError.ClientID%>').html("Please Enter Your Name.");
            }else if(Email.trim() == ''){
                $('#<%=lblError.ClientID%>').html("Please Enter Your Email.");
            }else{
                $('#<%=lblError.ClientID%>').html("");
                
                $.ajax({
                    type: "POST",
                    url: "Survey_wb.asmx/Register",
                    data: "{Exam:'" + Exam + "','Name':'" + Name + "','Email':'" + Email + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(response) {
                        var result = response.d;
                        
                        if(result=='AlreadyRegistered') {
                            $('#<%=lblError.ClientID%>').html("You have already registered this Email.");
                            $('#<%=drpCourse.ClientID%>').val('-999999');
                            $('#<%=txtName.ClientID%>').val('');
                            $('#<%=txtEmail.ClientID%>').val('');
                        }
                        else if(result=='CourseAlreadyRegistered') {
                            $('#<%=lblError.ClientID%>').html("You have already registered this Course.");
                            $('#<%=drpCourse.ClientID%>').val('-999999');
                        }
                        else {
                            $('#<%=lblError.ClientID%>').html("");
                            $('#<%=drpCourse.ClientID%>').val('-999999');
                            $('#<%=txtName.ClientID%>').val('');
                            $('#<%=txtEmail.ClientID%>').val('');
                            
                            $("#Register").hide();
                            
                            $.ajax({
                                type: "POST",
                                url: "Survey_wb.asmx/Survey",
                                data: "{Exam:'" + Exam + "'}",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function(response) {
                                    var survey = response.d;
                                
                                    $("#survey").tmpl(survey).appendTo("#Survey");
                                }
                            });
                        }
                    }
                });
            }
        });
    });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Survey">
    </div>
    <table id="Register">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Exam :
            </td>
            <td>
                <asp:DropDownList ID="drpCourse" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value="-999999">Select Exam</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Name :
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email :
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="btnStartSurvey" runat="server" Style="border: 1px Solid Black; padding: 2px 5px;
                    cursor: pointer;" Text="Start Survey"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
