using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule giving each player 1 point just for participating
    /// </summary>
    public class BasicMatchRule : IMatchRule
    {
        private const int SCORE_REWARD = 1;
        public int ScoreReward => SCORE_REWARD;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match)
        {
            firstPlayer.IncrementMatchScore(SCORE_REWARD);
            secondPlayer.IncrementMatchScore(SCORE_REWARD);
        }
    }
}