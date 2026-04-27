using System;
using System.Collections.Generic;

namespace LinguisticFun
{
    /// <summary>
    /// Translator class applies a series of linguistic transformation rules to input text.
    /// This library is designed for educational and entertainment purposes, allowing users to explore ways to destroy the English language through playful text manipulation.
    /// A fun thing to do is play around with the order of the rules to see how it changes the output.
    /// </summary>
    public static class Translator
    {
        public static List<Rule> Rules { get; } = new List<Rule>();

        public static void ActiveRule(string ruleName)
        {
            if(Phonetic.DoesRuleExist(ruleName))
            {
                Rules.Add(Phonetic.GetRule(ruleName));
            }
            if (Neologetic.DoesRuleExist(ruleName))
            {
                Rules.Add(Neologetic.GetRule(ruleName));
            }
        }

        public static string Translate(string input)
        {
            foreach(var rule in Rules)
            {
                input = rule(input);
            }
            return input;
        }
    }

    public delegate string Rule(string input);
}
