# DataTables.AspnetCore.Mvc
The **DataTables.AspnetCore.Mvc** provides htmlHelper wrapper for [jquery datatables](https://datatables.net/).

# Installation
The easiest way to install is by using [NuGet](https://www.nuget.org/packages/DataTables.AspnetCore.Mvc/). The current version is writing in netstandard2.0

### Dependencies
DataTables has only one library dependency [jQuery](https://jquery.com)

Add a link on datatables css and javascript files in your page

```javascript
<link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/v/dt/dt-1.10.16/b-1.4.2/b-html5-1.4.2/b-print-1.4.2/sl-1.2.3/datatables.min.css" />
<script type="text/javascript" src="https://cdn.datatables.net/v/dt/dt-1.10.16/b-1.4.2/b-html5-1.4.2/b-print-1.4.2/sl-1.2.3/datatables.min.js"></script>
```
Note that additional datatables packages can be required for [extensions](https://datatables.net/extensions/index).

To avoid to reference the namespace in each cshtml files you can add an using in the _ViewImports.cshtml file.
```javascript
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using DataTables.AspNetCore.Mvc
```

# HowTo
Refer to the official [dataTables.net](https://datatables.net/) documentation for details on options.

## Basic initialisation
The easy way  to use it with your own tables is to call the htmlHelper with our id table.
```javascript
@(Html.Ext().Grid<dynamic>().Name("example"))
```

Layout and columns definition can be set with Dom and ColumnDefs method
```javascript
     @(Html.Ext().Grid<dynamic>().Name("example2")
            .Dom("B<\"clear\">lfrtip")
            .ColumnDefs(c =>
            {
                c.TargetAll().Searchable(false);
                // Column 1 gives order for column 0
                c.Targets(0).OrderData(1);
            })
            .PagingType(PagingType.Full_numbers)
     )
```

## Datasource
External datasource can be set with Datasource method. The datasource option use ajax method to define the source url.

```javascript
        @(Html.Ext().Grid<dynamic>().Name("example")
            .DataSource(c => 
                c.Ajax().Url("/data/arrays.json").Method("GET")
            )
        )
```

If json source didn't match your header table it's required to define your columns as explain [here](https://datatables.net/manual/ajax)

This sample map the columns with the json properties : name, position and office.
```javascript
        @(Html.Ext().Grid<dynamic>().Name("example")
            .DataSource(c => 
                c.Ajax().Url("/data/arrays.json").Method("GET")
            )
            .Columns(cols =>
            {
                cols.Add().Data("name");
                cols.Add().Data("position");
                cols.Add().Data("office");
            })
        )
```

## ServerSide 
When dealing with thousands of data rows it can be helpfull to use the serverside configuration.

The following example map the datasource with a web api. Columns are defined regarding the Product properties class. By default the datasource mapping is based on JsonProperty attribute of property. If none is defined the property name is used. Use the Data method to modify the mapping.
Javascript scripts can be added to modify the render of column.
```javascript
        @(Html.Ext().Grid<Product>().Name("example").RowId("id")
            .Columns(cols =>
            {
                cols.Add(c => c.Name).Title("Name");
                cols.Add(c => c.Office).Title("Office");
                cols.Add(c => c.Position).Title("Position");
                cols.Add(c => c.Salary).Visible(false).Title("Salary");
                cols.Add(c => c.Created).Title("Date");
                cols.Add(c => c.Id).Data("id").Title("").Render(() => "onRender").Click("onClick");
            })
            .ServerSide(true)
            .DataSource(c =>
                c.Ajax().Url("/api/value").Method("GET")
            )
        )
        
        <script>
        function onRender(data, type, row, meta) {
            return '<button type="button" data-type="view" class="btn btn-sm btn-default"><i class="fa fa-lg fa-fw fa-search"></i></button> <button type="button" data-type="remove" class="btn btn-sm btn-danger"><i class="fa fa-lg fa-fw fa-trash"></i></button>';
        }

        function onClick(e) {
          if (e.data.type == 'remove') {
            console.log('remove clicked');
          } else if (e.data.type == 'view') {
            console.log('view clicked');
          }
        }
        </script>
```

```csharp
    public class Product
    { 
        // JsonProperty not defined
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
```

From server side, the request is processing using the helper class DataTableRequest and extension ToDataTablesResponse on collection.
```csharp
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
            products = products.Skip(dataRequest.Start).Take(dataRequest.Length);

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
       }
```

## Events
Events are catch from client side with the Events method
```javascript
        @(Html.Ext().Grid<dynamic>().Name("example")
            .Select(s => {})
            .Events(e => { e.Select("onSelected").Deselect("onDeselected"); })
        )
        
        <script type="text/javascript">
          function onSelected(e, dt, type, i) {
              console.log("select " + type);
          }

          function onDeselected(e, dt, type, i) {
              console.log("deselect " + type);
          }
      </script>
```

## Extensions
The current library supports buttons and select extensions.
Following sample enable the Select extension and catch select/deselect events

```javascript
        @(Html.Ext().Grid<dynamic>().Name("example")
            .ColumnDefs(c =>
            {
                c.Targets(0).Orderable(false).ClassName("select-checkbox");
            })
            .Select(s => {
                s.Blurable(true).Info(true);
            })
            .Events(e =>
            {
                e.Select("onSelected").Deselect("onDeselected");
            }
            )
        )
```

## Sample of table
        <table id="example" class="display" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Position</th>
                    <th>Office</th>
                    <th>Age</th>
                    <th>Start date</th>
                    <th>Salary</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Tiger Nixon</td>
                    <td>System Architect</td>
                    <td>Edinburgh</td>
                    <td>61</td>
                    <td>2011/04/25</td>
                    <td>$320,800</td>
                </tr>
                <tr>
                    <td>Garrett Winters</td>
                    <td>Accountant</td>
                    <td>Tokyo</td>
                    <td>63</td>
                    <td>2011/07/25</td>
                    <td>$170,750</td>
                </tr>
                <tr>
                    <td>Ashton Cox</td>
                    <td>Junior Technical Author</td>
                    <td>San Francisco</td>
                    <td>66</td>
                    <td>2009/01/12</td>
                    <td>$86,000</td>
                </tr>
            </tbody>
        </table>
