namespace cainfo.Models
{
    public class Match
    {

        public int Id { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int? GoalsTeam1 { get; set; } 
        public int? GoalsTeam2 { get; set; } 
        public string Group { get; set; }
        public DateTime DateTime { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string? Result { get; set; }
    
        public string GetResult()
        {
            if (GoalsTeam1 > GoalsTeam2)
            {
                Result = Team1;
            }
            else if (GoalsTeam1 < GoalsTeam2)
            {
                Result = Team2;
            }
            else
            {
                Result ="Draw";
            }

            return Result;
        }
        
    }
}
