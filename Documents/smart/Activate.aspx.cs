using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Activate : System.Web.UI.Page
{
    ICS_Login _login = new ICS_Login();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null && Request.QueryString["uid"] != null && Request.QueryString["data"] != null)
        {
            if (!IsPostBack)
            {
                string Type = Request.QueryString["type"];
                string UserId = Request.QueryString["uid"];
                string PersonalId = Request.QueryString["data"];

                _login.UserId = Convert.ToInt64(UserId);
                _login.PersonalID = PersonalId;
                DataTable dt = _login.CheckActivationData();

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Active"].ToString() == "True")
                    {
                        lblNote.Text = "You have already Activated your Account.";
                        lblNote.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        _login.UserActivate();
                        lblNote.Text = "You have successfully Activated your Account.";
                        lblNote.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    lblNote.Text = "Ahhhhh! Keep Trying. Good Luck... ;)";
                    lblNote.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        else
        {
            Response.Redirect("http://smartstudy.mytestbuddy.net");
        }
    }
}