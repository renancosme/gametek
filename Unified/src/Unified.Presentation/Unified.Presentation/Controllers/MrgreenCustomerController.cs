using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unified.Domain.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Unified.Presentation.Controllers
{
    public class MrgreenCustomerController : Controller
    {
        private readonly IMrgreenCustomerService _mrgreenAdapter;

        public IActionResult Index()
        {
            return View();
        }
    }
}
