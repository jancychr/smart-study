
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenerateTimeTable : System.Web.UI.Page
{
    Data _data = new Data();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTimeTable();
        }
    }

    public void BindTimeTable()
    {
        _data.CategoryId = 3;
        _data.UserID = Convert.ToInt64(Session["UserId"].ToString());
        DataTable dtTopic = _data.GetTopicData();

        double RemainingTime = 0.00;
        int bit = 1;
        double Time = 0.00;
        double TotalTime = 0.00;
        int Day = 0;

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

                        RemainingTime = Convert.ToDouble((RemainingTime - hour).ToString("0.0"));
                        Time = hour;
                        i = i - 1;
                    }
                    else
                    {
                        _data.HoursPerTopic = RemainingTime;
                        _data.UpdateTimeTable();

                        RemainingTime = hour - RemainingTime;
                        Time = RemainingTime;

                        DataTable dtTimeTableData = _data.GetTimeTableData();

                        Day = Day + 1;

                        _data.Day = Day;
                        _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                        _data.UpdateDay();

                        bit = 0;
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

                            RemainingTime = Convert.ToDouble((NeedTime - hour).ToString("0.0"));
                            Time = hour;
                            i = i - 1;

                            DataTable dtTimeTableData = _data.GetTimeTableData();

                            Day = Day + 1;

                            _data.Day = Day;
                            _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                            _data.UpdateDay();
                        }
                        else
                        {
                            if (RemainingTime == 0.0)
                            {
                                _data.HoursPerTopic = NeedTime;
                                RemainingTime = Convert.ToDouble((hour - NeedTime).ToString("0.0"));

                                Time = NeedTime;
                            }
                            else
                            {
                                if (RemainingTime > NeedTime)
                                {
                                    _data.HoursPerTopic = NeedTime;

                                    Time = NeedTime;
                                    RemainingTime = Convert.ToDouble((RemainingTime - NeedTime).ToString("0.0"));
                                }
                                else
                                {
                                    _data.HoursPerTopic = RemainingTime;

                                    Time = RemainingTime;
                                    RemainingTime = Convert.ToDouble((NeedTime - RemainingTime).ToString("0.0"));

                                    i = i - 1;
                                }
                            }

                            _data.UpdateTimeTable();
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

                            Day = Day + 1;

                            _data.Day = Day;
                            _data.TimeTableId = Convert.ToInt64(dtTimeTableData.Rows[0]["TimeTableId"].ToString());
                            _data.UpdateDay();
                        }
                        else
                        {
                            _data.HoursPerTopic = NeedTime;
                            _data.UpdateTimeTable();

                            Time = NeedTime;

                            if (RemainingTime > NeedTime)
                            {
                                RemainingTime = Convert.ToDouble((RemainingTime - NeedTime).ToString("0.0"));
                            }
                            else
                            {
                                RemainingTime = Convert.ToDouble((NeedTime - RemainingTime).ToString("0.0"));
                            }
                        }
                    }
                }
            }

            TotalTime = TotalTime + Time;
        }
    }
}