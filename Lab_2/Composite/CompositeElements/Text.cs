using System.Linq;

namespace Lab_2.Composite.CompositeElements
{
    class Text : CompositeElement
    {
        // to mach
        public int OfSentences { get { int tmp = 0; foreach (var item in _sentences) if (Data.Contains(item.Data)) tmp++; return tmp; } }
        public int OfWords { get { int tmp = 0; foreach (var item in _words) if (Data.Contains(item.Data)) tmp++; return tmp; } }
        public int OfPunctuationMarks { get { int tmp = 0; foreach (var item in _punctuationMarks) if (Data.Contains(item.Data)) tmp++; return tmp; } }
        public int OfSymbols { get { int tmp = 0; foreach (var item in _symbols) if (Data.Contains(item.Data)) tmp++; return tmp; } }

        // здесь создается первый высший элемент парсинга - public ctor
        public Text(string data) { Data = data; }

        public override void Parse() { _texts.Add(new Text(Data ?? string.Empty)); if (!char.IsPunctuation(Data.Last())) _texts[_texts.Count].Data += '.'; }
        public override void Parse(Component component)
        {
            if ((component as Text) != null)
            {
                _texts.Add(new Text(((Text)component).Data));
                if (!char.IsPunctuation(Data.Last())) _texts[_texts.Count].Data += '.';
            }
        }
    }
}
