using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Infrastructure.Data;
using MySportsPlaylist.Infrastructure.Repositories;
using System;

namespace MySportsPlaylist.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IMatchRepository Matches { get; private set; }
    public IPlaylistRepository Playlists { get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Matches = new MatchRepository(context);
        Playlists = new PlaylistRepository(context);
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}
