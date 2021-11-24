using System;
using System.Collections.Generic;
using Lab_2.Composite.CompositeElements;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite
{
    abstract class CompositeElement : Component
    {
        public string Data { get; protected set; }
        protected static List<Component> _components {get; set; }

        public override void Parse() { foreach (var item in _components) item.Parse(); }
        public override void Parse(Component component) { component.Parse(); }  

        public override bool IsComposite() => true; 
        public override void Add(Component component) { _components.Add(component); Parse(component); }
        public override void Remove(Component element)
        {
            _components.Remove(element); 
            if ((element as Sentence) != null) _sentences.Remove((Sentence)element); if ((element as Text) != null) _texts.Remove((Text)element); 
            if ((element as Word) != null) _words.Remove((Word)element); if ((element as PunctuationMark) != null) _punctuationMarks.Remove((PunctuationMark)element); 
            if ((element as Symbol) != null) _symbols.Remove((Symbol)element);
        }
        public new string ToString()
        {
            string tmp = string.Empty;
            if ((this as Sentence) != null) tmp += $"{((Sentence)this).ToString()}";
            else if ((this as Word) != null) tmp += $"{((Word)this).ToString()}";
            else if ((this as Text) != null) tmp += $"{((Text)this).ToString()}";
            if (tmp != null) return $"--- {GetType().Name} ---\n{tmp}";
            else return tmp;
        }
    }
}
