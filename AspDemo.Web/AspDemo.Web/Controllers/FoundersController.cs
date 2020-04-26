using System;
using System.Collections.Generic;
using System.Linq;
using AspDemo.DomainModel.common.model;
using AspDemo.DomainModel.founder.model;
using AspDemo.DomainModel.service;
using AspDemo.Web.common;
using Microsoft.AspNetCore.Mvc;

namespace AspDemo.Web.Controllers
{
    public class FoundersController : BaseController
    {
        public FoundersController(DataManager dataManager) : base(dataManager)
        {
        }

        public IActionResult Index()
        {
            return View(dataManager.GetAllFounders(false, 1, 100).Items);
        }

        public IActionResult NewFounder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FounderPostModel model)
        {
            dataManager.CreateFounder(model);
            return Redirect("/Founders");
        }
        
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            FounderPutModel putModel = dataManager.GetFounderPutModel(id);
            IList<ListItemModel> avalableCompanies =
                dataManager
                .GetAllCompanies(false, 1, 100)
                .Items
                .Where(i => !putModel.Companies.Contains(i))
                .ToList();
            return View(putModel);
        }

        [HttpPost]
        public IActionResult Update(FounderPutModel model)
        {
            dataManager.UpdateFounder(model);
            return Redirect("/Founders");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.DeleteFounder(id);
            return Redirect("/Founders");
        }
    }
}