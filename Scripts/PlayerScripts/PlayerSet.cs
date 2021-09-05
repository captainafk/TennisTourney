namespace PlayerScripts
{
    public class PlayerSet
    {
        private Player _winnerPlayer;
        private Player _loserPlayer;

        public Player WinnerPlayer { get => _winnerPlayer; }
        public Player LoserPlayer { get => _loserPlayer; }

        public PlayerSet(Player winnerPlayer, Player loserPlayer)
        {
            _winnerPlayer = winnerPlayer;
            _loserPlayer = loserPlayer;
        }
    }
}