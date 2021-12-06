using System.Linq;
using System.Collections.Generic;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite.CompositeElements
{
    class Word : IComponent
    {
        public string Contents { get; private set; }

        public List<Symbol> Symbols { get; protected set; } = new();

        public string ChildCount { get { return $"symbols - {Symbols.Count()}"; } }

        public IComponent Parent { get; set; }

        public bool IsDefault() { return Symbols == new List<Symbol>() ? true : false; }

        public void Parse(string contents)
        {
            contents = contents.Trim();

            foreach (var symbol in contents)
            {
                if (char.IsLetter(symbol))
                {
                    Symbols.Add(new Symbol());
                    Symbols.Last().Parent = this;
                    Symbols.Last().Parse(symbol);
                    if (Symbols.Last().IsDefault()) Symbols.Remove(Symbols.Last());
                }
            }

            if (!IsDefault()) Contents = contents;
        }

        public void Parse(char contents)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            string tmp = $"  {GetType().Name}\n   << {Contents} >> \n   ChildCount = {ChildCount}\n";
            
            foreach (var item in Symbols) tmp += $"  {item}";

            tmp += $"\n";

            return tmp;
        }
    }
}
