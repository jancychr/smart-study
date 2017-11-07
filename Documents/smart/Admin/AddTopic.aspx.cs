using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddTopic : System.Web.UI.Page
{
    Data _data = new Data();
    Dropdown _dropdown = new Dropdown();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
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

    private void BindSubject(string CatId)
    {
        _dropdown.CategoryId = Convert.ToInt64(CatId);
        DataTable dt = _dropdown.GetSubject();

        if (dt.Rows.Count > 0)
        {
            drpSubject.DataSource = dt;
            drpSubject.DataTextField = "TextField";
            drpSubject.DataValueField = "ValueField";
            drpSubject.DataBind();
        }
    }
    

    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubject(drpCategory.SelectedValue);
    }

    protected void btnSubmit_Click(object sernder, EventArgs e)
    {
        _data.SubjectId = Convert.ToInt64(drpSubject.SelectedValue);
        _data.Topic = txtTopic.Text;
        _data.AddTopic();
    }
}