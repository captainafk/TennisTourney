using PlayerScripts;

namespace MatchScripts
{
    public class CourtSkillMatchRule : IMatchRule
    {
        private readonly int _scoreReward = 4;
        public int ScoreReward => _scoreReward;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer, Match match)
        {
            var courtType = match.Tournament.CourtType;
            var firstPlayerSkill = firstPlayer.SkillByCourtType[courtType];
            var secondPlayerSkill = secondPlayer.SkillByCourtType[courtType];

            if (firstPlayerSkill > secondPlayerSkill)
            {
                firstPlayer.IncrementMatchScore(_scoreReward);
            }
            else if (secondPlayerSkill > firstPlayerSkill)
            {
                secondPlayer.IncrementMatchScore(_scoreReward);
            }
        }
    }
}