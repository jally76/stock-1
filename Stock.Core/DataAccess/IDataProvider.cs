using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Stock.Core.DataAccess
{
    interface IDataProvider
    {
        List<T> Select<T>() where T : class;
        List<T> Where<T>(Expression<Func<T, bool>> expression) where T : class;
        T SingleOrDefault<T>(Expression<Func<T, bool>> expression) where T : class;
        T Create<T>(T entity) where T : class;
        T Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}
