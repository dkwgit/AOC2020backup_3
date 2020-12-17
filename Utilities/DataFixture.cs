﻿namespace AOC2020.Utilities
{
    using System.Collections.Generic;
    using System.Linq;

    public class DataFixture
    {
        private readonly List<PuzzleData> _puzzleData;

        public DataFixture()
        {
            PuzzleDataStore puzzleDataStore = new PuzzleDataStore();

            _puzzleData = new ()
            {
                new PuzzleData("01", "Actual", puzzleDataStore.GetPuzzleInputAsList("01"), puzzleDataStore.GetPuzzleAnswer("01", "1"), puzzleDataStore.GetPuzzleAnswer("01", "2")),
                new PuzzleData("02", "Actual", puzzleDataStore.GetPuzzleInputAsList("02"), puzzleDataStore.GetPuzzleAnswer("02", "1"), puzzleDataStore.GetPuzzleAnswer("02", "2")),
                new PuzzleData("03", "Actual", puzzleDataStore.GetPuzzleInputAsList("03"), puzzleDataStore.GetPuzzleAnswer("03", "1"), puzzleDataStore.GetPuzzleAnswer("03", "2")),
                new PuzzleData("04", "Actual", puzzleDataStore.GetPuzzleInputAsList("04"), puzzleDataStore.GetPuzzleAnswer("04", "1"), puzzleDataStore.GetPuzzleAnswer("04", "2")),
                new PuzzleData("05", "Actual", puzzleDataStore.GetPuzzleInputAsList("05"), puzzleDataStore.GetPuzzleAnswer("05", "1"), puzzleDataStore.GetPuzzleAnswer("05", "2")),
                new PuzzleData("06", "Actual", puzzleDataStore.GetPuzzleInputAsList("06"), puzzleDataStore.GetPuzzleAnswer("06", "1"), puzzleDataStore.GetPuzzleAnswer("06", "2")),
                new PuzzleData("07", "Actual", puzzleDataStore.GetPuzzleInputAsList("07"), puzzleDataStore.GetPuzzleAnswer("07", "1"), puzzleDataStore.GetPuzzleAnswer("07", "2")),
                new PuzzleData("08", "Actual", puzzleDataStore.GetPuzzleInputAsList("08"), puzzleDataStore.GetPuzzleAnswer("08", "1"), puzzleDataStore.GetPuzzleAnswer("08", "2")),
                new PuzzleData("09", "Actual", puzzleDataStore.GetPuzzleInputAsList("09"), puzzleDataStore.GetPuzzleAnswer("09", "1"), puzzleDataStore.GetPuzzleAnswer("09", "2")),
                new PuzzleData("10", "Actual", puzzleDataStore.GetPuzzleInputAsList("10"), puzzleDataStore.GetPuzzleAnswer("10", "1"), puzzleDataStore.GetPuzzleAnswer("10", "2")),
                new PuzzleData("11", "Actual", puzzleDataStore.GetPuzzleInputAsList("11"), puzzleDataStore.GetPuzzleAnswer("11", "1"), puzzleDataStore.GetPuzzleAnswer("11", "2")),
                new PuzzleData("12", "Actual", puzzleDataStore.GetPuzzleInputAsList("12"), puzzleDataStore.GetPuzzleAnswer("12", "1"), puzzleDataStore.GetPuzzleAnswer("12", "2")),
                new PuzzleData("13", "Actual", puzzleDataStore.GetPuzzleInputAsList("13"), puzzleDataStore.GetPuzzleAnswer("13", "1"), puzzleDataStore.GetPuzzleAnswer("13", "2")),
                new PuzzleData("14", "Actual", puzzleDataStore.GetPuzzleInputAsList("14"), puzzleDataStore.GetPuzzleAnswer("14", "1"), puzzleDataStore.GetPuzzleAnswer("14", "2"), string.Empty, false),
                new PuzzleData("15", "Actual", puzzleDataStore.GetPuzzleInputAsList("15"), puzzleDataStore.GetPuzzleAnswer("15", "1"), puzzleDataStore.GetPuzzleAnswer("15", "2")),
                new PuzzleData("16", "Actual", puzzleDataStore.GetPuzzleInputAsList("16"), puzzleDataStore.GetPuzzleAnswer("16", "1"), puzzleDataStore.GetPuzzleAnswer("16", "2")),
                new PuzzleData(
                    "08",
                    "Sample",
                    new List<string>()
                    {
                        "nop +0",
                        "acc +1",
                        "jmp +4",
                        "acc +3",
                        "jmp -3",
                        "acc -99",
                        "acc +1",
                        "jmp -4",
                        "acc +6",
                    },
                    "5",
                    string.Empty),
                new PuzzleData(
                    "10",
                    "Sample",
                    new List<string>()
                    {
                        "1", "4", "5", "6", "7", "10", "11", "12", "15", "16", "19",
                    },
                    "35",
                    "8"),
                new PuzzleData(
                    "10",
                    "Sample",
                    new List<string>()
                    {
                        "28", "33", "18", "42", "31", "14", "46", "20", "48", "47", "24", "23", "49", "45", "19", "38", "39", "11", "1", "32", "25", "35", "8", "17", "7", "9", "4", "2", "34", "10", "3",
                    },
                    "220",
                    "19208"),
                new PuzzleData(
                    "10",
                    "Sample",
                    new List<string>()
                    {
                        "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
                    },
                    "30",
                    "53798080",
                    "Test case from Brian",
                    false),
                new PuzzleData(
                    "11",
                    "Sample",
                    new List<string>()
                    {
                        "L.LL.LL.LL",
                        "LLLLLLL.LL",
                        "L.L.L..L..",
                        "LLLL.LL.LL",
                        "L.LL.LL.LL",
                        "L.LLLLL.LL",
                        "..L.L.....",
                        "LLLLLLLLLL",
                        "L.LLLLLL.L",
                        "L.LLLLL.LL",
                    },
                    "37",
                    "26"),
                new PuzzleData(
                    "12",
                    "Sample",
                    new List<string>()
                    {
                        "F10",
                        "N3",
                        "F7",
                        "R90",
                        "F11",
                    },
                    "25",
                    "286"),
                new PuzzleData(
                    "13",
                    "Sample",
                    new List<string>()
                    {
                        "939",
                        "7,13,x,x,59,x,31,19",
                    },
                    "295",
                    "1068781"),
                new PuzzleData(
                    "14",
                    "Sample",
                    new List<string>()
                    {
                        "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                        "mem[8] = 11",
                        "mem[7] = 101",
                        "mem[8] = 0",
                    },
                    "165",
                    null),
                new PuzzleData(
                    "14",
                    "Sample",
                    new List<string>()
                    {
                        "mask = 000000000000000000000000000000X1001X",
                        "mem[42] = 100",
                        "mask = 00000000000000000000000000000000X0XX",
                        "mem[26] = 1",
                    },
                    null,
                    "208"),
                new PuzzleData(
                    "15",
                    "Sample",
                    new List<string>()
                    {
                        "0,3,6",
                    },
                    "436",
                    "175594",
                    string.Empty,
                    false),
                new PuzzleData(
                    "15",
                    "Sample",
                    new List<string>()
                    {
                        "1,3,2",
                    },
                    "1",
                    "2578",
                    string.Empty,
                    false),
                new PuzzleData(
                    "15",
                    "Sample",
                    new List<string>()
                    {
                        "2,1,3",
                    },
                    "10",
                    "3544142",
                    string.Empty,
                    false),
                new PuzzleData(
                    "15",
                    "Sample",
                    new List<string>()
                    {
                        "1,2,3",
                    },
                    "27",
                    "261214",
                    string.Empty,
                    false),
                new PuzzleData(
                    "15",
                    "Sample",
                    new List<string>()
                    {
                        "2,3,1",
                    },
                    "78",
                    "6895259",
                    string.Empty,
                    false),
                new PuzzleData(
                    "15",
                    "Sample",
                    new List<string>()
                    {
                        "3,2,1",
                    },
                    "438",
                    "18",
                    string.Empty,
                    false),
                new PuzzleData(
                    "15",
                    "Sample",
                    new List<string>()
                    {
                        "3,1,2",
                    },
                    "1836",
                    "362",
                    string.Empty,
                    false),
                new PuzzleData(
                    "16",
                    "Sample",
                    new List<string>()
                    {
                        "class: 1-3 or 5-7",
                        "row: 6-11 or 33-44",
                        "seat: 13-40 or 45-50",
                        string.Empty,
                        "your ticket:",
                        "7,1,14",
                        string.Empty,
                        "nearby tickets:",
                        "7,3,47",
                        "40,4,50",
                        "55,2,20",
                        "38,6,12",
                    },
                    "71",
                    null),
            };
        }

        public List<PuzzleData> GetPuzzleData()
        {
            return _puzzleData.Where(x => x.Enabled).OrderBy(x => (x.Day, (x.Type == "Actual") ? 2 : 1)).ToList();
        }
    }
}
