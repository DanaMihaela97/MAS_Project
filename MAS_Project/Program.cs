using ActressMas;
using System;
using System.Collections.Generic;

namespace Proiect_MAS
{
    public class Program
    {
        static void Main(string[] args)
        {
            EnvironmentMas env = new EnvironmentMas(0, 100);
            BuilderAgent builder = new BuilderAgent();
            builder.AddCompany("Air");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Arad", destination: "Sibiu",
                        departureTime: new DateTime(2008, 6, 1, 7, 47, 0),
                        arrivalTime: new DateTime(2008, 6, 1, 7, 59, 0),
                        price: 150),
                new Flight(departure: "Arad", destination: "Timisoara", departureTime: new DateTime(2008, 6, 1, 7, 0, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 32, 0), price: 120),
                new Flight(departure: "Sibiu", destination: "Arad", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 180),
                new Flight(departure: "Sibiu", destination: "Oradea", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime : new DateTime(2008, 6, 1, 7, 47, 0), price: 100),
                new Flight(departure: "Rimnicu-Valcea", destination: "Craiova", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 120),
                new Flight(departure: "Rimnicu-Valcea", destination: "Sibiu", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 90),
                new Flight(departure: "Pitesti", destination: "Bucuresti", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 90)
            });
            var agent1 = builder.GetServiceAgent();

            builder.AddCompany("Ozone");
            builder.AddFlights(new List<Flight>
            {
                new Flight(departure: "Arad", destination: "Zerind", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 9, 47, 0), price: 140),
                new Flight(departure: "Sibiu", destination: "Fagaras", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 10, 47, 0), price: 200),
                new Flight(departure: "Sibiu", destination: "Rimnicu-Valcea", departureTime  : new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 55, 0), price: 130),
                new Flight(departure: "Rimnicu-Valcea", destination: "Pitesti", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 120),
                new Flight(departure: "Fagaras", destination: "Bucuresti", departureTime : new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 130),
                new Flight(departure: "Fagaras", destination: "Sibiu", departureTime : new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 130),
                new Flight(departure: "Pitesti", destination: "Rimnicu-Valcea", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 300),
                new Flight(departure: "Pitesti", destination: "Craiova", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 100)
            });
            var agent2 = builder.GetServiceAgent();

            var assistantAgent = new AssistantAgent(
                departure: "Arad",
                destination: "Bucuresti",
                departureTime: new DateTime(2008, 6, 1, 7, 47, 0),
                arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0));

            InitAgents(out AssistantAgent assistant, out List<ServiceAgent> listAgents);
            env.Add(assistantAgent, "assistant");
            env.Add(agent1, agent1.Company);
            env.Add(agent2, agent2.Company);
            env.Start();
            Console.ReadKey();
        }
        private static void InitAgents(out AssistantAgent assistant, out List<ServiceAgent> agents)
        {
            assistant = new AssistantAgent(
                departure: "Arad",
                destination: "Bucuresti",
                departureTime: new DateTime(2008, 6, 1, 7, 47, 0),
                arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0));
            agents = new List<ServiceAgent>();
            //BuilderAgent builder = new BuilderAgent();
            //builder.AddCompany("Air");
            //builder.AddFlights(new List<Flight>
            //{
            //    new Flight(departure: "Rimnicu-Valcea", destination: "Craiova", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 120),
            //    new Flight(departure: "Rimnicu-Valcea", destination: "Sibiu", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 90),
            //    new Flight(departure: "Pitesti", destination: "Bucuresti", departureTime: new DateTime(2008, 6, 1, 7, 47, 0), arrivalTime: new DateTime(2008, 6, 1, 7, 47, 0), price: 90)
            //});
            //agents[0] = builder.GetServiceAgent();
            //pt restul ..
        }
    }
}
