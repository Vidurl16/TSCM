using System;
using System.Collections.Generic;
using API.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public partial class KCP_DbContext : DbContext
{
    public KCP_DbContext()
    {
    }

    public KCP_DbContext(DbContextOptions<KCP_DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TestCase> TestCases { get; set; }

    public virtual DbSet<TestEnvironment> TestEnvironments { get; set; }

    public virtual DbSet<TestExecution> TestExecutions { get; set; }

    public virtual DbSet<TestSuite> TestSuites { get; set; }

    public virtual DbSet<Tester> Testers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=KCP_DB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK__Attachme__442C64DE1013324F");

            entity.Property(e => e.AttachmentId).ValueGeneratedNever();

            entity.HasOne(d => d.Case).WithMany(p => p.Attachments).HasConstraintName("FK__Attachmen__CaseI__4222D4EF");

            entity.HasOne(d => d.Execution).WithMany(p => p.Attachments).HasConstraintName("FK__Attachmen__Execu__4316F928");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AAC2AC67E");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TestCase>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PK__TestCase__6CAE526C71CA01B4");

            entity.Property(e => e.CaseId).ValueGeneratedNever();

            entity.HasOne(d => d.Suite).WithMany(p => p.TestCases).HasConstraintName("FK__TestCases__Suite__38996AB5");
        });

        modelBuilder.Entity<TestEnvironment>(entity =>
        {
            entity.HasKey(e => e.EnvironmentId).HasName("PK__TestEnvi__4B909A698B025DB7");

            entity.Property(e => e.EnvironmentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TestExecution>(entity =>
        {
            entity.HasKey(e => e.ExecutionId).HasName("PK__TestExec__473088E50916BE42");

            entity.Property(e => e.ExecutionId).ValueGeneratedNever();

            entity.HasOne(d => d.Case).WithMany(p => p.TestExecutions).HasConstraintName("FK__TestExecu__CaseI__3B75D760");
        });

        modelBuilder.Entity<TestSuite>(entity =>
        {
            entity.HasKey(e => e.SuiteId).HasName("PK__TestSuit__8858CFD5404D9345");

            entity.Property(e => e.SuiteId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tester>(entity =>
        {
            entity.HasKey(e => e.TesterId).HasName("PK__Testers__61EB7DFBCE37823F");

            entity.Property(e => e.TesterId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC50CB213F");

            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
