using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unified.Domain.Interfaces;
using Unified.Domain.Model;
using Unified.Presentation.ViewModels;

namespace Unified.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMrgreenAdapter _mrgreenAdapter;

        public CustomerController(IMrgreenAdapter mrgreenAdapter)
        {
            _mrgreenAdapter = mrgreenAdapter;
        }

        // GET: Customer/Index
        public ActionResult Index()
        {
            var customers = _mrgreenAdapter.GetAll();

            var customersToReturn = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                customersToReturn.Add(new CustomerViewModel(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.PersonalNumber));
            }

            return View(customersToReturn);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if(!string.IsNullOrEmpty(customerViewModel.PersonalNumber))
                {
                    MrgreenCustomer mrgreenCustomer = new MrgreenCustomer {
                        FirstName = customerViewModel.FirstName,
                        LastName = customerViewModel.LastName,
                        Address = customerViewModel.Address,
                        PersonalNumber = customerViewModel.PersonalNumber
                    };

                    return RedirectToAction("Create", "MrgreenCustomer", mrgreenCustomer);                    
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: Customer/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                //return RedirectToAction(nameof(Index));
                return null;
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                //return RedirectToAction(nameof(Index));
                return null;
            }
            catch
            {
                return View();
            }
        }
    }
}