using MinimalAPI.Data.Entities;

namespace MinimalAPI.Interfaces
{
    public interface ICustomerFieldValueRepository : IDisposable
    {
        void Create(CustomerFieldValue entry);
        void Update(int id, CustomerFieldValue entry);
        Task<List<CustomerFieldValue>> GetAllPerCriteria(int customerId, int fieldId);
        Task<CustomerFieldValue> GetById(int id);
        Task Save();
        void Delete(int id);
    }
}
