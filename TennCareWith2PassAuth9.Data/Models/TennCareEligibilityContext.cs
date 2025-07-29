using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TennCareWith2PassAuth9.Data.Models;

public partial class TennCareEligibilityContext : DbContext
{
    public TennCareEligibilityContext(DbContextOptions<TennCareEligibilityContext> options)
        : base(options)
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        IConfigurationRoot configuration =
            new ConfigurationBuilder()
                .SetBasePath(projectPath)
        .AddJsonFile(MyConstants.AppSettingsFile)
        .Build();
        Database.SetCommandTimeout(9000);
        MyConnectionString =
            configuration.GetConnectionString(MyConstants.ConnectionString);
    }

    public string MyConnectionString { get; set; }

    public virtual DbSet<DailyFileCollectionsComparison> DailyFileCollectionsComparisons { get; set; }
    public virtual DbSet<qy_GetTennCareWith2PassAuthConfigOutputColumns> qy_GetTennCareWith2PassAuthConfigOutputColumnsList { get; set; }   
    public virtual DbSet<dd_CollectionsComparisonOutputColumns> dd_CollectionsComparisonOutputColumnsList { get; set; }   
    public virtual DbSet<dd_DunningComparisonOutputColumns> dd_DunningComparisonOutputColumnsList { get; set; }
    public virtual DbSet<di_FinalizeCollectionsComparisonOutputColumns> di_FinalizeCollectionsComparisonOutputColumnsList { get; set; }   
    public virtual DbSet<di_FinalizeDunningComparisonOutputColumns> di_FinalizeDunningComparisonOutputColumnsList { get; set; }
    public virtual DbSet<dd_MonthlyToLookUpOutputColumns> dd_MonthlyToLookUpOutputColumnsList { get; set; }
    public virtual DbSet<di_FinalizeMonthlyToLookUpOutputColumns> di_FinalizeMonthlyToLookUpOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetCollectionsToLookUpOutputColumns> qy_GetCollectionsToLookUpOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetMonthlyToLookUpOutputColumns> qy_GetMonthlyToLookUpOutputColumnsList { get; set; }
    public virtual DbSet<du_MarkCollectionsToLookUpAsLookedUpOutputColumns> du_MarkCollectionsToLookUpAsLookedUpOutputColumnsList { get; set; }
    public virtual DbSet<du_MarkDunningToLookUpAsLookedUpOutputColumns> du_MarkDunningToLookUpAsLookedUpOutputColumnsList { get; set; }
    public virtual DbSet<du_MarkMonthlyToLookUpAsLookedUpOutputColumns> du_MarkMonthlyToLookUpAsLookedUpOutputColumnsList { get; set; }
    public virtual DbSet<dd_DunningEligibilityOutputColumns> dd_DunningEligibilityOutputColumnsList { get; set;  }
    public virtual DbSet<dd_MonthlyEligibilityOutputColumns> dd_MonthlyEligibilityOutputColumnsList { get; set; }
    public virtual DbSet<di_InsertCollectionsEligibilityOutputColumns> di_InsertCollectionsEligibilityOutputColumnsList { get; set; }
    public virtual DbSet<di_InsertDunningEligibilityOutputColumns> di_InsertDunningEligibilityOutputColumnsList { get; set; }
    public virtual DbSet<di_InsertMonthlyEligibilityOutputColumns> di_InsertMonthlyEligibilityOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetCollectionsEligibilityOutputColumns> qy_GetCollectionsEligibilityOutputColumnsList { get; set;  }
    public virtual DbSet<qy_GetDunningEligibilityOutputColumns> qy_GetDunningEntriesYieldingEligInfoTodayOutputColumnsList { get; set;  }
    public virtual DbSet<qy_GetMonthlyEligibilityOutputColumns> qy_GetMonthlyEligibilityOutputColumnsList { get; set; }
    public virtual DbSet<dd_CollectionsEligibilityOutputColumns> dd_CollectionsEligibilityOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDunningEligibilityOutputColumns> qy_GetDunningEligibilityOutputColumnsList { get; set; }
    public virtual DbSet<qy_GetDunningToLookUpOutputColumns> qy_GetDunningToLookUpOutputColumnsList { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<qy_GetDunningToLookUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDunningEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<dd_CollectionsEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetMonthlyEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetDunningEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetMonthlyEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_InsertMonthlyEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_InsertDunningEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_InsertCollectionsEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<dd_MonthlyEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<dd_DunningEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<dd_CollectionsComparisonOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<du_MarkMonthlyToLookUpAsLookedUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<du_MarkDunningToLookUpAsLookedUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<du_MarkCollectionsToLookUpAsLookedUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetMonthlyToLookUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<qy_GetCollectionsEligibilityOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });


        modelBuilder.Entity<qy_GetCollectionsToLookUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_FinalizeMonthlyToLookUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<dd_MonthlyToLookUpOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_FinalizeDunningComparisonOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<di_FinalizeCollectionsComparisonOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<dd_DunningComparisonOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<dd_CollectionsComparisonOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });
        modelBuilder.Entity<qy_GetTennCareWith2PassAuthConfigOutputColumns>(entity =>
        {
            entity.HasNoKey();
        });
        modelBuilder.Entity<DailyFileCollectionsComparison>(entity =>
        {
            entity.HasKey(e => e.Pk);

            entity.ToTable("DailyFileCollectionsComparison");

            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Dos)
                .HasColumnType("datetime")
                .HasColumnName("DOS");
            entity.Property(e => e.FileName)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Ssn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SSN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
