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

public class ICS_Login
{
    private long _UserId;
    public long UserId
    {
        get
        {
            return _UserId;
        }
        set
        {
            _UserId = value;
        }
    }

    private long _CourseId;
    public long CourseId
    {
        get
        {
            return _CourseId;
        }
        set
        {
            _CourseId = value;
        }
    }

    private string _FirstName;
    public string FirstName
    {
        get
        {
            return _FirstName;
        }
        set
        {
            _FirstName = value;
        }
    }

    private string _LastName;
    public string LastName
    {
        get
        {
            return _LastName;
        }
        set
        {
            _LastName = value;
        }
    }

    private string _PersonalID;
    public string PersonalID
    {
        get
        {
            return _PersonalID;
        }
        set
        {
            _PersonalID = value;
        }
    }

    private string _Email;
    public string Email
    {
        get
        {
            return _Email;
        }
        set
        {
            _Email = value;
        }
    }

    private long _ContactNumber;
    public long ContactNumber
    {
        get
        {
            return _ContactNumber;
        }
        set
        {
            _ContactNumber = value;
        }
    }

    private string _Password;
    public string Password
    {
        get
        {
            return _Password;
        }
        set
        {
            _Password = value;
        }
    }

    private string _ConfirmPassword;
    public string ConfirmPassword
    {
        get
        {
            return _ConfirmPassword;
        }
        set
        {
            _ConfirmPassword = value;
        }
    }

    private string _Gender;
    public string Gender
    {
        get
        {
            return _Gender;
        }
        set
        {
            _Gender = value;
        }
    }

    private string _BirthDate;
    public string BirthDate
    {
        get
        {
            return _BirthDate;
        }
        set
        {
            _BirthDate = value;
        }
    }

    private string _DateTime;
    public string DateTime
    {
        get
        {
            return _DateTime;
        }
        set
        {
            _DateTime = value;
        }
    }

    private string _Address;
    public string Address
    {
        get
        {
            return _Address;
        }
        set
        {
            _Address = value;
        }
    }

    private string _RegisteredDate;
    public string RegisteredDate
    {
        get
        {
            return _RegisteredDate;
        }
        set
        {
            _RegisteredDate = value;
        }
    }

    private string _RegisteredIPAddress;
    public string RegisteredIPAddress
    {
        get
        {
            return _RegisteredIPAddress;
        }
        set
        {
            _RegisteredIPAddress = value;
        }
    }

    private long _CatId;
    public long CatId
    {
        get
        {
            return _CatId;
        }
        set
        {
            _CatId = value;
        }
    }

    public DataTable Login()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = _Email;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = _Password;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "Login";
        
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        
        return dt;
    }

    public long Registration()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("@PersonalID", SqlDbType.VarChar, 50).Value = _PersonalID;
        cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = _FirstName;
        cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = _LastName;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = _Email;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = _Password;
        cmd.Parameters.Add("@ContactNumber", SqlDbType.BigInt).Value = _ContactNumber;
        cmd.Parameters.Add("@RegisteredDate", SqlDbType.VarChar, 30).Value = Configuration.Datetime();
        cmd.Parameters.Add("@RegisteredIPAddress", SqlDbType.VarChar, 30).Value = Configuration.IPAddress();
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "Registration";

        con.Open();
        long UserId = Convert.ToInt64(cmd.ExecuteScalar());
        con.Close();

        return UserId;
    }

    public bool CourseRegistration()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserId;
        cmd.Parameters.Add("@CourseId", SqlDbType.BigInt).Value = _CourseId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "CourseRegistration";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public DataTable CheckActivationData()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("UserId", SqlDbType.BigInt).Value = _UserId;
        cmd.Parameters.Add("PersonalId", SqlDbType.VarChar, 50).Value = _PersonalID;
        cmd.Parameters.Add("Mode", SqlDbType.VarChar, 30).Value = "CheckActivationData";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public bool UserActivate()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("UserId", SqlDbType.BigInt).Value = _UserId;
        cmd.Parameters.Add("PersonalId", SqlDbType.VarChar, 50).Value = _PersonalID;
        cmd.Parameters.Add("Mode", SqlDbType.VarChar, 30).Value = "UserActivate";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public DataTable CheckEmail()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = _Email;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "CheckEmail";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }

    public DataTable CheckCourse()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserId;
        cmd.Parameters.Add("@CourseId", SqlDbType.BigInt).Value = _CourseId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "CheckCourse";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }

    public DataTable CheckUserExam()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserId;
       
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "CheckUserExam";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }

    public DataTable GetUsers()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("Mode", SqlDbType.VarChar, 50).Value = "GetUsers";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }


    public DataTable getUserData()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Login";

        cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = _UserId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getUserData";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }
}