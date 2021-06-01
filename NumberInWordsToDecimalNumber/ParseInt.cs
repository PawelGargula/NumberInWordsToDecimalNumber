using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberInWordsToDecimalNumber
{
    public class ParseInt
    {
        public static long NumberInWordsToDecimalNumber(string numberInWords)
        {
            var numberDictionary = new Dictionary<string, long>()
            {
                {"zero",      0},
                {"one",       1},
                {"two",       2},
                {"three",     3},
                {"four",      4},
                {"five",      5},
                {"six",       6},
                {"seven",     7},
                {"eight",     8},
                {"nine",      9},
                {"ten",       10},
                {"eleven",    11},
                {"twelve",    12},
                {"thirteen",  13},
                {"fourteen",  14},
                {"fifteen",   15},
                {"sixteen",   16},
                {"seventeen", 17},
                {"eighteen",  18},
                {"nineteen",  19},
                {"twenty",    20},
                {"thirty",    30},
                {"forty",     40},
                {"fifty",     50},
                {"sixty",     60},
                {"seventy",   70},
                {"eighty",    80},
                {"ninety",    90},
                {"hundred",   100},
                {"thousand",  1_000},
                {"million",   1_000_000},
                {"billion",   1_000_000_000},
                {"trillion",  1_000_000_000_000},
            };

            long decimalNumber = 0;
            //Remove optional word in string: "and"
            numberInWords = numberInWords.Replace(" and", "");
            IEnumerable<string> arrayWhereDivide = numberDictionary.Where(x => x.Value >= 100)
                                                                   .Select(x => x.Key)
                                                                   .Reverse();
            var parts = new List<string>();
            //Searching for keys from arrayWhereDivide
            foreach (string key in arrayWhereDivide)
                if (numberInWords.Contains(key))
                {
                    //Divide into two parts by actual key, first part add to parts, rest assign to numberInWords
                    parts.Add((numberInWords.Split(key, 2)[0] + key).Trim());
                    numberInWords = numberInWords.Split(key, 2)[1];
                }
            if (!String.IsNullOrWhiteSpace(numberInWords))
                parts.Add(numberInWords.Trim());
            foreach (string part in parts)
                decimalNumber += Count(part, numberDictionary);
            return decimalNumber;
        }

        static long Count(string part, Dictionary<string, long> numberDictionary)
        {
            //Words mean numbers which are keys in numberDictionary 
            string[] words = part.Split(' ', '-');
            long decimalNumber = 0;
            foreach (var word in words)
            {
                //numberDictionary[word] return value from numberDictionary of key: word
                if (numberDictionary[word] >= 100)
                    decimalNumber *= numberDictionary[word];
                else
                    decimalNumber += numberDictionary[word];
            }
            return decimalNumber;
        }
    }
}
