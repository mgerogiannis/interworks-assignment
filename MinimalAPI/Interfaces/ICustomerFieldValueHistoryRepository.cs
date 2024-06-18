using MinimalAPI.Data.Entities;

namespace MinimalAPI.Interfaces
{
    public interface ICustomerFieldValueHistoryRepository : IDisposable
    {
        void Create(CustomerFieldValueHistory entry);
        Task<List<CustomerFieldValueHistory>> GetById(int fieldValueId);
        Task Save();
    }
}
