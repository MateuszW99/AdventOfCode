using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{

    static class Day1
    {
        public static int Part1()
        {
            int totalFuel = 0;
            string[] input = ReadFile();

            foreach (var data in input)
            {
                int fuel = Int32.Parse(data);
                fuel /= 3;
                totalFuel += fuel - 2;
            }
            return totalFuel;

        }


        public static long Part2()
        {
            string[] input = ReadFile();
            long totalFuel = 0;

            foreach(var data in input)
            {
                int fuel = Int32.Parse(data);
                totalFuel += PartialFuel(fuel);
            }
            return totalFuel;
        }

        private static int PartialFuel(int mass)
        {
            if (mass > 6)
            {
                mass = mass / 3 - 2;
                return mass + PartialFuel(mass);
            }
            return 0;
        }


        private static string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                              .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }

        private static string[] ReadFile()
        {
            string path = Path.Combine(GetApplicationRoot(), @"Input\Day1.txt");
            string[] input = File.ReadAllLines(path);
            return input;
        }
    } 
}

