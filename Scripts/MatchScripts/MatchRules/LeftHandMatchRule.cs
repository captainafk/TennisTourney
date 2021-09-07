using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule rewarding players for using their left hand
    /// </summary>
    public class LeftHandMatchRule : IMatchRule
    {
        public int SCORE_REWARD => 2;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match)
        {
            if (firstPlayer.RacketHand == ERacketHand.Left)
            {
                firstPlayer.IncrementMatchScore(SCORE_REWARD);
            }

            if (secondPlayer.RacketHand == ERacketHand.Left)
            {
                secondPlayer.IncrementMatchScore(SCORE_REWARD);
            }
        }
    }
}