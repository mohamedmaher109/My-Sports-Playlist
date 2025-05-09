

using MySportsPlaylist.Domain.Entities;

namespace MySportsPlaylist.Application.Interfaces;

public interface IPlaylistService
{
    Task<IEnumerable<Match>> GetUserPlaylistAsync(Guid userId);
    Task<bool> AddToPlaylistAsync(Guid userId, Guid matchId);
    Task<bool> RemoveFromPlaylistAsync(Guid userId, Guid matchId);
}
