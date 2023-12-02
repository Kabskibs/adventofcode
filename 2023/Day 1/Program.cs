namespace Trebuchet
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            // Part 2
            string[] keywords = File.ReadAllLines("input.txt");     // Array from contents of input-file from challenge
            string[] alphaNums = File.ReadAllLines("alphanums.txt");    // Array that contains numbers as words
            string[] numNums = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            // Iterate through keywords and check if keyword contains a number in text form,
            // then add a corresponding number in the middle of keyword
            for (int i = 0; i < keywords.Length; i++) {
                for (int y = 0; y < alphaNums.Length; y++) {
                    while (true) {
                        if (keywords[i].Contains(alphaNums[y])) {
                            Console.WriteLine(keywords[i] + " contains " + alphaNums[y]);
                            string keywordAdd = keywords[i].Insert(keywords[i].IndexOf(alphaNums[y]) + 1, numNums[y]);
                            keywords[i] = keywordAdd;
                            Console.WriteLine(keywords[i]);
                        } else {
                            break;
                        }
                    }
                }
            }
            // Part 1
            // Check for first number left-to-right
            string nums = "";
            int numsSum = 0;
            foreach (string line in keywords) {
                for (int i = 0; i < line.Length; i++) {
                    if (Char.IsDigit(line[i])) {
                        nums += line[i];
                        break;
                    }
                }
                // Check for first number right-to-left
                for (int y = line.Length - 1; y >= 0; y--) {
                    if (Char.IsDigit(line[y])) {
                        nums += line[y];
                        break;
                    }
                }
                Console.WriteLine("Printing nums: " + nums);
                numsSum += Convert.ToInt32(nums);
                nums = "";
            }
            Console.WriteLine(numsSum);
        }
    }
}
