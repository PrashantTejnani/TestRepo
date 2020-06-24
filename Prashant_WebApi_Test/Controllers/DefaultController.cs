using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prashant_WebApi_Test.Models;
using System.Data;
using System.Data.SqlClient;

namespace Prashant_WebApi_Test.Controllers
{
    public class DefaultController : ApiController
    {
        string connString = @"Server=PRASHANT-PC\SQLEXPRESS;Database=test;Integrated Security=True;";


        //Create a static list of string of cities with following values
        public List<string> theList = new List<string>()
        {    "Mumbai","Pune","Bhopal","Delhi","Chennai"   };





        //Create an API to return a list of string order by city.
        [HttpGet]
        public List<string> ReturnListOrderByCity()
        {

            theList = theList.OrderBy(x => x).ToList();

            return theList;


        }

        //Create an API to get records from the Employee table.
        [HttpGet]
        
        public IEnumerable<EmployeeModel> Get()
        {
            DataTable dt = new DataTable();
            EmployeeModel emp = new EmployeeModel();
            List<EmployeeModel> emplist = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Employee" , con);
                sda.Fill(dt);

            }

            foreach (DataRow dr in dt.Rows)
            {
                emp.EmployeeId = (int)dr["EmployeeId"];
                emp.FirstName = dr["FirstName"].ToString();
                emp.LastName = dr["LastName"].ToString();
                emp.JoiningDate = dr["JoiningDate"].ToString();
                emp.salary = (decimal)dr["salary"];
                emp.DepartmentId = (int)dr["DepartMentId"];

                emplist.Add(emp);
            }

            return emplist;


        }



        //Create an API to get records from the Employee table by employee id.
        [HttpGet]
        public EmployeeModel Get(int id)
        {
            DataTable dt = new DataTable();
            EmployeeModel emp = new EmployeeModel();


            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Employee where EmployeeId = @Id", con);
                sda.SelectCommand.Parameters.AddWithValue("@Id" , id);
                sda.Fill(dt);

            }

            foreach (DataRow dr in dt.Rows)
            {
                emp.EmployeeId = (int)dr["EmployeeId"];
                emp.FirstName = dr["FirstName"].ToString();
                emp.LastName = dr["LastName"].ToString();
                emp.JoiningDate = dr["JoiningDate"].ToString();
                emp.salary = (decimal)dr["salary"];
                emp.DepartmentId = (int)dr["DepartMentId"];
            }

            return emp;

        }









    }
}
