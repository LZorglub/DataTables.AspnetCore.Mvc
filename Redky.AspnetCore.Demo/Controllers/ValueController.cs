using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using Redky.AspnetCore.Demo.Models;
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
            var products = Products.GetProducts();

            if (!string.IsNullOrEmpty(dataRequest.Search?.Value))
            {
                products = products.Where(e => e.Name.Contains(dataRequest.Search.Value));
            }

            return Json(products
                .Select(e => new { Id = e.Id, Name = e.Name, Created = e.Created, Price = 10 })
                .ToDataTablesResponse(dataRequest));
            //return Json(new {
            //    draw = dataRequest.Draw,
            //    recordsTotal = products.Count(),
            //    recordsFiltered = products.Count(),
            //    data = products.Select(e => new {  Id = e.Id, Name = e.Name, Created = e.Created, Price = 10 })
            //});
        }
    }
}
