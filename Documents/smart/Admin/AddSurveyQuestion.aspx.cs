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

public partial class Admin_AddSurveyQuestion : System.Web.UI.Page
{
    Survey _survey = new Survey();
    Dropdown _dropdown = new Dropdown();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCourse();
        }
    }

    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpType.SelectedValue == "-999999")
        {
            pnlSurveyQuestion.Visible = false;
        }
        else
        {
            pnlSurveyQuestion.Visible = true;
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Dropdown Value...
        int QType = Convert.ToInt32(drpType.SelectedValue);
        int Course = Convert.ToInt32(drpCourse.SelectedValue);

        // Add Question...
        _survey.QuestionType = QType;
        _survey.QuestionText = txtQuestion.Text.Trim();
        _survey.Course = Course;
        Int64 QId = _survey.AddQuestion();

        // Add Options...
        string[] option = txtOptions.Text.Split(',');
        int optionlength = option.Length;

        for (int i = 0; i < optionlength; i++)
        {
            string opt = option[i].ToString().Trim();

            if (opt != "")
            {
                _survey.QuestionID = QId;
                _survey.Option = opt;
                _survey.AddOption();
            }
        }
    }
}
