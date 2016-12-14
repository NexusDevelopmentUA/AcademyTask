using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AcademyTask
{
    public class SQL_repository
    {
        public const string constring = "Data Source=(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\aspnet-AcademyTask-20161129113406.mdf;Initial Catalog=aspnet-AcadeTask-20161129113406;Integrated Security=True";
        private SqlConnection connection = new SqlConnection(constring);
         
        public void SQL_Con()
        {
            //SqlConnection connection = new SqlConnection(constring);
            try
            {
              connection.Open();
                Console.WriteLine("Success!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public string SQL_Query(string in_query)
        {
            string result;
            SqlCommand query = new SqlCommand(in_query, connection);
            try
            {
                query.ExecuteScalar();
                result = "Success!";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                result = e.Message;
            }
            connection.Close();
            return result;
        }
        public string SQLselect_string(string query_in)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            string result;
            string query = "input params and other stuff...";
            query = query_in;

            try
            {
                SqlCommand select = new SqlCommand(query, connection);
                connection.Open();
                result = select.ExecuteScalar().ToString();
                Console.WriteLine("Query successfully done!");
            }
            catch (Exception e)
            {
                result = e.Message;
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return (result);
        }
    }
}