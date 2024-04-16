using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ZavrsniRadAK.Models;

namespace ZavrsniRadAK.Data
{
    public partial class GuildLeaderboard_ZavrsniContext : DbContext
    {
        public GuildLeaderboard_ZavrsniContext()
        {
        }

        public GuildLeaderboard_ZavrsniContext(DbContextOptions<GuildLeaderboard_ZavrsniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guild> Guilds { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Progress> Progresses { get; set; } = null!;
        public virtual DbSet<Raid> Raids { get; set; } = null!;
        public virtual DbSet<Raidgroup> Raidgroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-82R389N\\SQLEXPRESS01; Database=GuildLeaderboard_Zavrsni; TrustServerCertificate=True; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Croatian_CI_AS");

            modelBuilder.Entity<Guild>(entity =>
            {
                entity.ToTable("guilds");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("gname");

                entity.Property(e => e.Realm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("realm");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("members");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Charlevel).HasColumnName("charlevel");

                entity.Property(e => e.GuildId).HasColumnName("guild_id");

                entity.Property(e => e.Memclass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("memclass");

                entity.Property(e => e.Memname)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("memname");

                entity.Property(e => e.Race)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("race");

                entity.Property(e => e.Realm)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("realm");

                entity.HasOne(d => d.Guild)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.GuildId)
                    .HasConstraintName("FK__members__guild_i__44FF419A");
            });

            modelBuilder.Entity<Progress>(entity =>
            {
                entity.ToTable("progress");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cleardate)
                    .HasColumnType("datetime")
                    .HasColumnName("cleardate");

                entity.Property(e => e.Raidgroup).HasColumnName("raidgroup");

                entity.HasOne(d => d.RaidgroupNavigation)
                    .WithMany(p => p.Progresses)
                    .HasForeignKey(d => d.Raidgroup)
                    .HasConstraintName("FK__progress__raidgr__440B1D61");
            });

            modelBuilder.Entity<Raid>(entity =>
            {
                entity.ToTable("raids");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Difficulty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("difficulty")
                    .IsFixedLength();

                entity.Property(e => e.RaidgroupClear).HasColumnName("raidgroup_clear");

                entity.Property(e => e.Raidname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("raidname");

                entity.HasOne(d => d.RaidgroupClearNavigation)
                    .WithMany(p => p.Raids)
                    .HasForeignKey(d => d.RaidgroupClear)
                    .HasConstraintName("FK__raids__raidgroup__4316F928");
            });

            modelBuilder.Entity<Raidgroup>(entity =>
            {
                entity.ToTable("raidgroups");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Difficulty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("difficulty")
                    .IsFixedLength();

                entity.Property(e => e.Groupname)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("groupname");

                entity.HasMany(d => d.Members)
                    .WithMany(p => p.Raidgroups)
                    .UsingEntity<Dictionary<string, object>>(
                        "RaidPlanning",
                        l => l.HasOne<Member>().WithMany().HasForeignKey("MemberId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__raid_plan__membe__3E52440B"),
                        r => r.HasOne<Raidgroup>().WithMany().HasForeignKey("RaidgroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__raid_plan__raidg__3D5E1FD2"),
                        j =>
                        {
                            j.HasKey("RaidgroupId", "MemberId").HasName("PK__raid_pla__46065A6ED8DDDFED");

                            j.ToTable("raid_planning");

                            j.IndexerProperty<int>("RaidgroupId").HasColumnName("raidgroupID");

                            j.IndexerProperty<int>("MemberId").HasColumnName("memberID");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
