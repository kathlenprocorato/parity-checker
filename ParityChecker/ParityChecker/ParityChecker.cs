using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParityCheckerApp
{
    public class ParityChecker
    {
        // a function that will input a set of bits and set whether or not it is ODD or EVEN parity
        public string GetParity(int[] bits)
        {
            int countOnes = bits.Count(bit => bit == 1);
            return countOnes % 2 == 0 ? "EVEN" : "ODD";
        }

        // a function that examines the said set of bits
        // if it has an error or not
        public bool CheckError(int[] bits, string expectedParity)
        {
            string actualParity = GetParity(bits);
            return actualParity != expectedParity;
        }

        // a function that will input a block of character bits and will find its BCC
        public int[] CalculateBCC(int[][] blocks)
        {
            int blockSize = blocks[0].Length;
            int[] bcc = new int[blockSize];

            for (int i = 0; i < blockSize; i++)
            {
                bcc[i] = blocks.Sum(block => block[i]) % 2;
            }

            return bcc;
        }

        // a function that will input a block of character bits
        // and its BCC and checks if it has an  error or not
        public bool CheckErrorWithBCC(int[][] blocks, int[] expectedBCC)
        {
            int[] calculatedBCC = CalculateBCC(blocks);
            return !calculatedBCC.SequenceEqual(expectedBCC);
        }

        // a function that will input a block of character bits and will find its
        // BCC through LRC, EVEN-set or ODD-set parity bits and the parity bit of the BCC
        public int[] CalculateBCCWithParity(int[][] blocks, string parityType)
        {
            int blockSize = blocks[0].Length;
            int[] bcc = new int[blockSize];

            for (int i = 0; i < blockSize; i++)
            {
                int sum = blocks.Sum(block => block[i]);
                if (parityType == "EVEN")
                {
                    bcc[i] = sum % 2;
                }
                else if (parityType == "ODD")
                {
                    bcc[i] = (sum % 2 == 0) ? 1 : 0;
                }
            }

            return bcc;
        }
    }
}
