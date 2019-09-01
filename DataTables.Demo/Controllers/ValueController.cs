using Microsoft.AspNetCore.Mvc;
using DataTables.Demo.Models;
using DataTables.AspNetCore.Mvc.Binder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTables.Demo.Controllers
{
	public class ValueController : Controller
	{
		[HttpGet()]
		[Route("api/value")]
		public IActionResult Get([DataTablesRequest] DataTablesRequest dataRequest)
		{
			IEnumerable<Product> products = Products.GetProducts();
			int recordsTotal = products.Count();
			int recordsFilterd = recordsTotal;

			if (!string.IsNullOrEmpty(dataRequest.Search?.Value))
			{
				products = products.Where(e => e.Name.Contains(dataRequest.Search.Value));
				recordsFilterd = products.Count();
			}
            products = products.Skip(dataRequest.Start);
            if (dataRequest.Length != -1) products = products.Take(dataRequest.Length);

			return Json(products
				.Select(e => new
				{
					Id = e.Id,
					Name = e.Name,
					Created = e.Created,
					Salary = e.Salary,
					Position = e.Position,
					Office = e.Office
				})
				.ToDataTablesResponse(dataRequest, recordsTotal, recordsFilterd));
			//return Json(new {
			//    draw = dataRequest.Draw,
			//    recordsTotal = products.Count(),
			//    recordsFiltered = products.Count(),
			//    data = products.Select(e => new {  Id = e.Id, Name = e.Name, Created = e.Created, Price = 10 })
			//});
		}

		[HttpDelete()]
		[Route("api/value/{id:int}")]
		public IActionResult Delete(int id)
		{
			Products.GetProducts().Remove(Products.GetProducts().First(i => i.Id == id));
			return Ok();
		}
	}
}