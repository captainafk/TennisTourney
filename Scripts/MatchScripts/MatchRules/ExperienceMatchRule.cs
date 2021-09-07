using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule rewarding the more experienced player
    /// </summary>
    public class ExperienceMatchRule : IMatchRule
    {
        public int SCORE_REWARD => 3;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match)
        {
            var firstPlayerExp = firstPlayer.GetTotalExperience();
            var secondPlayerExp = secondPlayer.GetTotalExperience();

            if (firstPlayerExp > secondPlayerExp)
            {
                firstPlayer.IncrementMatchScore(SCORE_REWARD);
            }
            else if (firstPlayerExp < secondPlayerExp)
            {
                secondPlayer.IncrementMatchScore(SCORE_REWARD);
            }
        }
    }
}