using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;

public partial class ForgotPassword : System.Web.UI.Page
{
    Mail _email = new Mail();
    ICS_Login lg = new ICS_Login();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text.Trim() == "")
        {
            lblNote.Text = "Please Enter Valid Email Address.";
            lblNote.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lg.Email = txtEmail.Text;
            DataTable dt = lg.CheckEmail();

            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hello " + dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["FirstName"].ToString() + ",");
                sb.Append("<br/>");
                sb.Append("Greetings from Smart Study!");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("This Email is Regarding your request for Password");
                sb.Append("<br/>");
                sb.Append("Account Details are as below:");
                sb.Append("<br/>");
                sb.Append("<b>Email :</b>" + dt.Rows[0]["Email"].ToString() + "");
                sb.Append("<br/>");
                sb.Append("<b>Password :</b>" + dt.Rows[0]["Password"].ToString() + "");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("<b>Thanks & Regards,</b>");
                sb.Append("<br/>");
                sb.Append("Smart Study Team");

                _email.SendMail(txtEmail.Text, sb.ToString(), "You have received Password from Smart Study");

                txtEmail.Text = "";
                lblNote.Text = "We have successfully sent Password on your Email Address.";
                lblNote.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblNote.Text = "Your account does not exist.";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}