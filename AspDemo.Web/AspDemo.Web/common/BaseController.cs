using AspDemo.DomainModel.service;
using Microsoft.AspNetCore.Mvc;

namespace AspDemo.Web.common
{
    public class BaseController : Controller
    {
        protected readonly DataManager dataManager;

        public BaseController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    }
}
