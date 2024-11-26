using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect_MAS
{
    public class FactoryAgent
    {
        public static List<ServiceAgent> CreateAgent()
        {
            var agent1Flights = new List<Flight>
            {
                new Flight("Bucuresti", "Paris", 2.5, 150, "Compania A"),
                new Flight("Bucuresti", "Berlin", 2, 120, "Compania A"),
                new Flight("Cluj", "Paris", 3, 180, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.3, 100, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.1, 120, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.9, 90, "Compania A")
            };

            var agent2Flights = new List<Flight>
            {
                new Flight("Bucuresti", "Paris", 2.3, 140, "Compania B"),
                new Flight("Timisoara", "Paris", 3, 200, "Compania B"),
                new Flight("Bucuresti", "Amsterdam", 2.5, 130, "Compania B"),
                new Flight("Bucuresti", "Paris", 1.7, 120, "Compania A"),
                new Flight("Bucuresti", "Paris", 3.0, 300, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.6, 100, "Compania A")
            };

            string departure = "Bucuresti";  
            string destination = "Paris";   

            Console.WriteLine($"Requested route: {departure} -> {destination}");

            var allFlights = new List<Flight>();
            allFlights.AddRange(agent1Flights);
            allFlights.AddRange(agent2Flights);

            var filteredFlights = allFlights
                .Where(f => f.Departure == departure && f.Destination == destination)
                .ToList();

            foreach (var flight in filteredFlights)
            {
                Console.WriteLine($"{flight.Departure} -> {flight.Destination}, {flight.Duration}h, {flight.Price} EUR, Company: {flight.Company}");
            }

            return new List<ServiceAgent>
            {
                new ServiceAgent("Compania A", agent1Flights),
                new ServiceAgent("Compania B", agent2Flights)
            };
        }
    }
}
