using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_s_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Graph.lookUpTest(); 
            Graph2.graphTest();
        }

        void dictionatyKeyList() //реализация хэш-таблцы через словарь (строка, список) так что каждой строке может соответсовать несколько значений из списка
        {
            List < KeyValuePair<char, int>> values;
            Dictionary<char, List<KeyValuePair<char, int>>> graph = new Dictionary<char, List<KeyValuePair<char, int>>>();
            /*bool count = false;

            while (count == false)
            {
                Console.WriteLine("Введите из какой точки");
                string temp = Console.ReadLine();
                List<string> list;
                if (!graph.TryGetValue(temp, out list))
                {
                    list = new List<string>();
                    Console.WriteLine("Введите куда ведет ребро");
                    list.Add(Console.ReadLine());
                    graph.Add(temp, list);
                }
                else
                {
                    Console.WriteLine("Введите куда ведет ребро");
                    list.Add(Console.ReadLine());
                }
                Console.WriteLine("Это последний элемент? (y/n)");
                count = Console.ReadLine() == "y" ? true : false;
            }
            */

            graph.Add('s', values= new List<KeyValuePair<char, int>>() { new KeyValuePair<char, int>('s', 2)} );

            foreach (var dot in graph)
            {
                Console.Write($"key: {dot.Key}  value:");
                foreach (var dots in dot.Value)
                {
                    Console.Write(dots);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

    }

    class Graph2
    {
        public static void graphTest() // реализация хэш-таблицы через словарь (ключ-словарь, число) так что ключ ключ-словаря - начальная точка, значение ключ-словаря - конечная точка, значение словаря - длина
        {      
            Dictionary<string, string> keyDict = new Dictionary<string, string>(); 

            Dictionary< KeyValuePair<char, char>, int> graph = new Dictionary<KeyValuePair<char, char>, int>();
            graph.Add(new KeyValuePair<char, char>('s', 'a'), 6);
            graph.Add(new KeyValuePair<char, char>('s', 'b'), 7);
            graph.Add(new KeyValuePair<char, char>('s', 'c'), 8);

            List<int> graphs = new List<int>();

            graphs.AddRange( graph.Where(p => p.Key.Key == 's').Select(n => n.Value).DefaultIfEmpty());
            //string result2 = myDict.Where(p => p.Key.Value == 'b').Select(p => p.Value).FirstOrDefault();

            foreach (var packageGroup in graphs)
            {
                Console.WriteLine(packageGroup);            
            }
        }
    }

    class Graph // класс для реализации хэш-таблицы через лук-ап (строка, словарь) так что строка - начальная точка, ключ словаря - конечная точка, значение словаря - длина
    {
        public Dictionary<char, string> graph ;
        public char key;

        public static void lookUpTest() // реализация
        {
            List<Graph> graphs = new List<Graph> { new Graph { key =  '1', graph = new Dictionary<char, string>() { { '2', "66" },
                                                                                                             { '3', "22" } } }/*,
                                                   new Graph { key = 2, graph = new Dictionary<int, int>() { { 5, 77 },
                                                                                                             { 6, 33 } } }*/
                                                   };

            Lookup<int, KeyValuePair<char, string>> lookup = (Lookup< int, KeyValuePair<char, string>>)graphs.ToLookup(key => key.key, val => val.graph);

            foreach (var endVelue in lookup)
            {
                Console.WriteLine(endVelue.Key);
                foreach (var str in endVelue)
                    Console.WriteLine("    {0}", str);
            }
       
           // string result = lookup.Where(p => p.Key == 0).Select(t => t.Value).SingleOrDefault().Where(p => p.Key == 'a').Select(p => p.Value).SingleOrDefault();

            /* IEnumerable<Dictionary<char, string>> group = lookup['1'];

             Console.WriteLine("\nEnd-value with key of '1':");
             foreach (var str in group)
                 Console.WriteLine(str);
            */
        }

        static void simpleLookUpTest() // простой пример LookUp
        {
            string[] names = { "Igor", "Anton", "Inna", "Anna", "Boris", "Berta" };
            //var lookup = names.ToLookup(item => item[0]);
            Lookup<char, string> lookup = (Lookup<char, string>)names.ToLookup(item => item[0]);

            foreach (var group in lookup)
            {
                Console.WriteLine("group - {0}", group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("\t" + item);
                }
            }
        }
    }

}
