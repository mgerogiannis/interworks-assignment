using MinimalAPI.Data.Entities;

namespace MinimalAPI.Interfaces
{
    public interface ICustomerFieldValueService
    {
        void CreateFieldValue(CustomerFieldValue customerFieldValue);
        void UpdateFieldValue(int id, CustomerFieldValue updatedCustomerFieldValue);
        Task<List<CustomerFieldValue>> GetFieldValuesByFieldCustomer(int customerId, int fieldId);
        void DeleteFieldValue(int id);
    }
}
