using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class Discussion : System.Web.UI.Page
{
    Discussions _dis = new Discussions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDiscussion();
        }
    }

    private void BindDiscussion()
    {
        _dis.UserID = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dtCat = _dis.GetCatId();

        _dis.CategoryId = Convert.ToInt64(dtCat.Rows[0]["CategoryId"].ToString());
        DataTable dt = _dis.getDiscussion();

        if (dt.Rows.Count > 0)
        {
            dlDiscussion.DataSource = dt;
            dlDiscussion.DataBind();
        }
    }
}