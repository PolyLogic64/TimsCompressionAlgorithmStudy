using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimsCompressionStudy.CompressionAlgorithms
{
    public class HuffmanNode
    {
        public HuffmanNode()
        {
            childNodes = new List<HuffmanNode>();
        }

        public HuffmanNode parentNode;
        public HuffmanNode childRight;
        public HuffmanNode childLeft;
        public List<HuffmanNode> childNodes;
        public string symbols;
        public float frequency;

        //Combines two HuffmanNodes
        public static void Combine(HuffmanNode huffmanNode, HuffmanNode otherHuffmanNode, ref List<HuffmanNode> huffmanNodes)
        {
            HuffmanNode newNode = new HuffmanNode();
            newNode.frequency = huffmanNode.frequency + otherHuffmanNode.frequency;
            newNode.symbols = huffmanNode.symbols + otherHuffmanNode.symbols;
            newNode.childLeft = otherHuffmanNode;
            newNode.childRight = huffmanNode;
            newNode.childNodes.Add(huffmanNode);
            newNode.childNodes.Add(otherHuffmanNode);

            huffmanNode.parentNode = newNode;
            otherHuffmanNode.parentNode = newNode;

            huffmanNodes.Insert(0,newNode);
            huffmanNodes.Remove(otherHuffmanNode);
            huffmanNodes.Remove(huffmanNode);

            huffmanNodes = huffmanNodes.OrderBy(h => h.frequency).ToList();
        }

    }

    public class HuffmanCoding
    {
        //Takes the Input und encodes it as a List of HuffmanNodes
        public List<HuffmanNode> InputDigest(string file)
        {

            List<HuffmanNode> huffmanNodes = new List<HuffmanNode>();
            Dictionary<char, int> unsortedList = new Dictionary<char, int>();
            string filetext = File.ReadAllText(file);

            // DO NOT TOUCH MAGIC CODE
            var charList = filetext.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count() });
            // DO NOT TOUCH MAGIC CODE
            foreach (var item in charList)
            {
                unsortedList.Add(item.Char, item.Count);
            }

            // DO NOT TOUCH MAGIC CODE
            var sortedList = from entry in unsortedList orderby entry.Value ascending select entry;
            // DO NOT TOUCH MAGIC CODE

            foreach (var item in sortedList)
            {
                HuffmanNode node = new HuffmanNode();
                node.symbols = item.Key.ToString();
                node.frequency = item.Value;
                huffmanNodes.Add(node);


            }

            return huffmanNodes;
            
        }
        
        //Generates the Tree, and outputs a single HuffmanNode that is the root Node
        public HuffmanNode GenerateTree(List<HuffmanNode> huffmanNodes)
        {
            while (huffmanNodes.Count >= 2)
            {
                HuffmanNode.Combine(huffmanNodes[0], huffmanNodes[1], ref huffmanNodes);
            }

            return huffmanNodes[0];

        }
        
        //Encodes the string based on the entire HuffmanTree
        public string EncodeString(string plaintext, HuffmanNode rootNode)
        {
            string encodedtext = "";

            foreach (char plainchar in plaintext)
            {
                encodedtext += " ";
                HuffmanNode currentNode = rootNode;
                while(!(currentNode.childLeft == null && currentNode.childRight == null))
                {
                    if(!(currentNode.childLeft == null))
                    {
                        if (currentNode.childLeft.symbols.Contains(plainchar))
                        {
                            currentNode = currentNode.childLeft;
                            encodedtext += 0;
                        }
                    }
                    if(!(currentNode.childRight == null))
                    {
                        if (currentNode.childRight.symbols.Contains(plainchar))
                        {
                            currentNode = currentNode.childRight;
                            encodedtext += 1;
                        }
                    }
                    

                }


            }


            return encodedtext;
        }
        
        //A more efficent way to encode a string by building a dictionary of the HuffmanTree and the codes of the characters
        public void EncodeByDict(string plaintext, HuffmanNode rootNode)
        {
            
            
        }

        //
        public string DecodeHuffman(string encodedtext, HuffmanNode rootNode)
        {
            string decodedstring = "";
            HuffmanNode currentNode = rootNode;

            foreach (char encodedchar in encodedtext)
            {

                if(currentNode.symbols.Length == 1)
                {
                    decodedstring += currentNode.symbols;
                    currentNode = rootNode;
                    
                }


                if(encodedchar == '0')
                {
                    currentNode = currentNode.childLeft;
                }


                if(encodedchar == '1')
                {
                    currentNode = currentNode.childRight;
                }


            }

            return decodedstring;
        }
        
        //
        public void DecodeByDict(string encodedtext, HuffmanNode rootNode)
        {

        }
    }
}
