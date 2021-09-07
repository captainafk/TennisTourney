using PlayerScripts;
using System.Collections.Generic;

namespace TournamentScripts
{
    public abstract class Tournament
    {
        public abstract ECourtType CourtType { get; set; }

        public abstract void ResolveTournament(List<Player> players);

        public static List<Tournament> Tournaments = new List<Tournament>();
    }

    public static class TournamentCreator
    {
        public static Tournament Create(string tournamentType, ECourtType courtType)
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
                throw new System.Exception("Tournament type named " + tournamentType + " not found.");
            }
        }
    }
}