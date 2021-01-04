﻿namespace AOC2020.Day22
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    internal class PartTwoRuleVariants : IRuleVariants
    {
        private readonly Dictionary<BigInteger, bool> _history = new ();

        public GameWinInfo CheckHistoryForWinner(Hand deckOne, Hand deckTwo)
        {
            BigInteger composite = (deckOne.Cards << (6 * deckOne.CardCount)) + deckTwo.Cards;

            if (_history.ContainsKey(composite))
            {
                return GameWinInfo.PlayerOneWinsGame;
            }
            else
            {
                _history.Add(composite, true);
            }

            return GameWinInfo.NoWinYet;
        }

        public RoundWinInfo DecideRound(Game game)
        {
            if (game.PlayedOne > game.DeckOne.CardCount || game.PlayedTwo > game.DeckTwo.CardCount)
            {
                if (game.PlayedOne > game.PlayedTwo)
                {
                    return RoundWinInfo.PlayerOneWinsRound;
                }
                else
                {
                    return RoundWinInfo.PlayerTwoWinsRound;
                }
            }

            int totalCards = game.PlayedOne + game.PlayedTwo;

            Hand newDeckOne = Hand.DealHand(Hand.GetCards(game.DeckOne.Cards, game.PlayedOne));
            Hand newDeckTwo = Hand.DealHand(Hand.GetCards(game.DeckTwo.Cards, game.PlayedTwo));

            Game newGame = new Game(newDeckOne, newDeckTwo, new PartTwoRuleVariants());
            newGame.Play();

            if (newGame.WinState == GameWinInfo.PlayerOneWinsGame)
            {
                return RoundWinInfo.PlayerOneWinsRound;
            }
            else
            {
                return RoundWinInfo.PlayerTwoWinsRound;
            }

            throw new InvalidOperationException("Unexpected state after recursive game");
        }
    }
}
