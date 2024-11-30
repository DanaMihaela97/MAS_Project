using ActressMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

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
        private Timer _timer;
        private Stack<Flight> _openList = new Stack<Flight>();
        public AssistantAgent() { }
        public AssistantAgent(string departure, string destination, DateTime departureTime, DateTime arrivalTime)
        {
            _timer = new Timer();
            _timer.Elapsed += t_Elapsed;
            _timer.Interval = Utils.Delay;
            Departure = departure;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            _openList.Push(new Flight(departure, departure, departureTime, arrivalTime, 0));
        }
        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {

            if (Flights.Count > 0)
            {
                var bestRoutes = Flights
                .OrderBy(f => f.ArrivalTime - f.DepartureTime)
                .ThenBy(f => f.Price)
                .ToList();

                Console.WriteLine("Optimal routes:");
                Console.WriteLine("-------------");
                foreach (var route in bestRoutes)
                {
                    Console.WriteLine($"{route.Departure} -> {route.Destination}, {route.ArrivalTime - route.DepartureTime}h, {route.Price} EUR");
                }
                Console.WriteLine("-------------\n");
                _openList.Push(bestRoutes[0]);
                Flights.Clear();
            }

            var searchFlight = _openList.Peek();
            string message = $"SearchFlight {searchFlight.Destination} {Destination} {searchFlight.DepartureTime.ToString("MM/dd/yyyy HH:mm")} {ArrivalTime.ToString("MM/dd/yyyy HH:mm")} {FlexibleNo}";
            Console.WriteLine(message);
            Broadcast(message);
            _openList.Pop();
        }


        public override void Setup()
        {
            _timer.Start();
            //Broadcast($"SearchFlight {Departure} {Destination} {DepartureTime.ToString("MM/dd/yyyy HH:mm")} {ArrivalTime.ToString("MM/dd/yyyy HH:mm")} {FlexibleNo}");
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
            }
        }
    }
}
