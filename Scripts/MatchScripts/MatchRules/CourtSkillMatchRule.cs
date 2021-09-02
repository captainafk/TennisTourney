using PlayerScripts;

namespace MatchScripts
{
    public class CourtSkillMatchRule : IMatchRule
    {
        private readonly int _scoreReward = 4;
        public int ScoreReward => _scoreReward;

        public void ResolveMatchRule(Player firstPlayer, Player secondPlayer)
        {
            // TODO
        }
    }
}