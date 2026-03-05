using My_Classes;
using System.Xml.Linq;
namespace OOP_Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 1
            #region Question 1
            // a
            // 1. The balance is public so any one can access it
            // 2. The withdraw method has no amount validation
            // b
            // private balance;
            // public void withdraw(amount){
            // if (amount > 0 && balance > amount){
            // balance -= amount;
            // }}
            // c
            // public fields are not recommended because they can be accessed and modified from outside the class,
            // which can lead to unintended consequences and make it difficult to maintain the integrity of the data.
            // It is generally better to use private fields and provide public methods to access and modify the data,
            // which allows for better control and encapsulation.
            #endregion

            #region Question 2
            // field        property
            // 1. A field is a variable that is declared directly in a class or struct,
            // while a property is a member that provides a flexible mechanism to read, write, or compute the value of a private field.
            // 2. A field can be accessed directly, while a property is accessed through get and set accessors.
            // 3. A field breaks encapsulation, while a property allows for better encapsulation and control over the data.
            // A property can also include validation logic in the set accessor, while a field cannot.

            //    public class test
            //{
            //    public double Subtotal { get; set; }
            //    public double TaxRate { get; set; }
            //    public double TotalPrice
            //    {
            //        get
            //        {
            //            return Subtotal + (Subtotal * TaxRate);
            //        }
            //    }
            //    public double ModernTotalPrice => Subtotal + (Subtotal * TaxRate);
            //}
            #endregion
            #region Question 3
            // a  What is `this[int index]` called? Explain its purpose.
            // `this[int index]` is called an indexer. It allows an object to be indexed like an array,
            // providing a way to access elements of a collection or class using an index.
            // b What happens if someone writes `register[10] = "Ali";` ? How would you make the indexer safer?
            // 10 is out of bounds for the register array, which has a length of 4 (index 0 to 4). This would throw an IndexOutOfRangeException.
            // To make the indexer safer, you can add a check to ensure that the index is within the bounds of the array before trying to access it. For example:
            // public string this[int index]
            // {
            //     get
            //     {
            //         if (index >= 0 && index < register.Length)
            //         {
            //             return register[index];
            //         }
            //         else
            //         {
            //             console.WriteLine("Index out of bounds");
            //             return null;
            //         }
            //     }
            //     set
            //     {
            //         if (index >= 0 && index < register.Length)
            //         {
            //             register[index] = value;
            //         }
            //         else
            //         {
            //             console.WriteLine("Index out of bounds");
            //         }
            //     }
            // c
            // yes a class can have multiple indexers, but they must have different parameter types or a different number of parameters to avoid ambiguity.
            // For example, you could have one indexer that takes an int parameter like phone number and another that takes a string parameter like username.
            #endregion

            #region Question 4
            // a
            // static members belong to the class itself rather than to any specific instance of the class.
            // They can be accessed without creating an instance of the class,
            // and they are shared among all instances of the class
            // Non-static members, on the other hand, belong to a specific instance of the class and can only be accessed through that instance.
            // Each instance of the class has its own copy of non-static members, and they can have different values for each instance.
            // b 
            // static methods cannot access non-static members directly because they do not have an instance of the class to reference.
            #endregion
            #endregion

            #region Part 2
            Console.WriteLine("========= Ticket Booking ===========");
            Cinema cinema = new Cinema();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter Data for ticket {i + 1}:");
                Console.Write("Enter Movie Name: ");
                string name = Console.ReadLine() ?? "Unknown";

                Console.Write("Enter Ticket Type (0 = Standard, 1 = VIP, 2 = IMAX): ");
                TicketType type;
                Enum.TryParse(Console.ReadLine(), out type);


                Console.Write("Enter Seat Row (A, B, C...): ");
                char row;
                char.TryParse(Console.ReadLine()?.ToUpper(), out row);

                Console.Write("Enter Seat Number: ");
                int num;
                int.TryParse(Console.ReadLine(), out num);

                Console.Write("Enter Price: ");
                double price;
                double.TryParse(Console.ReadLine(), out price);
                Ticket myTicket = new Ticket(name, type, new Location(num, row), price);
                Cinema.AddTicket(myTicket);
            }
            Console.WriteLine("========= All Tickets ===========");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Ticket {i + 1}:");
                cinema[i]?.PrintTicket();
                Console.WriteLine();
            }
            Console.WriteLine("========= Search By Movie ===========");

            Console.Write("Enter Movie Name to search: ");
            string bookName = Console.ReadLine() ?? "Unknown";
            if (cinema[bookName] != null)
            {
                Console.WriteLine("Found: ");
                cinema[bookName]?.PrintTicket();
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }

            Console.WriteLine("========= Statistics ===========");


            Console.WriteLine($"Total Tickets Sold: {Ticket.GetTotalTicketsSold()}");

            Console.WriteLine($"Book Reference 1: {BookingHelper.GenerateBookingReference()}");
            Console.WriteLine($"Book Reference 2: {BookingHelper.GenerateBookingReference()}");

            Console.WriteLine($"Group Discount (5 tickets x 80 EGP) {BookingHelper.CalcGroupDiscount(5, 80)}");

            #endregion

        }
    }
}
