﻿namespace AOC2020.Utilities
{
    using System.Collections.Generic;
    using System.Linq;

    public record ComboGeneratorWithPositionalAlphabet<T>
    {
        public T[][] Alphabet { get; init; }

        public int LetterCount { get; init; }

        public ComboGeneratorWithPositionalAlphabet(T[][] alphabet, int letterCount) => (Alphabet, LetterCount) = (alphabet, letterCount);

        public IEnumerable<T[]> Iterator()
        {
            List<T[]> lists = GetCombo(Alphabet, LetterCount, 0);
            for (int j = 0; j < lists.Count; j++)
            {
                yield return lists[j];
            }

            yield break;
        }

        private static List<T[]> GetCombo(T[][] alphabet, int n, int alphabetSlot)
        {
            List<T[]> lists = new ();

            for (int a = 0; a < alphabet[alphabetSlot].Length; a++)
            {
                if (n > 1)
                {
                    var sublists = GetCombo(alphabet, n - 1, alphabetSlot + 1);
                    foreach (var sub in sublists)
                    {
                        // head
                        T[] arr = new T[n];
                        arr[0] = alphabet[alphabetSlot][a];
                        for (int s = 1; s < n; s++)
                        {
                            arr[s] = sub[s - 1];
                        }

                        lists.Add(arr);
                    }
                }
                else
                {
                    // head
                    T[] arr = new T[n];
                    arr[0] = alphabet[alphabetSlot][a];
                    lists.Add(arr);
                }
            }

            return lists;
        }
    }
}
