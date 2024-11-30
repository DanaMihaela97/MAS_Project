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
        private List<Flight> _openList = new List<Flight>();
        private List<Flight> _closedList = new List<Flight>();
        private Flight _searchFlight;
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
            _openList.Add(new Flight(departure, departure, departureTime, arrivalTime, 0));
        }
        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            _openList = _openList.OrderBy(f => f.GetF()).ToList();
            if (_openList.Count > 0)
            {
                _searchFlight = _openList[0];
                _openList.Remove(_searchFlight);
                if (_searchFlight.Destination == Destination)
                {
                    Send(this.Name, "Stop");
                    return;
                }
                string message = $"SearchFlight {_searchFlight.Destination} {Destination} {_searchFlight.DepartureTime.ToString("MM/dd/yyyy HH:mm")} {ArrivalTime.ToString("MM/dd/yyyy HH:mm")} {FlexibleNo}";
                Console.WriteLine("\n" + message);
                Broadcast(message);
                _closedList.Add(_searchFlight);
            }
        }


        public override void Setup()
        {
            _timer.Start();
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
                case "Rewind":
                    {
                        _closedList.RemoveAt(_closedList.Count - 1); break;
                    }
                default:
                    {
                        Console.WriteLine("Found the route");
                        Console.WriteLine("-------------");
                        foreach (var flight in _closedList)
                        {
                            Console.WriteLine(flight);
                        }
                        Console.WriteLine("-------------\n");
                        _closedList.Clear();
                        _openList.Clear();
                        break;
                    }
            }
        }
        void HandleFlight(string parameters, char separator)
        {
            var args = parameters.Split(separator);
            var flight = new Flight(
                departure: args[0],
                destination: args[1],
                departureTime: DateTime.Parse(args[2]),
                arrivalTime: DateTime.Parse(args[3]),
                price: double.Parse(args[4])
            );
            flight.SetParent(_searchFlight);
            var company = args[5];
            foreach (var flightElem in _openList)
            {
                if (flightElem.Destination == flight.Destination && flightElem.Departure == flight.Departure)
                {
                    return;
                }
            }
            _openList.Add(flight);
        }
    }
}
