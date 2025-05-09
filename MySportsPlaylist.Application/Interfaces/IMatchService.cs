using MySportsPlaylist.Application.DTOs;
using MySportsPlaylist.Domain.Entities;
using MySportsPlaylist.Domain.Enums;

namespace MySportsPlaylist.Application.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<Match>> GetMatchesAsync(string title = null, string competition = null, MatchStatus? status = null);
    Task<bool> AddMatchAsync(AddMatchDTO match);
}
