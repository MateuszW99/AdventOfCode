using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    static class Day2
    {
        private static int lookingFor = 19690720;
        public static int Part1()
        {
            string[] tempData = Utility.ReadFile();
            string badCode = tempData[0];
            int[] code = Array.ConvertAll(badCode.Split(','), int.Parse);


            for (int i = 0; i < code.Length; i += 4)
            {
                int position_1 = code[i + 1];
                int position_2 = code[i + 2];
                int destination = code[i + 3];
                switch (code[i])
                {
                    case 1:
                        {
                            code[destination] = code[position_1] + code[position_2];
                            break;
                        }
                    case 2:
                        {
                            code[destination] = code[position_1] * code[position_2];
                            break;
                        }
                    case 99:
                        {
                            return code[0];
                        }
                }


            }
            return code[0];
        }

        public static void Part2()
        {
            string[] tempData = Utility.ReadFile();
            string badCode = tempData[0];
            int[] code = Array.ConvertAll(badCode.Split(','), int.Parse);
            int[] codeCopy = new int[code.Length];
            Array.Copy(code, codeCopy, code.Length);


            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    code[1] = noun;
                    code[2] = verb;
                    for (int i = 0; i < code.Length; i += 4)
                    {
                        var result = Decode(code, noun, verb);
                        if (result == lookingFor)
                        {
                            Console.WriteLine(100 * noun + verb);
                        }
                    }
                }
            }



            static int Decode(int[] code, int noun, int verb)
            {
                code = code.ToArray();
                code[1] = noun;
                code[2] = verb;

                var instruction = 0;
                while (instruction != 99)
                {
                    switch (code[instruction])
                    {
                        case 1:
                            code[code[instruction + 3]] = code[code[instruction + 1]] + code[code[instruction + 2]];
                            instruction += 4;
                            break;  
                        case 2:
                            code[code[instruction + 3]] = code[code[instruction + 1]] * code[code[instruction + 2]];
                            instruction += 4;
                            break;
                        default: return code[0];
                    }
                }

                return code[0];
            }

        }
    }
}



