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

        private List<Flight> _openList = new List<Flight>();
        private List<Flight> _closedList = new List<Flight>();
        private List<Flight> _solutions = new List<Flight>();
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
            _openList.Add(new Flight(departure, departure, departureTime, arrivalTime, 0, "StartingPoint"));
        }
        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_openList.Count == 0 || _solutions.Count == 4)
            {
                Console.WriteLine($"___________________________________________________");
                Console.WriteLine($"Found solutions:");
                foreach (var solution in _solutions)
                {
                    Console.WriteLine($"\nSolution: {_solutions.IndexOf(solution) + 1}");
                    PrintSolution(solution);
                }
                Console.WriteLine($"___________________________________________________");
                Stop();
                _timer.Stop();
                return;
            }
            _openList = _openList.OrderBy(f => f.Price).ToList();

            //if (_openList.Count > 0 && _closedList.Count > 0 && _openList[0].Departure != _closedList[_closedList.Count - 1].Destination)
            //{
            //    _closedList.RemoveAt(_closedList.Count - 1);
            //}
            if (_openList.Count > 0)
            {
                if (_openList.Count > 1 && Math.Abs(_openList[0].Price - _openList[1].Price) < _openList[0].Price / 10)
                {
                    if (_openList[0].GetDuration() < _openList[1].GetDuration())
                    {
                        _searchFlight = _openList[0];
                    }
                    else
                    {

                        _searchFlight = _openList[1];
                    }
                }
                else
                {
                    _searchFlight = _openList[0];
                }
                //_searchFlight = _openList[0];
                _openList.Remove(_searchFlight);
                //if (_searchFlight.Destination == Destination)
                //{
                //    Send(this.Name, "Stop");
                //    return;
                //}
                string message = $"SearchFlight {_searchFlight.Destination} {Destination} {_searchFlight.DepartureTime.ToString("MM/dd/yyyy HH:mm")} {ArrivalTime.ToString("MM/dd/yyyy HH:mm")} {FlexibleNo}";
                Console.WriteLine("\n" + message + "\n");
                Broadcast(message);
                if (!_closedList.Contains(_searchFlight))
                    _closedList.Add(_searchFlight);
            }
        }


        public override void Setup()
        {
            _timer.Start();
        }

        public override void Act(Message message)
        {
            if (this.Environment.NoAgents < Utils.NoAgents)
            {
                return;
            }
            char separator = ';';
            string action; string parameters;
            Utils.ParseMessage(message.Content, out action, out parameters, separator);

            //if (_solutions.Count == 4)
            //{
            //    Console.WriteLine($"___________________________________________________");
            //    Console.WriteLine($"Found solutions:");
            //    foreach (var solution in _solutions)
            //    {
            //        Console.WriteLine($"\nSolution: {_solutions.IndexOf(solution) + 1}");
            //        PrintSolution(solution);
            //    }
            //    Console.WriteLine($"___________________________________________________");
            //    Stop();
            //    _timer.Stop();
            //}
            switch (action)
            {
                case "Flight":
                    {
                        HandleFlight(parameters, separator); break;
                    }
                case "Stop":
                    {
                        Stop();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Found the route");
                        Console.WriteLine("-------------");
                        //foreach (var flight in _closedList)
                        //{
                        //    Console.WriteLine(flight);
                        //}
                        _solutions.Add(_closedList[_closedList.Count - 1]);
                        PrintSolution(_closedList[_closedList.Count - 1]);
                        Console.WriteLine("-------------\n");
                        // _closedList.Clear();
                        // _openList.Clear();
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
                price: double.Parse(args[4]),
                agency: args[5]
            );
            if (flight.Departure == _searchFlight.Destination)
            {
                flight.SetParent(_searchFlight);
            }
            var company = args[5];
            //Console.WriteLine(flight.GetF());
            foreach (var flightElem in _openList)
            {
                if (flightElem.Destination == flight.Destination && flightElem.Departure == flight.Departure)
                {
                    return;
                }
            }
            if (flight.Destination == Destination)
            {
                foreach (var flightElem in _closedList)
                {
                    if (flightElem.Departure == flight.Departure && flightElem.Destination == flight.Destination)
                    {
                        Console.WriteLine($"Reached {flight.Departure} -> {flight.Destination} on a shorter path.");
                        return;
                    }
                }
                _closedList.Add(flight);
                Send(this.Name, "DisplayResults");
                return;
            }
            foreach (var flightElem in _openList)
            {
                if (flightElem.Departure == flight.Departure && flightElem.Destination == flight.Destination)
                {
                    Console.WriteLine($"We dont have to open {flight.Departure} -> {flight.Destination}.");
                    return;
                }
            }
            foreach (var flightElem in _closedList)
            {
                if ((flightElem.Departure == flight.Departure && flightElem.Destination == flight.Destination) ||
                    (flightElem.Departure == flight.Destination && flightElem.Destination == flight.Departure))
                {
                    Console.WriteLine($"Reached {flight.Departure} -> {flight.Destination} on a shorter path.");
                    return;
                }
            }
            _openList.Add(flight);
        }

        public void PrintSolution(Flight flight)
        {
            if (flight.GetParent() == null)
            {
                Console.WriteLine(flight);
                return;
            }
            PrintSolution(flight.GetParent());
            Console.WriteLine(flight);
            return;
        }
    }
}
