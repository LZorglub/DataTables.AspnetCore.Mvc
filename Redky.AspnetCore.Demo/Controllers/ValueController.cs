using Microsoft.AspNetCore.Mvc;
using Redky.AspnetCore.Mvc.Binder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redky.AspnetCore.Demo.Controllers
{
    public class ValueController : Controller
    {
        [HttpGet()]
        [Route("api/value")]
        public IActionResult Get([DataTablesRequest] DataTablesRequest dataRequest)
        {
            return Json(new { });
        }
    }
}
