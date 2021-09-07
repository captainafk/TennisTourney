using PlayerScripts;

namespace MatchScripts
{
    public class CourtSkillMatchRule : IMatchRule
    {
        private const int SCORE_REWARD = 4;
        public int ScoreReward => SCORE_REWARD;

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