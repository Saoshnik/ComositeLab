using System.Collections.Generic;
using System.Linq;
using Lab_2.Composite.SimpleElements;
using Lab_2.Composite.Enums;

namespace Lab_2.Composite.CompositeElements
{
    partial class Sentence : IComponent
    {
        public SentenceType sentenceType { get; private set; }

        private string _contents { get; set; }

        protected List<Word> words; // get; set; && private 
        protected List<Symbol> symbols; // get; set; && private
        protected List<PunctuationMark> punctuationMarks; // get; set; && private

        public Sentence() { words = new List<Word>(); symbols = new List<Symbol>(); punctuationMarks = new List<PunctuationMark>(); }

        public string ChildCount { get { return $"words - {words.Count()}\tsymbols - {symbols.Count()}\tpunctuationMarks - {punctuationMarks.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return symbols == new List<Symbol>() && punctuationMarks == new List<PunctuationMark>() && words == new List<Word>() ? true : false; }

        public void Parse(string contents)
        {
            contents = contents.Trim();
            if (!char.IsPunctuation(contents.Last())) contents.Append('.');

            foreach (var symbol in contents)
            {
                symbols.Add(new Symbol());
                symbols.Last().Parent = this;
                symbols.Last().Parse(symbol);
                if (symbols.Last().IsDefault()) symbols.Remove(symbols.Last());
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

                words.Add(new Word());
                words.Last().Parent = this;
                words.Last().Parse(parseString);
                if (words.Last().IsDefault()) words.Remove(words.Last());

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
            if (!IsDefault()) _contents = contents;
        }

        public void Parse(char contents)
        {
            throw new System.NotImplementedException();
        }

        //protected List<Word> _words { get; set; }

        //protected Sentence(string data) : base(data) { }
        //public override void Parse()
        //{
        //    foreach (var text in _texts)
        //    {
        //        int ltemp = 0, rtemp = 0;
        //        foreach (var ch in text.Data)
        //        {
        //            if (ch == '!' || ch == '?' || ch == '.')
        //            {
        //                if (rtemp == 0 && ltemp == 0) ltemp = text.Data.IndexOf(ch);
        //                else if (rtemp == 0 && ltemp != 0) rtemp = text.Data.IndexOf(ch);
        //                _sentences.Add(new Sentence(string.Join(" ", ltemp, rtemp - ltemp)));
        //            }
        //        }
        //    }
        //}
        //public override void Parse(Component component)
        //{
        //    if ((component as Text) != null)
        //    {
        //        int ltemp = 0, rtemp = 0;
        //        foreach (var ch in ((Text)component).Data)
        //        {
        //            if (ch == '!' || ch == '?' || ch == '.')
        //            {
        //                if (rtemp == 0 && ltemp == 0) ltemp = ((Text)component).Data.IndexOf(ch);
        //                else if (rtemp == 0 && ltemp != 0) rtemp = ((Text)component).Data.IndexOf(ch);
        //                _sentences.Add(new Sentence(string.Join(" ", ltemp, rtemp - ltemp)));
        //            }
        //        }
        //    }
        //}

        //public override void Remove(Component component) { if((component as Word) != null) _words.Remove((Word)component); }
    }
}
