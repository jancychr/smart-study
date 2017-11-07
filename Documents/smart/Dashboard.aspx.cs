using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    Data _data = new Data();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckData();
            BindUserAccuracy();
            BindUserTiming();

        }
    }

    private void CheckData()
    {
        _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dtCatId = _data.GetCatId();

        _data.CategoryId = Convert.ToInt64(dtCatId.Rows[0]["CategoryId"].ToString());
        DataTable dtTotalQue = _data.getTotalQuestion();
        DataTable dtUserQue = _data.getTotalUserAttemptedAnswer();

        lblNote1.Visible = true;
        lnkbtnNote.Visible = true;
        lnkbtnTest.Visible = true;

        if (dtCatId.Rows[0]["ExamDate"].ToString() == "" || dtCatId.Rows[0]["ExamDate"].ToString() == null)
        {
            lblNote1.Text = "Still you have not fill up Details for your Exam.";
            lnkbtnNote.PostBackUrl = "StudyHours.aspx";
            lnkbtnTest.Visible = false;
        }
        else
        {
            if (dtUserQue.Rows.Count == dtTotalQue.Rows.Count)
            {
                lblNote1.Visible = false;
                lnkbtnNote.Visible = false;
                lnkbtnTest.Visible = false;
            }
            else
            {
                lblNote1.Text = "Still you have not attempted Test for your Exam.";
                lnkbtnNote.Visible = false;
                lnkbtnTest.Visible = true;
            }
        }
    }

    protected void lnkbtnTest_Click(object sender, EventArgs e)
    {
        _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dtCatId = _data.GetCatId();
        _data.CategoryId = Convert.ToInt64(dtCatId.Rows[0]["CategoryId"].ToString());
        _data.DeleteExistingUserData();

        Response.Redirect("Test.aspx?type=test_smartstudy&power=mytestbuddy&CId=" + Convert.ToInt64(dtCatId.Rows[0]["CategoryId"].ToString()) + "");
    }

    private void BindUserAccuracy()
    {
        _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dtCatId = _data.GetCatId();
        _data.CategoryId = Convert.ToInt64(dtCatId.Rows[0]["CategoryId"].ToString());

        DataTable dtAccuracy = _data.GetAccuracyBar();

        if (dtAccuracy.Rows.Count > 0)
        {
            chtUserAccuracy.Visible = true;

            chtUserAccuracy.DataSource = dtAccuracy;

            chtUserAccuracy.Series["chtMASeries1"].XValueMember = "TopicName";
            chtUserAccuracy.Series["chtMASeries1"].YValueMembers = "Accuracy";

            chtUserAccuracy.ChartAreas[0].AxisY.Interval = 10;
            chtUserAccuracy.ChartAreas[0].AxisX.Interval = 1;

            chtUserAccuracy.DataBind();
        }
        else
        {
            chtUserAccuracy.Visible = false;
        }
    }

    private void BindUserTiming()
    {
        _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dtCatId = _data.GetCatId();
        _data.CategoryId = Convert.ToInt64(dtCatId.Rows[0]["CategoryId"].ToString());

        DataTable dtTiming = _data.GetTimingBar();

        if (dtTiming.Rows.Count > 0)
        {
            ChtUserTiming.Visible = true;

            ChtUserTiming.DataSource = dtTiming;

            ChtUserTiming.Series["chtMASeries1"].XValueMember = "TopicName";
            ChtUserTiming.Series["chtMASeries1"].YValueMembers = "Hour";

            ChtUserTiming.ChartAreas[0].AxisY.Interval = 5;
            ChtUserTiming.ChartAreas[0].AxisX.Interval = 1;

            ChtUserTiming.DataBind();
        }
        else
        {
            ChtUserTiming.Visible = false;
        }
    }
}