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
        }
    }
}
