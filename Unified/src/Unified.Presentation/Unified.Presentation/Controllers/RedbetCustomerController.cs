using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unified.Domain.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unified.Presentation.Controllers
{
    public class RedbetCustomerController : Controller
    {
        private readonly IRedbetAdapeter _mrgreenAdapter;

        public IActionResult Index()
        {            
            return View();
        }
    }
}
