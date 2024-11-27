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
                new Flight("Bucuresti", "Paris", 2.5, 150, "Compania A"),
                new Flight("Bucuresti", "Berlin", 2, 120, "Compania A"),
                new Flight("Cluj", "Paris", 3, 180, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.3, 100, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.1, 120, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.9, 90, "Compania A")
            });
            var agent1 = builder.GetServiceAgent();

            builder.AddCompany("Ozone");
            builder.AddFlights(new List<Flight>
            {
                new Flight("Bucuresti", "Paris", 2.3, 140, "Compania B"),
                new Flight("Timisoara", "Paris", 3, 200, "Compania B"),
                new Flight("Bucuresti", "Amsterdam", 2.5, 130, "Compania B"),
                new Flight("Bucuresti", "Paris", 1.7, 120, "Compania A"),
                new Flight("Bucuresti", "Paris", 3.0, 300, "Compania A"),
                new Flight("Bucuresti", "Paris", 1.6, 100, "Compania A")
            });
            var agent2 = builder.GetServiceAgent();

            //var assistantAgent = new AssistantAgent(agents);
            //env.Add(assistantAgent, "assistant");
            //foreach (var agent in agents)
            //{
            //    env.Add(agent, agent.Company);
            //}
            //env.Start();

        }
    }
}
