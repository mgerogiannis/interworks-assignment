using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Data.Entities;
using MinimalAPI.Interfaces;

namespace MinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFieldValueHistoryController : ControllerBase
    {
        private ICustomerFieldValueHistoryService _customerFieldValueHistoryService;

        public CustomerFieldValueHistoryController(ICustomerFieldValueHistoryService customerFieldValueHistoryService)
        {
            _customerFieldValueHistoryService = customerFieldValueHistoryService;
        }

        [HttpGet("get-history/{fieldId}")]
        public async Task<ActionResult<List<CustomerFieldValueHistory>>> GetCustomerFieldValuesHistory(int fieldId)
        {
            return Ok(_customerFieldValueHistoryService.GetFieldValueHistory(fieldId).Result);
        }
    }
}
