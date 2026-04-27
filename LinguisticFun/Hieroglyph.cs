using System;

namespace LinguisticFun
{
    public struct Hieroglyph
    {
        // Emoji, symbols, or pictograms that represent words or concepts in a visual form.
        public string Symbol { get; set; }
        public string[] word { get; set; }

        public string replace(string input)
        {
            foreach (var w in word)
            {
                input = input.Replace(w, Symbol, StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }

        public Hieroglyph(string symbol, params string[] words)
        {
            Symbol = symbol;
            word = words;
        }
    }
}

