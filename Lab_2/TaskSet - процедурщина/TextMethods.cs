using System.Collections.Generic;
using System.Linq;

// "aeiouAEIOU".Contains(word.Contents[0])) >= 0   =   char.isVowel()

namespace Lab_2.Composite.CompositeElements
{
    partial class Text
    {
        public Text SortWords() // set 1 +
        {
            var value = this;
            if (IsDefault()) throw new System.NotImplementedException("Text need to be parsed!");
            sentences = sentences.OrderBy(sentence => sentence.Words.Count).ToList();
            return this;
        }

        public string GetDeletedPartOfContents(int length, bool isVowel) // set 3 +
        {

            if (IsDefault()) throw new System.NotImplementedException("Text need to be parsed!");

            var list = new List<string>();
            foreach (var sentence in sentences)
                foreach (var word in sentence.Words) 
                if (word.Contents.Length == length && char.IsLetter(word.Contents[0]))
                {
                    if ("aeiouAEIOU".Contains(word.Contents[0]) && isVowel) list.Add(word.Contents);
                        else if (!"aeiouAEIOU".Contains(word.Contents[0]) && !isVowel) list.Add(word.Contents);
                } 

            return string.Join(", ", list.ToArray());
        }
    }
}
