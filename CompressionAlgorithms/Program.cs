using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TimsCompressionStudy.CompressionAlgorithms;


namespace TimsCompressionStudy
{
    class Program
    {

        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            HuffmanCoding hc1 = new HuffmanCoding();
            var nodelist1 = hc1.InputDigest(@"C:\Users\Tim\Desktop\file1.txt");
            var finalnode = hc1.GenerateTree(nodelist1);
            var encodetext = hc1.EncodeString(File.ReadAllText(@"C:\Users\Tim\Desktop\file1.txt"), finalnode);
            var boi = hc1.EncodeByDict(File.ReadAllText(@"C:\Users\Tim\Desktop\file1.txt"), finalnode);
            var decodedtext = hc1.DecodeHuffman(encodetext, finalnode);

            HuffmanCoding hc2 = new HuffmanCoding();
            var nodelist2 = hc2.InputDigest(@"C:\Users\Tim\Desktop\file2.txt");
            var finalnode2 = hc2.GenerateTree(nodelist2);
            var encodetext2 = hc2.EncodeString(File.ReadAllText(@"C:\Users\Tim\Desktop\file2.txt"), finalnode2);
            var decodedtext2 = hc2.DecodeHuffman(encodetext2, finalnode2);


            Console.WriteLine("Normal Huffman Coding Compression Ratio:");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Half Life 1:");
            Console.WriteLine("");
            Console.WriteLine((double)StringToBinary(decodedtext2).Length / (double)encodetext2.Length);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Half Life 2:");
            Console.WriteLine("");
            Console.WriteLine((double)StringToBinary(decodedtext).Length / (double)encodetext.Length);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            //Console.WriteLine("Normal Text:");
            //Console.WriteLine("");
            //Console.WriteLine(decodedtext);
            //Console.WriteLine("");
            //Console.WriteLine("Shitty Encoded:");
            //Console.WriteLine("");
            //Console.WriteLine(encodetext);
            //Console.WriteLine("");
            //Console.WriteLine("Nice Encoded:");
            //Console.WriteLine("");
            //Console.WriteLine(boi);





            //Console.WriteLine("encoded text:");
            //Console.WriteLine("");
            //Console.WriteLine(encodetext.Length);
            //Console.WriteLine("");
            //Console.WriteLine("decoded text:");
            //Console.WriteLine("");
            //Console.WriteLine(StringToBinary(decodedtext).Length);

            //Console.WriteLine("");
            //Console.WriteLine("");

            //Console.WriteLine("encoded text2:");
            //Console.WriteLine("");
            //Console.WriteLine(encodetext2);
            //Console.WriteLine("");
            //Console.WriteLine("decoded text2:");
            //Console.WriteLine("");
            //Console.WriteLine(decodedtext2);
        }
    }
}
