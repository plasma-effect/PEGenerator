using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static PEGenerator.Generator;

namespace PEGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator()
            {
                Start = "Start"
            };
            generator.Add("Start", NewSequence(NewTerm("a"), NewOption(NewTerm("b")), NewTerm("c")));
            WriteLine(generator.PrintOut("PEGenerator"));
#if DEBUG
            WriteLine("終了を待機しています。Enterを押してください。");
            ReadLine();
#endif
        }
    }
}
