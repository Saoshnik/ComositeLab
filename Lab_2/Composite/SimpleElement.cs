using System;
using System.Collections.Generic;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite
{
    abstract class SimpleElement : Component
    {
        public char Data { get; protected set; }

        public override bool IsComposite() => false;
        public new string ToString()
        {
            string tmp = string.Empty;
            if ((this as Symbol) != null) tmp += $"{((Symbol)this).ToString()}";
            else if ((this as PunctuationMark) != null && char.IsPunctuation(Data)) tmp += $"{((PunctuationMark)this).ToString()}";
            if (tmp != null) return $"--- {GetType().Name} ---\n{tmp}";
            else return tmp;
        }
    }
}
