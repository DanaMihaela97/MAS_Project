using ActressMas;
using System;
using System.Collections.Generic;

namespace Proiect_MAS
{
    public class Program
    {
        static void Main(string[] args)
        {
            EnvironmentMas env = new EnvironmentMas();
            InitAgents(env, out AssistantAgent assistant, out List<ServiceAgent> serviceAgents);
            env.Start();
        }
        private static void InitAgents(EnvironmentMas env, out AssistantAgent assistant, out List<ServiceAgent> agents)
        {
            assistant = new AssistantAgent(
                departure: "Arad",
                destination: "Bucuresti",
                departureTime: new DateTime(2008, 6, 1, 7, 47, 0),
                arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0)
            );

            agents = new List<ServiceAgent>();
            BuilderAgent builder = new BuilderAgent();

            builder.AddCompany("Air");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Rimnicu-Valcea", destination: "Craiova",//done
                           departureTime: new DateTime(2008, 6, 1, 5, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 8, 47, 0), price: 366),
                new Flight(departure: "Rimnicu-Valcea", destination: "Sibiu",//done
                           departureTime: new DateTime(2008, 6, 1, 5, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 9, 47, 0), price: 300),
                new Flight(departure: "Pitesti", destination: "Bucuresti",//done
                           departureTime: new DateTime(2008, 6, 1, 6, 27, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 6, 47, 0), price: 418),
                new Flight(departure: "Arad", destination: "Sibiu", //done
                           departureTime: new DateTime(2008, 6, 1, 7, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 8, 59, 0), price: 140),
                new Flight(departure: "Arad", destination: "Timisoara", //done
                           departureTime: new DateTime(2008, 6, 1, 7, 50, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 9, 55, 0), price: 118),
                new Flight(departure: "Sibiu", destination: "Arad", //done
                           departureTime: new DateTime(2008, 6, 1, 3, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 280),
                 new Flight(departure: "Sibiu", destination: "Oradea", //done
                           departureTime: new DateTime(2008, 6, 1, 3, 37, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 9, 47, 0), price: 291),
            });
            var airAgent = builder.GetServiceAgent();

            builder.AddCompany("Ozone");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Arad", destination: "Zerind", //done
                           departureTime: new DateTime(2008, 6, 1, 7, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 10, 42, 0), price: 75),
                new Flight(departure: "Sibiu", destination: "Fagaras", //done
                           departureTime: new DateTime(2008, 6, 1, 4, 37, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 5, 47, 0), price: 239),
                new Flight(departure: "Sibiu", destination: "Rimnicu-Valcea", //done
                           departureTime: new DateTime(2008, 6, 1, 4, 37, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 5, 30, 0), price: 220),
                new Flight(departure: "Rimnicu-Valcea", destination: "Pitesti",//done
                           departureTime: new DateTime(2008, 6, 1, 7, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 8, 45, 0), price: 317),
                new Flight(departure: "Fagaras", destination: "Bucuresti",//done
                           departureTime: new DateTime(2008, 6, 1, 5, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 6, 47, 0), price: 450),
                new Flight(departure: "Fagaras", destination: "Sibiu", //done
                           departureTime: new DateTime(2008, 6, 1, 5, 47, 0),
                           arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 338),
                new Flight(departure: "Pitesti", destination: "Rimnicu-Valcea",
                           departureTime: new DateTime(2008, 6, 1, 3, 47, 0),//done
                           arrivalTime: new DateTime(2008, 6, 1, 5, 00, 0), price: 414),
                new Flight(departure: "Pitesti", destination: "Craiova",
                           departureTime: new DateTime(2008, 6, 1, 2, 47, 0),//done
                           arrivalTime: new DateTime(2008, 6, 1, 5, 47, 0), price: 455),
               
            });
            var ozoneAgent = builder.GetServiceAgent();

            agents.Add(airAgent);
            agents.Add(ozoneAgent);
            env.Add(assistant, "Assistant");
            env.Add(airAgent, "AirAgent");
            env.Add(ozoneAgent, "OzoneAgent");
        }

    }
}

