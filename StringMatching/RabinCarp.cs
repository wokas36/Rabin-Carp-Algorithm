using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringMatching
{
    class RabinCarp
    {
         private string pattern;
        private int m, h, patternHash, q;

        public RabinCarp(string pattern)
        {
            this.pattern = pattern;//Set the pattern
            this.m = pattern.Length;//Set the pattern length
            this.q = 13;//Modulus prime number
            this.h = ((int)Math.Pow(10, m - 1)) % q;
            this.patternHash = Hash(pattern);//Generate the pattern hash value
        }
        //Hash value Generating function
        private int Hash(string text)
        {
            int hashVal = 0;
            for (int i = 0; i < m; i++)
                hashVal = (10 * hashVal + text[i]) % q;
            return hashVal;
        }
        //Check whether the pattern and text are match
        private bool Check(string text, int offset)
        {
            for (int i = 0; i < m; i++)
            {
                if (pattern[i] != text[offset + i])
                    return false;
            }
            return true;
        }
        //Check for exactly matching
        public int Match(string text)
        {
            int n = text.Length;
            if (n < m)
                return n;//Return the text length
            int textHash = Hash(text);//Generate the text hash value

            //Checking whether offset is 0
            if (patternHash == textHash && Check(text, 0))
                return 0;

            //Check for the hash match and exact match
            for (int i = m; i < n; i++)
            {
                //Remove the high order digit and add the new low order digit
                textHash = (textHash + q - h * text[i - m] % q) % q;
                textHash = (textHash * 10 + text[i]) % q;

                //Check whether the exact matching pattern and text
                int offset = i - m + 1;
                if (patternHash == textHash && Check(text, offset))
                    return offset;
            }
            //Matching is unsuccess
            return n;
        }
      
      /*  private string pattern;
        private int m, h, patternHash, q;

        public RabinCarp(string pattern)
        {
            this.pattern = pattern;//Set the pattern
            this.m = pattern.Length;//Set the pattern length
            this.q = 13;//Modulus prime number
            this.h = ((int)Math.Pow(2, m - 1)) % q;
            this.patternHash = Hash(pattern);//Generate the pattern hash value
        }
        //Hash value Generating function
        private int Hash(string text)
        {
            int hashVal = 0;
            for (int i = 0; i < m; i++)
                hashVal = (2 * hashVal + (int)text[i]) % q;
            return hashVal;
        }
        
        //Check for exactly matching
        public int Match(string text)
        {
            int n = text.Length;
            if (n < m)
                return n;//Return the text length
            int textHash = Hash(text);//Generate the text hash value

            //Checking whether hash values are equal
            if (patternHash == textHash)
            {
                //Check whether the pattern and text are match
                for (int i = 0; i < m; i++)
                {
                    if (pattern[i] != text[i])
                        return n;
                }
                return 0;
            }
            //Check for the hash match and exact match
            for (int i = m; i < n; i++)
            {
                //Remove the high order digit and add the new low order digit
                textHash = ((textHash + q +- h * text[i - m] % q) * 2 + text[i]) % q;

                //Check whether the exact matching pattern and text
                int remain = i - m + 1;
                if (patternHash == textHash)
                {
                    //Check whether the pattern and text are match
                    for (int j = 0; j < m; j++)
                    {
                        if (pattern[j] != text[remain+j])
                            return n;
                    }
                    return remain;
                }
            }
            //Matching is unsuccess
            return n;*/
        }
      
    }
}
