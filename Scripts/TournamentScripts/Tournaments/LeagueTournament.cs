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

            // TODO: Fix this so that every player plays simultaneously
            for (int playerIndex = 0; playerIndex < players.Count; playerIndex++)
            {
                for (int opponentIndex = playerIndex + 1; opponentIndex < players.Count; opponentIndex++)
                {
                    var match = new Match(playersInRandomOrder[playerIndex],
                                          playersInRandomOrder[opponentIndex],
                                          this,
                                          Match.AllMatchRules);

                    var playerSet = match.ResolveMatch();

                    playerSet.WinnerPlayer.GainExperience(WIN_EXPERIENCE_REWARD);
                    playerSet.LoserPlayer.GainExperience(LOSE_EXPERIENCE_REWARD);
                }
            }
        }
    }
}