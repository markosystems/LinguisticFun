using System;
using System.Collections.Generic;
using System.Text;

namespace LinguisticFun
{
    /// <summary>
    /// Provides functionality related to the creation of new words or phrases (neologisms).
    /// As well as restandardizing or regularizing existing words, introducing new linguistic patterns, 
    /// or blending elements from different languages and different symbol systems.
    /// </summary>
    public static class Neologetic
    {
        public static string MakeNeologism(string baseWord, string prefix = "", string suffix = "", bool toUpper = false)
        {
            var neologism = new StringBuilder();
            if (!string.IsNullOrEmpty(prefix))
            {
                neologism.Append(prefix);
            }
            neologism.Append(baseWord);
            if (!string.IsNullOrEmpty(suffix))
            {
                neologism.Append(suffix);
            }
            var result = neologism.ToString();
            return toUpper ? result.ToUpper() : result;
        }
    }
}
