using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mini_Project
{
    class AdminOperations
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        static SqlConnection getConnection()
        {
            con = new SqlConnection("Server=ICS-LT-D244D69Q;initial catalog=project;Integrated Security=true");
            con.Open();
            return con;
        }
        public static void AddTrain()
        {
            con = getConnection();
            Console.WriteLine("Enter Train Number: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Train Name: ");
            string trainName = Console.ReadLine();

            Console.WriteLine("Enter total Berths: ");
            int totalBerths = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter available Berths: ");
            int availableBerths = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Source: ");
            string source = Console.ReadLine();

            Console.WriteLine("Enter Destination: ");
            string destination = Console.ReadLine();
            cmd = new SqlCommand("insert into Trains values(@tid,@tname,@total,@available,@tsource,@tdestination,1)", con);

            cmd.Parameters.AddWithValue("@tid", trainNo);
            cmd.Parameters.AddWithValue("@tname", trainName);
            cmd.Parameters.AddWithValue("@total", totalBerths);
            cmd.Parameters.AddWithValue("@available", availableBerths);
            cmd.Parameters.AddWithValue("@tsource", source);
            cmd.Parameters.AddWithValue("@tdestination", destination);

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                Console.WriteLine("Inserted Successfully");
            else
                Console.WriteLine("Could not Insert..");
        }
        public static void UpdateTrain()
        {
            con = getConnection();
            Console.Write("Enter Train Number to update: ");
            int trainNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("What do you want to modify?");
            Console.WriteLine("1. Train Name");
            Console.WriteLine("2. Source");
            Console.WriteLine("3. Destination");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            string attribute = "";
            switch (choice)
            {
                case 1:
                    attribute = "trainName";
                    break;
                case 2:
                    attribute = "Source";
                    break;
                case 3:
                    attribute = "Destination";
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.Write($"Enter new value for {attribute}: ");
            string value = Console.ReadLine();
            string query = $"update Trains set {attribute}=@val where Train_No=@tno";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.Parameters.AddWithValue("@tno", trainNumber);
            cmd1.Parameters.AddWithValue("@val", value);
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Updated Successfully");

        }
        public static void DeleteTrain()
        {
            con = getConnection();
            Console.WriteLine("Enter train number to delete :");
            string trainid = Console.ReadLine();
            SqlCommand cmd2 = new SqlCommand("update Trains set IsActive = 0 where Train_No = @t_id;", con);
            cmd2.Parameters.AddWithValue("@t_id", trainid);
            cmd2.ExecuteNonQuery();
            Console.WriteLine("Record Deleted Successfully..");
        }
    }
}
