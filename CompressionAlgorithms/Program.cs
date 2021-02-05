using System;
using System.Collections.Generic;
using System.IO;
using TimsCompressionStudy.CompressionAlgorithms;


namespace TimsCompressionStudy
{
    class Program
    {
        
        static void Main(string[] args)
        {
            HuffmanCoding hc1 = new HuffmanCoding();
            var nodelist1 = hc1.InputDigest(@"C:\Users\Tim\Desktop\file1.txt");
            var finalnode = hc1.GenerateTree(nodelist1);
            var encodetext = hc1.EncodeString(File.ReadAllText(@"C:\Users\Tim\Desktop\file1.txt"), finalnode);
            var decodedtext = hc1.DecodeHuffman(encodetext, finalnode);

            HuffmanCoding hc2 = new HuffmanCoding();
            var nodelist2 = hc2.InputDigest(@"C:\Users\Tim\Desktop\file2.txt");
            var finalnode2 = hc2.GenerateTree(nodelist2);
            var encodetext2 = hc2.EncodeString(File.ReadAllText(@"C:\Users\Tim\Desktop\file2.txt"), finalnode2);
            var decodedtext2 = hc2.DecodeHuffman(encodetext2, finalnode2);



            Console.WriteLine("encoded text:");
            Console.WriteLine("");
            Console.WriteLine(encodetext);
            Console.WriteLine("");
            Console.WriteLine("decoded text:");
            Console.WriteLine("");
            Console.WriteLine(decodedtext);

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("encoded text2:");
            Console.WriteLine("");
            Console.WriteLine(encodetext2);
            Console.WriteLine("");
            Console.WriteLine("decoded text2:");
            Console.WriteLine("");
            Console.WriteLine(decodedtext2);
        }
    }
}
