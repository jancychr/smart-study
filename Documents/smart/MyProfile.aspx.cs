using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyProfile : System.Web.UI.Page
{
    ICS_Login _log = new ICS_Login();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserData();
        }
    }

    private void GetUserData()
    {
        _log.UserId = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dt = _log.getUserData();

        if (dt.Rows.Count > 0)
        {
            lblFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            lbLastName.Text = dt.Rows[0]["LastName"].ToString();
            lblBirthDate.Text = dt.Rows[0]["BirthDate"].ToString();
            lblGender.Text = dt.Rows[0]["Gender"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblContactNumber.Text = dt.Rows[0]["ContactNumber"].ToString();

            if (dt.Rows[0]["ProfilePhoto"].ToString() != "")
            {
                imgProfile.ImageUrl = "~\\Images\\UserPhoto\\" + dt.Rows[0]["ProfilePhoto"].ToString();
            }
            else
            {
                imgProfile.ImageUrl = "~\\Images\\UserPhoto\\No_Image.jpg";
            }
        }
    }
}