using System;
using System.Collections.Generic;

namespace MAS_Project
{
    public class Utils
    {
        public static int NoBidders = 5;
        public static int ReservePrice = 100;
        public static int MinPrice = 0;
        public static int MaxPrice = 1000;
        public static int Increment = 10;

        public static int Delay = 1000;
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
    }
}
