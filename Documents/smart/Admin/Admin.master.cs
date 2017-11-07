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

public partial class Admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["Mtb_SmartStudy"] == null || Session["UserId"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            if (Session["Mtb_SmartStudy"].ToString() != "Valid" && Session["UserId"].ToString() == "")
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }

    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session["Mtb_SmartStudy"] = null;
        Session["UserId"] = null;
        Response.Redirect("~/Default.aspx");
    }
}