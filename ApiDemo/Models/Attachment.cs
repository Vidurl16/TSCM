using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Models;

public partial class Attachment
{
    [Key]
    [Column("AttachmentID")]
    public int AttachmentId { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    public string? FilePath { get; set; }

    [Column("CaseID")]
    public int? CaseId { get; set; }

    [Column("ExecutionID")]
    public int? ExecutionId { get; set; }

    [ForeignKey("CaseId")]
    [InverseProperty("Attachments")]
    public virtual TestCases? Case { get; set; }

    [ForeignKey("ExecutionId")]
    [InverseProperty("Attachments")]
    public virtual TestExecution? Execution { get; set; }
}
