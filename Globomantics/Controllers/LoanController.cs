using Globomantics.Filters;
using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Globomantics.Controllers
{
    [TypeFilter(typeof(FeatureAuthFilter), Arguments = new object[] { FeatureAuthFilter.LoanFeatureName })]
    public class LoanController : Controller
    {
        private ILoanService loanService;

        public LoanController(ILoanService loanService)
        {
            this.loanService = loanService;
        }

        public IActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Application(LoanDetails app)
        {
            loanService.CreateLoanApplication(app, Guid.NewGuid().ToString());
            return RedirectToAction("Employment");
        }

        [HttpGet]
        public IActionResult Employment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employment(Employment employment)
        {
            loanService.UpdateLoanEmployment(employment);
            return RedirectToAction("Personal");
        }

        [HttpGet]
        public IActionResult Personal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Personal(Person person)
        {
            loanService.UpdateLoanPersonalInfo(person);
            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            var loan = loanService.GetConfirmationDetails();
            return View(loan);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
