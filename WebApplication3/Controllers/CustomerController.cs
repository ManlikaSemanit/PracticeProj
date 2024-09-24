using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication3.Controllers
{
    //[Route("[controller]")]
    public class CustomerController : Controller
    {
        //public CustomerController() { }

        [HttpGet]
        [Route("get")]
        public IEnumerable<Customer> Get()
        {
            List<Customer> customerList = new List<Customer>();
            string connectionString = "server=(localdb)\\MSSqlLocalDb;database=TestConnection;integrated Security=SSPI;";

            using (SqlConnection xSqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    xSqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = xSqlCon;
                        cmd.Parameters.Clear();
                        cmd.CommandTimeout = 1200;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_Customer_Sel";
                        cmd.Parameters.Add(new SqlParameter("@ID", 1));
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet dtsResult = new DataSet();
                        adp.Fill(dtsResult);

                        DataTable dtbResult = dtsResult.Tables[0];

                        if (dtbResult.Rows.Count > 0)
                        {
                            return customerList = dtbResult.Rows.Count > 0 ? dtbResult.AsEnumerable().Select(s => new Customer
                            {
                                ID = s.Field<int>("ID"),
                                CusCode = s.Field<string?>("CusCode"),
                                CusName = s.Field<string?>("CusName")
                            }).ToList() : new List<Customer>();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    xSqlCon.Close();
                }
            }

            return customerList;
        }

        [HttpGet]
        [Route("getbyid/{Id}")]
        public Customer GetById(int Id)
        {
            Customer? customerList = new Customer();
            string connectionString = "server=(localdb)\\MSSqlLocalDb;database=TestConnection;integrated Security=SSPI;";

            using (SqlConnection xSqlCon = new SqlConnection(connectionString))
            {
                try
                {
                    xSqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = xSqlCon;
                        cmd.Parameters.Clear();
                        cmd.CommandTimeout = 1200;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "API_Customer_Sel";
                        cmd.Parameters.Add(new SqlParameter("@ID", Id));
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet dtsResult = new DataSet();
                        adp.Fill(dtsResult);

                        DataTable dtbResult = dtsResult.Tables[0];

                        if (dtbResult.Rows.Count > 0)
                        {
                            customerList = dtbResult.Rows.Count > 0 ? dtbResult.AsEnumerable().Select(s => new Customer
                            {
                                ID = s.Field<int>("ID"),
                                CusCode = s.Field<string?>("CusCode"),
                                CusName = s.Field<string?>("CusName")
                            }).FirstOrDefault() : new Customer();
                        }
                        
                    }
                    return customerList;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    xSqlCon.Close();
                }
            }
        }
    }
}
