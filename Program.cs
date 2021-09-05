using IOScripts;
using PlayerScripts;
using System;
using TournamentScripts;

namespace TennisTourney
{
    /// <summary>
    /// Assumptions:
    /// 1. Experiences and skills are non-negative integers.
    /// 2. Court types on the input JSON are either "clay", "grass" or "hard".
    /// 3. Tournament types on the input JSON are either "elimination" or "league".
    /// </summary>
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            IO.ReadInputJSON();

            foreach (var tournament in Tournament.Tournaments)
            {
                tournament.ResolveTournament(Player.Players);
            }
        }
    }
}