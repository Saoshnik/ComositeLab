using Lab_2.Composite.CompositeElements;

namespace Lab_2.Composite.SimpleElements
{
    class Symbol : SimpleElement
    {
        public int Count { get; private set; }

        private Symbol(char data) { Data = data; }
        public override void Parse()
        {
            foreach (var word in _words)
                foreach (var ch in word.Data) if (char.IsSymbol(ch)) _symbols.Add(new Symbol(ch));
        }
        public override void Parse(Component component)
        {
            if ((component as Word) != null)
                foreach (var item in ((Word)component).Data)
                    if (char.IsSymbol(item)) _symbols.Add(new Symbol(item));
        }
    }
}
