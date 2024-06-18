using MinimalAPI.Data.Entities;
using MinimalAPI.Data.Repositories;

namespace MinimalAPI.Interfaces
{
    public interface ICustomerFieldService
    {
        void CreateField(CustomerField customerField);

        void UpdateField(int id, CustomerField updatedCustomerField);

        Task<List<CustomerField>> GetFields();

        Task<CustomerField> GetFieldById(int id);
        void DeleteField(int id);
    }
}
