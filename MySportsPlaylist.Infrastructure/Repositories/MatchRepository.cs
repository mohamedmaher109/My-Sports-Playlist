using Microsoft.EntityFrameworkCore;
using MySportsPlaylist.Application.Interfaces;
using MySportsPlaylist.Domain.Entities;
using MySportsPlaylist.Domain.Enums;
using MySportsPlaylist.Infrastructure.Data;
using System;
using System.Linq.Expressions;

namespace MySportsPlaylist.Infrastructure.Repositories;

public class MatchRepository : GenericRepository<Match>, IMatchRepository
{

    public MatchRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Match>> SearchAsync(string title, string competition, MatchStatus? status)
    {
        var query = GetAll();
        if (!string.IsNullOrWhiteSpace(competition))
            query = query.Where(m => m.Competition.ToLower().Contains(competition.ToLower()));
        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(m => m.Title.ToLower().Contains(title.ToLower()));
        if(status != null)
            query = query.Where(m=>m.Status == status.Value);
        return await query.OrderByDescending(d => d.Date).ToListAsync();
    }
}
