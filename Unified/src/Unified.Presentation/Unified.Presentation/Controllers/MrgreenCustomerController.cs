using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unified.Domain.Interfaces;
using Unified.Domain.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unified.Presentation.Controllers
{
    public class MrgreenCustomerController : Controller
    {
        private readonly IMrgreenAdapter _mrgreenAdapter;

        public MrgreenCustomerController(IMrgreenAdapter mrgreenAdapter)
        {
            _mrgreenAdapter = mrgreenAdapter;
        }

        public IActionResult GetById(Guid id)
        {
            var customer = _mrgreenAdapter.GetCustomer(id);
            return View();
        }

        public IActionResult Create(MrgreenCustomer mrgreenCustomer)
        {
            _mrgreenAdapter.AddCustomer(mrgreenCustomer);
            return RedirectToAction("Customer", "Index");
        }

        // GET: MrgreenCustomer/Edit/5
        public ActionResult Edit(Guid id)
        {
            var customer = _mrgreenAdapter.GetCustomer(id);
            return View(customer);
        }

        public IActionResult Edit(MrgreenCustomer mrgreenCustomer)
        {
            _mrgreenAdapter.UpdateCustomer(mrgreenCustomer);
            return RedirectToAction("Customer", "Index");
        }

        public IActionResult Delete(Guid id) // FindBy before!?
        {
            _mrgreenAdapter.RemoveCustomer(id);
            return RedirectToAction("Customer", "Index");
        }        
    }
}
