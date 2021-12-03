namespace Lab_2.Composite.SimpleElements
{
    class PunctuationMark : IComponent
    {
        protected char contents; // get; set;
        public char Contents { get { return contents; } }

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

        public override string ToString()
        {
            string tmp = $"   {GetType().Name}\n    << {Contents} >> \n";

            return tmp;
        }
    }
}
