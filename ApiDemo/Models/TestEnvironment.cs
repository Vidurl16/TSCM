using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Models;

public partial class TestEnvironment
{
    [Key]
    [Column("EnvironmentID")]
    public int EnvironmentId { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    public string? Description { get; set; }
}
