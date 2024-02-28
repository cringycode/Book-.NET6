using Book.Models;

namespace Book.DataAccess.Repository.IRepository;

public interface IOrderHeaderReopsitory : IRepository<OrderHeader>
{
    void Update(OrderHeader obj);

    void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
}