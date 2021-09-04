using System.Collections.Generic;

namespace TournamentScripts
{
    public enum ECourtType
    {
        None = 0,
        Grass = 1,
        Clay = 2,
        Hard = 3,
    }

    public static class Court
    {
        public static Dictionary<string, ECourtType> CourtTypeMap = new Dictionary<string, ECourtType>
        {
            ["grass"] = ECourtType.Grass,
            ["clay"] = ECourtType.Clay,
            ["hard"] = ECourtType.Hard,
        };
    }
}