using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTables.Demo.Models
{
    public class Products
    {
        static IList<Product> myProducts;

        public static IList<Product> GetProducts()
        {
            if (myProducts == null)
            {
                myProducts = new List<Product>()
            {
                new Product("Tiger Nixon", "System Architect", "Edinburgh", "5421", "2011/04/25", "$320,800"),
                new Product("Garrett Winters", "Accountant", "Tokyo", "8422", "2011/07/25", "$170,750"),
                new Product("Ashton Cox", "Junior Technical Author", "San Francisco", "1562", "2009/01/12", "$86,000"),
                new Product("Cedric Kelly", "Senior Javascript Developer", "Edinburgh", "6224", "2012/03/29", "$433,060"),
                new Product("Airi Satou", "Accountant", "Tokyo", "5407", "2008/11/28", "$162,700"),
                new Product("Brielle Williamson", "Integration Specialist", "New York", "4804", "2012/12/02", "$372,000"),
                new Product("Herrod Chandler", "Sales Assistant", "San Francisco", "9608", "2012/08/06", "$137,500"),
                new Product("Rhona Davidson", "Integration Specialist", "Tokyo", "6200", "2010/10/14", "$327,900"),
                new Product("Colleen Hurst", "Javascript Developer", "San Francisco", "2360", "2009/09/15", "$205,500"),
                new Product("Sonya Frost", "Software Engineer", "Edinburgh", "1667", "2008/12/13", "$103,600"),
                new Product("Jena Gaines", "Office Manager", "London", "3814", "2008/12/19", "$90,560"),
                new Product("Quinn Flynn", "Support Lead", "Edinburgh", "9497", "2013/03/03", "$342,000"),
                new Product("Charde Marshall", "Regional Director", "San Francisco", "6741", "2008/10/16", "$470,600"),
                new Product("Haley Kennedy", "Senior Marketing Designer", "London", "3597", "2012/12/18", "$313,500"),
                new Product("Tatyana Fitzpatrick", "Regional Director", "London", "1965", "2010/03/17", "$385,750"),
                new Product("Michael Silva", "Marketing Designer", "London", "1581", "2012/11/27", "$198,500"),
                new Product("Paul Byrd", "Chief Financial Officer (CFO)", "New York", "3059", "2010/06/09", "$725,000"),
                new Product("Gloria Little", "Systems Administrator", "New York", "1721", "2009/04/10", "$237,500"),
                new Product("Bradley Greer", "Software Engineer", "London", "2558", "2012/10/13", "$132,000"),
                new Product("Dai Rios", "Personnel Lead", "Edinburgh", "2290", "2012/09/26", "$217,500"),
                new Product("Jenette Caldwell", "Development Lead", "New York", "1937", "2011/09/03", "$345,000"),
                new Product("Yuri Berry", "Chief Marketing Officer (CMO)", "New York", "6154", "2009/06/25", "$675,000"),
                new Product("Caesar Vance", "Pre-Sales Support", "New York", "8330", "2011/12/12", "$106,450"),
                new Product("Doris Wilder", "Sales Assistant", "Sidney", "3023", "2010/09/20", "$85,600"),
                new Product("Angelica Ramos", "Chief Executive Officer (CEO)", "London", "5797", "2009/10/09", "$1,200,000"),
                new Product("Gavin Joyce", "Developer", "Edinburgh", "8822", "2010/12/22", "$92,575"),
                new Product("Jennifer Chang", "Regional Director", "Singapore", "9239", "2010/11/14", "$357,650"),
                new Product("Brenden Wagner", "Software Engineer", "San Francisco", "1314", "2011/06/07", "$206,850"),
                new Product("Fiona Green", "Chief Operating Officer (COO)", "San Francisco", "2947", "2010/03/11", "$850,000"),
                new Product("Shou Itou", "Regional Marketing", "Tokyo", "8899", "2011/08/14", "$163,000"),
                new Product("Michelle House", "Integration Specialist", "Sidney", "2769", "2011/06/02", "$95,400"),
                new Product("Suki Burks", "Developer", "London", "6832", "2009/10/22", "$114,500"),
                new Product("Prescott Bartlett", "Technical Author", "London", "3606", "2011/05/07", "$145,000"),
                new Product("Gavin Cortez", "Team Leader", "San Francisco", "2860", "2008/10/26", "$235,500"),
                new Product("Martena Mccray", "Post-Sales support", "Edinburgh", "8240", "2011/03/09", "$324,050"),
                new Product("Unity Butler", "Marketing Designer", "San Francisco", "5384", "2009/12/09", "$85,675")
            };
            }
            return myProducts;
        }
    }
}
