using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class Admin
    {
        public static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("****************************************Admin Operations**************************************");
                Console.WriteLine("\n--- Admin Operations ---");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Delete Train");
                Console.WriteLine("3. Update Train");
                Console.WriteLine("4. Exit Admin Menu");
                Console.Write("Choose an operation: ");
                int adminChoice = Convert.ToInt32(Console.ReadLine());

                switch (adminChoice)
                {
                    case 1:
                        AdminOperations.AddTrain();
                        break;

                    case 2:
                        AdminOperations.DeleteTrain();
                        break;

                    case 3:
                        AdminOperations.UpdateTrain();
                        break;

                    case 4:
                        Console.WriteLine("Exiting Admin Menu...");
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Please choose again.");
                        break;
                }
            }
        }
    }
}
