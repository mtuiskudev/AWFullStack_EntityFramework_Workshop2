using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AWFullStack_EntityFramework_Workshop2.Models
{
    public partial class Testi_dbContext : DbContext
    {
        public Testi_dbContext()
        {
        }

        public Testi_dbContext(DbContextOptions<Testi_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelaaja> Pelaaja { get; set; }
        public virtual DbSet<Varuste> Varuste { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=Testi_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Pelaaja>(entity =>
            {
                entity.ToTable("Pelaaja");

                entity.Property(e => e.PelaajaLuokka).HasMaxLength(20);

                entity.Property(e => e.PelaajaNimi).HasMaxLength(20);
            });

            modelBuilder.Entity<Varuste>(entity =>
            {
                entity.ToTable("Varuste");

                entity.Property(e => e.VarusteNimi).HasMaxLength(20);

                entity.Property(e => e.VarusteTyyppi).HasMaxLength(20);

                entity.HasOne(d => d.OmistajaNavigation)
                    .WithMany(p => p.Varuste)
                    .HasForeignKey(d => d.Omistaja)
                    .HasConstraintName("FK_Varuste_Pelaaja");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
