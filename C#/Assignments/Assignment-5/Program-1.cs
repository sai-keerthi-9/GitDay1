using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Book
    {
        string Book_Name;
        string Author_Name;
        public Book(string book_name, string author_name)
        {
            Book_Name = book_name;
            Author_Name = author_name;
        }
        public void Display()
        {
            Console.WriteLine("Book Name : {0} ", Book_Name);
            Console.WriteLine("Author Name : {0} ", Author_Name);
        }
    }
    class Bookshelf
    {
        Book[] bobj = new Book[5];
        public Book this[int pos]
        {
            get
            {
                return bobj[pos];
            }
            set
            {
                bobj[pos] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Enter Book class Details-----");
            Console.WriteLine("Enter the book name");
            string bname = Console.ReadLine();
            Console.WriteLine("Enter the author name");
            string aname = Console.ReadLine();
            Book b = new Book(bname, aname);
            Console.WriteLine("-----Displaying Book class Details-----");
            b.Display();

            Console.WriteLine("-----Indexers Example----");
            Bookshelf bs = new Bookshelf();
            Console.WriteLine("-----Entering Book Details----");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("enter the {0} book name", i + 1);
                string bookname = Console.ReadLine();
                Console.WriteLine("enter the {0} author name", i + 1);
                string authorname = Console.ReadLine();
                bs[i] = new Book(bookname, authorname);
            }
            Console.WriteLine("-----Displaying Book Details----");
            for (int j = 0; j < 5; j++)
            {
                bs[j].Display();
            }
            Console.Read();

        }
    }
}
