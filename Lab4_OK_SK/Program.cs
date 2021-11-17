using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lab4_OK_SK
{
    class Program
    {

        static List<int> globalData;
        static int max;
        static int printIdx;

        static void Main(string[] args)
        {
            string fileName = args[0];

            fileName = AppDomain.CurrentDomain.BaseDirectory + fileName;

            Console.WriteLine("Load data from: "+fileName);
          
            var dataString = File.ReadAllText(fileName);

            //dataString = "[83,86,77,15,93,35,86,92,49,21,62,27,99]";

            dataString = dataString.Replace("[", "");
            dataString = dataString.Replace("]", "");



            string[] valuesString = dataString.Split(',');

            globalData = new List<int>();

            foreach(var str in valuesString)
            {
                globalData.Add(Int32.Parse(str));
            }

            max = 0;
            SearchTree(globalData, 0, globalData.Count);
            Console.WriteLine("Maximum: "+max);

            int r = 0;
        }

        static bool SearchTree(List<int> dataInput, int scoreInput, int orginalLen)
        {
            //printData(dataInput);
            if(dataInput.Count == orginalLen - 1)
            {
                printData(dataInput, orginalLen);
            }

            for (int i = 1; i < dataInput.Count-1; i++)
            {
                List<int> data = dataInput.GetRange(0, dataInput.Count);
                int score = scoreInput;

                score += data[i] + data[i-1]+ data[i+1];
                data.RemoveAt(i);

                SearchTree(data, score, orginalLen);

            }

            if(scoreInput > max)
            {
                max = scoreInput;
            }

            return true;
        }

        static void printData(List<int> data, int origLen)
        {

            string number = "Process = " + (printIdx+1) + "/" + (origLen - 2);
            Console.Write(number);

            int spaceLen = 20 - number.Length;

            for (int i = 0; i < spaceLen; i++)
            {
                Console.Write(" ");
            }


            Console.Write(": [ ");
            for (int i = 0; i < data.Count; i++)
            {
                Console.Write(data[i]+" ");
            }
            Console.Write("]\n");

            printIdx++;
        }


    }
}
