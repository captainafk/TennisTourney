using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule rewarding players for using their left hand
    /// </summary>
    public class LeftHandMatchRule : IMatchRule
    {
        private readonly int _scoreReward = 2;
        public int ScoreReward => _scoreReward;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer)
        {
            if (firstPlayer.RacketHand == ERacketHand.Left)
            {
                firstPlayer.IncrementMatchScore(_scoreReward);
            }

            if (secondPlayer.RacketHand == ERacketHand.Left)
            {
                secondPlayer.IncrementMatchScore(_scoreReward);
            }
        }
    }
}