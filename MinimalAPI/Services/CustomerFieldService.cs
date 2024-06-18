using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalAPI.Data.Entities;
using MinimalAPI.Interfaces;
using System.Collections.Generic;

namespace MinimalAPI.Services
{
    public class CustomerFieldService : ICustomerFieldService
    {
        private readonly ICustomerFieldRepository _customerFieldRepository;
        private readonly ICustomerFieldValueService _customerFieldValueService;

        public CustomerFieldService(ICustomerFieldRepository customerFieldRepository, ICustomerFieldValueService customerFieldValueService)
        {
            _customerFieldRepository = customerFieldRepository;
            _customerFieldValueService = customerFieldValueService;
        }

        public void CreateField(CustomerField customerField)
        {
            _customerFieldRepository.Create(customerField);
            _customerFieldRepository.Save();
        }

        public void UpdateField(int id, CustomerField updatedCustomerField)
        {
            _customerFieldRepository.Update(id, updatedCustomerField);
            _customerFieldRepository.Save();
        }

        public async Task<List<CustomerField>> GetFields()
        {
            List<CustomerField> customerFields = await _customerFieldRepository.GetAll();
            return customerFields;
        }

        public async Task<CustomerField> GetFieldById(int id)
        {
            CustomerField result = await _customerFieldRepository.GetById(id);
            return result;
        }

        public void DeleteField(int id)
        {
            _customerFieldRepository.Delete(id);
            _customerFieldValueService.DeleteFieldValue(id);
            _customerFieldRepository.Save();
        }
    }
}
