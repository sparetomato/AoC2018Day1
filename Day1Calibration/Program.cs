using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Day1Calibration
{
    public class Program
    {

        public static List<int> frequencies = new List<int>();

        public static void Main(string[] args)
        {
            Console.WriteLine("Calibration Code [" + Calibrate(args) + "]");

        }


        public static int Calibrate(string[] calibration)
        {
            if (calibration.Length == 1)
              return Calibrate(string.Join("",calibration));
            else
            {
                return Calibrate(string.Join("", calibration));
            }
        }
        public static int Calibrate(string calibration)
        { 

            int sum = 0;
            string[] calibrationCode = new string[0];

            if (calibration.Contains(','))
            {
                calibrationCode = calibration.Split(',');
            }
            else
            {
                if (!calibration.EndsWith(".txt"))
                {
                    calibration += ".txt";
                }
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                calibrationCode = File.ReadAllLines(System.IO.Path.GetDirectoryName(path) + @"\" + calibration);
            }

            bool repeatFrequencyFound = false;
            while(!repeatFrequencyFound)
            {
                for (int i = 0; i < calibrationCode.Length; i++)
                {
                    sum = transformCalibration(sum, calibrationCode[i].Trim());
                    
                    repeatFrequencyFound = isRepeatFrequency(sum);
                    if (repeatFrequencyFound)
                        break;

                    Console.WriteLine(sum);

                    frequencies.Add(sum);
                }                
            }

            return sum;
        }

        public static bool isRepeatFrequency(int frequency)
        {
            return frequencies.Any(freq => freq == frequency);
        }



        public static int transformCalibration(int currentVal, string transformation)
        {
            switch(transformation.Substring(0,1))
            {
                case "+":
                    currentVal += Convert.ToInt32(transformation.Substring(1));
                    break;
                case "-":
                    currentVal -= Convert.ToInt32(transformation.Substring(1));
                    break;
                default:
                    throw new Exception("Input is not valid. Must start with a + or -");

            }

            return currentVal;
        }



    }
}
