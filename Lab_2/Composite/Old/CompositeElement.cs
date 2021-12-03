//using System;
//using System.Collections.Generic;
//using Lab_2.Composite.CompositeElements;
//using Lab_2.Composite.SimpleElements;

//namespace Lab_2.Composite
//{
//    abstract class CompositeElement : Component
//    {
//        public string Data { get; protected set; }
//        protected static List<Component> _components {get; set; }

//        public override void Parse() { foreach (var item in _components) item.Parse(); }
//        public override void Parse(Component component) { component.Parse(); }  

//        public override bool IsComposite() => true; 
//        public override void Add(Component component) { _components.Add(component); Parse(component); }
//        public override void Remove(Component component)
//        {
//            // данные находятся в component.cs
//            _components.Remove(component);
//            if ((component as Text) != null) _texts.Remove((Text)component);
//            if ((component as PunctuationMark) != null) _punctuationMarks.Remove((PunctuationMark)component);
//            if ((component as Symbol) != null) _symbols.Remove((Symbol)component);
            
//            // данные находятся в классах CompositeElements
//            if ((component as Sentence) != null) ((Sentence)component).Remove(component);
//            if ((component as Word) != null) ((Word)component).Remove(component);
//        }
//        public new string ToString()
//        {
//            string tmp = string.Empty;
//            if ((this as Sentence) != null) tmp += $"{((Sentence)this).ToString()}";
//            else if ((this as Word) != null) tmp += $"{((Word)this).ToString()}";
//            else if ((this as Text) != null) tmp += $"{((Text)this).ToString()}";
//            if (tmp != null) return $"--- {GetType().Name} ---\n{tmp}";
//            else return tmp;
//        }
//    }
//}
