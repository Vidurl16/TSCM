using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Models;

public partial class TestCase
{
    [Key]
    [Column("CaseID")]
    public int CaseId { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Priority { get; set; }

    public string? Preconditions { get; set; }

    public string? Postconditions { get; set; }

    [Column("SuiteID")]
    public int? SuiteId { get; set; }

    [InverseProperty("Case")]
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    [ForeignKey("SuiteId")]
    [InverseProperty("TestCases")]
    public virtual TestSuite? Suite { get; set; }

    [InverseProperty("Case")]
    public virtual ICollection<TestExecution> TestExecutions { get; set; } = new List<TestExecution>();
}
