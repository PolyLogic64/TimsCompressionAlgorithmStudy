using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

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
        public string Shit()
        {
            return "shit";
        }
    }
}
