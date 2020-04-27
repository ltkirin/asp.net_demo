﻿using System;
using System.Collections.Generic;
using System.Linq;
using AspDemo.DomainModel.common.model;
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(FounderFullModel model)
        {
            dataManager.CreateFounder(model);
            return Redirect("/Founders");
        }
        
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            FounderFullModel putModel = dataManager.GetFounderPutModel(id);
            ViewBag.Companies = new MultiSelectList(dataManager.GetAllCompanies().Items, "Id", "Value");
            return View(putModel);
        }

        [HttpPost]
        public IActionResult Update(FounderFullModel model)
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