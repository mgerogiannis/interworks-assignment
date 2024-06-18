using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Data.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFieldController : ControllerBase
    {
        private ICustomerFieldService _customerFieldService;

        public CustomerFieldController(ICustomerFieldService customerFieldService)
        {
            _customerFieldService = customerFieldService;
        }

        [HttpPost("insert-customer-field")]
        public async Task<ActionResult<List<CustomerField>>> AddCustomerField(CustomerField customerField)
        {
            _customerFieldService.CreateField(customerField);
            return Ok();
        }

        [HttpGet("get-all-customer-fields")]
        public async Task<ActionResult<List<CustomerField>>> GetCustomerFields()
        {
            return Ok(_customerFieldService.GetFields().Result.ToList());
        }

        [HttpGet("get-customer-field/{id}")]
        public Task<ActionResult<List<CustomerField>>> GetCustomerField(int id)
        {
            return Task.FromResult<ActionResult<List<CustomerField>>>(Ok(_customerFieldService.GetFieldById(id).Result));
        }

        [HttpDelete("delete-customer-field/{id}")]
        public async Task<ActionResult<List<CustomerField>>> DeleteCustomerField(int id)
        {
            _customerFieldService.DeleteField(id);
            return Ok();
        }
    }
}
