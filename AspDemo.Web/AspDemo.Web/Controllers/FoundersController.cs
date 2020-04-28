using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspDemo.DomainModel.founder.model;
using AspDemo.DomainModel.service;
using AspDemo.Web.common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspDemo.Web.Controllers
{
    public class FoundersController : BaseController
    {
        public FoundersController(DataProvider dataManager) : base(dataManager)
        {

        }

        public IActionResult Index()
        {
            return View(dataManager.GetAllFounders(false, 1, 100).Items);
        }

        public IActionResult Add()
        {
            ViewBag.Companies = new MultiSelectList(dataManager.GetAllCompanies().Items, "Id", "Value");
            return View("Create", new FounderFullModel());
        }

        [HttpPost]
        public IActionResult Create(FounderFullModel model)
        {
            ViewBag.Companies = new MultiSelectList(dataManager.GetAllCompanies().Items, "Id", "Value");
            IList<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                return View(model);
            }
            else
            {
                dataManager.CreateFounder(model);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Open(Guid id)
        {
            ViewBag.Companies = new MultiSelectList(dataManager.GetAllCompanies().Items, "Id", "Value");
            FounderFullModel putModel = dataManager.GetFounderPutModel(id);
            return View("Edit", putModel);
        }

        [HttpPost]
        public IActionResult Edit(FounderFullModel model)
        {
            ViewBag.Companies = new MultiSelectList(dataManager.GetAllCompanies().Items, "Id", "Value");
            IList<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                return View(model);
            }
            else
            {
                dataManager.UpdateFounder(model);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.DeleteFounder(id);
            return RedirectToAction("Index");
        }
    }
}