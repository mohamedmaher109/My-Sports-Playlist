using MySportsPlaylist.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MySportsPlaylist.Domain.Entities;
public class Match
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(250, MinimumLength = 3)]
    [Required]
    public string Title { get; set; }

    [StringLength(250, MinimumLength = 3)]
    [Required]
    public string Competition { get; set; }
    public DateTime? Date { get; set; } 
    public MatchStatus Status { get; set; } // Live / Replay
}
