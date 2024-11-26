using System;
using System.Collections.Generic;
using System.Linq;
using ActressMas;

namespace Proiect_MAS
{
    public class AssistantAgent : Agent
    {
        private List<ServiceAgent> AirlineAgents { get; } = new List<ServiceAgent>();
        private List<Flight> Flights { get; } = new List<Flight>();

        public AssistantAgent(List<ServiceAgent> airlineAgents)
        {
            AirlineAgents = airlineAgents;
        }

        public override void Setup()
        {
            foreach (var agent in AirlineAgents)
            {
                Send(agent.Company, "SearchFlight Bucuresti Paris"); 
            }
        }

        public override void Act(Message message)
        {
            if (message.Content.StartsWith("Flight"))
            {
                var parts = message.Content.Split(' ');
                var flight = new Flight(parts[1], parts[2], double.Parse(parts[3]), double.Parse(parts[4]), parts[5]);
                Flights.Add(flight);

                if (Flights.Count >= AirlineAgents.Count)
                {
                    var bestRoutes = Flights
                        .OrderBy(f => f.Price)
                        .ThenBy(f => f.Duration)
                        .Take(4)
                        .ToList();

                    Console.WriteLine("Optimal routes:");
                    foreach (var route in bestRoutes)
                    {
                        Console.WriteLine($"{route.Departure} -> {route.Destination}, {route.Duration}h, {route.Price} EUR, ({route.Company})");
                    }
                }
            }
        }
    }
}
