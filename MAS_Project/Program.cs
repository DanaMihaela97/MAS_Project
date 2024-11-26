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

            var agents = FactoryAgent.CreateAgent();
            var assistantAgent = new AssistantAgent(agents);
            env.Add(assistantAgent, "assistant");
            foreach (var agent in agents)
            {
                env.Add(agent, agent.Company); 
            }
            env.Start();

        }
    }
}
