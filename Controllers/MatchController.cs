using cainfo.Models;
using cainfo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace cainfo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {

        private string filePath = "Public/matches.json";
        private readonly MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public ActionResult<List<Match>> GetAll()
        {

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var matches = _matchService.GetMatches();

            return Ok(matches);
        }

        [HttpGet("{id}")]
        public ActionResult<Match> GetOne(int id)
        {
            var match = _matchService.GetMatch(id);
            
            if(match == null)
            {
                return NotFound("There is no existing match with that id");
            }

            return match;
        }

        [HttpPost]
        public ActionResult<string> Post(Match newMatch) {

            try
            {
                var matches = _matchService.GetMatches();
                newMatch.GetResult();
                matches.Add(newMatch);
                _matchService.SaveNewMatch(matches);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("addResults")]
        public ActionResult<string> addMatchResults(int matchId, int[] results) {
            try
            {
                var matches = _matchService.GetMatches();
                var matchIndex = matches.FindIndex(x => x.Id == matchId);

                var match = matches[matchIndex];

                match.GoalsTeam1 = results[0];
                match.GoalsTeam2 = results[1];
                match.GetResult();

                matches[matchIndex] = match;
                
                _matchService.SaveNewMatch(matches);

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
