using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateDiscussion : System.Web.UI.Page
{
    Discussions _dis = new Discussions();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtTitle.Text.Trim() == "")
        {
            lblNote.Text = "Please Enter Title";
            lblNote.ForeColor = System.Drawing.Color.Red;
        }
        else if (txtDiscussion.Text.Trim() == "")
        {
            lblNote.Text = "Please Enter Discussion";
            lblNote.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            _dis.UserID = Convert.ToInt64(Session["UserId"].ToString());
            _dis.Title = txtTitle.Text;
            DataTable dt = _dis.GetCatId();
            _dis.CategoryId = Convert.ToInt64(dt.Rows[0]["CategoryId"].ToString());
            _dis.Discussion = txtDiscussion.Text;
            _dis.AddDiscussion();

            txtTitle.Text = "";
            txtDiscussion.Text = "";

            lblNote.Text = "You have successfully Created Discussion";
            lblNote.ForeColor = System.Drawing.Color.Green;
        }
    }
}