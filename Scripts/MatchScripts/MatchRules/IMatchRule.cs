using PlayerScripts;

namespace MatchScripts
{
    public interface IMatchRule
    {
        int SCORE_REWARD { get; }

        void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match);
    }
}