using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayTimeTable : System.Web.UI.Page
{
    Data _data = new Data();

    public static string UserId;
    public static string CatId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Session["UserId"].ToString();

        _data.UserID = Convert.ToInt64(UserId);
        DataTable dt = _data.GetCatId();
        CatId = dt.Rows[0]["CategoryId"].ToString();
    }
}