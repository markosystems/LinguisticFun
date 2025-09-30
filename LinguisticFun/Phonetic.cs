using System;
using System.Collections.Generic;
using System.Text;

namespace LinguisticFun
{
    /// <summary>
    /// Provides methods for phonetic transformations of English words.
    /// please note that these methods are not comprehensive and may not cover all edge cases in English pronunciation.
    /// The methods are better suited for single words rather than full sentences.
    /// </summary>
    public static class Phonetic
    {
        public static HomophoneRules homophoneRules { get; } = new HomophoneRules();
        static string vowels = "aeiouy";
        /// <summary>
        /// Removes common silent letters from English words.
        /// </summary>
        public static string NoSilentLetters(string input)
        {
            
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }
            if(input.Contains("kn", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("kn", "n", StringComparison.OrdinalIgnoreCase);
            }
            if(input.Contains("gn", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("gn", "n", StringComparison.OrdinalIgnoreCase);
            }
            if(input.Contains("pn", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("pn", "n", StringComparison.OrdinalIgnoreCase);
            }
            if(input.Contains("ae", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("ae", "e", StringComparison.OrdinalIgnoreCase);
            }
            if(input.Contains("wr", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("wr", "r", StringComparison.OrdinalIgnoreCase);
            }
            if(input.Contains("wh", StringComparison.OrdinalIgnoreCase))
            {
                if(input.Contains("who", StringComparison.OrdinalIgnoreCase))
                {
                    input = input.Replace("who", "hoo", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    input = input.Replace("wh", "w", StringComparison.OrdinalIgnoreCase);
                }
            }
            if(input.EndsWith("mb", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring(0, input.Length - 1);
            }

            return input;
        }
        /// <summary>
        /// Removes consecutive duplicate consonants from English words.
        ///</summary>
        public static string SimplifyConsonants(string input)
        {
            /// <summary>
            /// Simplifies consonant clusters in English words.
            /// 
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }
            var sb = new StringBuilder();
            sb.Append(input[0]);
            for(int i = 1; i < input.Length; i++)
            {
                if(char.ToLower(input[i]) == char.ToLower(input[i - 1]) &&
                   "bcdfghjklmnpqrstvwxyz".Contains(char.ToLower(input[i])))
                {
                    continue;
                }
                sb.Append(input[i]);
            }
            /// <summary>
            /// keeps the first letter and removes consecutive duplicate consonants.
            return sb.ToString();
        }
        /// <summary>
        /// substitutes homophones with their dominant variants.
        /// </summary>
        public static string NoHomophones(string input)
        {
            if (!homophoneRules.DomsSet)
            {
                throw new InvalidOperationException("Dominant homophone variants have not been set. Call homophoneRules.SetDominantVariants() first.");
            }
            return homophoneRules.getdominant(input);
        }
        /// <summary>
        /// Replaces "ph" with "f" and handles special cases like "rough", "cough", "tough", and "enough".
        /// </summary>
        public static string JustUseF(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }
            if (input.Contains("rough", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("rough", "ruf", StringComparison.OrdinalIgnoreCase);

            }
            else if (input.Contains("cough", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("cough", "kof", StringComparison.OrdinalIgnoreCase);
            }
            else if (input.Contains("tough", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("tough", "tuf", StringComparison.OrdinalIgnoreCase);
            }
            else if (input.Contains("enough", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("enough", "enuf", StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                input = input.Replace("ph", "f", StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
        /// <summary>
        /// Replaces "ou" with "ow" to reflect its common phonetic pronunciation.
        /// </summary>
        public static string WhatIsOU(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }
           
            input = input.Replace("ou", "ow", StringComparison.OrdinalIgnoreCase);
            return input;
        }
        /// <summary>
        /// Replaces vowel combinations "ea", "ie", and "ei" with "ee" to simplify pronunciation.
        /// </summary>
        public static string JustUseDoubleE(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }
           
            input = input.Replace("ea", "ee", StringComparison.OrdinalIgnoreCase);
            if (!input.Contains("pie", StringComparison.OrdinalIgnoreCase) && !input.Contains("cei", StringComparison.OrdinalIgnoreCase) && !input.EndsWith("s", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("ie", "ee", StringComparison.OrdinalIgnoreCase);
            }
            input = input.Replace("ei", "ee", StringComparison.OrdinalIgnoreCase);
            return input;
        }
        /// <summary>
        /// Handles the letter "x" by replacing it with "z" if it starts a word, or "ks" otherwise.
        /// </summary>
        public static string XisAUselessLetter(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }

            if (input.StartsWith("x", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("x", "z", StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                input = input.Replace("x", "ks", StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
        /// <summary>
        /// Replaces "sh", "sch", "ti", and "ci" with "sh" or "zh" sounds based on context.
        /// </summary>
        public static string JustUseSh(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }
            // words like "station" and "action" should be transformed to "sh" sound as long as there is a vowel after "ti" or "ci"
            if (input.Contains("tion", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("tion", "shun", StringComparison.OrdinalIgnoreCase);
            }
            else if (input.Contains("sion", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("sion", "zhun", StringComparison.OrdinalIgnoreCase);
            }
            else if (input.Contains("ci", StringComparison.OrdinalIgnoreCase))
            {
                int index = input.IndexOf("ci", StringComparison.OrdinalIgnoreCase);
                if (index + 2 < input.Length && vowels.Contains(char.ToLower(input[index + 2])))
                {
                    input = input.Replace("ci", "shi", StringComparison.OrdinalIgnoreCase);
                }
            }
            else if (input.Contains("ti", StringComparison.OrdinalIgnoreCase))
            {
                int index = input.IndexOf("ti", StringComparison.OrdinalIgnoreCase);
                if (index + 2 < input.Length && vowels.Contains(char.ToLower(input[index + 2])))
                {
                    input = input.Replace("ti", "shi", StringComparison.OrdinalIgnoreCase);
                }
            }
            else
            {
                input = input.Replace("sh", "sh", StringComparison.OrdinalIgnoreCase);
                input = input.Replace("sch", "sh", StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }
        /// <summary>
        /// Replaces "th" with "d" to reflect its common phonetic pronunciation.
        /// </summary>
        public static string TH_IsntReal(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            if(input.Length < 2)
            {
                return input;
            }
           
            input = input.Replace("th", "d", StringComparison.OrdinalIgnoreCase);
            return input;
        }
        public static string C_IsntReal(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            if (input.Length < 2)
            {
                return input;
            }
            if(input.Contains("ce", StringComparison.OrdinalIgnoreCase) || input.Contains("ci", StringComparison.OrdinalIgnoreCase) || input.Contains("cy", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("ce", "se", StringComparison.OrdinalIgnoreCase);
                input = input.Replace("ci", "si", StringComparison.OrdinalIgnoreCase);
                input = input.Replace("cy", "sy", StringComparison.OrdinalIgnoreCase);
            }
            else if(input.Contains("ch", StringComparison.OrdinalIgnoreCase))
            {
                // words like "chord" and "chorus" should keep the "k" sound
                if (input.Contains("chor", StringComparison.OrdinalIgnoreCase) || input.Contains("char", StringComparison.OrdinalIgnoreCase) || input.Contains("chem", StringComparison.OrdinalIgnoreCase) || input.Contains("chord", StringComparison.OrdinalIgnoreCase))
                {
                    input = input.Replace("ch", "k", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    // check if vowel follows ch, if so, change to "K" sound
                    int index = input.IndexOf("ch", StringComparison.OrdinalIgnoreCase);
                    if (index + 2 < input.Length && vowels.Contains(char.ToLower(input[index + 2])))
                    {
                        input = input.Replace("ch", "k", StringComparison.OrdinalIgnoreCase);
                    }
                    else
                    {
                        input = input.Replace("ch", "ch", StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
            else
                input = input.Replace("c", "k", StringComparison.OrdinalIgnoreCase);
            return input;
        }
        public static string Y_isNotAVowel(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;

            }
            if (input.Length < 2)
            {
                return input;
            }
            if(input.EndsWith("y", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Replace("y", "ii", StringComparison.OrdinalIgnoreCase);
            }
            return input;
        }

        /// <summary>
        /// Translates a single word by applying a series of phonetic transformation rules.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TranslateSingleWord(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                return input;
            }
            var word = input;
            word = NoHomophones(word);
            word = NoSilentLetters(word);
            word = TH_IsntReal(word);
            word = JustUseF(word);
            word = WhatIsOU(word);
            //word = C_IsntReal(word);
            word = JustUseDoubleE(word);
            word = XisAUselessLetter(word);
            word = JustUseSh(word);
            word = Y_isNotAVowel(word);
            word = SimplifyConsonants(word);
            return word;

        }
        /// <summary>
        /// Translates a full sentence by applying phonetic transformations to each word individually.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TranslateSentence(string input)
        {
            var words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                try
                {
                    words[i] = TranslateSingleWord(words[i]);
                }catch(Exception ex)
                {
                    Console.WriteLine($"Error translating word '{words[i]}': {ex.Message}");
                }
            }
            return string.Join(' ', words);
        }
    }

    public class Homophone
    {
        public string[] Variants { get; set; }
        public string DomananttVariant { get; set; }
        public Homophone(string[] variants)
        {
            Variants = variants;
            DomananttVariant = null;
        }

        public string GetDominantVariant(string input)
        {
            if(!string.IsNullOrEmpty(DomananttVariant))
            {
                return DomananttVariant;
            }
            return input;
        }

        public bool Contains(string word)
        {
            foreach(var variant in Variants)
            {
                if(string.Equals(variant, word, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void SetDominantVariant(string dominant)
        {
            DomananttVariant = dominant;
        }
        public void SetFirstAsDominant()
        {
            if(Variants.Length > 0)
            {
                DomananttVariant = Variants[0];
            }
        }
    }
}
