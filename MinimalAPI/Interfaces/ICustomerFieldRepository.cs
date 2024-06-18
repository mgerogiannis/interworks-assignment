using MinimalAPI.Data.Entities;

namespace MinimalAPI.Interfaces
{
    public interface ICustomerFieldRepository : IDisposable
    {
        void Create(CustomerField entry);
        void Update(int id, CustomerField entry);
        Task<List<CustomerField>> GetAll();
        Task<CustomerField> GetById(int id);
        void Delete(int id);
        Task Save();
    }
}
