using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CountApp
{
    enum Codes
    {
        Error = 99,
        OK = 0,
        Info = 1
    }
    public class Program
    {
        static int Main(string[] args)
        {
            //Check arguments
            if (args.Length == 1 && args.First() == "?")
            {
                Console.WriteLine($"First argument - File path");
                Console.WriteLine($"Second argument - searching substring");
                return (int)Codes.Info;
            }
            else if(args.Length != 2)
            {
                Console.WriteLine($"Please enter all arguments. For help input ? {Codes.Error}");
                return (int)Codes.Error;
            }
            //friendly varibals names
            string path = args[0];
            string substring = args[1];
            //check file
            if (!File.Exists(path))
            {
                Console.WriteLine($"File not found. {Codes.Error}");
                return (int)Codes.Error;
            }
            else if (Path.GetExtension(path) != ".txt")
            {
                Console.WriteLine($"File not a text. {Codes.Error}");
                return (int)Codes.Error;
            }
            //check substring
            if (String.IsNullOrWhiteSpace(substring) || substring.Length == 0)
            {
                Console.WriteLine($"Substing incorrect. {Codes.Error}");
                return (int)Codes.Error;
            }
            foreach(char ch in new List<char> { '.', '*', '^', '$', '+', '?' })
            {
                if (substring.Contains(ch))
                {
                    Console.WriteLine($"Do not using regex simbols. {Codes.Error}");
                    return (int)Codes.Error;
                }
            };
            //find count substrigs
            Console.WriteLine($"Cont of substring in file {new Regex(substring).Matches(File.ReadAllText(path)).Count} {Codes.OK}");
            return (int)Codes.OK;
        }
    }
}
