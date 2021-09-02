using PlayerScripts;
using System.Collections.Generic;

namespace TournamentScripts
{
    public abstract class Tournament
    {
        private ECourtType _courtType = ECourtType.None;

        public ECourtType CourtType { get => _courtType; set => _courtType = value; }

        public abstract void ResolveTournament(List<Player> players);
    }
}