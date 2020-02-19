namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ElmechContext : DbContext
    {
        public ElmechContext()
            : base("name=ElmechContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BillingInfo> BillingInfoes { get; set; }
        public virtual DbSet<CatagoryMaster> CatagoryMasters { get; set; }
        public virtual DbSet<CatalogMaster> CatalogMasters { get; set; }
        public virtual DbSet<InquiryMaster> InquiryMasters { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<SampleTable> SampleTables { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<ProductMaster> ProductMasters { get; set; }
        public object ProductMaster { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<InquiryMaster>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<InquiryMaster>()
                .Property(e => e.LastName)
                .IsFixedLength();

            modelBuilder.Entity<InquiryMaster>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<InquiryMaster>()
                .Property(e => e.City)
                .IsFixedLength();

           

            modelBuilder.Entity<ProductMaster>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
