using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redky.AspnetCore.Mvc.Binder
{
    public static class DataTablesExtensions
    {
        /// <summary>
        /// Gets a <see cref="DataTablesResponse"/> from collection/request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DataTablesResponse<T> ToDataTablesResponse<T>(this IEnumerable<T> collection, DataTablesRequest request)
        {
            DataTablesResponse<T> response = new DataTablesResponse<T>();
            response.Draw = request.Draw;
            response.RecordsTotal = collection.Count(); response.RecordsFiltered = collection.Count();
            response.Data = collection;
            return response;
        }
    }
}
