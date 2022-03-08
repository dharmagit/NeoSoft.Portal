using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NeoSoft.Portal.Data.Interface
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll(string procedureName, SqlCommand command);
        TEntity Get(int id);
        void Add(TEntity entity);
        void Change(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}

