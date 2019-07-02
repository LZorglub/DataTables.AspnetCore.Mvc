using System;
using DataTables.AspNetCore.Mvc;
using Xunit;

namespace DataTables.Tests
{
	public class DataTablesTest
	{
		[Fact]
		public void TestColumnDataToInt()
		{
			GridColumnsBuilder builder = new GridColumnsBuilder();
			builder.Data(0);
			var j = builder.ToJToken();
			Assert.Equal("{\"data\":0}", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnDataToString()
		{
			GridColumnsBuilder builder = new GridColumnsBuilder();
			builder.Data("name");
			var j = builder.ToJToken();
			Assert.Equal("{\"data\":\"name\"}", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnOrderDataToInt()
		{
			GridColumnsBuilder builder = new GridColumnsBuilder();
			builder.OrderData(0);
			var j = builder.ToJToken();
			Assert.Equal("{\"orderData\":[0]}", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnOrderDataToArray()
		{
			GridColumnsBuilder builder = new GridColumnsBuilder();
			builder.OrderData(new int[] { 0, 1, 2 });
			var j = builder.ToJToken();
			Assert.Equal("{\"orderData\":[0,1,2]}", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnDefFactoryInt()
		{
			ColumnDefsFactory factory = new ColumnDefsFactory();
			factory.Targets(0);
			var j = factory.ToJToken();
			Assert.Equal("[{\"targets\":0}]", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnDefFactoryArray()
		{
			ColumnDefsFactory factory = new ColumnDefsFactory();
			factory.Targets(new int[] { 0, 1, 2 });
			var j = factory.ToJToken();
			Assert.Equal("[{\"targets\":[0,1,2]}]", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnDefFactoryAll()
		{
			ColumnDefsFactory factory = new ColumnDefsFactory();
			factory.TargetAll(); ;
			var j = factory.ToJToken();
			Assert.Equal("[{\"targets\":\"_all\"}]", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnDefFactoryClassName()
		{
			ColumnDefsFactory factory = new ColumnDefsFactory();
			factory.Targets("class");
			var j = factory.ToJToken();
			Assert.Equal("[{\"targets\":\"class\"}]", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnDefFactoryDeeper()
		{
			ColumnDefsFactory factory = new ColumnDefsFactory();
			var colDef = factory.Targets(new int[] { 3, 4 });
			colDef.Searchable(false).OrderData(0);
			factory.Targets(1).Visible(false);
			var j = factory.ToJToken();
			Assert.Equal("[{\"targets\":[3,4],\"orderData\":[0],\"searchable\":false},{\"targets\":1,\"visible\":false}]", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnRenderNull()
		{
			GridColumnsBuilder factory = new GridColumnsBuilder();
			factory.Render((string)null);
			var j = factory.ToJToken();

			Assert.Equal("{\"render\":null}", j.ToString(Newtonsoft.Json.Formatting.None));
		}

		[Fact]
		public void TestColumnRenderFunction()
		{
			GridColumnsBuilder factory = new GridColumnsBuilder();
			factory.Render(() => "onRender");
			var j = factory.ToJToken();

			Assert.Equal("{\"render\":function(d,t,r,m){return onRender(d,t,r,m);}}", j.ToString(Newtonsoft.Json.Formatting.None));
		}
	}
}
