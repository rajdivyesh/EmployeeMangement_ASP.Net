using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows;

namespace Lab1_ASPNetConnectedMode.BLL
{
    public class Employee
    {
        private string connectionString = "Data Source=.;Initial Catalog=EmployeeDB;User ID=sa;Password=sysadm";

        //private class variables
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;
        //properties
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        //custom methods

        //public void SaveEmployee(Employee emp)
        //{
        //    EmployeeDB.SaveRecord(emp);
        //}
        // Save new employee data to the database

        public bool SaveEmployee(string empID, string fName, string lName, string jobTitle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string selectQuery = "SELECT COUNT(*) FROM employees WHERE EmployeeID = @EmpID";
                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmpID", empID);
                        int existingRecordsCount = (int)cmd.ExecuteScalar();

                        if (existingRecordsCount > 0)
                        {
                            // The record with the same ID already exists, perform an UPDATE
                            string updateQuery = "UPDATE employees SET FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle WHERE EmployeeID = @EmpID";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                            {
                                updateCmd.Parameters.AddWithValue("@EmpID", empID);
                                updateCmd.Parameters.AddWithValue("@FirstName", fName);
                                updateCmd.Parameters.AddWithValue("@LastName", lName);
                                updateCmd.Parameters.AddWithValue("@JobTitle", jobTitle);

                                int rowsAffected = updateCmd.ExecuteNonQuery();
                                return rowsAffected > 0; // Return true if at least one row was updated
                            }
                        }
                        else
                        {
                            // The record with the same ID doesn't exist, perform an INSERT
                            string insertQuery = "INSERT INTO employees (EmployeeID, FirstName, LastName, JobTitle) VALUES (@EmpID, @FirstName, @LastName, @JobTitle)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@EmpID", empID);
                                insertCmd.Parameters.AddWithValue("@FirstName", fName);
                                insertCmd.Parameters.AddWithValue("@LastName", lName);
                                insertCmd.Parameters.AddWithValue("@JobTitle", jobTitle);

                                int rowsAffected = insertCmd.ExecuteNonQuery();
                                return rowsAffected > 0; // Return true if at least one row was inserted
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log the error)
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }


        public bool DeleteEmployee(string employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM employees WHERE EmployeeID = @EmployeeID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateEmployee(string employeeID, string firstName, string lastName, string jobTitle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE employees SET FirstName = @FirstName, LastName = @LastName, JobTitle = @JobTitle WHERE EmployeeID = @EmployeeID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@JobTitle", jobTitle);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}