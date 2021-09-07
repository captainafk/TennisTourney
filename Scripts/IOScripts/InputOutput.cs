using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayerScripts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TournamentScripts;

namespace IOScripts
{
    public static class InputOutput
    {
        public static void ReadInputJSON()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName.Trim() != string.Empty)
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        string json = sr.ReadToEnd();

                        var jObject = JObject.Parse(json);

                        IList<JToken> players = jObject["players"].Children().ToList();

                        foreach (var player in players)
                        {
                            var playerID = (int)player["id"];
                            var racketHand = player["hand"].ToString() == "right" ?
                                                    ERacketHand.Right : ERacketHand.Left;

                            var initialExperience = (int)player["experience"];

                            var skillByCourtType = new Dictionary<ECourtType, int>();

                            foreach (var skills in player["skills"])
                            {
                                var courtType = Court.CourtTypeMap[((JProperty)skills).Name];

                                skillByCourtType[courtType] = (int)((JProperty)skills).Value;
                            }

                            var newPlayer = new Player(playerID, racketHand, initialExperience, skillByCourtType);
                            Player.Players.Add(newPlayer);
                        }

                        IList<JToken> tournaments = jObject["tournaments"].Children().ToList();

                        foreach (var tournament in tournaments)
                        {
                            var courtType = Court.CourtTypeMap[tournament["surface"].ToString()];

                            var newTournament = TournamentCreator.Create(tournament["type"].ToString(),
                                                                         courtType);
                            Tournament.Tournaments.Add(newTournament);
                        }
                    }
                }
            }
        }

        public static void WriteOutputJSON(List<Player> players)
        {
            players.Sort(
                delegate (Player firstPlayer, Player secondPlayer)
                {
                    if (firstPlayer.GainedExperience == secondPlayer.GainedExperience)
                    {
                        return secondPlayer.InitialExperience.CompareTo(firstPlayer.InitialExperience);
                    }
                    return secondPlayer.GainedExperience.CompareTo(firstPlayer.GainedExperience);
                }
            );

            var results = new List<Result>();

            for (int resultIndex = 0; resultIndex < players.Count; resultIndex++)
            {
                var player = players[resultIndex];

                var result = new Result(resultIndex + 1,
                                        player.PlayerID,
                                        player.GainedExperience,
                                        player.GetTotalExperience());
                results.Add(result);
            }

            string outputJSON = JsonConvert.SerializeObject(results, Formatting.Indented);

            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Json files (*.json)|*.json";
            sf.FilterIndex = 2;
            sf.RestoreDirectory = true;
            if (sf.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sf.FileName, outputJSON);
            }
        }
    }
}