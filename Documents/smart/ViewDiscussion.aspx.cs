using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewDiscussion : System.Web.UI.Page
{
    Discussions _dis = new Discussions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["did"] != null)
        {
            if (!IsPostBack)
            {
                BindDiscussion(Request.QueryString["did"].ToString());
                BindDiscussionComments(Request.QueryString["did"].ToString());
            }
        }
    }

    private void BindDiscussion(string DiscussionId)
    {
        _dis.DiscussionId = Convert.ToInt64(DiscussionId);
        DataTable dtDiscussion = _dis.getClickedDiscussion();

        if (dtDiscussion.Rows.Count > 0)
        {
            dlDiscussion.DataSource = dtDiscussion;
            dlDiscussion.DataBind();
        }
    }

    private void BindDiscussionComments(string DiscussionId)
    {
        _dis.DiscussionId = Convert.ToInt64(DiscussionId);
        DataTable dtDiscussionComment = _dis.getDiscussionComment();

        if (dtDiscussionComment.Rows.Count > 0)
        {
            dlDisucssionComment.DataSource = dtDiscussionComment;
            dlDisucssionComment.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtComment.Text.Trim() == "")
        {
            lblNote.Text = "Please Enter Your Comment";
            lblNote.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            _dis.UserID = Convert.ToInt64(Session["UserId"].ToString());
            _dis.DiscussionId = Convert.ToInt64(Request.QueryString["did"].ToString());
            _dis.Comment = txtComment.Text;
            _dis.AddComment();

            txtComment.Text = "";

            lblNote.Text = "Thank you for your Comment!";
            lblNote.ForeColor = System.Drawing.Color.Green;

            BindDiscussionComments(Request.QueryString["did"].ToString());
        }
    }
}