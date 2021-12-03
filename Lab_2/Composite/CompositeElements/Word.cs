using System.Linq;
using System.Collections.Generic;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite.CompositeElements
{
    class Word : IComponent
    {
        private string _contents { get; set; }
        public string Contents { get { return _contents; } }

        protected List<Symbol> symbols; // get; set; && private
        public List<Symbol> Symbols { get { return symbols; } }

        public Word() { symbols = new List<Symbol>(); }

        public string ChildCount { get { return $"symbols - {symbols.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return symbols == new List<Symbol>() ? true : false; }

        public void Parse(string contents)
        {
            contents = contents.Trim();

            foreach (var symbol in contents)
            {
                if (char.IsLetter(symbol))
                {
                    symbols.Add(new Symbol());
                    symbols.Last().Parent = this;
                    symbols.Last().Parse(symbol);
                    if (symbols.Last().IsDefault()) symbols.Remove(symbols.Last());
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
            string tmp = $"  {GetType().Name}\n   << {Contents} >> \n   ChildCount = {ChildCount}\n";
            
            foreach (var item in symbols) tmp += $"  {item}";

            tmp += $"\n";

            return tmp;
        }


        //protected List<int> _corcodance { get; set; }


        //protected Word(string data) : base(data) { }
        //public override void Parse()
        //{
        //    foreach (var sentence in _sentences)
        //    {
        //        List<string> splittedSentences = sentence.Data.Split('.').ToList();
        //        splittedSentences.AddRange(sentence.Data.Split('?').ToList());
        //        splittedSentences.AddRange(sentence.Data.Split('!').ToList());
        //        foreach (var splittedSentence in splittedSentences)
        //        {
        //            // получение слов
        //            var splittedWords = sentence.Data.Split(' ');
        //            foreach (var splittedWord in splittedWords)
        //            {
        //                _words.Add(char.IsPunctuation(splittedWord.Last()) ?
        //                    new Word(splittedWord.Remove(splittedWord.Length - 1)) :
        //                    new Word(splittedWord));
        //                // запись коркоданса
        //                if (_corcodance.Contains(splittedSentences.IndexOf(splittedSentence))) _corcodance.Add(splittedSentences.IndexOf(splittedSentence));
        //            }
        //        }
        //    }
        //}
        //public override void Parse(Component component)
        //{
        //    if((component as Sentence) != null)
        //    {
        //        // делим предложения на strings, в качестве разделителя выступает пробел
        //        var splittedWords = ((Sentence)component).Data.Split(' ');
        //        foreach (var splittedWord in splittedWords)
        //        {   
        //            // удаление пунктуации в конце каждой string
        //            _words.Add(char.IsPunctuation(splittedWord.Last()) ?
        //                new Word(splittedWord.Remove(splittedWord.Length - 1)) :
        //                new Word(splittedWord));
        //        }
        //    }
        // }
    }
}
