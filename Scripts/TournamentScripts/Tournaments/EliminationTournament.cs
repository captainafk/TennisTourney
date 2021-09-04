using PlayerScripts;
using System;
using System.Collections.Generic;

namespace TournamentScripts
{
    public class EliminationTournament : Tournament
    {
        public override ECourtType CourtType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EliminationTournament(ECourtType courtType) : base(courtType)
        {
            Tournaments.Add(this);
        }

        public override void ResolveTournament(List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}