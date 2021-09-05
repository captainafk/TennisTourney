using MatchScripts;
using PlayerScripts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentScripts
{
    public class EliminationTournament : Tournament
    {
        private ECourtType _courtType;

        private const int WIN_EXPERIENCE_REWARD = 20;
        private const int LOSE_EXPERIENCE_REWARD = 10;

        public override ECourtType CourtType { get => _courtType; set => _courtType = value; }

        public EliminationTournament(ECourtType courtType)
        {
            _courtType = courtType;
        }

        public override void ResolveTournament(List<Player> players)
        {
            var rnd = new Random();
            var playersInRandomOrder = players.OrderBy(player => rnd.Next()).ToList();

            ResolveEliminationTournament(playersInRandomOrder);
        }

        private void ResolveEliminationTournament(List<Player> players)
        {
            if (players.Count == 1) return;

            var remainingPlayers = new List<Player>();

            for (int playerIndex = 0; playerIndex < players.Count; playerIndex += 2)
            {
                var match = new Match(players[playerIndex],
                                      players[playerIndex + 1],
                                      this,
                                      Match.AllMatchRules);

                var playerSet = match.ResolveMatch();

                var winnerPlayer = playerSet.WinnerPlayer;
                winnerPlayer.GainExperience(WIN_EXPERIENCE_REWARD);
                remainingPlayers.Add(winnerPlayer);

                playerSet.LoserPlayer.GainExperience(LOSE_EXPERIENCE_REWARD);
            }

            ResolveEliminationTournament(remainingPlayers);
        }
    }
}