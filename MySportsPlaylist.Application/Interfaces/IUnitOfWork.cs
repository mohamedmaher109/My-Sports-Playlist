

namespace MySportsPlaylist.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMatchRepository Matches { get; }
        IPlaylistRepository Playlists { get; }
        Task<int> CompleteAsync();
    }
}
