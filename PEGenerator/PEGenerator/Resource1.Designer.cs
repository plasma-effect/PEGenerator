﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PEGenerator {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource1 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource1() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PEGenerator.Resource1", typeof(Resource1).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   using System.Text.RegularExpressions;
        ///
        ///namespace [[0]]
        ///{
        ///	namespace Values
        ///	{
        ///		[[1]]
        ///	}
        ///	public interface IPResult{}
        ///	[[2]]
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string NamespaceTemplate {
            get {
                return ResourceManager.GetString("NamespaceTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class _[[0]]
        ///{
        ///	_[[1]] item;
        ///	public class Result
        ///	{
        ///		public _[[1]].Result Item{ get; set;}
        ///	}
        ///
        ///	public Result Parse(string line, int index, out int next, Parser parser)
        ///	{
        ///		var ret = new Result{ Item = this.item.Parse(line, index, out next, parser)};
        ///		if(next != -1)
        ///		{
        ///			next = index;
        ///		}
        ///		return ret;
        ///	}
        ///
        ///	public _[[0]]()
        ///	{
        ///		this.item = new _[[1]]();
        ///	}
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string OptionalTemplate {
            get {
                return ResourceManager.GetString("OptionalTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class Parser
        ///{
        ///	[[0]]
        ///	
        ///	public IPResult Parse(string line, int index, out int next, int value)
        ///	{
        ///		switch (value)
        ///		{
        ///			[[1]]
        ///		}
        ///		next = -1;
        ///		return null;
        ///	}
        ///
        ///	public Values.[[2]] Parse(string line, out int end)
        ///	{
        ///		return Parse(line, 0, out end, [[4]]) as Values.[[2]];
        ///	}
        ///	
        ///	public Parser()
        ///	{
        ///		[[3]]
        ///	}
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ParserTemplate {
            get {
                return ResourceManager.GetString("ParserTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   case [[0]]:
        ///	var ret[[0]] = this.item[[0]].Parse(line, index, out next, this);
        ///	if(next != -1)
        ///	{
        ///		return new Values.[[1]]{ Item = ret[[0]] };
        ///	}
        ///	break; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ParsingActionTemplate {
            get {
                return ResourceManager.GetString("ParsingActionTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class _[[0]]
        ///{
        ///	public class Result : IPResult
        ///	{
        ///		public string Value { get; set; }
        ///	}
        ///	public Regex regex;
        ///
        ///	public _[[0]]()
        ///	{
        ///		this.regex = new Regex(@&quot;^[[1]]&quot;);
        ///	}
        ///	public Result Parse(string line, int index, out int next, Parser parser)
        ///	{
        ///		var match = this.regex.Match(line, index);
        ///		if (match.Success)
        ///		{
        ///			next = index + match.Length;
        ///			return new Result { Value = match.Value };
        ///		}
        ///		next = -1;
        ///		return null;
        ///	}
        ///}
        /// に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string RegexTermTemplate {
            get {
                return ResourceManager.GetString("RegexTermTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class _[[0]]
        ///{
        ///	_[[1]] item;
        ///
        ///	public class Result
        ///	{
        ///		List&lt;_[[1]].Result&gt; Items{ get; set; }
        ///	}
        ///
        ///	public Result Parse(string line, int index, out int next, Parser parser)
        ///	{
        ///		var list = new List&lt;_[[1]].Result&gt;();
        ///		while(index != line.Length)
        ///		{
        ///			var ret = this.item.Parse(line, index, out var n, parser);
        ///			if(n == -1)
        ///			{
        ///				break;
        ///			}
        ///			list.Add(ret);
        ///			index = n;
        ///		}
        ///		next = index;
        ///		return new Result{ Items = list };
        ///	}
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string RepeatTemplate {
            get {
                return ResourceManager.GetString("RepeatTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   var ret[[0]] = this.item[[0]].Parse(line, index, out next, parser);
        ///if(next != -1)
        ///{
        ///	return new Result{ Selected = [[0]], Item[[0]] = ret[[0]] };
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SelectInsideTemplate {
            get {
                return ResourceManager.GetString("SelectInsideTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class _[[0]]
        ///{
        ///	public class Result
        ///	{
        ///		public int Selected { get; set; }
        ///		[[1]]
        ///	}
        ///	[[2]]
        ///
        ///	public Result Parse(string line, int index, out int next, Parser parser)
        ///	{
        ///		[[3]]
        ///		return null;
        ///	}
        ///
        ///	public _[[0]]()
        ///	{
        ///		[[4]]
        ///	}
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SelectTemplate {
            get {
                return ResourceManager.GetString("SelectTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class _[[0]]
        ///{
        ///	public class Result : IPResult
        ///	{
        ///		[[1]]
        ///	}
        ///	[[2]]
        ///
        ///	public _[[0]]()
        ///	{
        ///		[[3]]
        ///	}
        ///
        ///	public Result Parse(string line, int index, out int next, Parser parser)
        ///	{
        ///		[[4]]
        ///		next = index;
        ///		return new Result()
        ///		{
        ///			[[5]]
        ///		};
        ///	}
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SequenceTemplate {
            get {
                return ResourceManager.GetString("SequenceTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class _[[0]]
        ///{
        ///	public class Result : IPResult
        ///	{
        ///		public string Value { get; set; }
        ///	}
        ///	public string[] Values { get; }
        ///
        ///	public _[[0]]()
        ///	{
        ///		this.Values = new string[]{ [[1]] };
        ///	}
        ///	public Result Parse(string line, int index, out int next, Parser parser)
        ///	{
        ///		foreach (var v in this.Values)
        ///		{
        ///			if (line.Length - index &lt; v.Length)
        ///			{
        ///				continue;
        ///			}
        ///			if (v == line.Substring(index, v.Length))
        ///			{
        ///				next = index + v.Length;
        ///				return new Result() { Value = v };
        ///	 [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string TermTemplate {
            get {
                return ResourceManager.GetString("TermTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class _[[0]]
        ///{
        ///	public class Result
        ///	{
        ///		public Values.[[1]] Item{ get; set; }
        ///	}
        ///
        ///	public Result Parse(string line, int index, out int next, Parser parser)
        ///	{
        ///		var ret = parser.Parse(line, index, out next, [[2]]);
        ///		if (next != -1)
        ///		{
        ///			return new Result { Item = ret as Values.[[1]] };
        ///		}
        ///		return null;
        ///	}
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ValueExprTemplate {
            get {
                return ResourceManager.GetString("ValueExprTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   public class [[0]] : IPResult
        ///{
        ///	public _[[1]].Result Item{ get; set; }
        ///} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string ValueTemplate {
            get {
                return ResourceManager.GetString("ValueTemplate", resourceCulture);
            }
        }
    }
}
