using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using PEGenerator.Values;

namespace ParserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new PEGenerator.Parser();
            var ret = parser.Parse(ReadLine(), out var n);
            WriteLine(ret?.ToString() ?? "null");
            if (ret != null)
            {
                var item = ret.Item;
                WriteLine(item.Item0.Value);
                WriteLine(item.Item1.Item?.Value ?? "[]");
                WriteLine(item.Item2.Value);
            }
        }
    }
}
