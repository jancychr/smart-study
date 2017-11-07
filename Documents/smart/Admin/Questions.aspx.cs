using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Questions : System.Web.UI.Page
{
    Data _data = new Data();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindQuestions();
        }
    }

    private void BindQuestions()
    {
        DataTable dtFinal = new DataTable();
        dtFinal.Columns.Add("QuestionId");
        dtFinal.Columns.Add("Question");
        dtFinal.Columns.Add("QOption");

        DataTable dt = _data.GetQuestions();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string Option = "";
            _data.QuestionID = Convert.ToInt64(dt.Rows[i]["QuestionId"].ToString());
            DataTable dtOpt = _data.GetOptions();

            for (int j = 0; j < dtOpt.Rows.Count; j++)
            {
                Option = Option + "," + dtOpt.Rows[j]["QOption"].ToString();
            }

            Option = Option.Substring(1, Option.Length - 1);
            DataRow dr = dtFinal.NewRow();
            dr["QuestionId"] = dt.Rows[i]["QuestionId"].ToString();
            dr["Question"] = dt.Rows[i]["Question"].ToString();
            dr["QOption"] = Option.Replace(",", "<br/>");

            dtFinal.Rows.Add(dr);
        }

        if (dt.Rows.Count > 0)
        {
            gvQuestions.DataSource = dtFinal;
            gvQuestions.DataBind();
        }
    }

    protected void gvQuestions_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvQuestions_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string QId = e.CommandArgument.ToString();

        if (e.CommandName == "Edit")
        {
            Response.Redirect("UpdateQuestion.aspx?qid=" + QId + "");
        }
    }
}