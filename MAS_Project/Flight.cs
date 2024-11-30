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
        private Flight _parent = null;
        public double G { get; set; }
        public double H { get; set; }

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
        public double GetF()
        {
            H = Price;
            if (_parent == null)
            {
                G = 0;
            }
            else
            {
                G = _parent.Price;
            }
            return G + H;
        }
        public Flight GetParent()
        {
            return this._parent;
        }
        public void SetParent(Flight flight)
        {
            if ((flight.ArrivalTime - flight.DepartureTime).TotalSeconds != 0)
            {
                _parent = flight;
            }
        }
    }
}
