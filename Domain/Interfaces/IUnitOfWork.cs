﻿using Domain.Interfaces.Repositories;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IBrandRepository BrandRepository { get; }
        ITypeRepository TypeRepository { get; }
        IShippingMethodRepository ShippingMethodRepository { get; }
        IBasketItemRepository BasketItemRepository { get; }
        IBasketRepository BasketRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IPaymentLogRepository PaymentLogRepository { get; }

        //IPurchaseRepository PurchaseRepository { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}