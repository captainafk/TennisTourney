using PlayerScripts;

namespace MatchScripts
{
    public interface IMatchRule
    {
        int ScoreReward { get; }

        void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match);
    }
}