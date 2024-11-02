using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;
using Type = Domain.Entities.Type;

namespace InfraStructure.Data
{
    public class EcpContext : DbContext
    {
        public EcpContext(DbContextOptions<EcpContext> options) : base(options)
        {

        }
        public EcpContext()
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentLog> PaymentLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
