using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.DAL;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        private string connectionString = "Data Source=.;Initial Catalog=EmployeeDB;User ID=sa;Password=sysadm";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                DropDownList1.Visible = true;

            }
        }

        protected void btnLstAll_Click(object sender, EventArgs e)
        {
            // Fetch all data from the database table
            DataTable allData = GetAllEmployees();

            // Bind the data to the GridView
            GridView1.DataSource = allData;
            GridView1.DataBind();
        }

        private DataTable GetAllEmployees()
        {
            // Use ADO.NET to query the database for all data
            // Create a SqlConnection, SqlCommand, and execute the SELECT query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM employees";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchCriteria = DropDownList1.SelectedValue;
            string searchValue = TextBoxSearchEmpID.Text;

            // Perform a database query based on the selected criteria and value
            DataTable searchResults = SearchEmployees(searchCriteria, searchValue);

            // Bind the search results to the GridView
            GridView1.DataSource = searchResults;
            GridView1.DataBind();
        }
        private DataTable SearchEmployees(string searchCriteria, string searchValue)
        {
            // Use ADO.NET to query the database based on the search criteria and value
            // Create a SqlConnection, SqlCommand, and execute the SELECT query
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = $"SELECT * FROM employees WHERE {searchCriteria} = @SearchValue";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", searchValue);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList1.SelectedIndex)
            {
                case 0: //Search by ID
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter Employee ID : ";
                    }
                    lblDisplay.Text = Session["message"].ToString();
                    TextBoxSearchEmpID.Focus();
                    break;

                case 1:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter First Name : ";
                    }
                    lblDisplay.Text = Session["message"].ToString();
                    TextBoxFName.Focus();

                    break;

                case 2:
                    if (Page.IsPostBack)
                    {
                        Session["message"] = "Please enter Last Name : ";
                    }
                    lblDisplay.Text = Session["message"].ToString();
                    TextBoxLName.Focus();
                    break;

                default:
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Get data from textboxes
            string empID = TextBoxEmpID.Text;
            string fName = TextBoxFName.Text;
            string lName = TextBoxLName.Text;
            string jobTitle = TextBoxJobTitle.Text;
            Employee employee = new Employee();

            // Insert data into the database
            if (employee.SaveEmployee(empID, fName, lName, jobTitle))
            {
                // If the save is successful, display a success message
                lblDisplay.Text = "Employee saved successfully.";
                ClearTextFields(); // Clear textboxes
            }
            else
            {
                // If there is an error, display an error message
                lblDisplay.Text = "Failed to save employee.";
            }
        }

        // Clear all text fields
        private void ClearTextFields()
        {
            TextBoxEmpID.Text = string.Empty;
            TextBoxFName.Text = string.Empty;
            TextBoxLName.Text = string.Empty;
            TextBoxJobTitle.Text = string.Empty;
            TextBoxSearchEmpID.Text = string.Empty;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = GridView1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < GridView1.Rows.Count)
            {
                GridViewRow selectedRow = GridView1.Rows[selectedIndex];
                TextBoxEmpID.Text = selectedRow.Cells[1].Text; // EmployeeID
                TextBoxFName.Text = selectedRow.Cells[2].Text; // FirstName
                TextBoxLName.Text = selectedRow.Cells[3].Text; // LastName
                TextBoxJobTitle.Text = selectedRow.Cells[4].Text; // JobTitle
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string empID = TextBoxEmpID.Text;
            string fName = TextBoxFName.Text;
            string lName = TextBoxLName.Text;
            string jobTitle = TextBoxJobTitle.Text;
            Employee employee = new Employee();

            btnLstAll_Click(sender, e);

            if (employee.UpdateEmployee(empID, fName, lName, jobTitle))
            {
                // If the save is successful, display a success message
                lblDisplay.Text = "Employee update successfully.";
                ClearTextFields(); // Clear textboxes
            }
            else
            {
                // If there is an error, display an error message
                lblDisplay.Text = "Failed to update employee.";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string empID = TextBoxEmpID.Text;
            
            Employee employee = new Employee();

            btnLstAll_Click(sender, e);
            if (employee.DeleteEmployee(empID))
            {
                // If the save is successful, display a success message
                lblDisplay.Text = "Employee delete successfully.";
            }
            else
            {
                // If there is an error, display an error message
                lblDisplay.Text = "Failed to delete employee.";
            }

            ClearTextFields();
        }
    }
}