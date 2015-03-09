using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace EmailCommunicator
{
    class NlpLogic
    {

        // Split the text are their in message
        public static string[] ArrangeText(string text)
        {
            
            char[] delimiters_no_digits = new char[] {
          '{', '}', '(', ')', '[', ']', '>', '<','-', '_', '=', '+',
          '|', '\\', ':', ';', ' ', ',', '.', '/', '?', '~', '!',
          '@', '#', '$', '%', '^', '&', '*', ' ', '\r', '\n', '\t',
          '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            string[] tokens = text.Split(delimiters_no_digits,
            StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];

                // Change token only when it starts and/or ends with "'" and it has at least 2 characters. 
                if (token.Length > 1)
                {
                    if (token.StartsWith("'") && token.EndsWith("'"))
                        tokens[i] = token.Substring(1, token.Length - 2);

                    else if (token.StartsWith("'"))
                        tokens[i] = token.Substring(1);

                    else if (token.EndsWith("'"))
                        tokens[i] = token.Substring(0, token.Length - 1);
                }
            }

            return tokens;
        }

        // This method is to Calculate the frequency
        public static Dictionary<string, int> BuildFreqTable(LinkedList<string> tokens)
        {
            Dictionary<string, int> token_freq_table = new Dictionary<string, int>();
            foreach (string token in tokens)
            {
                if (token_freq_table.ContainsKey(token))
                    token_freq_table[token]++;
                else
                    token_freq_table.Add(token, 1);
            }

            return token_freq_table;
        }

       public Dictionary<string, int> ToDict(string[] words)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string word in words)
            {
                // if the word is in the dictionary, increment its freq. 
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                // if not, add it to the dictionary and set its freq = 1 
                else
                {
                    dict.Add(word, 1);
                }
            }

            return dict;
        }

       public Dictionary<string, int> ListWordsByFreq(Dictionary<string, int> strIntDict)
        {
            // Copy keys and values to two arrays 
            SortOrder sortOrder = SortOrder.Descending;
            string[] words = new string[strIntDict.Keys.Count];
            strIntDict.Keys.CopyTo(words, 0);

            int[] freqs = new int[strIntDict.Values.Count];
            strIntDict.Values.CopyTo(freqs, 0);

            //Sort by freqs: it sorts the freqs array, but it also rearranges 
            //the words array's elements accordingly (not sorting) 
            Array.Sort(freqs, words);

            // If sort order is descending, reverse the sorted arrays. 
            if (sortOrder == SortOrder.Descending)
            {
                //reverse both arrays 
                Array.Reverse(freqs);
                Array.Reverse(words);
            }

            //Copy freqs and words to a new Dictionary<string, int> 
            Dictionary<string, int> dictByFreq = new Dictionary<string, int>();

            for (int i = 0; i < freqs.Length; i++)
            {
                dictByFreq.Add(words[i], freqs[i]);
            }

            return dictByFreq;
        }
    }
}
