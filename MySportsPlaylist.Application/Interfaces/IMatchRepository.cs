using MySportsPlaylist.Domain.Entities;
using MySportsPlaylist.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MySportsPlaylist.Application.Interfaces
{
    public interface  IMatchRepository : IGenericRepository<Match>
    {
        Task<IEnumerable<Match>> SearchAsync(string title, string competition, MatchStatus? status);
    }
}
