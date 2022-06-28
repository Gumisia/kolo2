using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>(p =>
            {
                p.HasKey(e => e.OrganizationId);
                p.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                p.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Member>(p =>
            {
                p.HasKey(e => e.MemberId);
                p.Property(e => e.OrganizationId).IsRequired();
                p.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                p.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                p.Property(e => e.MemberNickName).HasMaxLength(20);

                p.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationId);

            });
            modelBuilder.Entity<Team>(p =>
            {
                p.HasKey(e => e.TeamId);
                p.Property(e => e.OrganizationId).IsRequired();
                p.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                p.Property(e => e.TeamDescription).HasMaxLength(500);

                p.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationId);
            });

            modelBuilder.Entity<Membership>(p =>
            {
                p.HasKey(e => new { e.MemberId, e.TeamId });
                p.Property(e => e.MembershipDate).IsRequired();

                p.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberId);
                p.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamId);
            });

            modelBuilder.Entity<File>(p =>
            {
                //p.HasKey(e => e.FileId);
                p.HasKey(e => new { e.FileId, e.TeamId });
                p.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                p.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                p.Property(e => e.FileSize).IsRequired();

                p.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamId);
            });

        }

    }
}
