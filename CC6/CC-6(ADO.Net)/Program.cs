using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CC_6_ADO.Net_
{
    class Program
    {
        public static SqlConnection con=null;
        public static SqlCommand cmd=null;

        static void Main(string[] args)
        {

            using (SqlConnection con = new SqlConnection("Server=ICS-LT-D244D69Q;initial catalog=assessments; integrated security=true;"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Product_Details", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //input for procedure

                    cmd.Parameters.Add(new SqlParameter("@pname", "p1"));
                    cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.Int)).Value = 50000;
                    //output for procedure
                    SqlParameter param1 = new SqlParameter("@pid", SqlDbType.Int);
                    param1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param1);
                    SqlParameter param2 = new SqlParameter("@discount", SqlDbType.Float);
                    param2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param2);
                    cmd.ExecuteNonQuery();
                    int product_id = Convert.ToInt32(cmd.Parameters["@pid"].Value);
                    int discount = Convert.ToInt32(cmd.Parameters["@discount"].Value);

                    Console.WriteLine($"Product ID : {product_id}  ,  Discount Price : {discount}");

                }
            }
        Console.Read();
            }
           
        }
    }
