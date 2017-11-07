using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class Discussions
{
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

     private string _Title;
     public string Title
     {
         get
         {
             return _Title;
         }
         set
         {
             _Title = value;
         }
     }
    private string _Discussion;
    public string Discussion
    {
        get
        {
            return _Discussion;
        }
        set
        {
            _Discussion = value;
        }
    }

    private long _DiscussionId;
    public long DiscussionId
    {
        get
        {
            return _DiscussionId;
        }
        set
        {
            _DiscussionId = value;
        }

    }

    private string _Comment;
    public string Comment
    {
        get
        {
            return _Comment;
        }
        set
        {
            _Comment = value;
        }
    }


    public bool AddDiscussion()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_DiscussionC";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = _UserID;
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Title", SqlDbType.VarChar, 200).Value = _Title;
        cmd.Parameters.Add("@Discussion", SqlDbType.VarChar).Value = _Discussion;
        cmd.Parameters.Add("@DateTime", SqlDbType.VarChar, 30).Value = Configuration.Datetime();
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "AddDiscussion";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
    }

    public DataTable getDiscussion()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_DiscussionC";
       
        cmd.Parameters.Add("@CatId", SqlDbType.BigInt).Value = _CategoryId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getDiscussion";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
    }

    public DataTable getClickedDiscussion()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_DiscussionC";

        cmd.Parameters.Add("@DiscussionId", SqlDbType.BigInt).Value = _DiscussionId;
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getClickedDiscussion";

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        return dt;
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

     public DataTable getDiscussionComment()
     {
         SqlConnection con = new SqlConnection();
         con.ConnectionString = Connection.GetConnection();
         SqlCommand cmd = new SqlCommand();
         cmd.Connection = con;
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandText = "sp_DiscussionC";

         cmd.Parameters.Add("@DiscussionId", SqlDbType.BigInt).Value = _DiscussionId;
         cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "getDiscussionComment";

         DataTable dt = new DataTable();
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(dt);

         return dt;
     }

     public bool AddComment()
     {
         SqlConnection con = new SqlConnection();
         con.ConnectionString = Connection.GetConnection();

         SqlCommand cmd = new SqlCommand();
         cmd.Connection = con;
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.CommandText = "sp_DiscussionC";

         cmd.Parameters.Add("@UserId",SqlDbType.BigInt).Value = _UserID;
         cmd.Parameters.Add("@DiscussionId",SqlDbType.BigInt).Value = _DiscussionId;
         cmd.Parameters.Add("@Comment",SqlDbType.VarChar,500).Value = _Comment;
         cmd.Parameters.Add("@DateTime", SqlDbType.VarChar, 30).Value = Configuration.Datetime();
         cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "AddComment";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        return true;
     }
}