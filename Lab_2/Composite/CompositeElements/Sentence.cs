using System.Collections.Generic;
using System.Linq;
using Lab_2.Composite.SimpleElements;
using Lab_2.Composite.Enums;

namespace Lab_2.Composite.CompositeElements
{
    partial class Sentence : IComponent
    {
        public SentenceType sentenceType { get; private set; }

        public string Contents { get; private set; }

        public List<Word> Words { get; protected set; } = new();
        public List<PunctuationMark> punctuationMarks { get; protected set; } = new();

        public string ChildCount { get { return $"words - {Words.Count()}\tpunctuationMarks - {punctuationMarks.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return punctuationMarks == new List<PunctuationMark>() && Words == new List<Word>() ? true : false; }

        public void Parse(string contents)
        {
            contents = contents.Trim();
            if (!char.IsPunctuation(contents.Last())) contents.Append('.');

            foreach (var symbol in contents)
            {
                punctuationMarks.Add(new PunctuationMark());
                punctuationMarks.Last().Parent = this;
                punctuationMarks.Last().Parse(symbol);
                if (punctuationMarks.Last().IsDefault()) punctuationMarks.Remove(punctuationMarks.Last());
            }

            // get words 
            var splittedWords = contents.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var splittedWord in splittedWords)
            {   
                // redact words
                string parseString = char.IsPunctuation(splittedWord.Last()) ?
                    splittedWord.Substring(0, splittedWord.Length - 1) :
                    splittedWord;

                Words.Add(new Word());
                Words.Last().Parent = this;
                Words.Last().Parse(parseString);
                if (Words.Last().IsDefault()) Words.Remove(Words.Last());

                // enum
                if (!IsDefault())
                {
                    switch (contents.Last())
                    {
                        case '.': sentenceType = SentenceType.Narration; break;
                        case '!': sentenceType = SentenceType.Exclamation; break;
                        case '?': sentenceType = SentenceType.Question; break;
                        default: sentenceType = SentenceType.Unknown; break;
                    }
                }
            }
            if (!IsDefault()) Contents = contents;
        }

        public void Parse(char contents)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString() 
        {
            string tmp = $" {GetType().Name}\n  << {Contents} >> \n  ChildCount = {ChildCount}\n\n";
            foreach (var item in punctuationMarks) tmp += $" {item}";
            foreach (var item in Words) tmp += $" {item}";
            return tmp;
        }
    }
}
