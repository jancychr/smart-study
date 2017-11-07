using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddSubject : System.Web.UI.Page
{
    Data _data = new Data();
    Dropdown _dropdown = new Dropdown();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
        }
    }

    private void BindCategory()
    {
        DataTable dt = _dropdown.GetCategory();

        if (dt.Rows.Count > 0)
        {
            drpCategory.DataSource = dt;
            drpCategory.DataTextField = "TextField";
            drpCategory.DataValueField = "ValueField";
            drpCategory.DataBind();
        }
    }

    protected void btnSubmit_Click(object sernder, EventArgs e)
    {
        _data.CategoryId = Convert.ToInt64(drpCategory.SelectedValue);
        _data.Subject = txtSubject.Text;
        _data.AddSubject();
    }
}