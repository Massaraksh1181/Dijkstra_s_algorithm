using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra_s_algorithm
{
    class Algorithm
    {
        

        public char lowestNode(Dictionary<char, int> prices, List<char> processed)
        {
            int lowest_price = int.MaxValue;
            char lowest_node = ' ';

            foreach (var node in prices)
            {
                if (node.Value < lowest_price && processed.Contains(node.Key)==false)
                {
                    lowest_price = node.Value;
                    lowest_node = node.Key;
                }
            }
            return lowest_node;
        }

        public Dictionary<char, char> execution (Dictionary<KeyValuePair<char, char>, int> graph, Dictionary<char, int> prices, Dictionary<char, char> parents)
        {
            List<char> processed = new List<char>();
            Algorithm algorithm = new Algorithm();
            HashTables hashTables = new HashTables();

            var myLowestNode = algorithm.lowestNode(prices, processed);

            int price;
            int newPrice;

            while (myLowestNode != ' ')
            {
                price = prices[myLowestNode];
                var neighbor = hashTables.neighborsNodes(graph, myLowestNode);
                foreach(var n in neighbor.Keys)
                {
                    newPrice = price + neighbor[n];
                    if (prices[n] > newPrice)
                    {
                        prices[n] = newPrice;
                        parents[n] = myLowestNode;
                    }
                }
                processed.Add(myLowestNode);
                myLowestNode = algorithm.lowestNode(prices, processed);
            }
            return parents; 
        }
    }
}
