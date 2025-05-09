using MySportsPlaylist.Application.DTOs;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Domain.Entities;
using MySportsPlaylist.Domain.Enums;

namespace MySportsPlaylist.Application.Services;
public class MatchService : IMatchService
{
    private readonly IUnitOfWork _unitOfWork;

    public MatchService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AddMatchAsync(AddMatchDTO match)
    {
        if (match == null) return false;
        var newMatch = new Match
        {
            Title = match.Title,
            Competition = match.Competition,
            Status = match.Status,
        };
        await _unitOfWork.Matches.AddAsync(newMatch);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<IEnumerable<Match>> GetMatchesAsync(string title = null, string competition = null, MatchStatus? status = null)
    {
        var matches = await _unitOfWork.Matches.SearchAsync(title, competition, status);
        return matches;
    }
}