using System;
using System.Collections.Generic;
using DataLibrary.SqlHelper;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Model;

public partial class QuccContext : DbContext , IQuccContext
{
    private readonly ISqlHelper _sqlHelper;
    public QuccContext(ISqlHelper sqlHelper)
    {
        _sqlHelper = sqlHelper;
    }

    public QuccContext(DbContextOptions<QuccContext> options)
        : base(options)
    {
    }


    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    public virtual DbSet<TblCar> TblCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_sqlHelper.MySqlConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCar>(entity =>
        {
            entity.ToTable("tbl_car");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.ChassisNo)
                .HasMaxLength(50)
                .HasColumnName("chassis_no");
            entity.Property(e => e.Colour)
                .HasMaxLength(50)
                .HasColumnName("colour");
            entity.Property(e => e.EngineNo)
                .HasMaxLength(50)
                .HasColumnName("engine_no");
            entity.Property(e => e.FuelType)
                .HasMaxLength(50)
                .HasColumnName("fuel_type");
            entity.Property(e => e.Make)
                .HasMaxLength(50)
                .HasColumnName("make");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.ModelYear)
                .HasColumnType("date")
                .HasColumnName("model_year");
            entity.Property(e => e.RegNo)
                .HasMaxLength(50)
                .HasColumnName("reg_no");
            entity.Property(e => e.RegYear)
                .HasColumnType("date")
                .HasColumnName("reg_year");
            entity.Property(e => e.ScCode)
                .HasMaxLength(50)
                .HasColumnName("sc_code");
            entity.Property(e => e.SourceType)
                .HasMaxLength(50)
                .HasColumnName("source_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
