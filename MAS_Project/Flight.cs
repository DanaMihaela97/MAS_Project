using System;

namespace Proiect_MAS
{
    public class Flight
    {
        public string Departure { get; }
        public string Destination { get; }
        public DateTime DepartureTime { get; }
        public DateTime ArrivalTime { get; }
        public double Price { get; }

        public Flight(string departure, string destination, DateTime departureTime, DateTime arrivalTime, double price)
        {
            Departure = departure;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Departure} -> {Destination}, {DepartureTime.ToString()} -> {ArrivalTime.ToString()}, {Price} EUR";
        }
    }
}
