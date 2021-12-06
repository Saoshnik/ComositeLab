using System.Linq;
using System.Collections.Generic;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite.CompositeElements
{
    partial class Text : IComponent
    {
        private string _contents { get; set; }
        public string Contents { get { return _contents; } }

        public List<Sentence> Sentences { get; protected set; } = new();
        public List<PunctuationMark> PunctuationMarks { get; protected set; } = new();

        public string ChildCount { get { return $"sentences - {Sentences.Count()}\tpunctuationMarks - {PunctuationMarks.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return PunctuationMarks == new List<PunctuationMark>() && Sentences == new List<Sentence>() ? true : false; }

        public void Parse(string contents)
        {
            contents = contents.Trim();
            if (!char.IsPunctuation(contents.Last())) contents.Append('.');

            List<int> n = new List<int>();

            foreach (var symbol in contents)
            {
                PunctuationMarks.Add(new PunctuationMark());
                PunctuationMarks.Last().Parent = this;
                PunctuationMarks.Last().Parse(symbol);
                if (PunctuationMarks.Last().IsDefault()) PunctuationMarks.Remove(PunctuationMarks.Last());
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
                    Sentences.Add(new Sentence());
                    Sentences.Last().Parent = this;
                    Sentences.Last().Parse(parseString);
                    if (Sentences.Last().IsDefault()) Sentences.Remove(Sentences.Last());
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
            foreach (var item in PunctuationMarks) tmp += $" {item}";
            foreach (var item in Sentences) tmp += $" {item}";
            return tmp;
        }
    }
}
