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
            InitAgents1(env, out AssistantAgent assistant, out List<ServiceAgent> serviceAgents);
            try
            {
                env.Start();
            }
            catch
            {

            }
        }
        private static void InitAgents1(EnvironmentMas env, out AssistantAgent assistant, out List<ServiceAgent> agents)
        {
            assistant = new AssistantAgent(
                departure: "Arad",
                destination: "Bucuresti",
                departureTime: new DateTime(2024, 6, 1, 8, 0, 0),
                arrivalTime: new DateTime(2024, 6, 15, 20, 0, 0),
                flexibleNo: 1
            );

            agents = new List<ServiceAgent>();
            BuilderAgent builder = new BuilderAgent();

            builder.AddCompany("Air");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Rimnicu_Valcea", destination: "Craiova",//done
                           departureTime: new DateTime(2024, 6, 1, 15, 47, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 18, 47, 0), price: 366),
                new Flight(departure: "Rimnicu_Valcea", destination: "Sibiu",//done
                           departureTime: new DateTime(2024, 6, 1, 15, 47, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 19, 47, 0), price: 300),
                new Flight(departure: "Pitesti", destination: "Bucuresti",//done
                           departureTime: new DateTime(2024, 6, 2, 4, 27, 0),
                           arrivalTime: new DateTime(2024, 6, 4, 6, 47, 0), price: 418),
                new Flight(departure: "Arad", destination: "Sibiu", //done
                           departureTime: new DateTime(2024, 6, 1, 9, 0, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 12, 0, 0), price: 140),
                new Flight(departure: "Arad", destination: "Timisoara", //done
                           departureTime: new DateTime(2024, 6, 1, 8, 50, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 9, 55, 0), price: 118),
                new Flight(departure: "Timisoara", destination: "Bucuresti", //done
                           departureTime: new DateTime(2024, 6, 9, 7, 50, 0),
                           arrivalTime: new DateTime(2024, 6, 9, 9, 55, 0), price: 118),
                new Flight(departure: "Sibiu", destination: "Arad", //done
                           departureTime: new DateTime(2024, 6, 1, 3, 47, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 7, 47, 0), price: 386),
                 new Flight(departure: "Sibiu", destination: "Oradea", //done
                           departureTime: new DateTime(2024, 6, 1, 3, 37, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 9, 47, 0), price: 291),

                new Flight(departure: "Zerind", destination: "Timisoara",
                           departureTime: new DateTime(2024, 6, 1, 10, 30, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 12, 45, 0), price: 190),

                new Flight(departure: "Craiova", destination: "Pitesti",
                           departureTime: new DateTime(2024, 6, 1, 12, 0, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 14, 0, 0), price: 180),

                new Flight(departure: "Mehadia", destination: "Timisoara",
                           departureTime: new DateTime(2024, 6, 1, 9, 0, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 10, 30, 0), price: 150),

                new Flight(departure: "Sibiu", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 15, 30, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 19, 0, 0), price: 350),

                new Flight(departure: "Pitesti", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 18, 0, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 19, 30, 0), price: 180),

        });
            var airAgent = builder.GetServiceAgent();

            builder.AddCompany("Ozone");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Arad", destination: "Zerind", //done
                           departureTime: new DateTime(2024, 6, 1, 8, 30, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 10, 30, 0), price: 75),
                new Flight(departure: "Zerind", destination: "Bucuresti", //done
                           departureTime: new DateTime(2024, 6, 1, 7, 47, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 9, 42, 0), price: 75),
                new Flight(departure: "Sibiu", destination: "Fagaras", //done
                           departureTime: new DateTime(2024, 6, 1, 11, 37, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 12, 47, 0), price: 239),
                new Flight(departure: "Sibiu", destination: "Rimnicu_Valcea", //done
                           departureTime: new DateTime(2024, 6, 1, 13, 37, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 14, 30, 0), price: 220),
                new Flight(departure: "Rimnicu_Valcea", destination: "Pitesti",//done
                           departureTime: new DateTime(2024, 6, 1, 15, 47, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 17, 45, 0), price: 317),
                new Flight(departure: "Fagaras", destination: "Bucuresti",//done
                           departureTime: new DateTime(2024, 6, 1, 5, 47, 0),
                           arrivalTime: new DateTime(2024, 6, 6, 6, 47, 0), price: 450),
                new Flight(departure: "Fagaras", destination: "Sibiu", //done
                           departureTime: new DateTime(2024, 6, 1, 5, 47, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 7, 47, 0), price: 338),
                new Flight(departure: "Pitesti", destination: "Rimnicu_Valcea",
                           departureTime: new DateTime(2024, 6, 1, 3, 47, 0),//done
                           arrivalTime: new DateTime(2024, 6, 1, 5, 00, 0), price: 414),
                new Flight(departure: "Pitesti", destination: "Craiova",
                           departureTime: new DateTime(2024, 6, 1, 2, 47, 0),//done
                           arrivalTime: new DateTime(2024, 6, 1, 5, 47, 0), price: 455),
                new Flight(departure: "Craiova", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 19, 0, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 21, 0, 0), price: 160),
                new Flight(departure: "Oradea", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 18, 30, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 22, 30, 0), price: 380),
                new Flight(departure: "Rimnicu_Valcea", destination: "Fagaras",
                           departureTime: new DateTime(2024, 6, 1, 16, 30, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 18, 30, 0), price: 200),
                new Flight(departure: "Fagaras", destination: "Craiova",
                           departureTime: new DateTime(2024, 6, 1, 19, 0, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 21, 0, 0), price: 300),
                new Flight(departure: "Timisoara", destination: "Craiova",
                           departureTime: new DateTime(2024, 6, 1, 11, 30, 0),
                           arrivalTime: new DateTime(2024, 6, 1, 14, 0, 0), price: 210),
            });
            var ozoneAgent = builder.GetServiceAgent();

            agents.Add(airAgent);
            agents.Add(ozoneAgent);
            env.Add(assistant, "Assistant");
            env.Add(airAgent, "AirAgent");
            env.Add(ozoneAgent, "OzoneAgent");
        }

        private static void InitAgents2(EnvironmentMas env, out AssistantAgent assistant, out List<ServiceAgent> agents)
        {
            assistant = new AssistantAgent(
                departure: "Arad",
                destination: "Bucuresti",
                departureTime: new DateTime(2024, 6, 1, 8, 0, 0),
                arrivalTime: new DateTime(2024, 6, 15, 20, 0, 0),
                flexibleNo: 1
            );

            agents = new List<ServiceAgent>();
            BuilderAgent builder = new BuilderAgent();

            builder.AddCompany("Air");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Rimnicu_Valcea", destination: "Craiova",
                           departureTime: new DateTime(2024, 6, 1, 15, 47, 0), // No change
                           arrivalTime: new DateTime(2024, 6, 1, 18, 47, 0), price: 366),
                new Flight(departure: "Rimnicu_Valcea", destination: "Sibiu",
                           departureTime: new DateTime(2024, 6, 1, 14, 30, 0), // Slightly adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 15, 53, 0), price: 300),
                new Flight(departure: "Pitesti", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 17, 45, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 19, 45, 0), price: 418),
                new Flight(departure: "Arad", destination: "Sibiu",
                           departureTime: new DateTime(2024, 6, 1, 9, 0, 0), // No change
                           arrivalTime: new DateTime(2024, 6, 1, 12, 0, 0), price: 140),
                new Flight(departure: "Arad", destination: "Timisoara",
                           departureTime: new DateTime(2024, 6, 1, 8, 50, 0), // No change
                           arrivalTime: new DateTime(2024, 6, 1, 9, 55, 0), price: 118),
                new Flight(departure: "Timisoara", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 9, 55, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 12, 00, 0), price: 118),
                new Flight(departure: "Sibiu", destination: "Arad",
                           departureTime: new DateTime(2024, 6, 1, 7, 47, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 9, 30, 0), price: 386),
                 new Flight(departure: "Sibiu", destination: "Oradea",
                           departureTime: new DateTime(2024, 6, 1, 9, 47, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 12, 47, 0), price: 291),
            });
            var airAgent = builder.GetServiceAgent();

            builder.AddCompany("Ozone");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Arad", destination: "Zerind",
                           departureTime: new DateTime(2024, 6, 1, 8, 30, 0), // No change
                           arrivalTime: new DateTime(2024, 6, 1, 10, 30, 0), price: 75),
                new Flight(departure: "Zerind", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 10, 30, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 12, 30, 0), price: 75),
                new Flight(departure: "Sibiu", destination: "Fagaras",
                           departureTime: new DateTime(2024, 6, 1, 12, 47, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 14, 47, 0), price: 239),
                new Flight(departure: "Sibiu", destination: "Rimnicu_Valcea",
                           departureTime: new DateTime(2024, 6, 1, 10, 30, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 11, 45, 0), price: 220),
                new Flight(departure: "Rimnicu_Valcea", destination: "Pitesti",
                           departureTime: new DateTime(2024, 6, 1, 14, 47, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 15, 53, 0), price: 317),
                new Flight(departure: "Fagaras", destination: "Bucuresti",
                           departureTime: new DateTime(2024, 6, 1, 14, 47, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 16, 47, 0), price: 450),
                new Flight(departure: "Fagaras", destination: "Sibiu",
                           departureTime: new DateTime(2024, 6, 1, 6, 47, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 8, 47, 0), price: 338),
                new Flight(departure: "Pitesti", destination: "Rimnicu_Valcea",
                           departureTime: new DateTime(2024, 6, 1, 12, 30, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 13, 47, 0), price: 414),
                new Flight(departure: "Pitesti", destination: "Craiova",
                           departureTime: new DateTime(2024, 6, 1, 11, 00, 0), // Adjusted
                           arrivalTime: new DateTime(2024, 6, 1, 13, 47, 0), price: 455),
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

