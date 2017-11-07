<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testdesign.aspx.cs" Inherits="testdesign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style type="text/css">
   table
{
    width: 500px;
	height: 50px;
	padding: 5px;
	border: 5px Solid Blue;
	font-family:@Arial Unicode MS;
	font-style:normal;
	font:20px;
}
    tr
 {
     padding: 3px;
	border: 3px Solid Blue;
	font-family:@Arial Unicode MS;
	font-style:normal;
	font:30px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="7" align="center" style="background-color: #FFFFFF">
            <tr>
                <td>                 
                    Questions
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton runat="server" ID="rdbOpt1" Text="option1" GroupName="rdbOption" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton runat="server" ID="rdbOpt2" Text="option2" GroupName="rdbOption" />
                </td>
            </tr>
            <tr>
                <td> 
                    <asp:RadioButton runat="server" ID="rdbOpt3"  Text="option3" GroupName="rdbOption" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton runat="server" ID="rdbOpt4" Text="option4" GroupName="rdbOption" />
                </td>
            </tr>
            <tr>
            <td align="center">
            <asp:Button ID="btnSubmit" runat="server" Text="NEXT" BackColor="Coral"/>
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
