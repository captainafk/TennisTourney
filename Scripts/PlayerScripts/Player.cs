using System.Collections.Generic;
using TournamentScripts;

namespace PlayerScripts
{
    public class Player
    {
        private int _playerID = 0;
        private ERacketHand _racketHand = ERacketHand.None;
        private Dictionary<ECourtType, int> _skillByCourtType;
        private int _initialExperience;
        private int _gainedExperience;
        private int _matchScore;

        public static List<Player> Players = new List<Player>();

        public int PlayerID { get => _playerID; }
        public ERacketHand RacketHand { get => _racketHand; }
        public Dictionary<ECourtType, int> SkillByCourtType { get => _skillByCourtType; }
        public int InitialExperience { get => _initialExperience; }
        public int GainedExperience { get => _gainedExperience; }
        public int MatchScore { get => _matchScore; }

        public Player(int playerID,
                      ERacketHand racketHand,
                      int initialExperience,
                      Dictionary<ECourtType, int> skillByCourtType)
        {
            _playerID = playerID;
            _racketHand = racketHand;
            _initialExperience = initialExperience;
            _skillByCourtType = skillByCourtType;
        }

        public int GetTotalExperience()
        {
            return _initialExperience + _gainedExperience;
        }

        public void ResetMatchScore()
        {
            _matchScore = 0;
        }

        public void IncrementMatchScore(int score)
        {
            _matchScore += score;
        }

        public void GainExperience(int experience)
        {
            _gainedExperience += experience;
        }
    }
}