using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml;
using Transaction_System.Domain;

namespace Transaction_System.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<UserCredential>().HasOne(x => x.User).WithOne().HasForeignKey("Id");
            modelBuilder.Entity<Account>().HasMany(x => x.ToTransactions).WithOne(t => t.To).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Account>().HasMany(x => x.FromTransactions).WithOne(t => t.From).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transaction>().HasMany(t => t.Attachments).WithOne(a => a.Transaction).HasForeignKey(a => a.TransactionId).OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatus { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
    }
}
