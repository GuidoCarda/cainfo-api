using cainfo.Models;
using System.Text.Json;

namespace cainfo.Services
{
    public class MatchService
    {
        private string FilePath = "Public/matches.json";

        public List<Match> GetMatches() {

            if (!File.Exists(FilePath)) {
                return new List<Match>();   
            }

            var json = File.ReadAllText(FilePath);
            var matches = JsonSerializer.Deserialize<List<Match>>(json);
            foreach (var match in matches)
            {
                match.GetResult();
            }
            return matches;
        }

        public void SaveNewMatch(List<Match> matches)
        {
            var json = JsonSerializer.Serialize(matches, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }
    }
}
