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

    protected void nextBtn_Click(object sender, EventArgs e)
    {
        if (InputValid())
        {
            INFO.registrationCustomer.lastname = lastNameFld.Text.ToUpper();
            INFO.registrationCustomer.firstname = firstNameFld.Text.ToUpper();
            INFO.registrationCustomer.email = emailFld.Text;
            INFO.registrationCustomer.contactnumber = contactFld.Text;
            INFO.registrationCustomer.id = randomID();
            while (!checkID(INFO.registrationCustomer.id))
            {
                INFO.registrationCustomer.id = randomID();
            }
            Response.Redirect("register_final.aspx");
        }
    }

    Boolean InputValid()
    {
        if (lastNameFld.Text.Equals("") || firstNameFld.Text.Equals("") || contactFld.Text.Equals("") || emailFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        List<string> emailData = DATABASE.GETDATA.everything("tbl_customers", "email");
        Boolean emailExist = false;
        foreach (string x in emailData)
        {
            if (x.Equals(emailFld.Text))
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

    string randomID()
        {
            Random r = new Random();
            var x = r.Next(0, 1000000);
            string year = DateTime.Now.Year.ToString();
            string month = "";
            if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 10)
            {
                month = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                month = DateTime.Now.Month.ToString();
            }
            string id = year + "-" + month + "-" + x.ToString("000000");
            return id;
        }

    Boolean checkID(string id)
    {
        Boolean c = true;
        List<string> idData = DATABASE.GETDATA.everything("tbl_customers", "id");
        foreach (string x in idData)
        {
            if (x.Equals(id))
            {
                c = false;
            }
        }
        return c;
    }



}