using System.Collections.Generic;
using System.Linq;

// "aeiouAEIOU".Contains(word.Contents[0])) >= 0   =   char.isVowel()

namespace Lab_2.Composite.CompositeElements
{
    partial class Text
    {
        public string GetSortWords()
        {
            var value = this;
            if (IsDefault()) throw new System.NotImplementedException("Text need to be parsed!");
            var list = sentences.OrderBy(sentence => sentence.ChildCount);
            return string.Join(" ,", list.GetEnumerator());
        }

        public string GetRedactText(int length, bool isVowel)
        {

            if (IsDefault()) throw new System.NotImplementedException("Text need to be parsed!");

            var list = new List<string>();
            foreach (var word in words)
                if (word.Contents.Length == length && char.IsLetter(word.Contents[0]))
                {
                    if ("aeiouAEIOU".Contains(word.Contents[0]) && isVowel) list.Add(word.Contents);
                    else if(!"aeiouAEIOU".Contains(word.Contents[0]) && !isVowel) list.Add(word.Contents);
                } 

            return string.Join(" ,", list.ToArray());
        }
    }
}
