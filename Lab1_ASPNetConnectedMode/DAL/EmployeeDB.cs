using Lab1_ASPNetConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class EmployeeDB
    {
        // <summary>
        // This method saves an Employee object data to the database;
        // Version 1
        // </summary>
        // <param name = "emp" ></ param >
        public static void SaveRecord(Employee emp)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Employees " +
            "VALUES (" + emp.EmployeeId + ",'" +
            emp.FirstName + "','" +
            emp.LastName + "','" +
            emp.JobTitle + "')";
            cmd.ExecuteNonQuery();
            connDB.Close();
        }
    }
}