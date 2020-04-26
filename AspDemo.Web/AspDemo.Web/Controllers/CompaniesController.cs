using System;
using AspDemo.DomainModel.company.model;
using AspDemo.DomainModel.service;
using AspDemo.Web.common;
using Microsoft.AspNetCore.Mvc;

namespace AspDemo.Web.Controllers
{
    public class CompaniesController : BaseController
    {
        public CompaniesController(DataManager dataManager) : base(dataManager)
        {
        }

        public IActionResult Index()
        {
            return View(dataManager.GetAllCompanies(false, 1,100).Items);
        }

        [HttpPost]
        public IActionResult Create(CompanyPostModel model)
        {
            dataManager.CreateCompany(model);
            return Redirect("/Companies");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            CompanyPutModel putModel = dataManager.GetCompanyPutModel(id);
            return View(putModel);
        }

        [HttpPost]
        public IActionResult Update(CompanyPutModel model)
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