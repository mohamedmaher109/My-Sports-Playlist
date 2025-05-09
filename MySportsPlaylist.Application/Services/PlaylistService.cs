using Microsoft.EntityFrameworkCore;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Domain.Entities;


namespace MySportsPlaylist.Application.Services;

public class PlaylistService : IPlaylistService
{
    private readonly IUnitOfWork _unitOfWork;

    public PlaylistService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Match>> GetUserPlaylistAsync(Guid userId)
    {
        return await _unitOfWork.Playlists.GetUserPlaylistAsync(userId);
    }

    public async Task<bool> AddToPlaylistAsync(Guid userId, Guid matchId)
    {
        // Check if match exists
        var match = await _unitOfWork.Matches.GetByIdAsync(matchId);
        if (match == null) return false;

        // Check for duplicates
        var exists = await _unitOfWork.Playlists
            .GetAll(p => p.UserId == userId && p.MatchId == matchId)
            .AnyAsync();

        if (exists) return false;

        var playlist = new Playlist
        {
            UserId = userId,
            MatchId = matchId
        };

        await _unitOfWork.Playlists.AddAsync(playlist);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> RemoveFromPlaylistAsync(Guid userId, Guid matchId)
    {
        var playlistEntry = await _unitOfWork.Playlists
            .GetAll(p => p.UserId == userId && p.MatchId == matchId)
            .FirstOrDefaultAsync();

        if (playlistEntry == null) return false;

        _unitOfWork.Playlists.Remove(playlistEntry);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}