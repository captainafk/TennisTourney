using Newtonsoft.Json.Linq;
using PlayerScripts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TournamentScripts;

namespace IOScripts
{
    public static class IO
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
    }
}