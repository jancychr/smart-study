
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
using System.Web.Services;

public class TQuestions
{
    public string TestID;
    public string TestName;
    public string TestDescription;
    public string TestImage;
    public string QuestionID;
    public string Question;
    public string DateTime;
    public string CategoryID;
    public string SubjectID;
    public string TopicId;
    public string TotalQuestion;

    public List<TQuestionOption> Opt;
}

public class TQuestionOption
{
    public string Options;
    public string OptionID;
    public string Answer;
}

public class TTimeTable
{
    public string Topic;
    public string Time;
    public string StudyDate;
}

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Test : System.Web.Services.WebService
{

    public Test()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    List<TQuestions> UserTest = new List<TQuestions>();
    [WebMethod]
    public List<TQuestions> GetTest(int CategoryID)
    {
        FillTest(CategoryID);
        return UserTest;
    }

    [WebMethod]
    public void SaveTest(int UserID, int QuestionID, int OptionID, int Point)
    {
        SaveTestData(UserID, QuestionID, OptionID, Point);
    }

    List<TTimeTable> TestTimeTable = new List<TTimeTable>();
    [WebMethod]
    public List<TTimeTable> GetTimeTableData(int UserId, int CatId)
    {
        FillTimeTableData(UserId, CatId);
        return TestTimeTable;
    }

    public void FillTest(int CategoryID)
    {
        DAL dal = new DAL();
        DataTable dt = new DataTable();
        dt = dal.GetDataTable(String.Format("Select * from tblCategory ct inner join tblExamQuestion tq on tq.CategoryID=ct.CategoryID where ct.CategoryID={0}", CategoryID), "TEXT");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    TQuestions objQuestion = new TQuestions();
                    objQuestion.QuestionID = Convert.ToString(dt.Rows[i]["QuestionID"]);
                    objQuestion.Question = HttpUtility.HtmlDecode(Convert.ToString(dt.Rows[i]["Question"]));

                    objQuestion.TotalQuestion = Convert.ToString(dt.Rows.Count);

                    DataTable dt2 = new DataTable();
                    dt2 = dal.GetDataTable(String.Format("Select OptionID,QOption,Answer from tblQuestionOption where QuestionID={0}", Convert.ToString(dt.Rows[i]["QuestionID"])), "TEXT");
                    if (dt2 != null)
                    {
                        if (dt2.Rows.Count > 0)
                        {
                            List<TQuestionOption> QueOpt = new List<TQuestionOption>();
                            for (int k = 0; k <= dt2.Rows.Count - 1; k++)
                            {
                                try
                                {
                                    TQuestionOption ObjOpt = new TQuestionOption();
                                    ObjOpt.OptionID = Convert.ToString(dt2.Rows[k]["OptionID"]);
                                    ObjOpt.Options = HttpUtility.HtmlDecode(Convert.ToString(dt2.Rows[k]["QOption"]));
                                    ObjOpt.Answer = Convert.ToString(dt2.Rows[k]["Answer"]);
                                    QueOpt.Insert(k, ObjOpt);
                                }
                                catch (Exception ex)
                                {
                                    string error = ex.Message.ToString();
                                }
                            }
                            try
                            {
                                objQuestion.Opt = QueOpt;
                            }
                            catch (Exception ex)
                            {
                                string error = ex.Message.ToString();
                            }
                        }
                    }

                    UserTest.Insert(i, objQuestion);
                }
            }
        }
    }

    public void SaveTestData(int UserID, int QuestionID, int OptionID, int Point)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = Connection.GetConnection();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_Exam";

        cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
        cmd.Parameters.Add("@QuestionID", SqlDbType.BigInt).Value = QuestionID;
        cmd.Parameters.Add("@OptionID", SqlDbType.BigInt).Value = OptionID;
        cmd.Parameters.Add("@Answer", SqlDbType.BigInt).Value = Point;
        cmd.Parameters.Add("@Datetime", SqlDbType.VarChar, 30).Value = Configuration.Datetime();
        cmd.Parameters.Add("@Mode", SqlDbType.VarChar, 30).Value = "SaveUserData";

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void FillTimeTableData(int UserId, int CatId)
    {
        DAL dal = new DAL();
        DataTable dt = new DataTable();
        dt = dal.GetDataTable(String.Format("Select tp.TopicName, tt.Time, tt.StudyDate from tblTestTimeTable as tt INNER JOIN tblTopic as tp ON tt.TopicId=tp.TopicID INNER JOIN tblSubject as sb ON tp.SubjectId=sb.SubjectID Where tt.UserId={0} AND sb.CategoryID={1}", UserId, CatId), "TEXT");

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    TTimeTable objTimeTable = new TTimeTable();
                    objTimeTable.Topic = dt.Rows[i]["TopicName"].ToString();
                    objTimeTable.Time = dt.Rows[i]["Time"].ToString();
                    string[] sd = dt.Rows[i]["StudyDate"].ToString().Split('-');
                    string dd = sd[2] + "-" + sd[1] + "-" + sd[0];
                    objTimeTable.StudyDate = dd;

                    TestTimeTable.Insert(i, objTimeTable);
                }
            }
        }
    }
}