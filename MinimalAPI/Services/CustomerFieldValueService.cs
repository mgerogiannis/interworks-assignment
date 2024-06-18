using MinimalAPI.Data.Entities;
using MinimalAPI.Data.Repositories;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Services
{
    public class CustomerFieldValueService : ICustomerFieldValueService
    {
        private readonly ICustomerFieldValueRepository _customerFieldValueRepository;
        private readonly ICustomerFieldValueHistoryService _customerFieldValueHistoryService;

        public CustomerFieldValueService(ICustomerFieldValueRepository customerFieldValueRepository, 
            ICustomerFieldValueHistoryService customerFieldValueHistoryService)
        {
            _customerFieldValueRepository = customerFieldValueRepository;
            _customerFieldValueHistoryService = customerFieldValueHistoryService;
        }

        public void CreateFieldValue(CustomerFieldValue customerFieldValue)
        {
            _customerFieldValueRepository.Create(customerFieldValue);
            _customerFieldValueRepository.Save();
        }

        public void UpdateFieldValue(int id, CustomerFieldValue updatedCustomerFieldValue)
        {
            var oldEntry = _customerFieldValueRepository.GetById(id).Result;

            _customerFieldValueRepository.Update(id, updatedCustomerFieldValue);

            var history = new CustomerFieldValueHistory
            {
                FieldValueId = oldEntry.FieldId,
                OldValue = oldEntry.Value,
                NewValue = updatedCustomerFieldValue.Value,
                ChangeDate = DateTime.Now
            };
            _customerFieldValueRepository.Save();
            _customerFieldValueHistoryService.CreateFieldValueHistory(history);
        }

        public async Task<List<CustomerFieldValue>> GetFieldValuesByFieldCustomer(int customerId, int fieldId)
        {
            List<CustomerFieldValue> customerFieldValues = await _customerFieldValueRepository.GetAllPerCriteria(customerId, fieldId);
            return customerFieldValues;
        }

        public void DeleteFieldValue(int id) 
        {
            _customerFieldValueRepository.Delete(id);
        }
    }
}
