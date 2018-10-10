using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PEGenerator.Utility;

namespace PEGenerator
{
    public class Generator
    {
        public interface IExpr
        {
            int PrintOut(StringBuilder builder, ref int index, Generator generator);
        }

        public class Term : IExpr
        {
            IEnumerable<string> values;
            public Term(string[] values)
            {
                this.values = values.Select(v => "\"" + v + "\"");
            }

            public override bool Equals(object obj)
            {
                return obj is Term term &&
                       EqualityComparer<IEnumerable<string>>.Default.Equals(this.values, term.values);
            }

            public override int GetHashCode()
            {
                return 1649527923 + EqualityComparer<IEnumerable<string>>.Default.GetHashCode(this.values);
            }

            public int PrintOut(StringBuilder builder, ref int index, Generator generator)
            {
                if (generator.HashTable.TryGetValue(this, out var ind))
                {
                    return ind;
                }
                var @this = ++index;
                generator.HashTable.Add(this, @this);
                builder.AppendLine(Resource1.TermTemplate)
                    .Replace(2, @this.ToString(), this.values.ToListString());
                return @this;
            }
        }
        public class RegexTerm : IExpr
        {
            string regex;

            public RegexTerm(string regex)
            {
                this.regex = regex;
            }

            public override bool Equals(object obj)
            {
                return obj is RegexTerm term &&
                       this.regex == term.regex;
            }

            public override int GetHashCode()
            {
                return 589921080 + EqualityComparer<string>.Default.GetHashCode(this.regex);
            }

            public int PrintOut(StringBuilder builder, ref int index, Generator generator)
            {
                if (generator.HashTable.TryGetValue(this, out var ind))
                {
                    return ind;
                }
                var @this = ++index;
                generator.HashTable.Add(this, @this);
                builder.AppendLine(Resource1.RegexTermTemplate).Replace(2,
                    @this.ToString(),
                    this.regex);
                return @this;
            }
        }
        public class Sequence : IExpr
        {
            IExpr[] exprs;

            public Sequence(IExpr[] exprs)
            {
                this.exprs = exprs;
            }

            public override bool Equals(object obj)
            {
                return obj is Sequence sequence &&
                       EqualityComparer<IExpr[]>.Default.Equals(this.exprs, sequence.exprs);
            }

            public override int GetHashCode()
            {
                return -894226177 + EqualityComparer<IExpr[]>.Default.GetHashCode(this.exprs);
            }

            public int PrintOut(StringBuilder builder, ref int index, Generator generator)
            {
                var result = new StringBuilder();
                var define = new StringBuilder();
                var init = new StringBuilder();
                var run = new StringBuilder();
                var @return = new StringBuilder();
                var child = new List<int>();
                if (generator.HashTable.TryGetValue(this, out var ind))
                {
                    return ind;
                }
                foreach (var e in this.exprs)
                {
                    child.Add(e.PrintOut(builder, ref index, generator));
                }
                var @this = ++index;
                generator.HashTable.Add(this, @this);
                foreach (var (i, j) in child.Indexed())
                {
                    result.AppendLine($"public _{i}.Result Item{j} {{get; set; }}");
                    define.AppendLine($"_{i} item{j};");
                    init.AppendLine($"this.item{j} = new _{i}();");
                    run.AppendLine($"var ret{j} = this.item{j}.Parse(line, index, out index, parser);");
                    run.AppendLine($"if(index == -1) {{ next = -1; return null; }}");
                    @return.AppendLine($"Item{j} = ret{j},");
                }
                builder.AppendLine(Resource1.SequenceTemplate).Replace(6,
                    @this.ToString(),
                    result.ToString(),
                    define.ToString(),
                    init.ToString(),
                    run.ToString(),
                    @return.ToString());
                return @this;
            }
        }
        public class Value : IExpr
        {
            string key;

            public Value(string key)
            {
                this.key = key;
            }

            public override bool Equals(object obj)
            {
                return obj is Value value &&
                       this.key == value.key;
            }

            public override int GetHashCode()
            {
                return 249886028 + EqualityComparer<string>.Default.GetHashCode(this.key);
            }

            public int PrintOut(StringBuilder builder, ref int index, Generator generator)
            {
                if (generator.HashTable.TryGetValue(this, out var ind))
                {
                    return ind;
                }
                var @this = ++index;
                generator.HashTable.Add(this, @this);

                builder.AppendLine(Resource1.ValueExprTemplate).Replace(3,
                    @this.ToString(),
                    this.key,
                    generator.Rkeys[this.key].ToString());
                return @this;
            }
        }
        public class Select : IExpr
        {
            IExpr[] exprs;

            public Select(IExpr[] exprs)
            {
                this.exprs = exprs;
            }

            public override bool Equals(object obj)
            {
                return obj is Select select &&
                       EqualityComparer<IExpr[]>.Default.Equals(this.exprs, select.exprs);
            }

            public override int GetHashCode()
            {
                return -894226177 + EqualityComparer<IExpr[]>.Default.GetHashCode(this.exprs);
            }

