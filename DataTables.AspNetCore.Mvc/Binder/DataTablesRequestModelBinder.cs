using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc.Binder
{
    class DataTablesRequestModelBinder : IModelBinder
    {
        /// <summary>
        /// Attempts to bind a model.
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            return Task.Factory.StartNew(() =>
            {
                BindModel(bindingContext);
            });
        }

        /// <summary>
        /// Attempts to bind a model.
        /// </summary>
        /// <param name="bindingContext"></param>
        private void BindModel(ModelBindingContext bindingContext) { 
            var valueProvider = bindingContext.ValueProvider;

            int draw, start, length;

            var valueResultProvider = valueProvider.GetValue("draw");
            if (valueProvider == null)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }
            TryParse<int>(valueResultProvider, out draw);
            TryParse<int>(valueProvider.GetValue("start"), out start);
            TryParse<int>(valueProvider.GetValue("length"), out length);

            DataTablesRequest result = new DataTablesRequest(draw, start, length, TryGetSearch(valueProvider),
                TryGetOrders(valueProvider), TryGetColumns(valueProvider));
            bindingContext.Result = ModelBindingResult.Success(result);
        }

        /// <summary>
        /// Gets the search part of query
        /// </summary>
        /// <returns></returns>
        private Search TryGetSearch(IValueProvider valueProvider)
        {
            string searchValue;
            if (TryParse<string>(valueProvider.GetValue("search[value]"), out searchValue) &&
                !string.IsNullOrEmpty(searchValue))
            {
                bool regex = false;
                TryParse<bool>(valueProvider.GetValue("search[regex]"), out regex);
                return new Search(searchValue, regex);
            }
            return null;
        }

        /// <summary>
        /// Gets the list of columns in request
        /// </summary>
        /// <param name="valueProvider"></param>
        /// <returns></returns>
        private IEnumerable<DataTableColumn> TryGetColumns(IValueProvider valueProvider)
        {
            //columns[0][data]:name
            //columns[0][name]:
            //columns[0][searchable]:true
            //columns[0][orderable]:true
            //columns[0][search][value]:
            //columns[0][search][regex]:false
            int index = 0;
            List<DataTableColumn> columns = new List<DataTableColumn>();

            // Count number of column
            do
            {
                if (valueProvider.GetValue($"columns[{index}][data]").FirstValue != null)
                {
                    string data, name, searchValue;
                    bool searchable, orderable, searchRegEx;
                    TryParse<string>(valueProvider.GetValue($"columns[{index}][data]"), out data);
                    TryParse<string>(valueProvider.GetValue($"columns[{index}][name]"), out name);
                    TryParse<bool>(valueProvider.GetValue($"columns[{index}][searchable]"), out searchable);
                    TryParse<bool>(valueProvider.GetValue($"columns[{index}][orderable]"), out orderable);
                    TryParse<string>(valueProvider.GetValue($"columns[{index}][search][value]"), out searchValue);
                    TryParse<bool>(valueProvider.GetValue($"columns[{index}][search][regex]"), out searchRegEx);

                    columns.Add(new DataTableColumn(data, name, searchable, orderable, searchValue, searchRegEx));
                    index++;
                }
                else
                {
                    break;
                }
            } while (true);

            return columns;
        }

        /// <summary>
        /// Gets the list of order columns in request
        /// </summary>
        /// <param name="valueProvider"></param>
        /// <returns></returns>
        private IEnumerable<Order> TryGetOrders(IValueProvider valueProvider)
        {
            //order[0][column]:0
            //order[0][dir]:asc
            int index = 0;
            List<Order> orders = new List<Order>();

            do
            {
                if (valueProvider.GetValue($"order[{index}][column]").FirstValue != null)
                {
                    int column; string dir;
                    TryParse<int>(valueProvider.GetValue($"order[{index}][column]"), out column);
                    TryParse<string>(valueProvider.GetValue($"order[{index}][dir]"), out dir);

                    orders.Add(new Order(column, dir));
                    index++;
                }
                else
                {
                    break;
                }
            } while (true);

            return orders;
        }

        /// <summary>
        /// Try to gets the first value in the request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool TryParse<T>(ValueProviderResult value, out T result)
        {
            result = default(T);
            if (value == null || value.FirstValue == null) return false;

            try
            {
                result = (T)Convert.ChangeType(value.FirstValue, typeof(T));
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
