using System;
using System.Collections.Generic;

namespace Proiect_MAS
{
    public class Utils
    {
        private static Dictionary<string, int> CityCode = new Dictionary<string, int>()
        {
            { "Arad", 0 },
            { "Bucuresti" , 1 },
            { "Craiova" ,2 },
            {"Fagaras" , 3 },
            {"Oradea" , 4 },
            {"Pitesti" , 5 },
            {"Rimnicu_Valcea" , 6 },
            {"Sibiu", 7 },
           { "Timisoara", 8 },
            {"Zerind", 9 }
        };
        public static int NoAgents = 3;
        public static int ReservePrice = 100;
        public static int MinPrice = 0;
        public static int MaxPrice = 1000;
        public static int Increment = 10;

        public static int Delay = 1500;
        public static Random RandNoGen = new Random();
        public static List<int> winningPrices = new List<int>();
        public static void ParseMessage(string content, out string action, out string parameters, char separator = ' ')
        {
            string[] t = content.Split(separator);

            action = t[0];

            parameters = "";

            if (t.Length > 1)
            {
                for (int i = 1; i < t.Length - 1; i++)
                    parameters += t[i] + separator;
                parameters += t[t.Length - 1];
            }
        }

        public static string Str(object p1, object p2)
        {
            return string.Format("{0} {1}", p1, p2);
        }

        public static void AddWinnerPrice(int price)
        {
            winningPrices.Add(price);
        }
        public static int GetHeuristic(string city)
        {
            return distanceDict[CityCode[city]];
        }
        public static int[] distanceDict =
        {366, 0, 160, 176, 380, 100, 193, 253, 329, 374};
    }
}
