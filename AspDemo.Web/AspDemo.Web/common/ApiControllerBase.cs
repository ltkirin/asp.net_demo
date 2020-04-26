using AspDemo.DomainModel.common.command.response;
using AspDemo.DomainModel.service;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspDemo.Web.common
{
	public class ApiControllerBase : ControllerBase
    {

		protected readonly DataManager dataManager;

		public ApiControllerBase(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

		private ILog log = LogManager.GetLogger(typeof(ApiControllerBase));

		public TResponse Query<TResponse>(Func<TResponse> func) where TResponse : ResponseBase, new()
		{
			try
			{
				log.Info($"METHOD:{HttpContext.Request.Method} PATH:{HttpContext.Request.Path}");
				ResponseBase response = func();
				response.IsSuccess = true;

				return (TResponse)response;
			}
			catch (Exception ex)
			{
				log.Error("ERROR ON API CALL!");
				log.ErrorFormat("Message: {0}", ex.Message);
				log.ErrorFormat("StackTrace: {0}", ex.StackTrace);

				TResponse errorResponse = new TResponse
				{
					ErrorMessge = ex.Message
				};
				return errorResponse;
			}

		}
	}
}
