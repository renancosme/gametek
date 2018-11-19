using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Unified.Domain.Interfaces;
using Unified.Domain.Model;
using Unified.Presentation.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unified.Presentation.Controllers
{
    public class RedbetCustomerController : Controller
    {
        private readonly IRedbetAdapter _redbetAdapter;
        private readonly IMapper _mapper;

        public RedbetCustomerController(IRedbetAdapter redbetAdapter, IMapper mapper)
        {
            _redbetAdapter = redbetAdapter;
            _mapper = mapper;
        }

        public IActionResult Details(Guid id)
        {
            // TODO: create partial view

            var customer = _redbetAdapter.GetCustomer(id);
            var redbetCustomerViewModel = _mapper.Map<RedbetCustomerViewModel>(customer);
            return View(redbetCustomerViewModel);
        }

        //[HttpPost]
        public IActionResult Create(RedbetCustomer redbetCustomer)
        {
            _redbetAdapter.AddCustomer(redbetCustomer);
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(Guid id)
        {
            var customer = _redbetAdapter.GetCustomer(id);
            var redbetCustomerViewModel = _mapper.Map<RedbetCustomerViewModel>(customer);
            return View(redbetCustomerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RedbetCustomer redbetCustomer)
        {
            _redbetAdapter.UpdateCustomer(redbetCustomer);
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Delete(Guid id) // FindBy before!?
        {
            _redbetAdapter.RemoveCustomer(id);
            return RedirectToAction("Index", "Customer");
        }
    }
}
