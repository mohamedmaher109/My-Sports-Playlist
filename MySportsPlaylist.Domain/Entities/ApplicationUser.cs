
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MySportsPlaylist.Domain.Entities
{
    public class ApplicationUser :IdentityUser<Guid>
    {
        public ICollection<Playlist> Playlists { get; set; } = [];
    }
}
