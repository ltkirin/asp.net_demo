using AspDemo.DomainModel.service;
using Microsoft.AspNetCore.Mvc;

namespace AspDemo.Web.common
{
    public class BaseController : Controller
    {
        protected readonly DataProvider dataManager;

        public BaseController(DataProvider dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
