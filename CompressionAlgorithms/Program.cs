using System;
using System.Collections.Generic;
using System.IO;


namespace CompressionAlgorithms
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            HuffmanCoding huffmanCoding = new HuffmanCoding();
            
            string s = "Hello";

            huffmanCoding.Start(s);
        }
    }
}
