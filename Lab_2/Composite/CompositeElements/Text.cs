using System.Linq;
using System.Collections.Generic;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite.CompositeElements
{
    partial class Text : IComponent
    {
        private string _contents { get; set; }
        public string Contents { get { return _contents; } }

        protected List<Sentence> sentences { get; set; } // get; set; && private
        public List<Sentence> Sentences { get { return sentences; } }
        // protected List<Symbol> symbols; // get; set; && private
        protected List<PunctuationMark> punctuationMarks; // get; set; && private
        public List<PunctuationMark> PunctuationMarks { get { return punctuationMarks; } }

        public Text() { sentences = new(); punctuationMarks = new List<PunctuationMark>(); }

        public string ChildCount { get { return $"sentences - {sentences.Count()}\tpunctuationMarks - {punctuationMarks.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return punctuationMarks == new List<PunctuationMark>() && sentences == new List<Sentence>() ? true : false; }

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
            string tmp = $"{GetType().Name}\n << {Contents} >> \n ChildCount = {ChildCount}\n\n\n";
            foreach (var item in punctuationMarks) tmp += $" {item}";
            foreach (var item in sentences) tmp += $" {item}";
            return tmp;
        }
    }
}
