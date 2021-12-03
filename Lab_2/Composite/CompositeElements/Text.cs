using System.Linq;
using System.Collections.Generic;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite.CompositeElements
{
    partial class Text : IComponent
    {
        private string _contents { get; set; }

        protected List<Sentence> sentences { get; } // get; set; && private
        protected List<Word> words; // get; set; && private 
        protected List<Symbol> symbols; // get; set; && private
        protected List<PunctuationMark> punctuationMarks; // get; set; && private

        public Text() { sentences = new(); words = new(); symbols = new List<Symbol>(); punctuationMarks = new List<PunctuationMark>(); }

        public string ChildCount { get { return $"sentences - {sentences.Count()}\twords - {words.Count()}\tsymbols - {symbols.Count()}\tpunctuationMarks - {punctuationMarks.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return symbols == new List<Symbol>() && punctuationMarks == new List<PunctuationMark>() && words == new List<Word>() && sentences == new List<Sentence>() ? true : false; }

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

            // выборка строки
            int lPosition = int.MaxValue - 10, rPosition = int.MaxValue - 10;
            foreach (var symbol in contents)
            {
                if (char.IsUpper(symbol) && lPosition == int.MaxValue - 10)
                    lPosition = contents.IndexOf(symbol);
                if (symbol == '!' || symbol == '?' || symbol == '.' && lPosition != int.MaxValue - 10)
                    // для более сложного текста вы можете создать List<int> для неподходящих индексов либо просто счетчик для цикла. Затем IndexOf вызвать через цикл/рекурсию.
                    rPosition = contents.IndexOf(symbol, lPosition);

                if (lPosition != int.MaxValue - 10 && rPosition != int.MaxValue - 10)
                {
                    // получение строки
                    string parseString = contents.Substring(lPosition, rPosition - lPosition + 1);
                    lPosition = int.MaxValue - 10; rPosition = int.MaxValue - 10;

                    // парсинг компонентов  
                    sentences.Add(new Sentence());
                    sentences.Last().Parent = this;
                    sentences.Last().Parse(parseString);
                    if (sentences.Last().IsDefault()) sentences.Remove(sentences.Last());
                    words.Add(new Word());
                    words.Last().Parent = this;
                    words.Last().Parse(parseString);
                    if (words.Last().IsDefault()) words.Remove(words.Last());
                }
            }
            if (!IsDefault()) _contents = contents;
        }

        public void Parse(char contents)
        {
            throw new System.NotImplementedException();
        }
    }
}
