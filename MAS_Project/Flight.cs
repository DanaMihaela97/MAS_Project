using System;

namespace Proiect_MAS
{
    public class Flight
    {
        public string Departure { get; }
        public string Destination { get; }
        public double Duration { get; }
        public double Price { get; }
        public string Company { get; set; }

        public Flight(string departure, string destination, double duration, double price, string company)
        {
            Departure = departure;
            Destination = destination;
            Duration = duration;
            Price = price;
            Company = company;
        }

        public override string ToString()
        {
            return $"{Departure} -> {Destination}, {Duration}h, {Price} EUR, ({Company})";
        }
    }
}
