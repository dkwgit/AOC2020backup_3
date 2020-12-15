﻿namespace AOC2020.Day14Computer
{
    using System.Collections.Generic;

    public interface IMemory
    {
        MemoryWord GetWord(long location);

        List<MemoryWord> GetMemory();

        MemoryWord CreateNewWord(long location);

        void SetWordWidth(int wordWidth);
    }
}
