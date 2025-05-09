using Microsoft.EntityFrameworkCore;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Domain.Entities;
using MySportsPlaylist.Infrastructure.Data;

namespace MySportsPlaylist.Infrastructure.Repositories;

public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
{
    public PlaylistRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Match>> GetUserPlaylistAsync(Guid userId)
    {
        return await GetAll(p => p.UserId == userId, q => q.Include(p => p.Match)).Select(s=>s.Match).ToListAsync();
    }
}
