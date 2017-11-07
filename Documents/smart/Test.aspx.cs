using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    public static string CategoryID;
    public static string UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["CId"] != null)
        {
            CategoryID = Request.QueryString["CId"].ToString();
            UserId = Session["UserId"].ToString();
        }
    } 
}