            public int PrintOut(StringBuilder builder, ref int index, Generator generator)
            {
                if (generator.HashTable.TryGetValue(this, out var ind))
                {
                    return ind;
                }
                var child = new List<int>();
                foreach(var e in this.exprs)
                {
                    child.Add(e.PrintOut(builder, ref index, generator));
                }
                var @this = ++index;
                generator.HashTable.Add(this, @this);
                var resultdefine = new StringBuilder();
                var define = new StringBuilder();
                var inside = new StringBuilder();
                var init = new StringBuilder();
                foreach (var (i, j) in child.Indexed())
                {
                    resultdefine.AppendLine($"public _{j}.Result Item{i} {{ get; set; }}");
                    define.AppendLine($"_{j} item{i};");
                    inside.AppendLine(Resource1.SelectInsideTemplate.BuilderReplace(j.ToString()));
                    init.AppendLine($"this.item{j} = new _{i}();");
                }
                builder.AppendLine(Resource1.SelectTemplate).Replace(5,
                    @this.ToString(),
                    resultdefine.ToString(),
                    define.ToString(),
                    inside.ToString(),
                    init.ToString());
                return @this;
            }
        }
        public class Optional : IExpr
        {
            IExpr expr;

            public Optional(IExpr expr)
            {
                this.expr = expr;
            }

            public override bool Equals(object obj)
            {
                return obj is Optional optional &&
                       EqualityComparer<IExpr>.Default.Equals(this.expr, optional.expr);
            }

            public override int GetHashCode()
            {
                return -1623473186 + EqualityComparer<IExpr>.Default.GetHashCode(this.expr);
            }

            public int PrintOut(StringBuilder builder, ref int index, Generator generator)
            {
                if (generator.HashTable.TryGetValue(this, out var ind))
                {
                    return ind;
                }
                var child = this.expr.PrintOut(builder, ref index, generator);
                var @this = ++index;
                generator.HashTable.Add(this, @this);
                builder.AppendLine(Resource1.OptionalTemplate).Replace(2,
                    @this.ToString(),
                    child.ToString());
                return @this;
            }
        }
        public class Repeat : IExpr
        {
            IExpr expr;

            public Repeat(IExpr expr)
            {
                this.expr = expr;
            }

            public override bool Equals(object obj)
            {
                return obj is Repeat repeat &&
                       EqualityComparer<IExpr>.Default.Equals(this.expr, repeat.expr);
            }

            public override int GetHashCode()
            {
                return -1623473186 + EqualityComparer<IExpr>.Default.GetHashCode(this.expr);
            }

            public int PrintOut(StringBuilder builder, ref int index, Generator generator)
            {
                if (generator.HashTable.TryGetValue(this, out var ind))
                {
                    return ind;
                }
                var child = this.expr.PrintOut(builder, ref index, generator);
                var @this = ++index;
                generator.HashTable.Add(this, @this);
                builder.AppendLine(Resource1.RepeatTemplate).Replace(2,
                    @this.ToString(),
                    child.ToString());
                return @this;
            }
        }
        
        public static Term NewTerm(params string[] values)
        {
            return new Term(values);
        }
        public static RegexTerm NewRegexTerm(string regex)
        {
            return new RegexTerm(regex);
        }
        public static Sequence NewSequence(params IExpr[] exprs)
        {
            return new Sequence(exprs);
        }
        public static Value NewValue(string key)
        {
            return new Value(key);
        }
        public static Select NewSelect(params IExpr[] exprs)
        {
            return new Select(exprs);
        }
        public static Optional NewOption(IExpr expr)
        {
            return new Optional(expr);
        }
        public static Repeat NewRepeat(IExpr expr)
        {
            return new Repeat(expr);
        }
        
        public Generator()
        {
            this.Exprs = new List<IExpr>();
            this.Keys = new List<string>();
            this.Rkeys = new Dictionary<string, int>();
            this.HashTable = new HashTable<IExpr, int>();
        }

        public void Add(string key, IExpr expr)
        {
            this.Rkeys.Add(key, this.Keys.Count);
            this.Keys.Add(key);
            this.Exprs.Add(expr);
        }

        public string Start { get; set; }
        public List<string> Keys { get; }
        public Dictionary<string, int> Rkeys { get; }
        public List<IExpr> Exprs { get; }
        public HashTable<IExpr, int> HashTable { get; }

        public string PrintOut(string @namespace)
        {
            var builder = new StringBuilder();
            var indexes = new List<int>();
            var index = -1;
            foreach(var e in this.Exprs)
            {
                indexes.Add(e.PrintOut(builder, ref index, this));
            }
            var valuedefine = new StringBuilder();
            var inswitch = new StringBuilder();
            var init = new StringBuilder();
            var usingdefine = new StringBuilder();
            foreach(var (i, j) in indexes.Indexed())
            {
                valuedefine.AppendLine($"_{i} item{j};");
                inswitch.AppendLine(Resource1.ParsingActionTemplate
                    .BuilderReplace(j.ToString(), this.Keys[j]));
                init.AppendLine($"this.item{j} = new _{i}();");
                usingdefine.AppendLine(Resource1.ValueTemplate
                    .BuilderReplace(this.Keys[j], i.ToString()));
            }
            builder.AppendLine(Resource1.ParserTemplate.BuilderReplace(
                valuedefine.ToString(),
                inswitch.ToString(),
                this.Start,
                init.ToString(),
                this.Rkeys[this.Start].ToString()));
            return Resource1.NamespaceTemplate.BuilderReplace(
                @namespace,
                usingdefine.ToString(),
                builder.ToString());
        }
    }
}
