using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        oldFld.Text = INFO.currentUser.email;
        try
        {
            if (INFO.currentUser.usertype.Equals("customer"))
            {
                loginText.Text = "My Account";
                loginLink.NavigateUrl = "myaccount.aspx";
            }
            else
            {
                loginText.Text = "Login";
                loginLink.NavigateUrl = "login.aspx";
            }
        }
        catch {
            loginText.Text = "Login";
            loginLink.NavigateUrl = "login.aspx";
        }
    }


    protected void changeBtn_Click(object sender, EventArgs e)
    {
        if (InputValid())
        {
            INFO.currentUser.email = newFld.Text;
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please check your email for the verification code')", true);
            EMAIL.grey.send(INFO.currentUser.email , "Grey Avenue Email Verification Code", "Hi " + INFO.currentUser.firstname + "\n\n We would like to verify your account here is your verification code that you can enter in our web page. Thank you\n\n" + "VERIFICATION CODE : " + createCode());
            Response.Redirect("myaccount_change_email_verification.aspx");
        }
    }

    protected string createCode()
    {
        Random r = new Random();
        var x = r.Next(0, 1000000);
        string s = x.ToString("000000");
        INFO.currentUser.code = s;
        return s;
    }

    Boolean InputValid()
    {
        if (newFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        List<string> emailData = DATABASE.GETDATA.everything("tbl_customers", "email");
        Boolean emailExist = false;
        foreach (string x in emailData)
        {
            if (x.Equals(newFld.Text))
            {
                emailExist = true;
            }
        }

        if (emailExist)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Email is already registered')", true);
            return false;
        }
        return true;
    }
}