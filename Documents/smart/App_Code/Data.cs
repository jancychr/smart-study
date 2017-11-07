using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Data
{
    public Data()
    {

    }

    private long _StudyHourId;
    public long StudyHourId
    {
        get
        {
            return _StudyHourId;
        }
        set
        {
            _StudyHourId = value;
        }
    }

    private string _StudyDate;
    public string StudyDate
    {
        get
        {
            return _StudyDate;
        }
        set
        {
            _StudyDate = value;
        }
    }

    private string _Category;
    public string Category
    {
        get
        {
            return _Category;
        }
        set
        {
            _Category = value;
        }
    }

    private string _Subject;
    public string Subject
    {
        get
        {
            return _Subject;
        }
        set
        {
            _Subject = value;
        }
    }

    private string _Topic;
    public string Topic
    {
        get
        {
            return _Topic;
        }
        set
        {
            _Topic = value;
        }
    }

    private long _CategoryId;
    public long CategoryId
    {
        get
        {
            return _CategoryId;
        }
        set
        {
            _CategoryId = value;
        }
    }

    private long _OptionId;
    public long OptionId
    {
        get
        {
            return _OptionId;
        }
        set
        {
            _OptionId = value;
        }
    }

    private long _SubjectId;
    public long SubjectId
    {
        get
        {
            return _SubjectId;
        }
        set
        {
            _SubjectId = value;
        }
    }
    private decimal _Accuracy;
    public decimal Accuracy
    {
        get
        {
            return _Accuracy;
        }
        set
        {
            _Accuracy = value;
        }
    }
    private decimal _AcPt;
    public decimal AcPt
    {
        get
        {
            return _AcPt;
        }
        set
        {
            _AcPt = value;
        }
    }

    private long _TopicId;
    public long TopicId
    {
        get
        {
            return _TopicId;
        }
        set
        {
            _TopicId = value;
        }
    }

    private double _TopicAvg;
    public double TopicAvg
    {
        get
        {
            return _TopicAvg;
        }
        set
        {
            _TopicAvg = value;
        }
    }

    private string _Question;
    public string Question
    {
        get
        {
            return _Question;
        }
        set
        {
            _Question = value;
        }

    }
    private string _ExamDate;
    public string ExamDate
    {
        get
        {
            return _ExamDate;
        }
        set
        {
            _ExamDate = value;
        }

    }
    private long _CourseID;
    public long CourseID
    {
        get
        {
            return _CourseID;
        }
        set
        {
            _CourseID = value;
        }
    }

    private long _StudyDays;
    public long StudyDays
    {
        get
        {
            return _StudyDays;
        }
        set
        {
            _StudyDays = value;
        }

    }

    private long _StudyHours;
    public long StudyHours
    {
        get
        {
            return _StudyHours;
        }
        set
        {
            _StudyHours = value;
        }

    }


    private long _finalhours;
    public long finalhours
    {
        get
        {
            return _finalhours;
        }
        set
        {
            _finalhours = value;
        }

    }

    private long _TotalAccuracy;
    public long TotalAccuracy
    {
        get
        {
            return _TotalAccuracy;
        }
        set
        {
            _TotalAccuracy = value;
        }

    }

    private long _TotalDays;
    public long TotalDays
    {
        get
        {
            return _TotalDays;
        }
        set
        {
            _TotalDays = value;
        }

    }


    private string _QOption;
    public string QOption
    {
        get
        {
            return _QOption;
        }
        set
        {
            _QOption = value;
        }

    }
    private Boolean _Answer;
    public Boolean Answer
    {
        get
        {
            return _Answer;
        }
        set
        {
            _Answer = value;
        }

    }

    private long _QuestionID;
    public long QuestionID
    {
        get
        {
            return _QuestionID;
        }
        set
        {
            _QuestionID = value;
        }

    }
    private long _UserID;
    public long UserID
    {
        get
        {
            return _UserID;
        }
        set
        {
            _UserID = value;
        }

    }

    private double _HoursPerTopic;
    public double HoursPerTopic
    {
        get
        {
            return _HoursPerTopic;
        }
        set
        {
            _HoursPerTopic = value;
        }

    }

    private long _TimeTableId;
    public long TimeTableId
    {
        get
        {
            return _TimeTableId;
        }
        set
        {
            _TimeTableId = value;
        }
    }

    private long _Day;
    public long Day
    {
        get
        {
            return _Day;
        }
        set
        {
            _Day = value;
        }
    }



    public DataTable CheckUserTest()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "CheckUserTest";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public bool DeleteExistingUserData()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "DeleteExistingUserData";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public bool AddCategory()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = _Category;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "InsertCategory";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public bool AddSubject()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 50).Value = _Subject;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "InsertSubject";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public bool AddTopic()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@SubjectId", SqlDbType.BigInt).Value = _SubjectId;
        cmd.Parameters.Add("@Topic", SqlDbType.VarChar, 50).Value = _Topic;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "InsertTopic";


        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public bool AddTopicAvg()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@TopicAvg", SqlDbType.Decimal).Value = _TopicAvg;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "InsertTopicAvg";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public long AddQuestion()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@SubjectID", SqlDbType.BigInt).Value = _SubjectId;
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Question", SqlDbType.VarChar).Value = _Question;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "InsertQuestions";

        con.Open();
        Int64 QueID = Convert.ToInt64(cmd.ExecuteScalar());
        con.Close();

        return QueID;
    }

    public bool AddOptions()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@QuestionID", SqlDbType.BigInt).Value = _QuestionID;
        cmd.Parameters.Add("@QOption", SqlDbType.VarChar).Value = _QOption;
        cmd.Parameters.Add("@Answer", SqlDbType.Bit).Value = _Answer;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "InsertOptions";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public DataTable getTopic()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getTopic";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getTotalHours()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getTotalHours";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getTotalAccuracy()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getTotalAccuracy";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getAccuracy()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getAccuracy";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getDataFor100()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getDataFor100";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getAllData()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getAllData";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public bool UpdateStudyHours()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@ExamDate", SqlDbType.VarChar, 30).Value = _ExamDate;
        cmd.Parameters.Add("@TotalHours", SqlDbType.BigInt).Value = _finalhours;
        cmd.Parameters.Add("@CatID", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@StudyDays", SqlDbType.BigInt).Value = _StudyDays;
        cmd.Parameters.Add("@TotalDays", SqlDbType.BigInt).Value = _TotalDays;
        cmd.Parameters.Add("@StudyHours", SqlDbType.BigInt).Value = _StudyHours;
        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "UpdateStudyHours";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public bool DeleteUserStudyDays()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@StudyHourId", SqlDbType.BigInt).Value = _StudyHourId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "DeleteUserStudyDays";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public bool AddStudyDates()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@StudyHourId", SqlDbType.BigInt).Value = _StudyHourId;
        cmd.Parameters.Add("@StudyDate", SqlDbType.VarChar, 30).Value = _StudyDate;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "AddStudyDates";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public DataTable GetStudyDates()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetStudyDates";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public bool AddAccuracy()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicID", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@CatID", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Accuracy", SqlDbType.Decimal).Value = _Accuracy;
        cmd.Parameters.Add("@AcPt", SqlDbType.Decimal).Value = _AcPt;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "AddAccuracy";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public bool UpdateHoursPerTopic()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicID", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@HoursPerTopic", SqlDbType.Decimal).Value = _HoursPerTopic;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "UpdateHoursPerTopic";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }


    public DataTable GetTopicData()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetTopicData";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public bool UpdateTimeTable()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicID", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@HoursPerTopic", SqlDbType.Decimal).Value = _HoursPerTopic;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "UpdateTimeTable";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public DataTable GetTotalTime()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetTotalTime";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetTimeTableData()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetTimeTableData";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public bool UpdateDay()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@TimeTableId", SqlDbType.BigInt).Value = _TimeTableId;
        cmd.Parameters.Add("@StudyDate", SqlDbType.VarChar, 30).Value = _StudyDate;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "UpdateDay";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public DataTable GetCatId()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetCatId";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getTotalQuestion()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getTotalQuestion";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getTotalUserAttemptedAnswer()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getTotalUserAttemptedAnswer";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetAccuracyBar()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetAccuracyBar";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetQuestions()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("Mode", SqlDbType.VarChar, 50).Value = "GetQuestions";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetQue()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("QuestionId", SqlDbType.BigInt).Value = _QuestionID;
        cmd.Parameters.Add("Mode", SqlDbType.VarChar, 50).Value = "GetOue";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetOptions()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("QuestionId", SqlDbType.BigInt).Value = _QuestionID;
        cmd.Parameters.Add("Mode", SqlDbType.VarChar, 50).Value = "GetOptions";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetTimingBar()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetTimingBar";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public bool DeleteRetestData()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Data";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "DeleteRetestData";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }
}