namespace Lab_2.Composite.CompositeElements
{
    class Sentence : CompositeElement
    {
        int CountOfWords { get { } }
        public int CountOfPunctuationMarks { get { } }
        public int CountOfSymbols { get { } }

        private Sentence(string data) { Data = data; }

        public override void Parse()
        {
            foreach (var text in _texts)
            {
                int ltemp = 0, rtemp = 0;
                foreach (var ch in text.Data)
                {
                    if (ch == '!' || ch == '?' || ch == '.')
                    {
                        if (rtemp == 0 && ltemp == 0) ltemp = text.Data.IndexOf(ch);
                        else if (rtemp == 0 && ltemp != 0) rtemp = text.Data.IndexOf(ch);
                        _sentences.Add(new Sentence(string.Join(" ", ltemp, rtemp - ltemp)));
                    }
                }
            }
        }

        public override void Parse(Component component)
        {
            if ((component as Text) != null)
            {
                int ltemp = 0, rtemp = 0;
                foreach (var ch in ((Text)component).Data)
                {
                    if (ch == '!' || ch == '?' || ch == '.')
                    {
                        if (rtemp == 0 && ltemp == 0) ltemp = ((Text)component).Data.IndexOf(ch);
                        else if (rtemp == 0 && ltemp != 0) rtemp = ((Text)component).Data.IndexOf(ch);
                        _sentences.Add(new Sentence(string.Join(" ", ltemp, rtemp - ltemp)));
                    }
                }
            }
        }
    }
}
