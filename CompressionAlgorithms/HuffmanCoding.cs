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

    }
    
    class HuffmanCoding
    {
        // This is the main HuffmanCoding program

        public Dictionary<char, int> inputDict = new Dictionary<char, int>();
        List<HuffmanNode<char>> sortedList;
        public List<HuffmanNode<char>> SortTheList(List<HuffmanNode<char>> l)
        {
            // A function for Sorting the list of Huffman Nodes
            return l.OrderBy(o => o.frequency).ToList();
        }
        public void InputDigest(string s)
        {
            // A function for interpreting the Input data
            int amount;
            List<HuffmanNode<char>> currentList = new List<HuffmanNode<char>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (inputDict.ContainsKey(s[i]))
                {
                    amount = s.Split(s[i]).Length - 1;
                    inputDict[s[i]] = amount;
                }
                else
                {
                    amount = s.Split(s[i]).Length - 1;
                    inputDict.Add(s[i], amount);
                }
            }
            // I probably need to change this, I want this huffman coding to be used on files.
            // The Idea is that the binary of the file will be converted into hex and then this
            // algorithm can run on the hex numbers.


            foreach (KeyValuePair<char, int> stuff in inputDict)
            {

                HuffmanNode<char> node = new HuffmanNode<char>();
                node.symbol = stuff.Key;
                node.frequency = stuff.Value;

                currentList.Add(node);
            }
            sortedList = SortTheList(currentList);
        }
        public void ConnectNodes(List<HuffmanNode<char>> nodes)
        {
            // All of this is just for using of char, I will completly rewrite this section for hex

            if (nodes.Count <= 1)
            {
                Console.WriteLine("its a 1");
            }
            else
            {
                HuffmanNode<char> low1 = sortedList[0];
                HuffmanNode<char> low2 = sortedList[1];

                HuffmanNode<char> temp = new HuffmanNode<char>();
                temp.child1 = low1;
                temp.child2 = low2;
                temp.frequency = low1.frequency + low2.frequency;

                sortedList.RemoveAt(sortedList.IndexOf(low1));
                sortedList.RemoveAt(sortedList.IndexOf(low2));
                sortedList.Add(temp);

                temp = new HuffmanNode<char>();

                sortedList = SortTheList(sortedList);

            }
        }
        public void Start(string s)
        {
            // A function used for Starting the Huffman Coding Algorithm
            InputDigest(s);
            do
            {
                ConnectNodes(sortedList);
            } while (sortedList.Count > 1);

            

        }
    }
}
