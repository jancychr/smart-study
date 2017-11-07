using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Studyhours : System.Web.UI.Page
{
    Data _data = new Data();


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        int total = 0;

        if (txtExamDate.Text.Trim() != "")
        {
            string CurrentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string[] dd = txtExamDate.Text.Split('-');
            string Exam = dd[2] + "-" + dd[1] + "-" + dd[0];

            if (Convert.ToDateTime(Exam) < Convert.ToDateTime(CurrentDate))
            {
                lblNote.Text = "Date can not be before today's date";
                return;
            }
            else
            {
                lblNote.Text = "*";
            }
        }

        foreach (ListItem li in chkDays.Items)
        {
            if (li.Selected)
            {
                total = total + 1;
            }
        }

        if (txtExamDate.Text.Trim() == "")
        {
            lblNote.Text = "Please Enter Exam Date";
        }
        else if (drpStudyDays.SelectedValue == "-999999")
        {
            lblNote.Text = "Please Select Study Days per Week";
        }
        else if (total != Convert.ToInt32(drpStudyDays.SelectedValue))
        {
            lblNote.Text = "Please Select Proper Days as per Study Hours per Day";
        }
        else if (drpStudyHours.SelectedValue == "-999999")
        {
            lblNote.Text = "Please Select Study Hours per Day";
        }
        else
        {
            _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
            DataTable dtCat = _data.GetCatId();
            _data.CategoryId = Convert.ToInt64(dtCat.Rows[0]["CategoryId"].ToString());
            DataTable dtSHId = _data.CheckUserTest();

            _data.StudyHourId = Convert.ToInt64(dtSHId.Rows[0]["StudyHoursId"].ToString());
            _data.DeleteUserStudyDays();

            StudyData();
        }
    }

    public void StudyData()
    {
        DataTable dtDates = new DataTable();
        dtDates.Columns.Add("Date");

        string CurrentDat = DateTime.Now.ToString("yyyy-MM-dd");
        string[] dd = txtExamDate.Text.Split('-');

        foreach (ListItem li in chkDays.Items)
        {
            if (li.Selected)
            {
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), li.Value.ToString());

                List<DayOfWeek> days = new List<DayOfWeek>();
                days.Add(day);

                List<DateTime> dtResult = ProcessDate(new DateTime(Convert.ToDateTime(System.DateTime.Now.ToString("yyyy, MM, dd")).Ticks), new DateTime(Convert.ToDateTime(dd[2] + "," + dd[1] + "," + dd[0]).Ticks), days);

                foreach (DateTime dt in dtResult)
                {
                    DataRow dr = dtDates.NewRow();
                    dr["Date"] = Convert.ToDateTime(dt.ToString()).ToString("dd-MM-yyyy");

                    dtDates.Rows.Add(dr);
                }
            }
        }

        string CurrentDate = DateTime.Now.ToString("dd-MM-yyyy");
        DateTime examdate = Convert.ToDateTime(txtExamDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        string ExamDate = examdate.ToString("dd-MM-yyyy");

        Int32 finalhours = Convert.ToInt32(drpStudyHours.SelectedValue) * dtDates.Rows.Count;

        _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dtCat = _data.GetCatId();

        _data.CategoryId = Convert.ToInt64(dtCat.Rows[0]["CategoryId"].ToString());
        _data.ExamDate = ExamDate;
        _data.StudyDays = Convert.ToInt64(drpStudyDays.SelectedValue);
        _data.StudyHours = Convert.ToInt64(drpStudyHours.SelectedValue);

        _data.TotalDays = Convert.ToInt64(dtDates.Rows.Count);
        _data.finalhours = Convert.ToInt64(finalhours);
        _data.UpdateStudyHours();

        DataTable dtSHId = _data.CheckUserTest();

        _data.StudyHourId = Convert.ToInt64(dtSHId.Rows[0]["StudyHoursId"].ToString());
        for (int i = 0; i < dtDates.Rows.Count; i++)
        {
            _data.StudyDate = dtDates.Rows[i]["Date"].ToString();
            _data.AddStudyDates();
        }

        Response.Redirect("Test.aspx?type=test_smartstudy&power=mytestbuddy&CId=" + Convert.ToInt64(dtCat.Rows[0]["CategoryId"].ToString()) + "");
    }

    private List<DateTime> ProcessDate(DateTime dtStartDate, DateTime targetDate, List<DayOfWeek> daysOfWeek)
    {
        DateTime dtLoop = dtStartDate;
        List<DateTime> dtRequiredDates = new List<DateTime>();

        for (int i = dtStartDate.DayOfYear; i < targetDate.DayOfYear; i++)
        {
            foreach (DayOfWeek day in daysOfWeek)
            {
                if (dtLoop.DayOfWeek == day)
                {
                    dtRequiredDates.Add(dtLoop);
                }
            }

            dtLoop = dtLoop.AddDays(1);
        }

        return dtRequiredDates;
    }
}