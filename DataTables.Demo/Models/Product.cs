using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTables.Demo.Models
{
	public class Product
	{
		public Product(string name, string position, string office, string extn, string date, string salary)
		{
			this.Name = name;
			this.Id = Convert.ToInt32(extn);
			this.Created = DateTime.Parse(date);
			this.Salary = salary;
			this.Office = office;
			this.Position = position;
		}

		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "position")]
		public string Position { get; set; }

		[JsonProperty(PropertyName = "office")]
		public string Office { get; set; }

		[JsonProperty(PropertyName = "salary")]
		public string Salary { get; set; }

		[JsonProperty(PropertyName = "created")]
		public DateTime Created { get; set; }
	}
}
