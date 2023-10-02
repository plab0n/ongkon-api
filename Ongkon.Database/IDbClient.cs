using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Interfaces;

namespace Ongkon.Database
{
    public interface IDbClient
    {
        Task Save<T>(string db, IRepository item);
        Task<T> GetById<T>(string db, string id);
        Task GetAll<T>(string db);
        Task<T> GetItemByQuery<T>(IQuery query);
    }

}
