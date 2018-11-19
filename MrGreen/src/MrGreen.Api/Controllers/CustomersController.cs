using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MrGreen.Application.Services.Interfaces;
using MrGreen.Application.ViewModels;
using MrGreen.Domain.Exceptions;

namespace MrGreen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomersController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // GET api/customers/
        /// <summary>
        /// Get a list of Customers.
        /// </summary>
        /// <response code="200">Returns a list of Customers</response>
        [ProducesResponseType(200)]
        [HttpGet()]
        public ActionResult Get()
        {
            var customers = _customerAppService.GetAll();
            return Ok(customers);
        }

        // GET api/customers/5
        /// <summary>
        /// Get a specific Customer.
        /// </summary>
        /// <param name="id">The Customer Id to get</param>
        /// <response code="200">Returns the existent Customer</response>
        /// <response code="404">Customer not found</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var customer = _customerAppService.GetById(id);

            if (customer == null) return NotFound();

            return Ok(customer);
        }

        // POST api/customers
        /// <summary>
        /// Creates a Customer.
        /// </summary>
        /// <param name="createCustomerViewModel">The Customer to create</param>
        /// <response code="201">Returns the newly created Customer</response>
        /// <response code="400">If the customerViewModel is null</response> 
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ValidationResult), 400)]
        [HttpPost]
        public ActionResult Post([FromBody] CreateCustomerViewModel createCustomerViewModel)
        {
            try
            {
                if (createCustomerViewModel == null) return BadRequest();

                var newCustomerViewModel = _customerAppService.Add(createCustomerViewModel);

                return CreatedAtAction("Get", new { id = newCustomerViewModel.Id }, newCustomerViewModel);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Errors);
            }            
        }

        // PUT api/customers/5
        /// <summary>
        /// Update a Customer.
        /// </summary>
        /// <param name="customerViewModel">The Customer to update</param>
        /// <response code="204">Customer updated</response>
        /// <response code="400">If the customerViewModel is null</response>
        /// <response code="404">Customer not found</response> 
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut]
        public ActionResult Put([FromBody] CustomerViewModel customerViewModel)
        {
            if (customerViewModel == null) return BadRequest();

            var customer = _customerAppService.GetById(customerViewModel.Id);

            if (customer == null) return NotFound();

            _customerAppService.Update(customerViewModel);

            return NoContent();
        }

        /// DELETE api/customers/5
        /// <summary>
        /// Deletes a specific Customer.
        /// </summary>
        /// <param name="id">The Customer Id to delete</param> 
        /// <response code="204">Customer deleted</response> 
        /// <response code="404">Customer not found</response> 
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var customer = _customerAppService.GetById(id);

            if (customer == null) return NotFound();

            _customerAppService.Remove(id);

            return NoContent();
        }
    }
}
