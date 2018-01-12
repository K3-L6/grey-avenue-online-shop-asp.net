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
        oldFld.Text = INFO.currentUser.lastname;
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
            DATABASE.UPDATE.byfield("tbl_customers", "lastname", INFO.currentUser.id, newFld.Text.ToUpper());
            INFO.currentUser.lastname = newFld.Text.ToUpper(); ;
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
        return true;
    }
}