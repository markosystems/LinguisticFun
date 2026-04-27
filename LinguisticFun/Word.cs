using System;
using System.Collections.Generic;
using System.Text;

namespace LinguisticFun
{
    /// <summary>
    /// Represents an english word with properties and methods for linguistic manipulation.
    /// </summary>
    public class WordVariation
    {
        public string Text { get; set; }
        public int Length => Text.Length;
        public string Root { get; set; }
        public List<string> Prefixes { get; set; } = new List<string>();
        public List<string> Suffixes { get; set; } = new List<string>();
    }
}
