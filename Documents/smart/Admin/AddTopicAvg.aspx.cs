using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddTopicAvg : System.Web.UI.Page
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

    private void BindTopic(string SubId)
    {
        _dropdown.CategoryId = Convert.ToInt64(SubId);
        DataTable dt = _dropdown.GetTopic();

        if (dt.Rows.Count > 0)
        {
            drpTopic.DataSource = dt;
            drpTopic.DataTextField = "TextField";
            drpTopic.DataValueField = "ValueField";
            drpTopic.DataBind();
        }
    }

    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubject(drpCategory.SelectedValue);
    }

    protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTopic(drpSubject.SelectedValue);
    }

    protected void btnSubmit_Click(object sernder, EventArgs e)
    {
        _data.TopicId = Convert.ToInt64(drpTopic.SelectedValue);
        _data.TopicAvg = Convert.ToDouble(txtTopicAvg.Text);
        _data.AddTopicAvg();
    }
}