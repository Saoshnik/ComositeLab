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
        public string Contents { get { return _contents; } }

        protected List<Word> words; // get; set; && private 
        public List<Word> Words { get { return words; } }
        protected List<PunctuationMark> punctuationMarks; // get; set; && private

        public Sentence() { words = new List<Word>(); punctuationMarks = new List<PunctuationMark>(); }
        private Sentence(Sentence sentence) { words = sentence.words; punctuationMarks = sentence.punctuationMarks; }

        public string ChildCount { get { return $"words - {words.Count()}\tpunctuationMarks - {punctuationMarks.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return punctuationMarks == new List<PunctuationMark>() && words == new List<Word>() ? true : false; }

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

        public override string ToString() 
        {
            string tmp = $" {GetType().Name}\n  << {Contents} >> \n  ChildCount = {ChildCount}\n\n";

            foreach (var item in punctuationMarks) tmp += $" {item}";
            foreach (var item in words) tmp += $" {item}";

            tmp += $"\n\n";

            return tmp;
        }

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
