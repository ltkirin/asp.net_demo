using System;
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
            return View(dataManager.GetAllCompanies(false, 1,100).Items);
        }

        public IActionResult Add()
        {
            ViewBag.Founders = new MultiSelectList(dataManager.GetAllFounders().Items, "Id", "Value");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompanyFullModel model)
        {
            dataManager.CreateCompany(model);
            ViewBag.Founders = new MultiSelectList(dataManager.GetAllFounders().Items, "Id", "Value");
            return Redirect("/Companies");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            CompanyFullModel putModel = dataManager.GetCompanyPutModel(id);
            ViewBag.Founders = new MultiSelectList(dataManager.GetAllFounders().Items, "Id", "Value");
            return View(putModel);
        }

        [HttpPost]
        public IActionResult Update(CompanyFullModel model)
        {
            dataManager.UpdateCompany(model);
            return Redirect("/Companies");
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