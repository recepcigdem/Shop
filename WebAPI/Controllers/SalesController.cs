using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController:Controller
    {
        private ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }


        [HttpPost("add")]
        public ActionResult Add(Sales sales)
        {
            var data = _salesService.Add(sales);
            if (data.Success)
            {
                return Ok(data.Message);
            }

            return BadRequest(data.Message);
        }
    }
}
