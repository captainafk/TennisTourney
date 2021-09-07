using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule giving each player 1 point just for participating
    /// </summary>
    public class BasicMatchRule : IMatchRule
    {
        public int SCORE_REWARD => 1;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match)
        {
            firstPlayer.IncrementMatchScore(SCORE_REWARD);
            secondPlayer.IncrementMatchScore(SCORE_REWARD);
        }
    }
}