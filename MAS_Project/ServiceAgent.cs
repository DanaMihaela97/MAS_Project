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
            string action; string parameters;
            Utils.ParseMessage(message.Content, out action, out parameters);

            if (action == "SearchFlight")
            {
                var args = parameters.Split(' ');
                var departure = args[0];
                var destination = args[1];
                var departureDate = DateTime.Parse(args[2]);
                var arrivalDate = DateTime.Parse(args[3]);
                // var flexibleNo = parts[5];

                var results_departure = Flights
                    .Where(f => f.Departure == departure)
                    .ToList();

                //Console.WriteLine(results_departure.Count);

                foreach (var flight in results_departure)
                {
                    var msg = $"Flight;{flight.Departure};{flight.Destination};{flight.DepartureTime};{flight.ArrivalTime};{flight.Price};{flight.Agency}";
                    Console.WriteLine($"{message.Receiver} -> {message.Sender}: {msg.Replace(";", " ")}");
                    Send(message.Sender, msg);
                }
            }
        }
    }
}
