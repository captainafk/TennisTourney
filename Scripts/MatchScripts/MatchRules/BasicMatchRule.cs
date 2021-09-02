using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule giving each player 1 point just for participating
    /// </summary>
    public class BasicMatchRule : IMatchRule
    {
        private readonly int _scoreReward = 1;
        public int ScoreReward => _scoreReward;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer)
        {
            firstPlayer.IncrementMatchScore(_scoreReward);
            secondPlayer.IncrementMatchScore(_scoreReward);
        }
    }
}