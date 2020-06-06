namespace DKAC.Models.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DKACDbContext : DbContext
    {
        public DKACDbContext()
            : base("name=DKACDbContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishType> DishTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Jugment> Jugments { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuDetail> MenuDetails { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Tel)
                .IsFixedLength();
        }
    }
}
