using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_s_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTables hashTables = new HashTables();
            var myGraph = hashTables.graph;

            hashTables.graphAdd(myGraph, 's', 'a', 6);
            hashTables.graphAdd(myGraph, 's', 'b', 2);
            hashTables.graphAdd(myGraph, 'b', 'a', 3);
            hashTables.graphAdd(myGraph, 'b', 'f', 5);
            hashTables.graphAdd(myGraph, 'a', 'f', 1);

            Console.WriteLine("Граф: откуда-куда-стоимость");
            foreach (var ht in myGraph)
            {
                Console.WriteLine(ht);
            }

            Console.WriteLine("Соседи точки b: куда-стоимость");
            foreach (var ht in hashTables.neighborsNodes(myGraph, 'b'))
            {
                Console.WriteLine(ht);
            }

            Console.WriteLine("Цены перехода: куда-стоимость");
            foreach (var ht in hashTables.prices(myGraph))
            {
                Console.WriteLine(ht);
            }

            Console.WriteLine("Родители: узел-родитель");
            foreach (var ht in hashTables.parents(myGraph))
            {
                Console.WriteLine(ht);
            }
        }
    }

    class HashTables //класс для реализаци хэш-таблиц
    {
        public Dictionary<KeyValuePair<char, char>, int> graph = new Dictionary<KeyValuePair<char, char>, int>();

        public Dictionary<KeyValuePair<char, char>, int> graphAdd (Dictionary<KeyValuePair<char, char>, int> garph, char vertexFrom, char vertexTo, int price) // заполнение хэш-таблицы-графа
        {
            graph.Add(new KeyValuePair<char, char>(vertexFrom, vertexTo), price);
            return graph;
        }

        public Dictionary<char, int> neighborsNodes(Dictionary<KeyValuePair<char, char>, int> graph, char vertexFrom) // полчуние хэш-таблицы соседей узла
        {
            Dictionary<char, int> neighbor = new Dictionary<char, int>();

            foreach (var node in graph)
                if (node.Key.Key == vertexFrom)
                neighbor.Add(node.Key.Value, node.Value);

            return neighbor;
        }

        public Dictionary<char, int> prices (Dictionary<KeyValuePair<char, char>, int> graph) // получение хэш-таблицы стоимостей перехода в узел
        {
            Dictionary<char, int> price = new Dictionary<char, int>();
            HashSet<char> knownValues = new HashSet<char>();

            foreach (var node in graph)
            {
                if (knownValues.Add(node.Key.Value))
                {
                    price.Add(node.Key.Value, node.Value);
                }
            } 
            price['f'] = int.MaxValue;

            return price;
        }

        public Dictionary<char, char> parents (Dictionary<KeyValuePair<char, char>, int> graph) // получение хэш-таблицы "узел-родитель"
        {
            Dictionary<char, char> parent = new Dictionary<char, char>();
            HashSet<char> knownValues = new HashSet<char>();

            foreach (var node in graph)
            {
                if (knownValues.Add(node.Key.Value))
                {
                    parent.Add(node.Key.Value, node.Key.Key);
                }
            }
            parent['f'] = '-';

            return parent;
        }
    }

}
