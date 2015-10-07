namespace TimeLogging.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TimeLoggingContext : DbContext
    {
        public TimeLoggingContext()
            : base("name=TimeLogging")
        {
        }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.UserId)
                .IsFixedLength();

            modelBuilder.Entity<Log>()
                .Property(e => e.Comment)
                .IsFixedLength();
        }
    }
}
