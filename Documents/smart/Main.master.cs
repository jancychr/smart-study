using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Main : System.Web.UI.MasterPage
{
    public static string UserId = "0";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            UserId = Session["UserId"].ToString();
        }
        else
        {
            UserId = "0";
        }
    }

    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("Default.aspx");
    }
}
