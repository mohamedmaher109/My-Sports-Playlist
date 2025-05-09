using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySportsPlaylist.Application.DTOs;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Application.Models;
using MySportsPlaylist.Domain.Entities;
using MySportsPlaylist.Domain.Enums;
using System.Net;

namespace MySportsPlaylist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpGet("GetMatches")]
        public async Task<IActionResult> GetMatches([FromQuery] string title = null, string competition = null, MatchStatus? status = null)
        {
            var matches = await _matchService.GetMatchesAsync(title,competition,status);
            return Ok(ApiResponse<IEnumerable<Match>>.SuccessResponse(matches));
        }

        [HttpPost("AddMatch")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMatch([FromBody] AddMatchDTO match)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<string>.FailResponse("Validation failed", (int)HttpStatusCode.BadRequest,
                    ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))));
            var result = await _matchService.AddMatchAsync(match);
            if (!result)
                return BadRequest(ApiResponse<string>.FailResponse("Failed to add match"));

            return Ok(ApiResponse<string>.SuccessResponse("Match added successfully"));
        }
    }
}
