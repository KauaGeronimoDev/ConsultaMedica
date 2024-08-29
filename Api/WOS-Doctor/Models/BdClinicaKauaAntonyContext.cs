using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WOS_Doctor.MODELS;

public partial class BdClinicaKauaAntonyContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-INJ0NB6\\SQLEXPRESS; Database=bd_clinicaKauaAntony; User Id=sa; Password=senai.123;TrustServerCertificate=True;",
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, // Número máximo de tentativas de retry
                    maxRetryDelay: TimeSpan.FromSeconds(30), // Tempo máximo entre tentativas
                    errorNumbersToAdd: null // Códigos de erro adicionais para incluir como falhas transitórias (opcional)
                );
            });
    }
    public BdClinicaKauaAntonyContext()
    {
    }

    public BdClinicaKauaAntonyContext(DbContextOptions<BdClinicaKauaAntonyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consulta> Consultas { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.ConsultaId).HasName("PK__Consulta__7D0B7DAC96E15344");

            entity.Property(e => e.ConsultaId)
                .ValueGeneratedNever()
                .HasColumnName("ConsultaID");
            entity.Property(e => e.EspecialidadeId).HasColumnName("EspecialidadeID");
            entity.Property(e => e.MedicoId).HasColumnName("MedicoID");
            entity.Property(e => e.PacienteId).HasColumnName("PacienteID");
            entity.Property(e => e.Procedimento)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Especialidade).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.EspecialidadeId)
                .HasConstraintName("FK__Consultas__Espec__6383C8BA");

            entity.HasOne(d => d.Medico).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK__Consultas__Medic__628FA481");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__Consultas__Pacie__6477ECF3");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.EspecialidadeId).HasName("PK__Especial__8829C359E6DFCDFE");

            entity.Property(e => e.EspecialidadeId)
                .ValueGeneratedNever()
                .HasColumnName("EspecialidadeID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.MedicamentoId).HasName("PK__Medicame__003D65F3243D3115");

            entity.Property(e => e.MedicamentoId)
                .ValueGeneratedNever()
                .HasColumnName("MedicamentoID");
            entity.Property(e => e.ConsultaId).HasColumnName("ConsultaID");
            entity.Property(e => e.Dosagem)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomeMedicamento)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Consulta).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.ConsultaId)
                .HasConstraintName("FK__Medicamen__Consu__6754599E");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.MedicosId).HasName("PK__Medicos__9FB1F6DBEE35B367");

            entity.Property(e => e.MedicosId)
                .ValueGeneratedNever()
                .HasColumnName("MedicosID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__Paciente__9353C07F22F5A760");

            entity.Property(e => e.PacienteId)
                .ValueGeneratedNever()
                .HasColumnName("PacienteID");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
