using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace PEGenerator
{
    namespace Values
    {
        public class Start : IPResult
        {
            public _1.Result Item { get; set; }
        }

    }
    public interface IPResult { }
    public class _0
    {
        public class Result : IPResult
        {
            public string Value { get; set; }
        }
        public string[] Values { get; }

        public _0()
        {
            this.Values = new string[] { "a", };
        }
        public Result Parse(string line, int index, out int next, Parser parser)
        {
            foreach (var v in this.Values)
            {
                if (line.Length - index < v.Length)
                {
                    continue;
                }
                if (v == line.Substring(index, v.Length))
                {
                    next = index + v.Length;
                    return new Result() { Value = v };
                }
            }
            next = -1;
            return null;
        }
    }

    public class _1
    {
        _0 item;

        public class Result
        {
            public List<_0.Result> Items { get; set; }
        }

        public Result Parse(string line, int index, out int next, Parser parser)
        {
            var list = new List<_0.Result>();
            while (index != line.Length)
            {
                var ret = this.item.Parse(line, index, out var n, parser);
                if (n == -1)
                {
                    break;
                }
                list.Add(ret);
                index = n;
            }
            next = index;
            return new Result { Items = list };
        }

        public _1()
        {
            this.item = new _0();
        }
    }
    public class Parser
    {
        _1 item0;


        public IPResult Parse(string line, int index, out int next, int value)
        {
            switch (value)
            {
                case 0:
                    var ret0 = this.item0.Parse(line, index, out next, this);
                    if (next != -1)
                    {
                        return new Values.Start { Item = ret0 };
                    }
                    break;

            }
            next = -1;
            return null;
        }

        public Values.Start Parse(string line, out int end)
        {
            return Parse(line, 0, out end, 0) as Values.Start;
        }

        public Parser()
        {
            this.item0 = new _1();

        }
    }

}
