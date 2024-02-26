using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pavas.Abstractions.DatabaseContext.Models;

public class Sequence
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [MaxLength(20)]
    public string Name { get; init; } = string.Empty;

    public int Value { get; set; }

    [Timestamp] public uint Version { get; init; }
}