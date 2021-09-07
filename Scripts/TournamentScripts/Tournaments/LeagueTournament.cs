using MatchScripts;
using PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentScripts
{
    public class LeagueTournament : Tournament
    {
        private ECourtType _courtType;

        private const int WIN_EXPERIENCE_REWARD = 10;
        private const int LOSE_EXPERIENCE_REWARD = 1;

        public override ECourtType CourtType { get => _courtType; set => _courtType = value; }

        public LeagueTournament(ECourtType courtType)
        {
            _courtType = courtType;
        }

        public override void ResolveTournament(List<Player> players)
        {
            var rnd = new Random();
            var playersInRandomOrder = players.OrderBy(player => rnd.Next()).ToList();

            var numberOfMatches = 0;
            var playerIndex = 0;
            var opponentOffset = 1;

            while (numberOfMatches < players.Count * (players.Count - 1) / 2)
            {
                var opponentIndex = playerIndex + opponentOffset;

                var match = new Match(playersInRandomOrder[playerIndex],
                                      playersInRandomOrder[opponentIndex],
                                      this,
                                      Match.AllMatchRules);

                var playerSet = match.ResolveMatch();

                playerSet.WinnerPlayer.GainExperience(WIN_EXPERIENCE_REWARD);
                playerSet.LoserPlayer.GainExperience(LOSE_EXPERIENCE_REWARD);

                if (opponentIndex == players.Count - 1)
                {
                    playerIndex = 0;
                    opponentOffset++;
                }
                else
                {
                    playerIndex++;
                }

                numberOfMatches++;
            }
        }
    }
}