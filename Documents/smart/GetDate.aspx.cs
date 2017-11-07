using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _GetDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DayOfWeek day1 = DayOfWeek.Wednesday;
        DayOfWeek day2 = DayOfWeek.Thursday;

        List<DayOfWeek> days = new List<DayOfWeek>();
        days.Add(day1);
        days.Add(day2);

        List<DateTime> dtResult = ProcessDate(new DateTime(2014, 04, 23), new DateTime(2014, 05, 15), days);

        string Date = "";
        foreach (DateTime dt in dtResult)
        {
            Date = Date + "<br/>" + dt.ToString();
        }

        lblDate.Text = Date;
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
