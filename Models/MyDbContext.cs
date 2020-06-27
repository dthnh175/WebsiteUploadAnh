namespace WebsiteUploadAnh.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        public virtual DbSet<ALBUM> ALBUMS { get; set; }
        public virtual DbSet<IMAGE> IMAGES { get; set; }
        public virtual DbSet<Share> Shares { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALBUM>()
                .HasMany(e => e.Shares)
                .WithRequired(e => e.ALBUM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IMAGE>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.UserPhone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Passwords)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.Shares)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.ShareID)
                .WillCascadeOnDelete(false);
        }
    }
}
