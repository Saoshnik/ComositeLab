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
                "This page will help you practise for the Cambridge First and PTE exam?");
            // text.ToString();


            Console.WriteLine("1. Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них. Результат:");
            text.SortWords();
            foreach (var sentence in text.Sentences)
                Console.WriteLine($"{sentence.Contents}\n\n");

            Console.WriteLine("2. Во всех вопросительных предложениях текста найти и напеча¬тать без повторений слова заданной длины. Результат:");
            foreach (var sentence in text.Sentences)
                Console.WriteLine($"{sentence.GetWordsOfLength(4, Composite.Enums.SentenceType.Question)}\n\n");

            Console.WriteLine("3. Из текста удалить все слова заданной длины, начинающиеся на согласную букву. Результат:");
            Console.WriteLine($"{text.GetDeletedPartOfContents(4, false)}");

            Console.WriteLine("4. В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова. Результат:");
                Console.WriteLine($"{text.Sentences[0].GetChangetContects("[  Who I am  ]", 4)}");
        }
    }
}
