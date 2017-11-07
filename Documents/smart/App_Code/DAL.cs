using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;


/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{

    public string _ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    public SqlDataReader GetDataReader(string sSQL)
    {
        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        SqlDataReader result = default(SqlDataReader);

        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            return null;
        }

        // Return the datareader result
        return result;
    }

    public SqlDataReader GetDataReader(string sSQL, SortedList paramList)
    {
        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        SqlDataReader result = default(SqlDataReader);
        int x = 0;
        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            myConnection.Open();
            result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
        }
        // Return the datareader result
        return result;
    }

    public DataSet GetDataSet(string sSQL, SortedList paramList)
    {
        // Create Instance of Connection

        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        int x = 0;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = sSQL;
        cmd.Connection = myConnection;
        for (x = 0; x <= paramList.Count - 1; x++)
        {
            //cmd.Parameters.Add(paramList.GetKey(x), paramList.GetByIndex(x));
            cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
        }
        SqlDataAdapter myAdapter = default(SqlDataAdapter);
        myAdapter = new SqlDataAdapter(cmd);

        DataSet result = new DataSet();
        try
        {
            myAdapter.Fill(result);
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            return result;
        }
        // Return the datareader result
        return result;
    }

    public DataSet GetDataSet(string sSQL)
    {
        // Create Instance of Connection

        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlDataAdapter myAdapter = new SqlDataAdapter(sSQL, myConnection);
        DataSet result = new DataSet();
        try
        {
            myAdapter.Fill(result);
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            return result;
        }
        // Return the datareader result
        return result;
    }

    public int ExecuteSQL(string sSQL, string sText)
    {
        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        int result = 0;

        // Execute the command
        try
        {
            cmd.CommandType = CommandType.Text;
            myConnection.Open();
            result = cmd.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            result = -1;
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }

    public int ExecuteSQL(string sSQL)
    {
        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        int result = 0;

        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            result = cmd.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            result = -1;
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }

    public int ExecuteSQL(string sSQL, SortedList paramList)
    {
        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        int result = 0;
        Int16 x = default(Int16);

        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                //cmd.Parameters.Add(paramList.GetKey(x), paramList.GetByIndex(x));
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            myConnection.Open();
            result = cmd.ExecuteNonQuery();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            result = -1;
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }

    public int ExecuteSQL(string sSQL, SortedList paramList, SqlConnection myConnection, SqlTransaction myTransaction)
    {
        // Create Instance of Connection and Command Object
        //SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection, myTransaction);
        int result = 0;
        Int16 x = default(Int16);

        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                //cmd.Parameters.Add(paramList.GetKey(x), paramList.GetByIndex(x));
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            //myConnection.Open();
            result = cmd.ExecuteNonQuery();
            //myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            result = -1;
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    //myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }


    public int ExeTransactSql(string sSQL, SortedList paramList)
    {
        SqlTransaction MyTransaction;

        //String _ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        SqlConnection myConnection = new SqlConnection(_ConnString);

        myConnection.Open();

        MyTransaction = myConnection.BeginTransaction();

        SqlCommand cmd = new SqlCommand(sSQL, myConnection, MyTransaction);

        int result;

        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int x = 0; x <= paramList.Count - 1; x++)
            {
                cmd.Parameters.Add((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }

            result = Convert.ToInt32(cmd.ExecuteNonQuery());

            MyTransaction.Commit();

            cmd.Dispose();
            cmd = null;
            myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            MyTransaction.Rollback();
            result = -1;
            //ErrorHandler.WriteError(Convert.ToString(ex));
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            myConnection.Dispose();
            cmd.Dispose();
            MyTransaction.Dispose();
        }
        return result;
    }

    public object ExecuteScaler(string sSQL)
    {

        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        object result = null;

        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            result = cmd.ExecuteScalar();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return null;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }

    public object ExecuteScaler(string sSQL, String type)
    {

        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        object result = null;

        // Execute the command
        try
        {
            cmd.CommandType = CommandType.Text;
            myConnection.Open();
            result = cmd.ExecuteScalar();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return null;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }

    //SqlConnection myConnection, SqlTransaction myTransaction
    public object ExecuteScaler(string sSQL, SortedList paramList, SqlConnection myConnection, SqlTransaction myTransaction)
    {
        // Create Instance of Connection and Command Object
        //SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection, myTransaction);
        object result = null;
        Int16 x = default(Int16);
        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                //cmd.Parameters.Add(paramList.GetKey(x), paramList.GetByIndex(x));
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            result = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {

                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return null;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }

    public object ExecuteScaler(string sSQL, SortedList paramList)
    {

        // Create Instance of Connection and Command Object
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sSQL, myConnection);
        object result = null;
        Int16 x = default(Int16);
        // Execute the command
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                //cmd.Parameters.Add(paramList.GetKey(x), paramList.GetByIndex(x));
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            myConnection.Open();
            result = cmd.ExecuteScalar();
            myConnection.Close();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return null;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        // Return the result
        return result;
    }

    public DataTable GetDataTable(string SQL, string VAL)
    {
        DataTable dt = new DataTable();
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(SQL, myConnection);
        try
        {
            if (VAL == "TEXT")
            {
                cmd.Connection = myConnection;
                cmd.CommandText = SQL;
                cmd.CommandType = CommandType.Text;
                myConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                myConnection.Close();
                da.Dispose();
            }
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return dt;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        return dt;
    }

    public DataTable GetDataTable(string sp)
    {
        DataTable dt = new DataTable();
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sp, myConnection);
        try
        {
            cmd.Connection = myConnection;
            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            myConnection.Close();
            da.Dispose();

        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return dt;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        return dt;
    }

    public DataTable GetDataTableSchema(string sp, SortedList paramList)
    {
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sp, myConnection);
        DataTable dt = new DataTable();
        try
        {
            cmd.Connection = myConnection;
            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int x = 0; x <= paramList.Count - 1; x++)
            {
                //cmd.Parameters.Add(paramList.GetKey(x), paramList.GetByIndex(x));
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            myConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.FillSchema(dt, SchemaType.Source);
            myConnection.Close();
            da.Dispose();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return dt;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        return dt;
    }

    public DataTable GetDataTableSchema(string sp)
    {
        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sp, myConnection);
        DataTable dt = new DataTable();
        try
        {
            cmd.Connection = myConnection;
            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;
            myConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.FillSchema(dt, SchemaType.Source);
            myConnection.Close();
            da.Dispose();
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return dt;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        return dt;
    }

    public int DataTableUpdate(string sSQL, DataTable dtUpdate, SqlConnection myConnection, SqlTransaction myTransaction)
    {
        SqlDataAdapter adpt = default(SqlDataAdapter);
        SqlCommand cmd = default(SqlCommand);
        int result = 0;
        //SqlConnection myConnection = new SqlConnection(_ConnString);
        //
        try
        {

            cmd = new SqlCommand(sSQL, myConnection, myTransaction);
            adpt = new SqlDataAdapter(cmd);
            adpt.RowUpdated += OnRowUpdated;
            SqlCommandBuilder custCB = new SqlCommandBuilder(adpt);
            result = adpt.Update(dtUpdate);
            return result;
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            return -1;
        }
    }

    public int DataTableUpdate(string sSQL, DataTable dtUpdate)
    {
        SqlDataAdapter adpt = default(SqlDataAdapter);
        SqlCommand cmd = default(SqlCommand);
        int result = 0;
        SqlConnection myConnection = new SqlConnection(_ConnString);
        //
        try
        {

            cmd = new SqlCommand(sSQL, myConnection);
            adpt = new SqlDataAdapter(cmd);
            adpt.RowUpdated += OnRowUpdated;
            SqlCommandBuilder custCB = new SqlCommandBuilder(adpt);
            result = adpt.Update(dtUpdate);
            return result;
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            return -1;
        }
    }

    private void OnRowUpdated(object sender, SqlRowUpdatedEventArgs args)
    {
        System.Exception exp = default(System.Exception);
        exp = args.Errors;
        try
        {
            if ((exp != null))
            {
                args.Status = UpdateStatus.Continue;
            }
            //Else
            // If fieldName <> "" Then
            // If affectedLeadId <> "" Then
            // affectedLeadId = affectedLeadId & "," & CStr(args.Row.Item(fieldName))
            // Else
            // affectedLeadId = CStr(args.Row.Item(fieldName))
            // End If
            // End If
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
        }
    }

    public DataTable GetDataTable(string sp, SortedList paramList)
    {

        SqlConnection myConnection = new SqlConnection(_ConnString);
        SqlCommand cmd = new SqlCommand(sp, myConnection);
        DataTable dt = new DataTable();
        Int16 x = default(Int16);
        try
        {
            cmd.Connection = myConnection;
            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;
            for (x = 0; x <= paramList.Count - 1; x++)
            {
                //cmd.Parameters.Add(paramList.GetKey(x), paramList.GetByIndex(x));
                cmd.Parameters.AddWithValue((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }
            myConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            myConnection.Close();
            da.Dispose();

        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            try
            {
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex2)
            {
                if (ex2.ToString() == "")
                {

                }
                return dt;
            }
            //ErrorHandler.WriteError(Convert.ToString(ex));
        }
        return dt;
    }

    public DataTable GetDataTableWithTransact(string sp, SortedList paramList)
    {
        SqlTransaction MyTransaction;
        DataTable dt = new DataTable();
        SqlConnection myConnection = new SqlConnection(_ConnString);
        myConnection.Open();
        MyTransaction = myConnection.BeginTransaction();
        SqlCommand cmd = new SqlCommand(sp, myConnection, MyTransaction);
        try
        {
            cmd.Connection = myConnection;
            cmd.CommandText = sp;
            cmd.CommandType = CommandType.StoredProcedure;

            for (int x = 0; x <= paramList.Count - 1; x++)
            {
                cmd.Parameters.Add((String)paramList.GetKey(x), paramList.GetByIndex(x));
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            da.Dispose();
            MyTransaction.Commit();

            cmd.Dispose();
            cmd = null;
            myConnection.Close();

        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
            MyTransaction.Rollback();
            dt = null;
            //ErrorHandler.WriteError(Convert.ToString(ex));
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
            myConnection.Dispose();
            cmd.Dispose();
            MyTransaction.Dispose();
        }
        return dt;
    }

    public void SendMail(String from, String to, String subj, String bod, bool htmlFormat)
    {
        MailMessage mMsg = new MailMessage();
        mMsg.From = new MailAddress(from);
        mMsg.To.Add(new MailAddress(to));
        mMsg.Priority = MailPriority.High;
        mMsg.Subject = subj;
        mMsg.Body = bod;
        mMsg.IsBodyHtml = htmlFormat;
        SmtpClient smtpcli = new SmtpClient("mail.webmyne.com", 25);
        try
        {
            smtpcli.Send(mMsg);
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
        }
        return;

    }

    public void SendMailAttach(String from, String to, String subj, String bod, bool htmlFormat, String filename)
    {
        MailMessage mMsg = new MailMessage();
        mMsg.From = new MailAddress(from);
        mMsg.To.Add(new MailAddress(to));
        mMsg.Priority = MailPriority.High;
        mMsg.Subject = subj;
        mMsg.Body = bod;
        mMsg.IsBodyHtml = htmlFormat;
        mMsg.Attachments.Add(new System.Net.Mail.Attachment(filename));
        SmtpClient smtpcli = new SmtpClient("mail.webmyne.com", 25);
        try
        {
            smtpcli.Send(mMsg);
        }
        catch (Exception ex)
        {
            if (ex.ToString() == "")
            {

            }
        }
        return;

    }

    public void GetConnection(ref SqlConnection con)
    {
        //Return the current connection...
        con.ConnectionString = _ConnString;
        con.Open();
    }
}
