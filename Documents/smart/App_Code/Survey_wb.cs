using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public class Questions
{
    public Int64 Exam;

    public List<QuestionOptions> Options;
}

public class QuestionOptions
{
    public string QOptionsId;
    public string OptionText;
    public string IsAnswered;
}

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Survey_wb : System.Web.Services.WebService
{
    ICS_Login _login = new ICS_Login();
    Survey _survey = new Survey();


    public Survey_wb()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string Register(Int32 Exam, string Name, string Email)
    {
        _login.Email = Email;
        DataTable dt = _login.CheckEmail();

        if (dt.Rows.Count > 0)
        {
            _login.UserId = Convert.ToInt64(dt.Rows[0]["UserID"].ToString());
            _login.CourseId = Convert.ToInt64(Exam);
            DataTable dtCourse = _login.CheckCourse();

            if (dtCourse.Rows.Count > 0)
            {
                if (dtCourse.Rows[0]["CourseID"].ToString() == Exam.ToString())
                {
                    return "CourseAlreadyRegistered";
                }
                else
                {
                    return "AlreadyRegistered";
                }
            }
            else
            {
                _survey.UserID = Convert.ToInt64(dt.Rows[0]["UserID"].ToString());
                _survey.CourseID = Convert.ToInt64(Exam);
                _survey.AddUserCourse();

                return "CourseRegistered";
            }
        }
        else
        {
            _login.FirstName = Name.ToString();
            _login.Email = Email.ToString();
            _login.RegisteredDate = Configuration.Datetime();
            _login.RegisteredIPAddress = Configuration.IPAddress();
            long UserId = _login.Registration();

            _survey.UserID = UserId;
            _survey.CourseID = Convert.ToInt64(Exam);
            _survey.AddUserCourse();

            return "UserRegistered";
        }
    }

    List<Questions> questions = new List<Questions>();

    [WebMethod]
    public List<Questions> GetRandomQuestion(int Exam)
    {
        GetQuestions(Exam);
        return questions;
    }

    public void GetQuestions(int Exam)
    {
        //clsQuestion objQuePaper = new clsQuestion();

        //DataTable dt = _dal.GetDataTable("Select * from tblSurveyAddQuestion Where QuestionType=" + Exam + "", "TEXT");

        //if (dt != null)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //        {
        //            Questions objQuestion = new Questions();
        //            objQuestion.Exam = Convert.ToInt64(dt.Rows[i]["QId"]);

        //            DataTable dt2 = new DataTable();
        //            dt2 = _dal.GetDataTable(String.Format("Select QOptionId,QOptionText,IsAnswered from tblNQOption where QId={0}", Convert.ToString(dt.Rows[i]["QId"])), "TEXT");
        //            if (dt2 != null)
        //            {
        //                if (dt2.Rows.Count > 0)
        //                {
        //                    List<QuestionOptions> questionOptions = new List<QuestionOptions>();
        //                    for (int k = 0; k <= dt2.Rows.Count - 1; k++)
        //                    {
        //                        try
        //                        {
        //                            QuestionOptions objQUestionOption = new QuestionOptions();
        //                            objQUestionOption.QOptionsId = Convert.ToString(dt2.Rows[k]["QOptionId"]);
        //                            objQUestionOption.OptionText = HttpUtility.HtmlDecode(Convert.ToString(dt2.Rows[k]["QOptionText"]));
        //                            objQUestionOption.IsAnswered = Convert.ToString(dt2.Rows[k]["IsAnswered"]);

        //                            questionOptions.Insert(k, objQUestionOption);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            string error = ex.Message.ToString();
        //                        }
        //                    }
        //                    try
        //                    {
        //                        objQuestion.Options = questionOptions;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        string error = ex.Message.ToString();
        //                    }
        //                }
        //            }

        //            questions.Insert(i, objQuestion);
        //        }
        //    }
        //}
    }
}