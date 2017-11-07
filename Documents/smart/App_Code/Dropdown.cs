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

public class Dropdown
{
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

    
    public DataTable GetCourses()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Dropdown";

        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetCourses";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
 
   }

    public DataTable GetCategory()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Dropdown";

        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetCategory";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetSubject()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Dropdown";

        cmd.Parameters.Add("@CategoryId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetSubject";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable GetTopic()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Dropdown";

        cmd.Parameters.Add("@SubjectId", SqlDbType.BigInt).Value = _SubjectId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetTopic";

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
        cmd.CommandText = "sp_Dropdown";

        cmd.Parameters.Add("@SubjectId", SqlDbType.BigInt).Value = _SubjectId;
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetQuestons";

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
        cmd.CommandText = "sp_Dropdown";

      
        cmd.Parameters.Add("@TopicId", SqlDbType.BigInt).Value = _TopicId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "GetOptions";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

}