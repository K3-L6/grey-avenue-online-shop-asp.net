using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        catch
        {
            loginText.Text = "Login";
            loginLink.NavigateUrl = "login.aspx";
        }
    }

    

    protected void registerBtn_Click(object sender, EventArgs e)
    {
        if (InputValid())
        {
            //stay log in after registration code
            INFO.currentUser.usertype = "customer";
            INFO.currentUser.id = INFO.registrationCustomer.id;
            INFO.currentUser.username = INFO.registrationCustomer.username;
            INFO.currentUser.password = INFO.registrationCustomer.password;
            INFO.currentUser.lastname = INFO.registrationCustomer.lastname;
            INFO.currentUser.firstname = INFO.registrationCustomer.firstname;
            INFO.currentUser.contactnumber = INFO.registrationCustomer.contactnumber;
            INFO.currentUser.email = INFO.registrationCustomer.email;

            saveToDatabase();
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('You are now fully registered')", true);
            Response.Redirect("index.aspx");
        }
    }

    protected void resendBtn_Click(object sender, EventArgs e)
    {
        EMAIL.grey.send(INFO.registrationCustomer.email, "Grey Avenue Email Verification Code", "Hi " + INFO.registrationCustomer.firstname + "\n\n We would like to verify your account here is your verification code that you can enter in our web page. Thank you\n\n" + "VERIFICATION CODE : " + createCode());
        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Another verification code is sended to your email')", true);
    }

    protected string createCode()
    {
        Random r = new Random();
        var x = r.Next(0, 1000000);
        string s = x.ToString("000000");
        INFO.registrationCustomer.code = s;
        return s;
    }

    protected void saveToDatabase()
    {
        DATABASE.INSERT.everything("tbl_customers");
    }

    Boolean InputValid()
    {
        if (codeFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        if (!codeFld.Text.Equals(INFO.registrationCustomer.code))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Verification Code is Incorect')", true);
            return false;
        }

        
        return true;
    }
}