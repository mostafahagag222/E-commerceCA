namespace Domain
{
    public enum Role
    {
        None = 0,
        User,
        Admin
    }
    public enum SortOptions
    {
        name,
        priceAsc,
        priceDesc,
    }
    public enum Currency
    {
        Usd,
        Egp,
        Sar
    }
    public enum OrderStatus
    {
        PendingDelivery,
        Delivered
    }
    public enum PaymentStatus
    {
        Pending = 0,
        SuccessfulPayment,
        FailedPayment
    }
}
