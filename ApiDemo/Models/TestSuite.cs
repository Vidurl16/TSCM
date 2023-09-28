using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Models;

public partial class TestSuite
{
    [Key]
    [Column("SuiteID")]
    public int SuiteId { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [InverseProperty("Suite")]
    public virtual ICollection<TestCases> TestCases { get; set; } = new List<TestCases>();
}
