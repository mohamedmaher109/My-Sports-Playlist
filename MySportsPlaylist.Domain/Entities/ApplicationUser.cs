using Microsoft.AspNet.Identity.EntityFramework;

namespace MySportsPlaylist.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
