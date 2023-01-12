using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public class CareShareDBContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseGroup> ExpenseGroups { get; set; }
        public DbSet<ExpenseGroupMember> ExpenseGroupMembers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ExpenseGroupInvitation> ExpenseGroupInvitations { get; set; }

        public CareShareDBContext(DbContextOptions<CareShareDBContext> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount).HasColumnType("money");

            modelBuilder.Entity<ExpenseGroup>()
                .Property(e => e.TotalAmount).HasColumnType("money");

            modelBuilder.Entity<ExpenseGroupMember>()
                .Property(e => e.Balance).HasColumnType("money");

            modelBuilder.Entity<ExpenseGroupMember>()
                .Property(e => e.Paid).HasColumnType("money");

            modelBuilder.Entity<ExpenseGroupInvitation>()
                .HasOne(egi => egi.ExpenseGroup)
                .WithMany(eg => eg.expenseGroupInvitations)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExpenseGroupInvitation>()
                .HasOne(egi => egi.Profile)
                .WithMany(p => p.SentInvitations)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExpenseGroupInvitation>()
                .HasOne(egi => egi.InvitationProfile)
                .WithMany(p => p.ReceivedInvitations)
                .OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
