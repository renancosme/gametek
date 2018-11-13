using System;
using Microsoft.AspNetCore.Mvc;
using MrGreen.Application.Services.Interfaces;
using MrGreen.Application.ViewModels;

namespace MrGreen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _eventoAppService;

        public CustomerController(ICustomerAppService eventoAppService)
        {
            _eventoAppService = eventoAppService;
        }

        // GET api/customers/5
        /// <summary>
        /// Get a specific Customer.
        /// </summary>
        /// <param name="id">The Customer Id to get</param> 
        [HttpGet("{id}")]
        public ActionResult<string> Get(Guid id)
        {
            var customer = _eventoAppService.GetById(id);

            if (customer == null) return NotFound();

            return Ok();
        }

        // POST api/customers
        /// <summary>
        /// Creates a Customer.
        /// </summary>
        /// <param name="customerViewModel">The Customer to create</param> 
        [HttpPost]
        public ActionResult Post([FromBody] CustomerViewModel customerViewModel)
        {            
            // TODO: Use data annotations according with the validation itens
            if (customerViewModel == null) return BadRequest("Customer can not be null.");

            _eventoAppService.Add(customerViewModel);

            return CreatedAtRoute("Get", new { id = customerViewModel.Id });
        }

        // PUT api/customers/5
        /// <summary>
        /// Update a Customer.
        /// </summary>
        /// <param name="customerViewModel">The Customer to update</param> 
        [HttpPut]
        public ActionResult Put([FromBody] CustomerViewModel customerViewModel)
        {
            var customer = _eventoAppService.GetById(customerViewModel.Id);

            if (customer == null) return NotFound();

            _eventoAppService.Update(customerViewModel);

            return Accepted();
        }

        /// DELETE api/customers/5
        /// <summary>
        /// Deletes a specific Customer.
        /// </summary>
        /// <param name="id">The Customer Id to delete</param> 
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var customer = _eventoAppService.GetById(id);

            if (customer == null) return NotFound();

            _eventoAppService.Remove(id);

            return Accepted();
        }
    }
}
