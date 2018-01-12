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
        oldFld.Text = INFO.currentUser.username;
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
            DATABASE.UPDATE.byfield("tbl_customers", "username", INFO.currentUser.id, newFld.Text);
            INFO.currentUser.username = newFld.Text;
            Response.Redirect("myaccount.aspx");
        }
    }

    Boolean InputValid()
    {
        if (newFld.Text.Equals(""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Please Complete The Form')", true);
            return false;
        }

        if (newFld.Text.Length < 8 || newFld.Text.Length > 24)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Username length should be more than 8 but not greater than 24')", true);
            return false;
        }

        List<string> usernameData = DATABASE.GETDATA.everything("tbl_customers", "username");
        Boolean usernameExist = false;
        foreach (string x in usernameData)
        {
            if (x.Equals(newFld.Text))
            {
                usernameExist = true;
            }
        }

        if (usernameExist)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "alert('Username is already registered')", true);
            return false;
        }


        return true;
    }
}