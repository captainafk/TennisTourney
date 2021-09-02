using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayerScripts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
                        IList<JToken> tournaments = jObject["tournaments"].Children().ToList();

                        foreach (var player in players)
                        {
                            var a = player["skills"];
                        }
                    }
                }
            }

        }
    }
}
