using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;

namespace CompressionAlgorithms
{
    public class HuffmanNode<T>
    {
        public HuffmanNode<T> child1;
        public HuffmanNode<T> child2;
        public int frequency;
        public T symbol;

        public void Print()
        {

        }

    }
    
    class HuffmanCoding
    {
        public Dictionary<char, int> yes = new Dictionary<char, int>();
        List<HuffmanNode<char>> sortedshit;
        public List<HuffmanNode<char>> SortTheFuckingList(List<HuffmanNode<char>> l)
        {
            return l.OrderBy(o => o.frequency).ToList();
        }
        public void InputDigest(string s)
        {
            int amount;
            List<HuffmanNode<char>> shit = new List<HuffmanNode<char>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (yes.ContainsKey(s[i]))
                {
                    amount = s.Split(s[i]).Length - 1;
                    yes[s[i]] = amount;
                }
                else
                {
                    amount = s.Split(s[i]).Length - 1;
                    yes.Add(s[i], amount);
                }
            }
            foreach (KeyValuePair<char, int> what in yes)
            {
                //Console.WriteLine("Key = {0}, Value = {1}", what.Key, what.Value);

                HuffmanNode<char> node = new HuffmanNode<char>();
                node.symbol = what.Key;
                node.frequency = what.Value;

                shit.Add(node);
            }
            sortedshit = SortTheFuckingList(shit);
        }
        public void ConnectNodes(List<HuffmanNode<char>> nodes)
        {
            if (nodes.Count <= 1)
            {
                Console.WriteLine("fuck its a 1");
            }
            else
            {
                HuffmanNode<char> low1 = sortedshit[0];
                HuffmanNode<char> low2 = sortedshit[1];

                HuffmanNode<char> cum = new HuffmanNode<char>();
                cum.child1 = low1;
                cum.child2 = low2;
                cum.frequency = low1.frequency + low2.frequency;

                sortedshit.RemoveAt(sortedshit.IndexOf(low1));
                sortedshit.RemoveAt(sortedshit.IndexOf(low2));
                sortedshit.Add(cum);

                cum = new HuffmanNode<char>();

                sortedshit = SortTheFuckingList(sortedshit);

            }
        }
        public void Start(string s)
        {
            InputDigest(s);
            do
            {
                ConnectNodes(sortedshit);
                //sortedshit = SortTheFuckingList(sortedshit);
            } while (sortedshit.Count > 1);

            

        }
    }
}
