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
                foreach(var v in ret.Item.Items)
                {
                    WriteLine(v.Value);
                }
            }
        }
    }
}
