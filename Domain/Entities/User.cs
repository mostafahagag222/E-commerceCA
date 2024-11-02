namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public Role Role { get; set; } = Role.User;

        //navigational
        public virtual List<Basket> Baskets { get; set; } = new List<Basket>();
        public virtual List<Address> Addresses { get; set; } = new List<Address>();
        public virtual List<Order> Orders { get; set; } = new List<Order>();
        public virtual List<Payment> Payments { get; set; } = new List<Payment>();

    }
}
