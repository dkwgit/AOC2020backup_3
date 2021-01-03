﻿namespace AOC2020.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AOC2020.Map;
    using AOC2020.Utilities;
    using Microsoft.Extensions.Logging;

    public class Puzzle : IPuzzle
    {
        private readonly ILogger _logger;

        private List<string> _input = null;

        private Map _waitingRoom = null;

        private List<string> _currentRepresentation = null;

        public Puzzle(ILogger<Puzzle> logger)
        {
            _logger = logger;
        }

        public string Day => "11";

        public List<string> Input => _input;

        public string Part1
        {
            get
            {
                _waitingRoom = new MapBuilder(_input, false).Build();
                _currentRepresentation = _waitingRoom.GetTextRepresentation();

                /* var initial = new Printer(_currentRepresentation);
                initial.Print(); */

                bool different = true;
                while (different)
                {
                    RepresentationComparer r = new RepresentationComparer(_currentRepresentation);
                    _waitingRoom.ChangeSquares(MutateSquareForPart1);
                    var representation = _waitingRoom.GetTextRepresentation();

                    /* var printer = new Printer(representation);
                    printer.Print(); */

                    different = r.Different(representation);
                    _currentRepresentation = representation;
                }

                var flatten = string.Join(string.Empty, _currentRepresentation.ToArray());
                string answer = flatten.Count(x => x == '#').ToString();

                _logger.LogInformation("{Day}/Part1: Found {answer} occupied seats after waiting room stabilizes", Day, answer);
                return answer;
            }
        }

        public string Part2
        {
            get
            {
                _waitingRoom = new MapBuilder(_input, false).Build();
                _currentRepresentation = _waitingRoom.GetTextRepresentation();

                /*var initial = new Printer(_currentRepresentation);
                initial.Print();*/

                bool different = true;
                while (different)
                {
                    RepresentationComparer r = new RepresentationComparer(_currentRepresentation);
                    _waitingRoom.ChangeSquares(MutateSquareForPart2);
                    var representation = _waitingRoom.GetTextRepresentation();

                    /*var printer = new Printer(representation);
                    printer.Print();*/

                    different = r.Different(representation);
                    _currentRepresentation = representation;
                }

                var flatten = string.Join(string.Empty, _currentRepresentation.ToArray());

                string answer = flatten.Count(x => x == '#').ToString();
                _logger.LogInformation("{Day}/Part2: Found {answer} occupied seats after waiting room stabilizes", Day, answer);
                return answer;
            }
        }

        public void ProcessPuzzleInput(List<string> input)
        {
            _input = input;
        }

        private char MutateSquareForPart1(Square s)
        {
            var neighbors = s.GetNeighbors();
            if (s.Value == 'L')
            {
                if (!neighbors.Any(x => x.Value == '#'))
                {
                    return '#';
                }
            }

            if (s.Value == '#')
            {
                if (neighbors.Where(x => x.Value == '#').Count() >= 4)
                {
                    return 'L';
                }
            }

            return s.Value;
        }

        private char MutateSquareForPart2(Square s)
        {
            var firsts = s.GetFirstValuesInMainDirection(new char[2] { 'L', '#', }, _waitingRoom);

            if (s.Value == 'L')
            {
                if (!firsts.Any(x => x.Value == '#'))
                {
                    return '#';
                }
            }

            if (s.Value == '#')
            {
                if (firsts.Where(x => x.Value == '#').Count() >= 5)
                {
                    return 'L';
                }
            }

            return s.Value;
        }
    }
}
