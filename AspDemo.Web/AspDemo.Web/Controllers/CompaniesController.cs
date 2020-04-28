using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspDemo.DomainModel.company.model;
using AspDemo.DomainModel.service;
using AspDemo.Web.common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspDemo.Web.Controllers
{
    public class CompaniesController : BaseController
    {
        public CompaniesController(DataProvider dataManager) : base(dataManager)
        {
        }

        public IActionResult Index()
        {
            return View(dataManager.GetAllCompanies(false, 1, 100).Items);
        }

        public IActionResult Add()
        {
            ViewBag.Founders = new MultiSelectList(dataManager.GetAllFounders().Items, "Id", "Value");
            return View("Create", new CompanyFullModel());
        }

        [HttpPost]
        public IActionResult Create(CompanyFullModel model)
        {
            ViewBag.Founders = new MultiSelectList(dataManager.GetAllFounders().Items, "Id", "Value");
            IList<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                return View(model);
            }
            {
                dataManager.CreateCompany(model);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Open(Guid id)
        {
            CompanyFullModel putModel = dataManager.GetCompanyPutModel(id);
            ViewBag.Founders = new MultiSelectList(dataManager.GetAllFounders().Items, "Id", "Value");
            return View("Edit",putModel);
        }

        [HttpPost]
        public IActionResult Edit(CompanyFullModel model)
        {
            ViewBag.Founders = new MultiSelectList(dataManager.GetAllFounders().Items, "Id", "Value");
            IList<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                return View(model);
            }
            else
            {
                dataManager.UpdateCompany(model);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.DeleteCompany(id);
            return Redirect("/Companies");
        }

        public IActionResult NewCompany()
        {
            return View();
        }
    }
}