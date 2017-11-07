using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_algopage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        double AcTp1 = 100 - Convert.ToUInt16(txtAc1.Text);
        double AcTp2 = 100 - Convert.ToUInt16(txtAc2.Text);
        double AcTp3 = 100 - Convert.ToUInt16(txtAc3.Text);
        double AcTp4 = 100 - Convert.ToUInt16(txtAc4.Text);
        double AcTp5 = 100 - Convert.ToUInt16(txtAc5.Text);
        double AcTp6 = 100 - Convert.ToUInt16(txtAc6.Text);
        double AcTp7 = 100 - Convert.ToUInt16(txtAc7.Text);
        double AcTp8 = 100 - Convert.ToUInt16(txtAc8.Text);

        long TotalHours = Convert.ToInt64(txtTotalHours.Text);

        double TotalAccuracy = AcTp1 + AcTp2 + AcTp3 + AcTp4 + AcTp5 + AcTp6 + AcTp7 + AcTp8;

        double TotalHourPerTopic1 = AcTp1 * TotalHours / TotalAccuracy;
        double TotalHourPerTopic2 = AcTp2 * TotalHours / TotalAccuracy;
        double TotalHourPerTopic3 = AcTp3 * TotalHours / TotalAccuracy;
        double TotalHourPerTopic4 = AcTp4 * TotalHours / TotalAccuracy;
        double TotalHourPerTopic5 = AcTp5 * TotalHours / TotalAccuracy;
        double TotalHourPerTopic6 = AcTp6 * TotalHours / TotalAccuracy;
        double TotalHourPerTopic7 = AcTp7 * TotalHours / TotalAccuracy;
        double TotalHourPerTopic8 = AcTp8 * TotalHours / TotalAccuracy;

        lbltopic1.Text = "Total time for topic1: " + TotalHourPerTopic1.ToString("0.00");
        lbltopic2.Text = "Total time for topic2: " + TotalHourPerTopic2.ToString("0.00");
        lbltopic3.Text = "Total time for topic3: " + TotalHourPerTopic3.ToString("0.00");
        lbltopic4.Text = "Total time for topic4: " + TotalHourPerTopic4.ToString("0.00");
        lbltopic5.Text = "Total time for topic5: " + TotalHourPerTopic5.ToString("0.00");
        lbltopic6.Text = "Total time for topic6: " + TotalHourPerTopic6.ToString("0.00");
        lbltopic7.Text = "Total time for topic7: " + TotalHourPerTopic7.ToString("0.00");
        lbltopic8.Text = "Total time for topic8: " + TotalHourPerTopic8.ToString("0.00");

        lblTotalHoursByCal.Text = "Total Hours By Cal : " + (Convert.ToDouble(TotalHourPerTopic1.ToString("0.00")) + Convert.ToDouble(TotalHourPerTopic2.ToString("0.00")) + Convert.ToDouble(TotalHourPerTopic3.ToString("0.00")) + Convert.ToDouble(TotalHourPerTopic4.ToString("0.00")) + Convert.ToDouble(TotalHourPerTopic5.ToString("0.00")) + Convert.ToDouble(TotalHourPerTopic6.ToString("0.00")) + Convert.ToDouble(TotalHourPerTopic7.ToString("0.00")) + Convert.ToDouble(TotalHourPerTopic8.ToString("0.00")));
    }
}




