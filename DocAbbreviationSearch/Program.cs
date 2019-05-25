using System;
using System.Collections.Generic;
using System.IO;

namespace DocAbbreviationSearch
{
    class Program
    {
        static readonly byte defaultAbbreviationLength = 2;
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("usage: dotnet {0} <document filename> <minimal number of upper case letters in abbreviation>", AppDomain.CurrentDomain.FriendlyName);
                return;
            }

            try
            {
                DocAbbreviationSearcher searcher = new DocAbbreviationSearcher
                { 
                    Filepath = args[0]
                };
                foreach (string abbreviation in searcher.GetAbbreviations(args.Length > 1 ? byte.Parse(args[1]) : defaultAbbreviationLength))
                {
                    Console.WriteLine(abbreviation);
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("File {0} does not exist", args[0]);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File {0} does not exist", args[0]);
            }
            catch
            {
                Console.WriteLine("Search error occured");
            }
        }
    }
}
