using System;
using System.Collections.Generic;
using System.Text;

namespace KryptoLab2
{
    class MainClass
    {
        static byte[] XOR(byte[] array1, byte[] array2)
        {
            int minLength = (array1.Length > array2.Length) ? array2.Length : array1.Length;

            byte[] result = new byte[minLength];

            for (int i=0; i< minLength; i++)
            {
                result[i] = (byte)(array1[i] ^ array2[i]);
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

        public static void Main(string[] args)
        {

        }
    }
}
