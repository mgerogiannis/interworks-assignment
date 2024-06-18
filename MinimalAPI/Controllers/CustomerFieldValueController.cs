using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Data.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFieldValueController : ControllerBase
    {
        private ICustomerFieldValueService _customerFieldValueService;

        public CustomerFieldValueController(ICustomerFieldValueService customerFieldValueService)
        {
            _customerFieldValueService = customerFieldValueService;
        }

        [HttpPost("insert-customer-field-value")]
        public async Task<ActionResult<List<CustomerFieldValue>>> AddCustomerFieldValue(CustomerFieldValue customerFieldValue)
        {
            _customerFieldValueService.CreateFieldValue(customerFieldValue);
            return Ok();
        }

        [HttpPut("update-customer-field-value")]
        public async Task<ActionResult> UpdateCustomerFieldValue(int id, CustomerFieldValue updatedCustomerFieldValue)
        {
            _customerFieldValueService.UpdateFieldValue(id, updatedCustomerFieldValue);
            return Ok();
        }

        [HttpGet("get-customer-field-values/{customerId}/{fieldId}")]
        public async Task<ActionResult<List<CustomerFieldValue>>> GetCustomerFieldValues(int customerId, int fieldId)
        {
            return Ok(_customerFieldValueService.GetFieldValuesByFieldCustomer(customerId, fieldId).Result);
        }
    }
}