using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public static string Anti_Capitalism(string input)
        {
            return input.ToLower();
        }
        public static string To_UWU(string input)
        {
            return input.Replace("r", "w", StringComparison.OrdinalIgnoreCase).Replace("l", "w", StringComparison.OrdinalIgnoreCase);
        }
        public static string To_Leet(string input)
        {
            return input.Replace("a", "4", StringComparison.OrdinalIgnoreCase)
                        .Replace("e", "3", StringComparison.OrdinalIgnoreCase)
                        .Replace("i", "1", StringComparison.OrdinalIgnoreCase)
                        .Replace("o", "0", StringComparison.OrdinalIgnoreCase)
                        .Replace("s", "5", StringComparison.OrdinalIgnoreCase)
                        .Replace("t", "7", StringComparison.OrdinalIgnoreCase);
        }
        public static string To_Hieroglyph(string input)
        {
            foreach (var hieroglyph in Hieroglyphs)
            {
                input = hieroglyph.replace(input);
            }
            return input;
        }
        public static string To_HIRAGANA(string input)
        {
            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // Digraphs (must come first)
        { "kya", "きゃ" }, { "kyu", "きゅ" }, { "kyo", "きょ" },
        { "sha", "しゃ" }, { "shu", "しゅ" }, { "sho", "しょ" },
        { "cha", "ちゃ" }, { "chu", "ちゅ" }, { "cho", "ちょ" },
        { "nya", "にゃ" }, { "nyu", "にゅ" }, { "nyo", "にょ" },
        { "hya", "ひゃ" }, { "hyu", "ひゅ" }, { "hyo", "ひょ" },
        { "mya", "みゃ" }, { "myu", "みゅ" }, { "myo", "みょ" },
        { "rya", "りゃ" }, { "ryu", "りゅ" }, { "ryo", "りょ" },
        { "gya", "ぎゃ" }, { "gyu", "ぎゅ" }, { "gyo", "ぎょ" },
        { "ja", "じゃ" }, { "ju", "じゅ" }, { "jo", "じょ" },
        { "bya", "びゃ" }, { "byu", "びゅ" }, { "byo", "びょ" },
        { "pya", "ぴゃ" }, { "pyu", "ぴゅ" }, { "pyo", "ぴょ" },

        // Basic syllables
        { "a", "あ" }, { "i", "い" }, { "u", "う" }, { "e", "え" }, { "o", "お" },

        { "ka", "か" }, { "ki", "き" }, { "ku", "く" }, { "ke", "け" }, { "ko", "こ" },
        { "sa", "さ" }, { "shi", "し" }, { "su", "す" }, { "se", "せ" }, { "so", "そ" },
        { "ta", "た" }, { "chi", "ち" }, { "tsu", "つ" }, { "te", "て" }, { "to", "と" },
        { "na", "な" }, { "ni", "に" }, { "nu", "ぬ" }, { "ne", "ね" }, { "no", "の" },
        { "ha", "は" }, { "hi", "ひ" }, { "fu", "ふ" }, { "he", "へ" }, { "ho", "ほ" },
        { "ma", "ま" }, { "mi", "み" }, { "mu", "む" }, { "me", "め" }, { "mo", "も" },
        { "ya", "や" }, { "yu", "ゆ" }, { "yo", "よ" },
        { "ra", "ら" }, { "ri", "り" }, { "ru", "る" }, { "re", "れ" }, { "ro", "ろ" },
        { "wa", "わ" }, { "wo", "を" },
        { "n", "ん" },

        // Dakuten / Handakuten
        { "ga", "が" }, { "gi", "ぎ" }, { "gu", "ぐ" }, { "ge", "げ" }, { "go", "ご" },
        { "za", "ざ" }, { "ji", "じ" }, { "zu", "ず" }, { "ze", "ぜ" }, { "zo", "ぞ" },
        { "da", "だ" }, { "de", "で" }, { "do", "ど" },
        { "ba", "ば" }, { "bi", "び" }, { "bu", "ぶ" }, { "be", "べ" }, { "bo", "ぼ" },
        { "pa", "ぱ" }, { "pi", "ぴ" }, { "pu", "ぷ" }, { "pe", "ぺ" }, { "po", "ぽ" }
    };

            // Replace longest keys first to avoid partial conflicts
            var ordered = map.Keys.OrderByDescending(k => k.Length);

            foreach (var key in ordered)
            {
                input = input.Replace(key, map[key], StringComparison.OrdinalIgnoreCase);
            }

            return input;
        }
        public static string No_More_Homographs(string input)
        {
            return HomographsReader.Read(input, Homographs);
        }

        static List<Hieroglyph> Hieroglyphs { get; } = new List<Hieroglyph>()
        {
            new Hieroglyph("🌞", "sun", "day"),
            new Hieroglyph("🌙", "moon", "night"),
            new Hieroglyph("👋", "hello", "hi", "hey"),
            new Hieroglyph("❤️", "love", "heart"),
            new Hieroglyph("😊", "happy", "glad", "smile"),
            new Hieroglyph("😢", "sad", "cry", "unhappy"),
            new Hieroglyph("🔥", "fire", "lit", "hot"),
            new Hieroglyph("⭐", "star", "favorite"),
            new Hieroglyph("👍", "good", "yes", "ok", "okay"),
            new Hieroglyph("👎", "bad", "no"),
            new Hieroglyph("⚡", "fast", "quick", "lightning"),
            new Hieroglyph("💡", "idea", "think", "thought"),
            new Hieroglyph("📚", "book", "study", "learn"),
            new Hieroglyph("🎵", "music", "song"),
            new Hieroglyph("🍔", "burger", "food", "eat"),
            new Hieroglyph("☕", "coffee", "drink"),
            new Hieroglyph("🏠", "home", "house"),
            new Hieroglyph("🚗", "car", "drive"),
            new Hieroglyph("✈️", "plane", "travel", "fly"),
            new Hieroglyph("🌧️", "rain", "storm"),
            new Hieroglyph("☀️", "sun", "sunny"),
            new Hieroglyph("🌙", "night", "moon"),
            new Hieroglyph("⏰", "time", "clock"),
            new Hieroglyph("💰", "money", "cash"),
            new Hieroglyph("🔒", "lock", "secure"),
            new Hieroglyph("🔓", "unlock", "open"),
            new Hieroglyph("🎉", "party", "celebrate"),
            new Hieroglyph("🏆", "win", "victory", "trophy"),
            new Hieroglyph("💀", "dead", "death"),
            new Hieroglyph("👀", "look", "see", "watch"),
            new Hieroglyph("🧠", "brain", "smart", "think"),
            new Hieroglyph("💬", "talk", "chat", "message"),
            new Hieroglyph("📱", "phone", "call", "text"),
            new Hieroglyph("🍕", "pizza", "food", "eat"),
            new Hieroglyph("🎮", "game", "play"),
        };
        public static string[] RuleNames= new string[]
        {
            "Anti_Capitalism",
            "To_UWU",
            "To_Leet",
            "To_Hieroglyph",
            "To_HIRAGANA",
            "No_More_Homographs"
        };

        static Homograph[] Homographs = new Homograph[]
        {
            new Homograph(
                "lead",
                new WordVariant(
                    "leed",
                    "verb",
                    @"\blead\b.*\b(go|walk|run|follow|way)\b"
                ),
                new WordVariant(
                    "leid",
                    "metal",
                    @"\blead\b.*\b(pipe|metal|heavy|fill with)\b"
                )
            ),
            new Homograph(
                "read", new WordVariant(
                "readed",
                "past tense",
                @"\b(read)\b.*\b(yesterday|last week|in the past)\b"))
        };

        public static Rule GetRule(string ruleName)
        {
            return ruleName switch
            {
                "Anti_Capitalism" => Anti_Capitalism,
                "To_UWU" => To_UWU,
                "To_Leet" => To_Leet,
                "To_Hieroglyph" => To_Hieroglyph,
                "To_HIRAGANA" => To_HIRAGANA,
                "No_More_Homographs" => No_More_Homographs,
                _ => throw new ArgumentException($"Rule '{ruleName}' not found.")
            };
        }

        public static bool DoesRuleExist(string ruleName)
        {
            foreach (var name in RuleNames)
            {
                if (string.Equals(name, ruleName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    };
}

