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
    }
}
