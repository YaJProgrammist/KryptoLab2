using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KryptoLab2
{
    class MainClass
    {
        static byte[] firstCiphertext;
        static byte[] secondCiphertext;

        static string cribWord;

        static byte[] XOR(byte[] first, byte[] second)
        {
            int minLength = (first.Length > second.Length) ? second.Length : first.Length;

            byte[] result = new byte[minLength];

            for (int i = 0; i < minLength; i++)
            {
                result[i] = (byte)(first[i] ^ second[i]);
            }
            return result;

        }

        static byte[] HexStrToBytes(string input)
        {
            List<byte> bytes = new List<byte>();

            for (int i = 0; i < input.Length; i += 2)
            {
                bytes.Add(Convert.ToByte(input.Substring(i, 2), 16));
            }

            return bytes.ToArray();
        }

        static byte[] StrToBytes(string input)
        {
            return Encoding.ASCII.GetBytes(input);
        }

        static string BytesToStr(byte[] input)
        {
            return Encoding.ASCII.GetString(input);
        }

        public static byte[] SubArray(byte[] array, int offset, int length)
        {
            return array.Skip(offset)
                        .Take(length)
                        .ToArray();
        }

        static void AttackTheEncryption()
        {
            byte[] encodingCribWord = StrToBytes(cribWord);

            byte[] q1q2XOR = XOR(firstCiphertext, secondCiphertext);

            for (int i = 0; i < 1 + q1q2XOR.Length - encodingCribWord.Length; i++)
            {
                Console.WriteLine(i + "     " + BytesToStr(XOR(encodingCribWord, SubArray(q1q2XOR, i, encodingCribWord.Length))));
            }
        }

        public static void Main(string[] args)
        {
            //Console.WriteLine("Enter first ciphertext");
            //string quote1 = StrToBytes(Console.ReadLine());

            //Console.WriteLine("Enter second ciphertext");
            //string quote2 = StrToBytes(Console.ReadLine());

            firstCiphertext = HexStrToBytes("ad924af7a9cdaf3a1bb0c3fe1a20a3f367d82b0f05f8e75643ba688ea2ce8ec88f4762fbe93b50bf5138c7b699");
            secondCiphertext = HexStrToBytes("a59a0eaeb4d1fc325ab797b31425e6bc66d36e5b18efe8060cb32edeaad68180db4979ede43856a24c7d");

            while(true)
            {
                Console.WriteLine("Do you want to enter a new crib word? y/n");
                if(Console.ReadLine() == "y")
                {
                    Console.WriteLine("Enter crib word");
                    cribWord = Console.ReadLine();

                    AttackTheEncryption();
                } 
                else
                {
                    break;
                }
            }
        }
    }
}
