﻿using NDTuanShop.Service;
using NDTuanShop.Web.Infrastructure.Core;
using System.Web.Http;

namespace NDTuanShop.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        private IErrorService _errorService;

        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, NDTuanShop. ";
        }
    }
}