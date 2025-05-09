using MySportsPlaylist.Domain.Entities;

namespace MySportsPlaylist.Application.Interfaces
{
    public interface IPlaylistRepository:IGenericRepository<Playlist>
    {
        Task<IEnumerable<Match>> GetUserPlaylistAsync(Guid userId);
    }
}
