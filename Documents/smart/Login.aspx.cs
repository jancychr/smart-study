using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Login : System.Web.UI.Page
{
    ICS_Login _log = new ICS_Login();
    Data _data = new Data();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text.Trim() == "")
        {
            lblNote.Text = "Please Enter Email Address";
            lblNote.ForeColor = System.Drawing.Color.Red;
        }
        else if (txtPass.Text.Trim() == "")
        {
            lblNote.Text = "Please Enter Password";
            lblNote.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            _log.Email = txtEmail.Text;
            _log.Password = txtPass.Text;

            DataTable dt = _log.Login();

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Active"].ToString() == "True")
                {
                    long UserId = Convert.ToInt64(dt.Rows[0]["UserId"].ToString());
                    Session["UserId"] = UserId;

                    if (dt.Rows[0]["UserType"].ToString() == "Admin")
                    {
                        Session["Mtb_SmartStudy"] = "Valid";

                        Response.Redirect("~/Admin/Users.aspx");
                    }
                    else
                    {
                        Response.Redirect("Dashboard.aspx");
                    }
                }
                else
                {
                    lblNote.Text = "Still you have not activated your Account";
                    lblNote.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                _log.Email = txtEmail.Text;
                DataTable dtCheck = _log.CheckEmail();

                if (dtCheck.Rows.Count > 0)
                {
                    lblNote.Text = "It looks like Still you have not registered with us";
                    lblNote.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblNote.Text = "Email or Password is Wrong";
                    lblNote.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}