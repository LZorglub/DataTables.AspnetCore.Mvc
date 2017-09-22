using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTables.AspNetCore.Mvc;

namespace DataTables.Tests
{
    [TestClass]
    public class DataTablesTest
    {
        [TestMethod]
        public void TestColumnDataToInt()
        {
            GridColumnsBuilder builder = new GridColumnsBuilder();
            builder.Data(0);
            var j = builder.ToJToken();
            Assert.AreEqual("{\"data\":0}", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnDataToString()
        {
            GridColumnsBuilder builder = new GridColumnsBuilder();
            builder.Data("name");
            var j = builder.ToJToken();
            Assert.AreEqual("{\"data\":\"name\"}", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnOrderDataToInt()
        {
            GridColumnsBuilder builder = new GridColumnsBuilder();
            builder.OrderData(0);
            var j = builder.ToJToken();
            Assert.AreEqual("{\"orderData\":[0]}", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnOrderDataToArray()
        {
            GridColumnsBuilder builder = new GridColumnsBuilder();
            builder.OrderData(new int[] { 0, 1, 2});
            var j = builder.ToJToken();
            Assert.AreEqual("{\"orderData\":[0,1,2]}", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnDefFactoryInt()
        {
            ColumnDefsFactory factory = new ColumnDefsFactory();
            factory.Targets(0);
            var j = factory.ToJToken();
            Assert.AreEqual("[{\"targets\":0}]", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnDefFactoryArray()
        {
            ColumnDefsFactory factory = new ColumnDefsFactory();
            factory.Targets(new int[] { 0,1,2});
            var j = factory.ToJToken();
            Assert.AreEqual("[{\"targets\":[0,1,2]}]", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnDefFactoryAll()
        {
            ColumnDefsFactory factory = new ColumnDefsFactory();
            factory.TargetAll(); ;
            var j = factory.ToJToken();
            Assert.AreEqual("[{\"targets\":'_all'}]", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnDefFactoryClassName()
        {
            ColumnDefsFactory factory = new ColumnDefsFactory();
            factory.Targets("class");
            var j = factory.ToJToken();
            Assert.AreEqual("[{\"targets\":'class'}]", j.ToString(Newtonsoft.Json.Formatting.None));
        }

        [TestMethod]
        public void TestColumnDefFactoryDeeper()
        {
            ColumnDefsFactory factory = new ColumnDefsFactory();
            var colDef = factory.Targets(new int[] { 3,4});
            colDef.Searchable(false).OrderData(0);
            factory.Targets(1).Visible(false);
            var j = factory.ToJToken();
            Assert.AreEqual("[{\"targets\":[3,4],\"orderData\":[0],\"searchable\":false},{\"targets\":1,\"visible\":false}]", j.ToString(Newtonsoft.Json.Formatting.None));
        }
    }
}
