using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : ApiController
    {
        private SqlCommand cmd;

        public HttpResponseMessage Get()
        {
            string query = @" select departmentId, departmentName from dbo.Department ";

            DataTable table = new DataTable();
            using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeBD"].ConnectionString))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Post(Department dep)
        {
            try
            {
                string query = @"
                      insert into dbo.Department values
                      ('" + dep.departmentName + @"')
                      ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeBD"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully!!";

            } catch (Exception)
            {
                return "Failed to Add!!";
            }
        }


        public string Put(Department dep)
        {
            try
            {
                string query = @"
                     update  dbo.Department set departmentName=
                      '" + dep.departmentName + @"'
                       where departmentId=" + dep.departmentId + @"
                      ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeBD"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully!!";

            }
            catch (Exception)
            {
                return "Failed to Update!!";
            }
        }



            public string Delete(int id)
            {
                try
                {
                    string query = @"
                     delete from  dbo.Department 
                       where departmentId=" + id + @"
                      ";
                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeBD"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                    return "Deleted Successfully!!";

                }
                catch (Exception)
                {
                    return "Failed to Delete!!";
                }
            }
        }
}
