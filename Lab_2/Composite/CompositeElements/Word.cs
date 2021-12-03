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
    }
}
