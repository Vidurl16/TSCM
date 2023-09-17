using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Models;

public partial class TestExecution
{
    [Key]
    [Column("ExecutionID")]
    public int ExecutionId { get; set; }

    [Column("CaseID")]
    public int? CaseId { get; set; }

    [StringLength(255)]
    public string? TesterName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExecutionDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Notes { get; set; }

    [InverseProperty("Execution")]
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    [ForeignKey("CaseId")]
    [InverseProperty("TestExecutions")]
    public virtual TestCase? Case { get; set; }
}
