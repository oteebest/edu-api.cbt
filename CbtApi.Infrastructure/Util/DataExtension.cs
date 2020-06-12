using CbtApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Infrastructure.Util
{
    public static class DataExtension
    {
        public static async Task<PagedModel<T>> ToPagedList<T>(this IQueryable<T> queryable,int pageNumber, int pageSize)
        {
            var count = await queryable.CountAsync();
            int offset = (pageNumber - 1) * pageSize;
            var items = await queryable.Skip(offset).Take(pageSize).ToArrayAsync();
            return new PagedModel<T>(items, count, pageNumber, pageSize);
        }

     

    }
}
