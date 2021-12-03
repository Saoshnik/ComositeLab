namespace Lab_2.Composite.SimpleElements
{
    class PunctuationMark : IComponent
    {
        protected char contents; // get; set;

        public PunctuationMark() { contents = default; }

        public string ChildCount => $"0";

        public IComponent Parent { get; set; }

        public bool IsDefault() { return contents == default ? true : false; }

        public void Parse(string contents)
        {
            if (contents.Length > 1) throw new System.ArgumentOutOfRangeException();
            if (char.IsPunctuation(contents[0])) this.contents = contents[0];
        }

        public void Parse(char contents)
        {
            if (char.IsPunctuation(contents)) this.contents = contents;
        }


        //private PunctuationMark(char data) { Data = data; }
        //public override void Parse() { } // ??
        //public override void Parse(Component component)
        //{
        //    if ((component as Sentence) != null)
        //        foreach (var ch in ((Sentence)component).Data) if (char.IsPunctuation(ch)) _punctuationMarks.Add(new PunctuationMark(ch));
        //    if((component as Text) != null)
        //        foreach(var ch in ((Text)component).Data) if(char.IsWhiteSpace(ch)) _punctuationMarks.Add(new PunctuationMark(ch));
        //}
    }
}
