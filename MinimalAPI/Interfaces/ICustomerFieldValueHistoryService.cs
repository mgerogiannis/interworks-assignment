using MinimalAPI.Data.Entities;

namespace MinimalAPI.Interfaces
{
    public interface ICustomerFieldValueHistoryService
    {
        void CreateFieldValueHistory(CustomerFieldValueHistory customerFieldValueHistory);
        Task<List<CustomerFieldValueHistory>> GetFieldValueHistory(int fieldId);
    }
}
