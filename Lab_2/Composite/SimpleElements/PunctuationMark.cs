using Lab_2.Composite.CompositeElements;

namespace Lab_2.Composite.SimpleElements
{
    class PunctuationMark : SimpleElement
    {
        public int Count { get; private set; }

        private PunctuationMark(char data) { Data = data; }
        public override void Parse() 
        { 
            foreach (var sentence in _sentences) 
                foreach (var ch in sentence.Data) if (char.IsPunctuation(ch)) _punctuationMarks.Add(new PunctuationMark(ch));
            
            foreach(var text in _texts) foreach(var ch in text.Data) { if (char.IsWhiteSpace(ch)) _punctuationMarks.Add(new PunctuationMark(ch)); }
        }
        public override void Parse(Component component)
        {
            if ((component as Sentence) != null)
                foreach (var ch in ((Sentence)component).Data)
                    if (char.IsPunctuation(ch)) _punctuationMarks.Add(new PunctuationMark(ch));
            if((component as Text) != null)
                foreach(var ch in ((Text)component).Data) if(char.IsWhiteSpace(ch)) _punctuationMarks.Add(new PunctuationMark(ch));
        }
    }
}
