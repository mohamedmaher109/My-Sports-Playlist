using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Application.Models;
using MySportsPlaylist.Domain.Entities;
using System.Security.Claims;

namespace MySportsPlaylist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        private Guid GetUserId() => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        [HttpGet("GetUserPlaylist")]
        public async Task<IActionResult> GetUserPlaylist()
        {
            var userId = GetUserId();
            var playlist = await _playlistService.GetUserPlaylistAsync(userId);
            return Ok(ApiResponse<IEnumerable<Match>>.SuccessResponse(playlist));
        }

        [HttpPost("AddToPlaylist")]
        public async Task<IActionResult> AddToPlaylist([FromQuery]Guid matchId)
        {
            var userId = GetUserId();
            var result = await _playlistService.AddToPlaylistAsync(userId, matchId);

            if (!result)
                return BadRequest(ApiResponse<string>.FailResponse("Match already in playlist or does not exist"));

            return Ok(ApiResponse<string>.SuccessResponse("Match added to playlist"));
        }

        [HttpDelete("RemoveFromPlaylist")]
        public async Task<IActionResult> RemoveFromPlaylist([FromQuery]Guid matchId)
        {
            var userId = GetUserId();
            var result = await _playlistService.RemoveFromPlaylistAsync(userId, matchId);

            if (!result)
                return NotFound(ApiResponse<string>.FailResponse("Match not found in playlist"));

            return Ok(ApiResponse<string>.SuccessResponse("Match removed from playlist"));
        }
    }
}
