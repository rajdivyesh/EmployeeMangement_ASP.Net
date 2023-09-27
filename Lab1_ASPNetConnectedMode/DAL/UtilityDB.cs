using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class UtilityDB
    {
        //Version 1: Working but not good.Why? Another better solution?
        /// <summary>
        /// This method returns an active database connection
        /// </summary>
        /// <returns>object of type SqlConnection</returns>
        public static SqlConnection ConnectDB()
        {
            /*SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=DEV\\SQL2019Express;database=EmployeeDB;user=sa;password=sysadm";
            conn.Open();
            */

            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EmployeeDB";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = cs.ConnectionString;
            conn.Open();

            return conn;

        }
    }
}