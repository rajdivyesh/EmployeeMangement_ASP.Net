using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using Lab1_ASPNetConnectedMode.VALIDATION;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //SqlConnection connDB = UtilityDB.ConnectDB();
            //MessageBox.Show(Convert.ToString(connDB.State), "Database Connection");
            MessageBox.Show("Database Connection is " + UtilityDB.ConnectDB().State.ToString());
            Response.Redirect("WebFormEmployee.aspx");

        }
    }
}