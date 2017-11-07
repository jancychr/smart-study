using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignOut : System.Web.UI.Page
{
    ICS_Login _log = new ICS_Login();

    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }  
 
}