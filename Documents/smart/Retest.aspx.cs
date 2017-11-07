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
using System.Text;
using System.Text.RegularExpressions;

public partial class Retest : System.Web.UI.Page
{
    Data _data = new Data();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
            DataTable dtCat = _data.GetCatId();
            _data.CategoryId = Convert.ToInt64(dtCat.Rows[0]["CategoryId"].ToString());
            _data.DeleteRetestData();

            Response.Redirect("Test.aspx?type=test_smartstudy&power=mytestbuddy&CId=" + Convert.ToInt64(dtCat.Rows[0]["CategoryId"].ToString()) + "");
        }
    }
}