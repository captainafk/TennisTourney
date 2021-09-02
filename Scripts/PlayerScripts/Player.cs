using System.Collections.Generic;
using TournamentScripts;

namespace PlayerScripts
{
    public class Player
    {
        private ERacketHand _racketHand = ERacketHand.None;
        private Dictionary<ECourtType, int> _skillByCourtType = new Dictionary<ECourtType, int>();
        private int _initialExperience;
        private int _gainedExperience;
        private int _matchScore;

        public ERacketHand RacketHand { get => _racketHand; }

        public Player(ERacketHand racketHand,
                      int initialExperience,
                      Dictionary<ECourtType, int> skillByCourtType)
        {
            _racketHand = racketHand;
            _initialExperience = initialExperience;

            //foreach (var skillCourtTypePair in skillByCourtType)
            //{
            //    _skillByCourtType.Add(skillCourtTypePair.Key, skillCourtTypePair.Value);
            //}
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
    }
}