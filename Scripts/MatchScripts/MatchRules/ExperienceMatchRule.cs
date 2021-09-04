using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule rewarding the more experienced player
    /// </summary>
    public class ExperienceMatchRule : IMatchRule
    {
        private readonly int _scoreReward = 3;
        public int ScoreReward => _scoreReward;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match)
        {
            var firstPlayerExp = firstPlayer.GetTotalExperience();
            var secondPlayerExp = secondPlayer.GetTotalExperience();

            if (firstPlayerExp > secondPlayerExp)
            {
                firstPlayer.IncrementMatchScore(_scoreReward);
            }
            else if (firstPlayerExp < secondPlayerExp)
            {
                secondPlayer.IncrementMatchScore(_scoreReward);
            }
        }
    }
}