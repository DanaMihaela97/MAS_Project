using ActressMas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect_MAS
{
    public class AssistantAgent : Agent
    {
        private List<Flight> Flights { get; } = new List<Flight>();
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int FlexibleNo { get; set; }
        public AssistantAgent() { }
        public AssistantAgent(string departure, string destination, DateTime departureTime, DateTime arrivalTime)
        {
            Departure = departure;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }

        public override void Setup()
        {
            Broadcast($"SearchFlight {Departure} {Destination} {DepartureTime.ToString("MM/dd/yyyy HH:mm")} {ArrivalTime.ToString("MM/dd/yyyy HH:mm")} {FlexibleNo}");
        }

        public override void Act(Message message)
        {
            if (message.Content.StartsWith("Flight"))
            {
                var parts = message.Content.Split(';');
                var flight = new Flight(
                    departure: parts[1],
                    destination: parts[2],
                    departureTime: DateTime.Parse(parts[3]),
                    arrivalTime: DateTime.Parse(parts[4]),
                    price: double.Parse(parts[5])
                );
                Flights.Add(flight);
                var company = parts[6];
                var bestRoutes = Flights
                    .OrderBy(f => f.Price)
                    .ThenBy(f => f.ArrivalTime - f.DepartureTime)
                    .Take(4)
                    .ToList();

                Console.WriteLine("Optimal routes:");
                Console.WriteLine("-------------");
                foreach (var route in bestRoutes)
                {
                    Console.WriteLine($"{route.Departure} -> {route.Destination}, {route.ArrivalTime - route.DepartureTime}h, {route.Price} EUR, Company {message.Sender}");
                }
                Console.WriteLine("-------------\n");
            }
        }
    }
}
