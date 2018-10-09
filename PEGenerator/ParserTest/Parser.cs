using System.Text.RegularExpressions;

namespace PEGenerator
{
    namespace Values
    {
        public class Start : IPResult
        {
            public _4.Result Item { get; set; }
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
        public class Result : IPResult
        {
            public string Value { get; set; }
        }
        public string[] Values { get; }

        public _1()
        {
            this.Values = new string[] { "b", };
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

    public class _2
    {
        _1 item;
        public class Result
        {
            public _1.Result Item { get; set; }
        }

        public Result Parse(string line, int index, out int next, Parser parser)
        {
            var ret = new Result { Item = this.item.Parse(line, index, out next, parser) };
            if (next == -1)
            {
                next = index;
            }
            return ret;
        }

        public _2()
        {
            this.item = new _1();
        }
    }
    public class _3
    {
        public class Result : IPResult
        {
            public string Value { get; set; }
        }
        public string[] Values { get; }

        public _3()
        {
            this.Values = new string[] { "c", };
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

    public class _4
    {
        public class Result : IPResult
        {
            public _0.Result Item0 { get; set; }
            public _2.Result Item1 { get; set; }
            public _3.Result Item2 { get; set; }

        }
        _0 item0;
        _2 item1;
        _3 item2;


        public _4()
        {
            this.item0 = new _0();
            this.item1 = new _2();
            this.item2 = new _3();

        }

        public Result Parse(string line, int index, out int next, Parser parser)
        {
            var ret0 = this.item0.Parse(line, index, out index, parser);
            if (index == -1) { next = -1; return null; }
            var ret1 = this.item1.Parse(line, index, out index, parser);
            if (index == -1) { next = -1; return null; }
            var ret2 = this.item2.Parse(line, index, out index, parser);
            if (index == -1) { next = -1; return null; }

            next = index;
            return new Result()
            {
                Item0 = ret0,
                Item1 = ret1,
                Item2 = ret2,

            };
        }
    }
    public class Parser
    {
        _4 item0;


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
            this.item0 = new _4();

        }
    }

}
