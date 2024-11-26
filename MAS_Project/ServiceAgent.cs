using System;
using System.Collections.Generic;
using System.Linq;
using ActressMas;

namespace Proiect_MAS
{
    public class ServiceAgent : Agent
    {
        private List<Flight> Flights { get; }
        public string Company { get; }

        public ServiceAgent(string company, List<Flight> flights)
        {
            Company = company;
            Flights = flights;
        }

        public override void Act(Message message)
        {
            var content = message.Content;
            var parts = content.Split(' ');

            if (parts[0] == "SearchFlight") 
            {
                var departure = parts[1];
                var destination = parts[2];

                var results = Flights
                    .Where(f => f.Departure == departure && f.Destination == destination)
                    .ToList();

                foreach (var flight in results)
                {
                    Send(message.Sender, $"Flight {flight.Departure} {flight.Destination} {flight.Duration} {flight.Price} {flight.Company}");
                }
            }
        }
    }
}
