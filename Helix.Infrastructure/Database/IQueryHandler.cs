﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Helix.Infrastructure.Database
{
    public interface IQueryHandler
    {
        Task<IEnumerable<T>> ExecuteQuery<T>(string sql, object param = null);
    }
}