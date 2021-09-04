using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerScripts
{
    public class PlayerSet
    {
        private Player _winnerPlayer;
        private Player _loserPlayer;

        public PlayerSet(Player winnerPlayer, Player loserPlayer)
        {
            _winnerPlayer = winnerPlayer;
            _loserPlayer = loserPlayer;
        }
    }
}
