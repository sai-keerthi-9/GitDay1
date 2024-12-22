using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    class User
    {
        public static void UserMenu()
        {
            while(true)
            { 
            Console.WriteLine("****************************************User Operations**************************************");
            Console.WriteLine("\n--- User Operations ---");
            Console.WriteLine("1. Book Tickets");
            Console.WriteLine("2. Cancel Ticket");
            Console.WriteLine("3.Show all trains");
            Console.WriteLine("4. Show all booking details");
            Console.WriteLine("5. Exit User Menu");
            Console.Write("Choose an operation: ");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    UserOperations.BookTrainTicket();
                    break;

                case 2:
                    UserOperations.CancelBooking();
                    break;
                case 3:
                    UserOperations.ShowAllTrains();
                    break;

                case 4:
                    UserOperations.ShowBookings();
                    break;
                case 5:
                    Console.WriteLine("Exiting User Menu...");
                    return;
                default:
                    Console.WriteLine("Invalid Option. Please choose again.");
                    break;
            }
            }
        }
    }
}
