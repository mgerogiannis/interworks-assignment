using MinimalAPI.Data.Entities;
using MinimalAPI.Data.Repositories;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Services
{
    public class CustomerFieldValueHistoryService : ICustomerFieldValueHistoryService
    {

        private readonly ICustomerFieldValueHistoryRepository _customerFieldValueHistoryRepository;

        public CustomerFieldValueHistoryService(ICustomerFieldValueHistoryRepository customerFieldValueHistoryRepository)
        {
            _customerFieldValueHistoryRepository = customerFieldValueHistoryRepository;
        }

        public void CreateFieldValueHistory(CustomerFieldValueHistory customerFieldValueHistory)
        {
            _customerFieldValueHistoryRepository.Create(customerFieldValueHistory);
            _customerFieldValueHistoryRepository.Save();
        }

        public async Task<List<CustomerFieldValueHistory>> GetFieldValueHistory(int fieldId)
        {
            List<CustomerFieldValueHistory> customerFieldValueHistoryList = await _customerFieldValueHistoryRepository.GetById(fieldId);
            return customerFieldValueHistoryList;
        }
    }
}
