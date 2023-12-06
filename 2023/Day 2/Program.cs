namespace AoC_Day_2 {
    using System;
    public class Program {
        static void Main(string[] args) {
            string[] inputLines = File.ReadAllLines("input.txt");
            int lineCount = inputLines.Length;
            int[,] gameArrayMax = new int[lineCount, 4];    // To store the largest numbers
            int[,] gameArrayMin = new int[lineCount, 4];    // To store the minimum possible numbers
            /*  Game # | Red | Green | Blue
             *      0  |  1  |   2   |   3
             *      1  |  1  |   2   |   3
             *      2  |  1  |   2   |   3
             *      etc...
             */
            // Nested for-loops to get the Game # in the array (y),
            // then iterate through split lines to get right color numbers (i)
            for (int y = 0; y < inputLines.Length; y++) {
                int index = y + 1;
                gameArrayMax[y, 0] = index;
                gameArrayMin[y, 0] = index;
                string[] inputSplit = inputLines[y].Split(";");
                for (int i = 0; i < inputSplit.Length; i++) {
                    if (inputSplit[i].Contains("red")) {
                        int redNum = Convert.ToInt32(inputSplit[i].Substring(inputSplit[i].IndexOf("red") - 3, 2));
                        if (redNum > 12) {
                            gameArrayMax[y, 1] += redNum;
                        }
                        if (redNum > gameArrayMin[y, 1]) {
                            gameArrayMin[y, 1] = redNum;
                        }
                    }
                    if (inputSplit[i].Contains("green")) {
                        int greenNum = Convert.ToInt32(inputSplit[i].Substring(inputSplit[i].IndexOf("green") - 3, 2));
                        if ( greenNum> 13) {
                            gameArrayMax[y, 2] += greenNum;
                        }
                        if (greenNum > gameArrayMin[y, 2]) {
                            gameArrayMin[y, 2] = greenNum;
                        }
                    }
                    if (inputSplit[i].Contains("blue")) {
                        int blueNum = Convert.ToInt32(inputSplit[i].Substring(inputSplit[i].IndexOf("blue") - 3, 2));
                        if (blueNum > 14) {
                            gameArrayMax[y, 3] += blueNum;
                        }
                        if (blueNum > gameArrayMin[y, 3]) {
                            gameArrayMin[y, 3] = blueNum;
                        }
                    }
                }
            }
            // Calculate sum and power to submit
            int idSum = 0;
            for (int i = 0; i < gameArrayMax.GetLength(0); i++) {
                if (gameArrayMax[i, 1] <= 12 && gameArrayMax[i, 2] <= 13 && gameArrayMax[i, 3] <= 14) {
                    idSum += gameArrayMax[i, 0];
                }
            }
            int minPower = 0;
            for (int i = 0; i < gameArrayMin.GetLength(0); i++) {
                minPower += gameArrayMin[i, 1] * gameArrayMin[i, 2] * gameArrayMin[i, 3];
            }
            Console.WriteLine("Sum of IDs: " + idSum);
            Console.WriteLine("Sum of minimum powers: " + minPower);
        }
    }
}
