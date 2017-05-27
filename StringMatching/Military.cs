using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StringMatching
{
    class Military
    {
        public static void Main(string[] args)
        {
            try
            {
                string text;
                string pattern;
                string reverse = "";

                Military m = new Military();//Create the object from the Military class

               /* const string fileName = "Text.txt"; //Generate file name
                //Write the string to a file
                StreamWriter fs = new StreamWriter(fileName);
                //Random number generator
                Random r = new Random();
                //Binary coded stream Range 
                int number = r.Next(1, 1000);
                
                int decimalNumber = number;//Store the random number

                int remainder;
                string result = string.Empty;

                while (decimalNumber > 0)
                {
                    remainder = decimalNumber % 2;//Store the remainder
                    decimalNumber /= 2;
                    result = remainder.ToString() + result;//Store the binary number
                    fs.Write(result);
                }
                //Close the File
                fs.Close();*/

                //Read the All text which written to a File
                //text = File.ReadAllText("Text.txt");
                text = "0101100110001101001100100110101001100101001101010100110";

                //Read an input from the Console
                Console.Write("\nPattern : ");
                pattern = Console.ReadLine();

                while (true)
                {
                    double value;
                    bool parsed = Double.TryParse(pattern, out value);//Check whether the input is a binary number
                    //Check whether the null characters are input
                    if (pattern.Length <= 0)
                    {
                        Console.WriteLine("\nWARNING : Invalid Input.............\n");
                        Console.Write("\nPattern : ");
                        pattern = Console.ReadLine();
                    }
                    //Check whether the non binary stream is input    
                    else if (!parsed)
                    {
                        Console.WriteLine("\nInvalid Input................\n");
                        Console.Write("\nPattern : ");
                        pattern = Console.ReadLine();
                    }
                    //Access the rest of the program
                    else {
                        Console.WriteLine("\n");
                        break;
                    }
                }

                //Reverse the text string
                for (int i = (text.Length - 1); i >= 0; i--)
                    reverse += text[i];

                m.showText(text, pattern);//Access the showText method
                m.showReverse(reverse, pattern);//Access the showReverse method

            }catch(Exception ex){
                Console.WriteLine("File can't open : "+ex);
            }
           
            Console.ReadKey();

        }
        //Show the matching of text and pattern
        private void showText(string text, string pattern) {

            RabinCarp rc = new RabinCarp(pattern);
            int remain = rc.Match(text);

            if (remain != text.Length)
                Console.WriteLine("\n\t1. Text is matching Success.........................\n");
            else
                Console.WriteLine("\n\t1. Text is not matching.............................\n");

            Console.WriteLine(" text :    " + text);//Print the text

            Console.Write(" Pattern : ");//Print the pattern along the text
            for (int i = 0; i < remain; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(pattern);

        }
        //Show the matching of reverse text and pattern
        private void showReverse(string text, string pattern) {

            RabinCarp rc = new RabinCarp(pattern);
            int remain = rc.Match(text);

            if (remain != text.Length)
                Console.WriteLine("\n\t2. Reverse Text is matching Success.................\n");
            else
                Console.WriteLine("\n\t2. Reverse Text is not matching.....................\n");

            Console.WriteLine(" text :    " + text);//Print the text

            Console.Write(" Pattern : ");//Print the reverse of the pattern along the text
            for (int i = 0; i < remain; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(pattern);

        }
    }
}
