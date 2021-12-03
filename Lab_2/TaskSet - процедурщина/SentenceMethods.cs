using System.Collections.Generic;
using Lab_2.Composite.Enums;

namespace Lab_2.Composite.CompositeElements
{
    partial class Sentence
    {
        public string GetWordsOfLength (int length, SentenceType type)
        {
            if (IsDefault()) throw new System.NotImplementedException("Sentence need to be parsed!");

            if (sentenceType != type) return string.Empty;

            var list = new List<string>();
            foreach (var word in words)
            {
                if (word.Contents.Length != length || list.Contains(word.Contents)) continue;
                else list.Add(word.Contents);
            }

            return string.Join(" ,", list.ToArray());
        }

        public string GetRedactSentence(string subString, int replaceWordLength)
        {
            if (IsDefault()) throw new System.NotImplementedException("Sentence need to be parsed!");

            string tmp = _contents;
            foreach (var word in words)
            {
                if(word.Contents.Length == replaceWordLength)
                {
                    int startIndex = tmp.IndexOf(word.Contents);
                    if (startIndex != 0 && startIndex != -1)
                        tmp = tmp.Remove(startIndex, startIndex + word.Contents.Length - 1);
                }
            }

            return tmp;
        }
    }
}
