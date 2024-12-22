using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mini_Project
{
    class UserOperations
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        static SqlConnection getConnectionUser()
        {
            con = new SqlConnection("Server=ICS-LT-D244D69Q;initial catalog=project;Integrated Security=true");
            con.Open();
            return con;
        }
        public static void BookTrainTicket()
        {
            using (SqlConnection con = getConnectionUser())
            {

                SqlCommand cmd = new SqlCommand("SelectTrain", con);
                cmd.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Enter the source : ");
                string src = Console.ReadLine();
                Console.WriteLine("Enter the Destination : ");
                string dst = Console.ReadLine();
                cmd.Parameters.Add(new SqlParameter("@tsource", src));
                cmd.Parameters.Add(new SqlParameter("@tdestination", dst));


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Train_No"]}|\t{reader["Train_Name"]}!\t");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                }

                con.Close();
                con.Open();
                cmd = new SqlCommand("BookTickets", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //input parameters
                Console.WriteLine("Enter the train number: ");
                int t_no = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the user ID: ");
                int customer_Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the class(1AC,2AC,Sleeper): ");
                string trainclass = Console.ReadLine();
                Console.WriteLine("Enter the number of seats to book: ");
                int berths = Convert.ToInt32(Console.ReadLine());

                cmd.Parameters.Add(new SqlParameter("@tno", t_no));
                cmd.Parameters.Add(new SqlParameter("@cid", customer_Id));
                cmd.Parameters.Add(new SqlParameter("@tclass", trainclass));
                cmd.Parameters.Add(new SqlParameter("@seats", berths));
                //output parameter
                SqlParameter param = new SqlParameter("@status", SqlDbType.VarChar, 50);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteReader();
                string bookingStatus = Convert.ToString(param.Value);
                Console.WriteLine($"Booking Status :{bookingStatus} ");
                con.Close();
            }
        }
        public static void CancelBooking()
        {
            SqlConnection con = getConnectionUser();
            SqlCommand cmd = new SqlCommand("CancelBooking", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //input parameters
            Console.WriteLine("Enter the booking ID: ");
            int bookingno = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.Add(new SqlParameter("@bid", bookingno));
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Booking Cancelled!");
        }
        public static void ShowAllTrains()
        {
            SqlConnection con = getConnectionUser();
            SqlCommand cmd = new SqlCommand("ShowTrains", con);
            cmd.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("The available trains are : ");
            Console.WriteLine("Train_No|\tTrain_Name|\tSource|\tDestination|\tAvailable Berths");
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"{reader["Train_No"]}|\t{reader["Train_Name"]}|\t{reader["Source"]}|\t{reader["Destination"]}|\t{reader["AvailableBerths"]}|\t");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            }
        }
        public static void ShowBookings()
        {
            SqlConnection con = getConnectionUser();
            cmd = new SqlCommand("select * from Bookings", con);
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                Console.WriteLine($"{reader1["train_no"]}|\t{reader1["BookingId"]}|\t{reader1["CustomerId"]}|\t{reader1["class"]}|\t{reader1["NoOfTicketsNeedToBook"]}|\t");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            }

        }
    }
}
