using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Users : System.Web.UI.Page
{
   ICS_Login _login = new ICS_Login();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUsers();
        }
    }

    private void BindUsers()
    {
        DataTable dt = _login.GetUsers();
        lblNote.Text = "Total Registered Users: " + dt.Rows.Count;

        if (dt.Rows.Count > 0)
        {
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
        }
    }
}