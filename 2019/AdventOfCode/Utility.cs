using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    static class Utility
    {
        public static string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(System.Reflection
                              .Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }


        public static string[] ReadLinesIntoStringArray(string fileName)
        {
            string path = Path.Combine(GetApplicationRoot(), String.Format("@Input\\{0}", fileName));
            return File.ReadAllLines(path);
        }
    }
}
