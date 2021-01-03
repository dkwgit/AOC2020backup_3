﻿namespace AOC2020.Day23
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AOC2020.Utilities;
    using Microsoft.Extensions.Logging;

    public class Puzzle : IPuzzle
    {
        private readonly ILogger _logger;

        private List<string> _input = null;

        public Puzzle(ILogger<Puzzle> logger)
        {
            _logger = logger;
        }

        public string Day => "23";

        public List<string> Input => _input;

        public string Part1
        {
            get
            {
                Node firstNode = null;
                Node priorNode = null;
                Node[] allNodes = new Node[_input[0].Length];
                for (int i = 0; i < _input[0].Length; i++)
                {
                    Node n = new Node(int.Parse(_input[0][i].ToString()));
                    if (firstNode == null)
                    {
                        firstNode = n;
                    }

                    if (priorNode != null)
                    {
                        priorNode.Next = n;
                        n.Prev = priorNode;
                    }

                    if (i + 1 == _input[0].Length)
                    {
                        n.Next = firstNode;
                        firstNode.Prev = n;
                    }

                    allNodes[n.Label - 1] = n;
                    priorNode = n;
                }

                RunGame(allNodes, firstNode.Label, 100);

                Node current = allNodes[0].Next; // one node clockwise after node labeled with one.
                StringBuilder sb = new ();
                for (int i = 0; i < allNodes.Length - 1; i++)
                {
                    sb.Append(current.Label);
                    current = current.Next;
                }

                string answer = sb.ToString();
                _logger.LogInformation("{Day}/Part1: Found {answer}", Day, answer);
                return answer;
            }
        }

        public string Part2
        {
            get
            {
                int turns = 10000000;
                Node firstNode = null;
                Node priorNode = null;
                Node[] allNodes = new Node[turns / 10];
                for (int i = 0; i < turns / 10; i++)
                {
                    Node n;
                    if (i < _input[0].Length)
                    {
                        n = new Node(int.Parse(_input[0][i].ToString()));
                    }
                    else
                    {
                        n = new Node(i + 1);
                    }

                    if (firstNode == null)
                    {
                        firstNode = n;
                    }

                    if (priorNode != null)
                    {
                        priorNode.Next = n;
                        n.Prev = priorNode;
                    }

                    if (i + 1 == turns / 10)
                    {
                        n.Next = firstNode;
                        firstNode.Prev = n;
                    }

                    allNodes[n.Label - 1] = n;
                    priorNode = n;
                }

                RunGame(allNodes, firstNode.Label, turns);

                string answer = (1L * allNodes[0].Next.Label * allNodes[0].Next.Next.Label).ToString();
                _logger.LogInformation("{Day}/Part2: Found {answer}", Day, answer);
                return answer;
            }
        }

        public void ProcessPuzzleInput(List<string> input)
        {
            _input = input;
        }

        private static void RunGame(Node[] allNodes, int startLabel, int iterations)
        {
            Node current = allNodes[startLabel - 1];

            int max = allNodes[^1].Label;

            Node[] chosenCups = new Node[3];

            for (int i = 0; i < iterations; i++)
            {
                chosenCups[0] = current.Next;
                chosenCups[1] = current.Next.Next;
                chosenCups[2] = current.Next.Next.Next;

                current.Next = chosenCups[2].Next;
                current.Next.Prev = current;

                int destinationLabel = current.Label - 1;

                while (true)
                {
                    if (destinationLabel < 1)
                    {
                        destinationLabel = max;
                    }

                    if (chosenCups[0].Label == destinationLabel || chosenCups[1].Label == destinationLabel || chosenCups[2].Label == destinationLabel)
                    {
                        destinationLabel -= 1;
                        continue;
                    }

                    break;
                }

                Node destination = allNodes[destinationLabel - 1];

                Node afterDestination = destination.Next;
                destination.Next = chosenCups[0];
                chosenCups[0].Prev = destination;
                chosenCups[2].Next = afterDestination;
                afterDestination.Prev = chosenCups[2];

                current = current.Next;
            }
        }
    }
}
