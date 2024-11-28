using ActressMas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect_MAS
{
    public class ServiceAgent : Agent
    {
        public List<Flight> Flights { get; set; }
        public string Company { get; set; }

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
                var departureDate = DateTime.Parse(parts[3]);
                var arrivalDate = DateTime.Parse(parts[4]);
                // var flexibleNo = parts[5];

                var results_departure = Flights
                    .Where(f => f.Departure == departure)
                    .ToList();

                var direct_flight = Flights
                    .Where(f => f.Departure == departure && f.Destination == destination)
                    .ToList();
                if (direct_flight.Any())
                {
                    results_departure.AddRange(direct_flight);
                }
                foreach (var flight in results_departure)
                {
                    var msg = $"Flight;{flight.Departure};{flight.Destination};{flight.DepartureTime};{flight.ArrivalTime};{flight.Price};{this.Company}";
                    Console.WriteLine($"{message.Receiver} -> {message.Sender}: {msg.Replace(";", " ")}");
                    Send(message.Sender, msg);
                }
            }
        }
    }
}
