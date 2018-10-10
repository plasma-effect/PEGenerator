using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEGenerator
{
    static class Utility
    {
        static public IEnumerable<Tuple<T,int>> Indexed<T>(this IEnumerable<T> ie)
        {
            var index = -1;
            foreach(var v in ie)
            {
                yield return new Tuple<T, int>(v, ++index);
            }
        }

        static public IEnumerable<int> Range(int start, int end)
        {
            for (var i = start; i < end; ++i)
            {
                yield return i;
            }
        }

        static public string ToListString(this IEnumerable<string> vs, string digit = ",")
        {
            var ret = new StringBuilder();
            foreach(var v in vs)
            {
                ret.Append($"{v}{digit}");
            }
            return ret.ToString();
        }

        static public string BuilderReplace(this string str, params string[] args)
        {
            var builder = new StringBuilder(str);
            foreach (var (s, i) in args.Indexed())
            {
                builder.Replace($"[[{i}]]", s);
            }
            return builder.ToString();
        }
        
        /// <summary>
        /// [[i]]をReplaceする関数
        /// </summary>
        /// <param name="builder">本体のStringBuilder</param>
        /// <param name="count">個数(place holderなので別に-1でもよい)</param>
        /// <param name="args">置き換えたい文字列</param>
        /// <returns></returns>
        static public StringBuilder Replace(this StringBuilder builder, int count, params string[] args)
        {
            foreach (var (s, i) in args.Indexed())
            {
                builder.Replace($"[[{i}]]", s);
            }
            return builder;
        }
    }

    public class HashTable<T, U>
    {
        Dictionary<int, List<Tuple<T, U>>> tables;

        public HashTable()
        {
            this.tables = new Dictionary<int, List<Tuple<T, U>>>();
        }

        public void Add(T val, U code)
        {
            var hash = val.GetHashCode();
            if (!this.tables.ContainsKey(hash))
            {
                this.tables.Add(hash, new List<Tuple<T, U>>());
            }
            this.tables[hash].Add(new Tuple<T, U>(val, code));
        }

        public bool TryGetValue(T val, out U code)
        {
            var hash = val.GetHashCode();
            if (this.tables.ContainsKey(hash))
            {
                foreach(var v in this.tables[hash])
                {
                    if(v.Item1.Equals(val))
                    {
                        code = v.Item2;
                        return true;
                    }
                }
            }
            code = default(U);
            return false;
        }
    }

}
