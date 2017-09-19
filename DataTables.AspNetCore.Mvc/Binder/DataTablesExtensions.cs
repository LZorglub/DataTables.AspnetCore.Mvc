using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc.Binder
{
    /// <summary>
    /// Provides extensions for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class DataTablesExtensions
    {
        /// <summary>
        /// Gets a <see cref="DataTablesResponse{T}"/> from collection/request
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

        /// <summary>
        /// Gets a <see cref="DataTablesResponse{T}"/> from collection/request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="request"></param>
        /// <param name="recordsTotal">Number of records before filtered</param>
        /// <returns></returns>
        public static DataTablesResponse<T> ToDataTablesResponse<T>(this IEnumerable<T> collection, DataTablesRequest request, int recordsTotal)
        {
            DataTablesResponse<T> response = new DataTablesResponse<T>();
            response.Draw = request.Draw;
            response.RecordsTotal = recordsTotal;
            response.RecordsFiltered = recordsTotal;
            response.Data = collection;
            return response;
        }

        /// <summary>
        /// Gets a <see cref="DataTablesResponse{T}"/> from collection/request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="request"></param>
        /// <param name="recordsTotal">Number of records before filtered</param>
        /// <param name="recordsFiltered">Number of records after filtered</param>
        /// <returns></returns>
        public static DataTablesResponse<T> ToDataTablesResponse<T>(this IEnumerable<T> collection, DataTablesRequest request, int recordsTotal, int recordsFiltered)
        {
            DataTablesResponse<T> response = new DataTablesResponse<T>();
            response.Draw = request.Draw;
            response.RecordsTotal = recordsTotal;
            response.RecordsFiltered = recordsFiltered;
            response.Data = collection;
            return response;
        }
    }
}
