using System.Linq;
using System.Collections.Generic;
using Lab_2.Composite.CompositeElements;
using Lab_2.Composite.SimpleElements;

namespace Lab_2.Composite
{
    interface IComponent
    {
        string ChildCount { get; }
        
        IComponent Parent { get; set; }

        void Parse(string contents);
        void Parse(char contents);
    }
}
