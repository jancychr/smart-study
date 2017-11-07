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

public partial class survey : System.Web.UI.Page
{
    Dropdown _dropdown = new Dropdown();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCourse();
        }
    }

    private void BindCourse()
    {
        DataTable dt = _dropdown.GetCourses();

        if (dt.Rows.Count > 0)
        {
            drpCourse.DataValueField = "ValueField";
            drpCourse.DataTextField = "TextField";

            drpCourse.DataSource = dt;
            drpCourse.DataBind();
        }
    }
}
