using ActressMas;
using MAS_Project;
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
            char separator = ';';
            string action; string parameters;
            Utils.ParseMessage(message.Content, out action, out parameters, separator);

            if (action == "Flight")
            {
                var args = parameters.Split(separator);
                var flight = new Flight(
                    departure: args[0],
                    destination: args[1],
                    departureTime: DateTime.Parse(args[2]),
                    arrivalTime: DateTime.Parse(args[3]),
                    price: double.Parse(args[4])
                );
                Flights.Add(flight);
                var company = args[5];
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
