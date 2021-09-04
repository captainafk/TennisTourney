using PlayerScripts;
using System.Collections.Generic;

namespace TournamentScripts
{
    public abstract class Tournament
    {
        public abstract ECourtType CourtType { get; set; }

        protected Tournament(ECourtType courtType)
        {
            CourtType = courtType;
        }

        public abstract void ResolveTournament(List<Player> players);

        public static List<Tournament> Tournaments = new List<Tournament>();
    }

    public static class TournamentCreator
    {
        public static Tournament CreateTournament(string tournamentType, ECourtType courtType)
        {
            if (tournamentType == "elimination")
            {
                return new EliminationTournament(courtType);
            }
            else if (tournamentType == "league")
            {
                return new LeagueTournament(courtType);
            }
            else
            {
                return null;
            }
        }
    }
}