using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public partial class Feedback
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string UserId { get; set; } = null!;

    public string ChefId { get; set; } = string.Empty;

    public string? Review { get; set; }

    public double Rating { get; set; }

    public DateTime Date { get; set; }

    public virtual Chef Chef { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
