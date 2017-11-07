using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;

public partial class Registration : System.Web.UI.Page
{
    ICS_Login _reg = new ICS_Login();
    Dropdown _dropdown = new Dropdown();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategory();
        }
    }

    private void BindCategory()
    {
        DataTable dt = _dropdown.GetCategory();

        if (dt.Rows.Count > 0)
        {
            drpCategory.DataSource = dt;
            drpCategory.DataTextField = "TextField";
            drpCategory.DataValueField = "ValueField";
            drpCategory.DataBind();
        }
    }

    private bool CheckEmail()
    {
        _reg.Email = txtEmail.Text.Trim();
        DataTable dt = _reg.CheckEmail();

        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Regex rgxName = new Regex(@"^[a-zA-Z ]+$");
        Regex rgxEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        Regex rgxContactNumber = new Regex(@"^\d{10}$");

        try
        {
            if (txtFirstName.Text.Trim() == "" || !rgxName.IsMatch(txtFirstName.Text.Trim()))
            {
                lblNote.Text = "Please Enter Valid First Name";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtLastName.Text.Trim() == "" || !rgxName.IsMatch(txtLastName.Text.Trim()))
            {
                lblNote.Text = "Please Enter Valid Last Name";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtEmail.Text.Trim() == "" || !rgxEmail.IsMatch(txtEmail.Text.Trim()))
            {
                lblNote.Text = "Please Enter Valid Email Address";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else if (CheckEmail())
            {
                lblNote.Text = "This Email Address is already Registered With us";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtPassword.Text.Trim() == "" || txtPassword.Text.Trim().Length < 5)
            {
                lblNote.Text = "Please Enter Password with more than 5 Characters";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                lblNote.Text = "Confirm Password does not match";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtContact.Text.Trim() == "" || !rgxContactNumber.IsMatch(txtContact.Text.Trim()))
            {
                lblNote.Text = "Only 10 Digit Contact Number is allowed";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else if (drpCategory.SelectedValue == "-999999")
            {
                lblNote.Text = "Please Select Course";
                lblNote.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Guid random = Guid.NewGuid();
                string pID = random.ToString();

                _reg.PersonalID = pID.Substring(0, 36);
                _reg.FirstName = txtFirstName.Text.Trim();
                _reg.LastName = txtLastName.Text.Trim();
                _reg.Email = txtEmail.Text.Trim();
                _reg.Password = txtPassword.Text.Trim();
                _reg.ContactNumber = Convert.ToInt64(txtContact.Text.Trim());
                long UserId = Convert.ToInt64(_reg.Registration());

                _reg.CourseId = Convert.ToInt64(drpCategory.SelectedValue);
                _reg.UserId = UserId;
                _reg.CourseRegistration();

                Mail _email = new Mail();
                StringBuilder sb = new StringBuilder();
                sb.Append("Hello " + txtFirstName.Text + " " + txtLastName.Text + ",");
                sb.Append("<br/>");
                sb.Append("Greetings from Smart Study!");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("Thank you for Registering with us. Please Activate your account.");
                sb.Append("<br/>");
                sb.Append("<a href='http://smartstudy.mytestbuddy.net/Activate.aspx?type=mtb_smartstudy&uid=" + UserId + "&data=" + pID.Substring(0, 36) + "'>Activate Account</a>");
                sb.Append("<br/>");
                sb.Append("<br/>");
                sb.Append("<b>Thanks & Regards,</b>");
                sb.Append("<br/>");
                sb.Append("Smart Study Team");

                _email.SendMail(txtEmail.Text, sb.ToString(), "Congratulations! You have successfully created account on Smart Study");

                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtContact.Text = "";
                drpCategory.SelectedValue = "-999999";

                lblNote.Text = "You have successfully Created account.<br/>Please Check your Email for Account Activation.";
                lblNote.ForeColor = System.Drawing.Color.Green;
            }
        }
        catch (Exception ex)
        {
            lblNote.Text = ex.Message.ToString();
            lblNote.ForeColor = System.Drawing.Color.Red;

            Mail _email = new Mail();
            _email.SendMail("Jeetenfriend@gmail.com", ex.Message.ToString(), "Error in Registration()");
        }
    }
}