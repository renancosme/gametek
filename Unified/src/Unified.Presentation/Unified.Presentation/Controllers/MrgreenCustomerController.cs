using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unified.Domain.Interfaces;
using Unified.Domain.Model;
using Unified.Presentation.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unified.Presentation.Controllers
{
    public class MrgreenCustomerController : Controller
    {
        private readonly IMrgreenAdapter _mrgreenAdapter;
        private readonly IMapper _mapper;

        public MrgreenCustomerController(IMrgreenAdapter mrgreenAdapter, IMapper mapper)
        {
            _mrgreenAdapter = mrgreenAdapter;
            _mapper = mapper;
        }

        public IActionResult Details(Guid id)
        {
            // TODO: create partial view

            var customer = _mrgreenAdapter.GetCustomer(id);
            var mrgreenCustomerViewModel = _mapper.Map<MrgreenCustomerViewModel>(customer);
            return View(mrgreenCustomerViewModel);
        }

        //[HttpPost]
        public IActionResult Create(MrgreenCustomer mrgreenCustomer)
        {
            _mrgreenAdapter.AddCustomer(mrgreenCustomer);
            return RedirectToAction("Index", "Customer");
        }
                
        public ActionResult Edit(Guid id)
        {
            var customer = _mrgreenAdapter.GetCustomer(id);
            var mrgreenCustomerViewModel = _mapper.Map<MrgreenCustomerViewModel>(customer);
            return View(mrgreenCustomerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(MrgreenCustomer mrgreenCustomer)
        {
            _mrgreenAdapter.UpdateCustomer(mrgreenCustomer);
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Delete(Guid id) // FindBy before!?
        {
            _mrgreenAdapter.RemoveCustomer(id);
            return RedirectToAction("Index", "Customer");
        }        
    }
}
