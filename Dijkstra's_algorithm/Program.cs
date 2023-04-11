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

            /* hashTables.graphAdd(myGraph, 's', 'a', 6);
             hashTables.graphAdd(myGraph, 's', 'b', 2);
             hashTables.graphAdd(myGraph, 'b', 'a', 3);
             hashTables.graphAdd(myGraph, 'b', 'f', 5);
             hashTables.graphAdd(myGraph, 'a', 'f', 1);*/
            hashTables.graphAdd(myGraph, 'b', 'm', 15);
            hashTables.graphAdd(myGraph, 'b', 'p', 0);
            hashTables.graphAdd(myGraph, 'm', 'd', 20);
            hashTables.graphAdd(myGraph, 'm', 'g', 15);
            hashTables.graphAdd(myGraph, 'p', 'g', 30);
            hashTables.graphAdd(myGraph, 'g', 'f', 20);
            hashTables.graphAdd(myGraph, 'd', 'f', 10);

            Console.WriteLine("Граф: откуда-куда-стоимость");
            foreach (var ht in myGraph)
            {
                Console.WriteLine(ht);
            }

            var myNeighborsNodesOfNode = hashTables.neighborsNodes(myGraph, 'b');
            Console.WriteLine("Соседи точки b: куда-стоимость");
            foreach (var ht in myNeighborsNodesOfNode)
            {
                Console.WriteLine(ht);
            }

            var myPrices = hashTables.prices(myGraph);
            Console.WriteLine("Цены перехода: куда-стоимость");
            foreach (var ht in myPrices)
            {
                Console.WriteLine(ht);
            }

            var myParents = hashTables.parents(myGraph);
            Console.WriteLine("Родители: узел-родитель");
            foreach (var ht in myParents)
            {
                Console.WriteLine(ht);
            }

            Algorithm algorithm = new Algorithm();

            Console.WriteLine("Последовательность пути: узел-родитель:");
            var myParentsTree = algorithm.execution(myGraph,myPrices,myParents);
            foreach (var ht in myParentsTree)
            {
                Console.WriteLine(ht);
            }
        }
    }

}
