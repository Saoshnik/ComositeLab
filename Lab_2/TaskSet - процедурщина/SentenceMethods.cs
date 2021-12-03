using System.Collections.Generic;
using Lab_2.Composite.Enums;

namespace Lab_2.Composite.CompositeElements
{
    partial class Sentence
    {
        public string GetWordsOfLength (int length, SentenceType type) // set 2 +
        {
            if (IsDefault()) throw new System.NotImplementedException("Sentence need to be parsed!");

            if (sentenceType != type) return string.Empty;

            var list = new List<string>();
            foreach (var word in words)
            {
                if (word.Contents.Length != length || list.Contains(word.Contents)) continue;
                else list.Add(word.Contents);
            }

            return string.Join(", ", list.ToArray());
        }

        public string GetChangetContects(string subString, int changeLength) // set 4 +
        {
            if (IsDefault()) throw new System.NotImplementedException("Sentence need to be parsed!");

            string tmp = _contents;
            foreach (var word in words)
            {
                if(word.Contents.Length == changeLength)
                {
                    int startIndex = tmp.IndexOf(word.Contents);
                    if (startIndex != 0 && startIndex != -1)
                    {
                        tmp = tmp.Substring(0, startIndex) + subString + tmp.Substring(startIndex + changeLength + 1, _contents.Length - startIndex - changeLength - 1);
                    }
                }
            }

            return tmp;
        }
    }
}
