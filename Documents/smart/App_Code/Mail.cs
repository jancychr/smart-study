using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Net.Mail;

public class Mail
{
    public bool SendMail(string MessageTo, string MessageBody, string Subject)
    {
        bool isSent = false;
        SmtpClient Client = new SmtpClient();
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(Configuration.SMTPEmail, Configuration.SMTPName);
        mailMessage.To.Add(MessageTo);
        mailMessage.Subject = Subject;
        mailMessage.Body = MessageBody;
        mailMessage.IsBodyHtml = true;
        Client.Host = Configuration.SMTPHost;
        Client.Port = Configuration.SMTPPort;
        System.Net.NetworkCredential nc = new System.Net.NetworkCredential(Configuration.EmailUserName, Configuration.EmailPassword);
        Client.UseDefaultCredentials = false;
        Client.Credentials = nc;
        Client.EnableSsl = false;
        try
        {
            Client.Send(mailMessage);
            isSent = true;
        }
        catch (Exception ex)
        {
            string errror = ex.Message.ToString();
            isSent = false;
        }
        return isSent;
    }

    public bool SendMail(string MessageTo, string MessageBody, string Subject, string AttachedFileName)
    {
        bool isSent = false;
        SmtpClient Client = new SmtpClient();
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(Configuration.SMTPEmail, Configuration.SMTPName);
        mailMessage.To.Add(MessageTo);
        mailMessage.Subject = Subject;
        mailMessage.Body = MessageBody;
        mailMessage.IsBodyHtml = true;

        //Attachement Coding

        Attachment at = new Attachment(HttpContext.Current.Server.MapPath("~//images//UploadDocument//" + AttachedFileName));
        mailMessage.Attachments.Add(at);

        //Attachement Coding

        Client.Host = Configuration.SMTPHost;
        Client.Port = Configuration.SMTPPort;
        System.Net.NetworkCredential nc = new System.Net.NetworkCredential(Configuration.EmailUserName, Configuration.EmailPassword);
        Client.UseDefaultCredentials = false;
        Client.Credentials = nc;
        Client.EnableSsl = false;
        try
        {
            Client.Send(mailMessage);
            isSent = true;
        }
        catch (Exception ex)
        {
            string errror = ex.Message.ToString();
            isSent = false;
        }
        return isSent;
    }
}