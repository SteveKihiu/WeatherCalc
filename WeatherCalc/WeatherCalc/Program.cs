using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCalc
{
    class Program
    {
        const string fileName = "F:\\weather.dat";
        static void Main(string[] args)
        {
            string line;
            int counter = 0;

            //Read the dat file here
            StreamReader weatherFile = new StreamReader(fileName);

            int totalLines = System.IO.File.ReadAllLines(fileName).Length;

            int largestRange = 3, dayLargestRange = 0;

            while ((line = weatherFile.ReadLine()) != null)
            {
                if (counter > 1 && counter < totalLines - 1)
                {
                    string[] numbers = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();//Convert the line to an array removing white space                                         

                    int day, mxt, mnt;

                    //Convert the values to individual variables
                    day = int.Parse(string.Join(null, System.Text.RegularExpressions.Regex.Split(numbers[0], "[^\\d]")));

                    mxt = int.Parse(string.Join(null, System.Text.RegularExpressions.Regex.Split(numbers[1], "[^\\d]")));

                    mnt = int.Parse(string.Join(null, System.Text.RegularExpressions.Regex.Split(numbers[2], "[^\\d]")));

                    //Calculate the range here     
                    var range = mxt - mnt;
                    if (range > largestRange)
                    {
                        largestRange = range;
                        dayLargestRange = day;
                    }
                }

                counter += 1;
            }

            Console.WriteLine(dayLargestRange + " " + largestRange);

            //Suspend UI
            Console.ReadLine();
        }
    }
}
