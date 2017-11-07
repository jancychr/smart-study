using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AddTestQuestions : System.Web.UI.Page
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
        _dropdown.SubjectId = Convert.ToInt64(SubId);
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
        _data.CategoryId = Convert.ToInt64(drpCategory.SelectedValue);
        _data.SubjectId = Convert.ToInt64(drpSubject.SelectedValue);
        _data.TopicId = Convert.ToInt64(drpTopic.SelectedValue);
        _data.Question = txtQuestion.Text;
        long QId = _data.AddQuestion();

        _data.QuestionID = QId;
        _data.QOption = txtOpt1.Text;
        _data.Answer = rbOpt1.Checked;
        _data.AddOptions();
       
        _data.QOption = txtOpt2.Text;
        _data.Answer = rbOpt2.Checked;
        _data.AddOptions();
        _data.QOption = txtOpt3.Text;
        _data.Answer = rbOpt3.Checked;
        _data.AddOptions();
        _data.QOption = txtOpt4.Text;
        _data.Answer = rbOpt4.Checked;
        _data.AddOptions();

        txtOpt1.Text = "";
        txtOpt2.Text = ""; 
        txtOpt3.Text = "";
        txtOpt4.Text = "";

        txtQuestion.Text = "";
        rbOpt1.Checked = false;
        rbOpt2.Checked = false;
        rbOpt3.Checked = false;
        rbOpt4.Checked = false;

    }
}