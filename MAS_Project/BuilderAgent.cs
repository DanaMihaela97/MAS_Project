using System;
using System.Collections.Generic;
namespace Proiect_MAS
{
    public class BuilderAgent
    {
        private ServiceAgent serviceAgent = new ServiceAgent(null, null);
        public BuilderAgent() { 
            this.Reset();
        }

        void Reset()
        {
            serviceAgent = new ServiceAgent(null, null);
        }

        public void AddCompany(string companyName)
        {
            serviceAgent.Company = companyName;
        }
        public void AddFlights(List<Flight> flights)
        {
            serviceAgent.Flights = flights;
        }
        public ServiceAgent GetServiceAgent()
        {
            ServiceAgent agent = this.serviceAgent;
            this.Reset();
            return agent;
        }
    }
}
