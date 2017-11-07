using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public class Survey
{
    private long _QuestionType;
    public long QuestionType
    {
        get
        {
            return _QuestionType;
        }
        set
        {
            _QuestionType = value;
        }
    }

    private string _QuestionText;
    public string QuestionText
    {

        get
        {
            return _QuestionText;
        }
        set
        {
            _QuestionText = value;
        }
    }

    private string _Option;
    public string Option
    {

        get
        {
            return _Option;
        }
        set
        {
            _Option = value;
        }
    }

    private long _Course;
    public long Course
    {

        get
        {
            return _Course;
        }
        set
        {
            _Course = value;
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

    private string _OptionID;
    public string OptionID
    {

        get
        {
            return _OptionID;
        }
        set
        {
            _OptionID = value;
        }
    }

    private string _QTypeID;
    public string QType
    {

        get
        {
            return _QTypeID;
        }
        set
        {
            _QTypeID = value;
        }
    }

    private long _CourseID;
    public long CourseID
    {

        get
        {
            return  _CourseID;
        }
        set
        {
            _CourseID = value;
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

    public bool Surveying()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Survey";
        con.Open();
        cmd.Parameters.Add("@QuestionType", SqlDbType.VarChar, 50).Value = _QuestionType;
        cmd.Parameters.Add("@QuestionText", SqlDbType.VarChar, 50).Value = _QuestionText;
        cmd.Parameters.Add("@Option", SqlDbType.VarChar, 50).Value = _Option;
        cmd.Parameters.Add("@Question", SqlDbType.BigInt).Value = _QuestionText;
        cmd.Parameters.Add("@QuestionText", SqlDbType.BigInt).Value = _QuestionText;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "Surveying";

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
        cmd.CommandText = "sp_Survey";
        
        con.Open();

        cmd.Parameters.Add("@Course", SqlDbType.BigInt).Value = _Course;
        cmd.Parameters.Add("@QuestionType", SqlDbType.BigInt).Value = _QuestionType;
        cmd.Parameters.Add("QuestionText", SqlDbType.VarChar).Value = _QuestionText;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "AddSurveyQuestion";

        Int64 QId = Convert.ToInt64(cmd.ExecuteScalar());

        con.Close();

        return QId;
    }

   


    public bool AddOption()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Survey";

        con.Open();

        cmd.Parameters.Add("@QuestionID", SqlDbType.BigInt).Value = _QuestionID;
        cmd.Parameters.Add("@Option", SqlDbType.VarChar).Value = _Option;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "AddSurveyQuestionOption";
        
        cmd.ExecuteNonQuery();

        con.Close();

        return true;
    }

    public bool AddUserCourse()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Survey";


        con.Open();

        cmd.Parameters.Add("@Course", SqlDbType.BigInt).Value = _CourseID;
        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "AddUserCourse";

        cmd.ExecuteNonQuery();

        con.Close();

        return true;
    }
}