using System.Collections.Generic;
using System.Linq;
using Lab_2.Composite.CompositeElements;

namespace Lab_2.CorcodanceFolder
{
    class Corcodance
    {
        public Corcodance() { skeletons = new List<Skeleton>(); }

        public string GetCorcodance(Text text) 
        {
            if (text.IsDefault()) throw new System.ArgumentOutOfRangeException("Text need to be parsed!");

            foreach (var sentence in text.Sentences)
                foreach (var word in sentence.Words)
                    Record(text, sentence, word);

            // removing duplicates
            foreach (var skeleton in skeletons)
                skeleton.locations.Distinct().ToList();

            return ToString();
        }

        private void Record(Text text, Sentence sentence, Word word)
        {
            if (!IsRecorded(word, text.Sentences.IndexOf(sentence)))
            {
                skeletons.Add(new Skeleton());
                skeletons.Last().word = word;
                skeletons.Last().locations.Add(text.Sentences.IndexOf(sentence) + 1);
            }
            else
            {
                foreach (var skeleton in skeletons)
                    if (skeleton.word.Contents == word.Contents || skeleton.word == word)
                        skeleton.locations.Add(text.Sentences.IndexOf(sentence) + 1);
            }
        }

        public bool IsRecorded(Word word, int location) 
        {
            bool recorded = false;
            foreach (var skeleton in skeletons) 
                if ((skeleton.word == word  && skeleton.locations.Contains(location)) || skeleton.word.Contents == word.Contents) 
                    recorded = true;
            return recorded;
        }

        public override string ToString()
        {
            // letter sort
            skeletons = skeletons.OrderBy(word => word.word.Contents).ToList();

            string tmp = string.Empty;
            foreach (var skeleton in skeletons)
                tmp += $"{skeleton.word.Contents}.............................{skeleton.locations.Count}: {string.Join(", ", skeleton.locations.ToArray())}\n";

            return tmp;
        }


        private List<Skeleton> skeletons { get; set; }

        class Skeleton
        {
            public Skeleton() { word = new(); locations = new(); }

            public Word word { get; set; }
            // number of sentence that located in the text.sentences 
            public List<int> locations { get; set; }
        }
    }
}
