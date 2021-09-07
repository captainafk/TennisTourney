using PlayerScripts;

namespace MatchScripts
{
    /// <summary>
    /// The rule rewarding the more skilled player in that specific court type
    /// </summary>
    public class CourtSkillMatchRule : IMatchRule
    {
        public int SCORE_REWARD => 4;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match)
        {
            var courtType = match.Tournament.CourtType;
            var firstPlayerSkill = firstPlayer.SkillByCourtType[courtType];
            var secondPlayerSkill = secondPlayer.SkillByCourtType[courtType];

            if (firstPlayerSkill > secondPlayerSkill)
            {
                firstPlayer.IncrementMatchScore(SCORE_REWARD);
            }
            else if (secondPlayerSkill > firstPlayerSkill)
            {
                secondPlayer.IncrementMatchScore(SCORE_REWARD);
            }
        }
    }
}