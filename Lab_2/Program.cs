using System;
using Lab_2.Composite.CompositeElements;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            text.Parse("B2, is one of the CEFR levels described by the Council of Europe. " +
                "This page will help you practise for the Cambridge First and PTE exams.");
            Console.WriteLine(text.ChildCount);


            Console.WriteLine(text.GetSortWords());
        }
    }
}
