namespace MySportsPlaylist.Domain.Entities;
public class Playlist
{
    public Guid UserId { get; set; }
    public Guid MatchId { get; set; }

    public ApplicationUser User { get; set; }
    public Match Match { get; set; }
}
