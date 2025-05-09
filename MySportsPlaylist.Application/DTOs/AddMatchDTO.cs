
using MySportsPlaylist.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MySportsPlaylist.Application.DTOs;

public class AddMatchDTO
{
    [Required]
    [StringLength(250, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(250, MinimumLength = 3)]
    public string Competition { get; set; }
    public DateTime? Date { get; set; }
    public MatchStatus Status { get; set; } // Live / Replay
}
