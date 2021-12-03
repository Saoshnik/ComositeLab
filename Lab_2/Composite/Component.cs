using System.Linq;
using System.Collections.Generic;
using Lab_2.Composite.CompositeElements;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite
{
    abstract class Component
    {
        protected static List<Sentence> _sentences { get; set; }
        protected static List<Text> _texts { get; set; }
        protected static List<Word> _words {get; set;}

        protected static List<Symbol> _symbols { get; set; }
        protected static List<PunctuationMark> _punctuationMarks { get; set; }

        public abstract void Parse();
        public abstract void Parse(Component component);

        public virtual void Add(Component component) { }
        public virtual void Remove(Component component) { _words[0].ha}
        public abstract bool IsComposite();
    }
}
