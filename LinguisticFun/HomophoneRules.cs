using System;
using System.Collections.Generic;
using System.Text;

namespace LinguisticFun
{
    public class HomophoneRules
    {
        public bool DomsSet { get; private set; } = false;
        public List<Homophone> Homophones { get; } = new List<Homophone>(){
    new Homophone( new string[]{ "too", "to", "two" } ),
    new Homophone( new string[]{ "there", "their", "they're" } ),
    new Homophone( new string[]{ "your", "you're" } ),
    new Homophone( new string[]{ "its", "it's" } ),
    new Homophone( new string[]{ "hear", "here" } ),
    new Homophone( new string[]{ "sea", "see" } ),
    new Homophone( new string[]{ "rite", "right", "write" } ),
    new Homophone( new string[]{ "flower", "flour" } ),
    new Homophone( new string[]{ "plane", "plain" } ),
    new Homophone( new string[]{ "bye", "by", "buy" } ),
    new Homophone( new string[]{ "won", "one" } ),
    new Homophone( new string[]{ "no", "know" } ),
    new Homophone( new string[]{ "brake", "break" } ),
    new Homophone( new string[]{ "peace", "piece" } ),
    new Homophone( new string[]{ "blue", "blew" } ),
    new Homophone( new string[]{ "meet", "meat" } ),
    new Homophone( new string[]{ "night", "knight" } ),
    new Homophone( new string[]{ "stake", "steak" } ),
    new Homophone( new string[]{ "sell", "cell" } ),
    new Homophone( new string[]{ "male", "mail" } ),
    new Homophone( new string[]{ "rode", "road" } ),
    new Homophone( new string[]{ "sale", "sail" } ),
    new Homophone( new string[]{ "wait", "weight" } ),
    new Homophone( new string[]{ "wear", "where" } ),
    new Homophone( new string[]{ "wood", "would" } ),
    new Homophone( new string[]{ "aloud", "allowed" } ),
    new Homophone( new string[]{ "alter", "altar" } ),
    new Homophone( new string[]{ "isle", "aisle" } ),
    new Homophone( new string[]{ "bare", "bear" } ),
    new Homophone( new string[]{ "bark", "barque" } ),
    new Homophone( new string[]{ "base", "bass" } ),
    new Homophone( new string[]{ "bee", "be" } ),
    new Homophone( new string[]{ "beat", "beet" } ),
    new Homophone( new string[]{ "bore", "boar" } ),
    new Homophone( new string[]{ "born", "borne" } ),
    new Homophone( new string[]{ "bred", "bread" } ),
    new Homophone( new string[]{ "capital", "capitol" } ),
    new Homophone( new string[]{ "carrot", "carat", "caret" } ),
    new Homophone( new string[]{ "ceiling", "sealing" } ),
    new Homophone( new string[]{ "sent", "cent", "scent" } ),
    new Homophone( new string[]{ "cheap", "cheep" } ),
    new Homophone( new string[]{ "chilly", "chili" } ),
    new Homophone( new string[]{ "site", "sight", "cite" } ),
    new Homophone( new string[]{ "claws", "clause" } ),
    new Homophone( new string[]{ "course", "coarse" } ),
    new Homophone( new string[]{ "compliment", "complement" } ),
    new Homophone( new string[]{ "counsel", "council" } ),
    new Homophone( new string[]{ "creek", "creak" } ),
    new Homophone( new string[]{ "current", "currant" } ),
    new Homophone( new string[]{ "damn", "dam" } ),
    new Homophone( new string[]{ "deer", "dear" } ),
    new Homophone( new string[]{ "die", "dye" } ),
    new Homophone( new string[]{ "dough", "doe" } ),
    new Homophone( new string[]{ "duel", "dual" } ),
    new Homophone( new string[]{ "urn", "earn" } ),
    new Homophone( new string[]{ "faint", "feint" } ),
    new Homophone( new string[]{ "fair", "fare" } ),
    new Homophone( new string[]{ "feet", "feat" } ),
    new Homophone( new string[]{ "fur", "fir" } ),
    new Homophone( new string[]{ "flee", "flea" } ),
    new Homophone( new string[]{ "for", "four", "fore" } ),
    new Homophone( new string[]{ "forth", "fourth" } ),
    new Homophone( new string[]{ "fowl", "foul" } ),
    new Homophone( new string[]{ "gate", "gait" } ),
    new Homophone( new string[]{ "jean", "gene" } ),

    // ✅ Added common missing ones
    new Homophone( new string[]{ "pair", "pear", "pare" } ),
    new Homophone( new string[]{ "sole", "soul" } ),
    new Homophone( new string[]{ "scene", "seen" } ),
    new Homophone( new string[]{ "steel", "steal" } ),
    new Homophone( new string[]{ "witch", "which" } ),
    new Homophone( new string[]{ "whole", "hole" } ),
    new Homophone( new string[]{ "pale", "pail" } ),
    new Homophone( new string[]{ "made", "maid" } ),
    new Homophone( new string[]{ "minor", "miner" } ),
    new Homophone( new string[]{ "weather", "whether" } ),
    new Homophone( new string[]{ "past", "passed" } ),
    new Homophone( new string[]{ "principle", "principal" } ),
    new Homophone( new string[]{ "stationary", "stationery" } ),
    new Homophone( new string[]{ "waist", "waste" } ),
    new Homophone( new string[]{ "whose", "who's" } ),
    new Homophone( new string[]{ "yoke", "yolk" } ),
    new Homophone( new string[]{ "yew", "you", "ewe" } ),
    new Homophone( new string[]{ "zeal", "seal" } ),
    new Homophone( new string[]{ "ad", "add" } ),
    new Homophone( new string[]{ "ail", "ale" } ),
    new Homophone( new string[]{ "air", "heir" } ),
    new Homophone( new string[]{ "arc", "ark" } ),
    new Homophone( new string[]{ "awl", "all" } ),
    new Homophone( new string[]{ "ax", "axe" } ),
    new Homophone( new string[]{ "bail", "bale" } ),
    new Homophone( new string[]{ "ball", "bawl" } ),
    new Homophone( new string[]{ "band", "banned" } ),
    new Homophone( new string[]{ "bard", "barred" } ),

};

        public string getdominant(string input)
        {
            foreach(var homophone in Homophones)
            {
                foreach(var variant in homophone.Variants)
                {
                    if(string.Equals(input, variant, StringComparison.OrdinalIgnoreCase))
                    {
                        return homophone.DomananttVariant; // Return the most phonetically simple variant
                    }
                }
            }
            return input; // Return the original input if no homophone match is found
        }

        public void SetDominantVariants()
        {
            foreach(var homophone in Homophones)
            {
                homophone.SetFirstAsDominant();
            }
            DomsSet = true;
        }
    }
}
