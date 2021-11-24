using System.Linq;  

namespace Lab_2.Composite.CompositeElements
{
    class Word : CompositeElement
    {
        class Count
        {
            public int OfSymbols { get { } }
        }
        
        public int SymbolsCount { get; set; }

        private Word(string data) { Data = data; }

        public override void Parse()
        {
            foreach (var sentence in _sentences)
            {
                // делим предложения на strings, в качестве разделителя выступает пробел
                var splittedWords = sentence.Data.Split(' ');
                foreach (var splittedWord in splittedWords)
                {
                    // удаление пунктуации в конце каждой string
                    _words.Add(char.IsPunctuation(splittedWord.Last()) ?
                        new Word(splittedWord.Remove(splittedWord.Length - 1)) :
                        new Word(splittedWord));
                }
            }
        }
        public override void Parse(Component component)
        {
            if((component as Sentence) != null)
            {
                var splittedWords = ((Sentence)component).Data.Split(' ');
                foreach (var splittedWord in splittedWords)
                {
                    _words.Add(char.IsPunctuation(splittedWord.Last()) ?
                        new Word(splittedWord.Remove(splittedWord.Length - 1)) :
                        new Word(splittedWord));
                }
            }
        }
    }
}
