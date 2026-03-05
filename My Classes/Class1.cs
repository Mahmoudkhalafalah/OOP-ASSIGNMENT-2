using System.Runtime.CompilerServices;

namespace My_Classes
{
    public enum TicketType
    {
        Standard,
        VIP,
        IMAX
    }
    public struct Location
    {
        int number;
        char row;

        public Location(int number, char row)
        {
            this.number = number;
            this.row = row;
        }
        public override string ToString()
        {
            return ($"{row}{number}");
        }
    }
    public class Ticket
    {
        private string _movieName;
        private double _price;

        static int ticketCount = 0;
        public int ticketId;
        public string movieName
        {
            get
            {
                return _movieName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _movieName = value;
                }
            }
        }
        public TicketType type { get; set; }

        public Location seat { get; set; }
        public double price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                    _price = value;
            }
        }
        public double priceAfterTax
        {
            get => 1.14 * this.price;
        }
        public Ticket(string movieName, TicketType type, Location seat, double price)
        {
            this.movieName = movieName;
            this.type = type;
            this.price = price;
            this.seat = seat;
            ticketCount++;
            this.ticketId = ticketCount;
        }
        public Ticket(string movieName)
        {
            this.movieName = movieName;
            this.type = TicketType.Standard;
            this.price = 50;
            this.seat = new Location(1, 'A');
            ticketCount++;
            this.ticketId = ticketCount;

        }
        public double calcTotal(double taxPercent)
        {
            return (1 + taxPercent) * this.price;
        }
        public void ApplyDiscount(ref double discountAmount)
        {
            if (discountAmount > 0 && discountAmount <= this.price)
            {
                this.price -= discountAmount;
                discountAmount = 0;
            }
        }
        public static int GetTotalTicketsSold()
        {
            return ticketCount;
        }

        public void PrintTicket()
        {
            Console.WriteLine($"Movie   : {this.movieName}");
            Console.WriteLine($"Type    : {this.type}");
            Console.WriteLine($"Seat    : {this.seat}");
            Console.WriteLine($"Price   : {this.price:F2}");
            Console.WriteLine(($"Price after tax: {this.priceAfterTax:F2}"));
        }
    }
    public class Cinema
    {
        private static Ticket[] _tickets = new Ticket[20];

        public Ticket this[int index]
        {
            get => index < _tickets.Length ? _tickets[index] : null;
        }

        public Ticket? this[string name]
        {
            get
            {
                foreach (Ticket ticket in _tickets)
                {
                    if (ticket != null && ticket.movieName == name)
                    {
                        return ticket;
                    }
                }
                return null;
            }
        }

        public static bool AddTicket(Ticket ticket)
        {
            for (int i = 0; i < _tickets.Length; i++)
            {
                if (_tickets[i] == null)
                {
                    _tickets[i] = ticket;
                    return true;
                }
            }
            return false;
        }
    }
    public static class BookingHelper
    {
        private static int counter = 1;
        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            return numberOfTickets >= 5 ? pricePerTicket * 0.9 * numberOfTickets : numberOfTickets * pricePerTicket;
        }

        public static string GenerateBookingReference()
        {
            return $"BK-{counter++}";
        }

    }
}
