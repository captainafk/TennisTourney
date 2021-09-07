using PlayerScripts;
using System;
using System.Collections.Generic;
using TournamentScripts;

namespace MatchScripts
{
    public class Match
    {
        private Player _firstPlayer;
        private Player _secondPlayer;
        private Tournament _tournament;
        private List<IMatchRule> _matchRules;

        public Tournament Tournament { get => _tournament; }

        public static List<IMatchRule> AllMatchRules = new List<IMatchRule>()
        {
            new BasicMatchRule(),
            new LeftHandMatchRule(),
            new ExperienceMatchRule(),
            new CourtSkillMatchRule(),
        };

        public Match(Player firstPlayer, Player secondPlayer,
                     Tournament tournament, List<IMatchRule> matchRules)
        {
            _firstPlayer = firstPlayer;
            _secondPlayer = secondPlayer;
            _tournament = tournament;
            _matchRules = matchRules;
        }

        public PlayerSet ResolveMatch()
        {
            _firstPlayer.ResetMatchScore();
            _secondPlayer.ResetMatchScore();

            foreach (var matchRule in _matchRules)
            {
                matchRule.ResolveMatchRule(_firstPlayer, _secondPlayer, this);
            }

            return DetermineWinnerAndLoser(_firstPlayer, _secondPlayer);
        }

        private PlayerSet DetermineWinnerAndLoser(Player firstPlayer, Player secondPlayer)
        {
            Random rnd = new Random();

            if (rnd.Next(1, firstPlayer.MatchScore + secondPlayer.MatchScore) <= firstPlayer.MatchScore)
            {
                return new PlayerSet(firstPlayer, secondPlayer);
            }
            else
            {
                return new PlayerSet(secondPlayer, firstPlayer);
            }
        }
    }
}