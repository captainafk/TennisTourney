namespace IOScripts
{
    public class Result
    {
        public int order;
        public int player_id;
        public int gained_experience;
        public int total_experience;

        public Result(int order, int playerID, int gainedExperience, int totalExperience)
        {
            this.order = order;
            player_id = playerID;
            gained_experience = gainedExperience;
            total_experience = totalExperience;
        }
    }
}