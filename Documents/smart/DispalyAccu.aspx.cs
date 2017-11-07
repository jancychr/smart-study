using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DispalyAccu : System.Web.UI.Page
{
    Data _data = new Data();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["CID"] != null && Request.QueryString["CID"] != "")
        {
            if (!IsPostBack)
            {
                _data.CategoryId = Convert.ToInt64(Request.QueryString["CID"].ToString());
                DataTable dtTopic = _data.getTopic();

                for (int i = 0; i < dtTopic.Rows.Count; i++)
                {
                    double Accuracy = 0.00;
                    double Actp = 0.00;

                    string TopicId = dtTopic.Rows[i]["TopicId"].ToString();

                    _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
                    _data.TopicId = Convert.ToInt64(TopicId);
                    DataTable dt100 = _data.getDataFor100();
                    DataTable dtAll = _data.getAllData();

                    if (dt100.Rows[0]["Total"].ToString() != null && dt100.Rows[0]["Total"].ToString() != "0")
                    {
                        Accuracy = (Convert.ToDouble(dt100.Rows[0]["Total"].ToString()) * 100) / Convert.ToDouble(dtAll.Rows[0]["Total"].ToString());
                    }

                    Actp = 100.00 - Accuracy;

                    _data.CategoryId = Convert.ToInt64(Request.QueryString["CID"].ToString());
                    _data.Accuracy = Convert.ToDecimal(Accuracy.ToString("0.00"));
                    _data.AcPt = Convert.ToDecimal(Actp.ToString("0.00"));
                    _data.AddAccuracy();
                }

                double HoursPerTopic = 0.00;
                DataTable dtTotalHours = _data.getTotalHours();
                DataTable dtTotalAccuracy = _data.getTotalAccuracy();

                for (int j = 0; j < dtTopic.Rows.Count; j++)
                {
                    _data.TopicId = Convert.ToInt64(dtTopic.Rows[j]["TopicID"].ToString());
                    DataTable dtAccuracy = _data.getAccuracy();

                    if (dtAccuracy.Rows.Count > 0)
                    {
                        HoursPerTopic = (Convert.ToDouble(dtAccuracy.Rows[0]["AcPt"].ToString()) * Convert.ToDouble(dtTotalHours.Rows[0]["TotalHours"].ToString())) / Convert.ToDouble(dtTotalAccuracy.Rows[0]["TotalAccuracy"].ToString());

                        _data.HoursPerTopic = Convert.ToDouble(HoursPerTopic.ToString("0.00"));
                        _data.UpdateHoursPerTopic();
                    }
                }

                BindTimeTable();
            }
        }
    }

    public void BindTimeTable()
    {
        double RemainingTime = 0.00;
        int bit = 1;
        double Time = 0.00;
        double TotalTime = 0.00;
        int nextDay = 0;

        try
        {
            _data.CategoryId = Convert.ToInt64(Request.QueryString["CID"].ToString());
            _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
            DataTable dtTopic = _data.GetTopicData();

            DataTable dtStudyHours = _data.getTotalHours();
            double hour = Convert.ToDouble(dtStudyHours.Rows[0]["StudyHours"].ToString());

            for (int i = 0; i < dtTopic.Rows.Count; i++)
            {
                double NeedTime = Convert.ToDouble(dtTopic.Rows[i]["Hour"].ToString());

                _data.TopicId = Convert.ToInt64(dtTopic.Rows[i]["TopicId"].ToString());
                DataTable dtTime = _data.GetTotalTime();

                if (dtTime.Rows.Count > 0)
                {
                    if (dtTime.Rows[0]["TotalTime"].ToString() != null && dtTime.Rows[0]["TotalTime"].ToString() != "")
                    {
                        if (RemainingTime > hour)
                        {
                            _data.HoursPerTopic = hour;
                            _data.UpdateTimeTable();

                            RemainingTime = Convert.ToDouble((RemainingTime - hour).ToString("0.00"));
                            Time = hour;
                            i = i - 1;

                            DataTable dtTimeTableData = _data.GetTimeTableData();
                            DataTable dtStudyDates = _data.GetStudyDates();

                            _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                            if (dtTimeTableData.Rows.Count > 0)
                            {
                                _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                            }
                            else
                            {
                                _data.TimeTableId = 1;
                            }
                            _data.UpdateDay();

                            nextDay = nextDay + 1;
                        }
                        else
                        {
                            _data.HoursPerTopic = RemainingTime;
                            _data.UpdateTimeTable();

                            RemainingTime = hour - RemainingTime;
                            Time = RemainingTime;

                            bit = 0;

                            DataTable dtTimeTableData = _data.GetTimeTableData();
                            DataTable dtStudyDates = _data.GetStudyDates();

                            _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                            if (dtTimeTableData.Rows.Count > 0)
                            {
                                _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                            }
                            else
                            {
                                _data.TimeTableId = 1;
                            }
                            _data.UpdateDay();
                        }
                    }
                    else
                    {
                        if (bit == 1)
                        {
                            if (NeedTime > hour)
                            {
                                _data.HoursPerTopic = hour;
                                _data.UpdateTimeTable();

                                RemainingTime = Convert.ToDouble((NeedTime - hour).ToString("0.00"));
                                Time = hour;
                                i = i - 1;

                                DataTable dtTimeTableData = _data.GetTimeTableData();
                                DataTable dtStudyDates = _data.GetStudyDates();

                                _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                                if (dtTimeTableData.Rows.Count > 0)
                                {
                                    _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                                }
                                else
                                {
                                    _data.TimeTableId = 1;
                                }
                                _data.UpdateDay();

                                nextDay = nextDay + 1;
                            }
                            else
                            {
                                if (RemainingTime == 0.0)
                                {
                                    _data.HoursPerTopic = NeedTime;
                                    _data.UpdateTimeTable();

                                    RemainingTime = Convert.ToDouble((hour - NeedTime).ToString("0.00"));

                                    Time = NeedTime;

                                    DataTable dtTimeTableData = _data.GetTimeTableData();
                                    DataTable dtStudyDates = _data.GetStudyDates();

                                    _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                                    if (dtTimeTableData.Rows.Count > 0)
                                    {
                                        _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                                    }
                                    else
                                    {
                                        _data.TimeTableId = 1;
                                    }
                                    _data.UpdateDay();
                                }
                                else
                                {
                                    if (RemainingTime > NeedTime)
                                    {
                                        _data.HoursPerTopic = NeedTime;
                                        _data.UpdateTimeTable();

                                        Time = NeedTime;
                                        RemainingTime = Convert.ToDouble((RemainingTime - NeedTime).ToString("0.00"));

                                        DataTable dtTimeTableData = _data.GetTimeTableData();
                                        DataTable dtStudyDates = _data.GetStudyDates();

                                        _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                                        if (dtTimeTableData.Rows.Count > 0)
                                        {
                                            _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                                        }
                                        else
                                        {
                                            _data.TimeTableId = 1;
                                        }
                                        _data.UpdateDay();
                                    }
                                    else
                                    {
                                        _data.HoursPerTopic = RemainingTime;
                                        _data.UpdateTimeTable();

                                        Time = RemainingTime;
                                        RemainingTime = Convert.ToDouble((NeedTime - RemainingTime).ToString("0.00"));

                                        i = i - 1;

                                        DataTable dtTimeTableData = _data.GetTimeTableData();
                                        DataTable dtStudyDates = _data.GetStudyDates();

                                        _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                                        if (dtTimeTableData.Rows.Count > 0)
                                        {
                                            _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                                        }
                                        else
                                        {
                                            _data.TimeTableId = 1;
                                        }
                                        _data.UpdateDay();

                                        nextDay = nextDay + 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (NeedTime > RemainingTime)
                            {
                                _data.HoursPerTopic = RemainingTime;
                                _data.UpdateTimeTable();

                                RemainingTime = NeedTime - RemainingTime;
                                Time = RemainingTime;
                                i = i - 1;

                                DataTable dtTimeTableData = _data.GetTimeTableData();
                                DataTable dtStudyDates = _data.GetStudyDates();

                                _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                                if (dtTimeTableData.Rows.Count > 0)
                                {
                                    _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                                }
                                else
                                {
                                    _data.TimeTableId = 1;
                                }
                                _data.UpdateDay();

                                nextDay = nextDay + 1;
                            }
                            else
                            {
                                _data.HoursPerTopic = NeedTime;
                                _data.UpdateTimeTable();

                                Time = NeedTime;

                                DataTable dtTimeTableData = _data.GetTimeTableData();
                                DataTable dtStudyDates = _data.GetStudyDates();

                                _data.StudyDate = dtStudyDates.Rows[nextDay]["StudyDate"].ToString();
                                if (dtTimeTableData.Rows.Count > 0)
                                {
                                    _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                                }
                                else
                                {
                                    _data.TimeTableId = 1;
                                }
                                _data.UpdateDay();

                                if (RemainingTime > NeedTime)
                                {
                                    RemainingTime = Convert.ToDouble((RemainingTime - NeedTime).ToString("0.00"));
                                }
                                else
                                {
                                    RemainingTime = Convert.ToDouble((NeedTime - RemainingTime).ToString("0.00"));
                                }
                            }
                        }
                    }
                }

                TotalTime = TotalTime + Time;
            }
        }
        catch
        {
            DataTable dtTimeTableData = _data.GetTimeTableData();
            DataTable dtStudyDates = _data.GetStudyDates();

            _data.StudyDate = dtStudyDates.Rows[nextDay - 1]["StudyDate"].ToString();
            if (dtTimeTableData.Rows.Count > 0)
            {
                _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
            }
            else
            {
                _data.TimeTableId = 1;
            }

            _data.UpdateDay();
        }
        finally
        {
            Response.Redirect("DisplayTimeTable.aspx");
        }
    }
}