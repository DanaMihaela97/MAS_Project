using ActressMas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Proiect_MAS
{
    public class AssistantAgent : Agent
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int FlexibleNo { get; set; }
        private Timer _timer;

        private List<Flight> _receivedFlights = new List<Flight>();
        private Stack<Flight> _openList = new Stack<Flight>();
        private List<Flight> _closedList = new List<Flight>();
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

            if (_receivedFlights.Count > 0)
            {
                var bestRoutes = _receivedFlights
                .OrderBy(f => f.ArrivalTime - f.DepartureTime)
                //.OrderBy(f => f.Price)
                //.ThenBy(f => f.Price)
                .ToList();

                //Console.WriteLine("Optimal routes:");
                //Console.WriteLine("-------------");
                //foreach (var route in bestRoutes)
                //{
                //    Console.WriteLine($"{route.Departure} -> {route.Destination}, {route.ArrivalTime - route.DepartureTime}h, {route.Price} EUR");
                //}
                //Console.WriteLine("-------------\n");
                _openList.Push(bestRoutes[0]);
                _receivedFlights.Clear();
            }
            var searchFlight = _openList.Pop();
            _closedList.Add(searchFlight);
            string message = $"SearchFlight {searchFlight.Destination} {Destination} {searchFlight.DepartureTime.ToString("MM/dd/yyyy HH:mm")} {ArrivalTime.ToString("MM/dd/yyyy HH:mm")} {FlexibleNo}";
            Console.WriteLine("\n" + message);
            Broadcast(message);

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

            switch (action)
            {
                case "Flight":
                    {
                        HandleFlight(parameters, separator); break;
                    }
                default:
                    {
                        if (_timer.Enabled)
                        {
                            Console.WriteLine("Found the route");
                            Console.WriteLine("-------------");
                            foreach (var flight in _closedList)
                            {
                                Console.WriteLine(flight);
                            }
                            Console.WriteLine("-------------\n");
                            _timer.Stop();
                            Stop();
                        }
                        break;
                    }
            }
        }
        void HandleFlight(string parameters, char separator)
        {
            if (_timer.Enabled)
            {
                var args = parameters.Split(separator);
                var flight = new Flight(
                    departure: args[0],
                    destination: args[1],
                    departureTime: DateTime.Parse(args[2]),
                    arrivalTime: DateTime.Parse(args[3]),
                    price: double.Parse(args[4])
                );
                if (args[1] == Destination)
                {
                    Send(this.Name, "Stop");
                    _closedList.Add(flight);
                    return;
                }
                _receivedFlights.Add(flight);
                var company = args[5];
            }
        }
    }
}
