using PlayerScripts;
using System;
using System.Collections.Generic;

namespace TournamentScripts
{
    public class LeagueTournament : Tournament
    {
        public override ECourtType CourtType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public LeagueTournament(ECourtType courtType) : base(courtType)
        {
            Tournaments.Add(this);
        }

        public override void ResolveTournament(List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}