using System;
using System.Text.RegularExpressions;

namespace LinguisticFun
{
    public struct Homograph
    {
        public string Spelling;
        public WordVariant[] Variants;

        public Homograph(string spelling, params WordVariant[] variants)
        {
            Spelling = spelling;
            Variants = variants;
        }

        public string CheckVariant(string context)
        {
            for (int i = 0; i < Variants.Length; i++)
            {
                if (Variants[i].Context == context)
                    return Variants[i].Spelling;
            }

            return Spelling;
        }
    }
    public static class HomographsReader
    {
        public static string Read(string input, Homograph[] homonymns)
        {
            var sentences = input.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;

            foreach (var sentence in sentences)
            {
                result += ReadSentence(sentence, homonymns) + ". ";
            }

            return result.Trim();
        }

        public static string ReadSentence(string sentence, Homograph[] homonymns)
        {
            var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                foreach (var homonymn in homonymns)
                {
                    if (homonymn.Spelling.Equals(words[i], StringComparison.OrdinalIgnoreCase))
                    {
                        string context = GetContext(sentence, homonymn.Variants);

                        if (!string.IsNullOrEmpty(context))
                        {
                            words[i] = homonymn.CheckVariant(context);
                        }

                        break;
                    }
                }
            }

            return string.Join(' ', words);
        }

        private static string GetContext(string sentence, WordVariant[] variants)
        {
            foreach (var variant in variants)
            {
                foreach (var pattern in variant.Patterns)
                {
                    if (Regex.IsMatch(sentence, pattern, RegexOptions.IgnoreCase))
                    {
                        return variant.Context;
                    }
                }
            }

            return null;
        }
    }
    public struct WordVariant
    {
        public string Spelling;
        public string Context;

        // NEW: explicit triggers
        public string[] Patterns;

        public WordVariant(string spelling, string context, params string[] patterns)
        {
            Spelling = spelling;
            Context = context;
            Patterns = patterns;
        }
    }
}
