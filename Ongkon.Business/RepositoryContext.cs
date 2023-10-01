using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Interfaces;
using Ongkon.Database;

namespace Ongkon.Business
{
    public class RepositoryContext : IRepositoryContext<IRepository>
    {
        private IDbClient _dbClient;
        public RepositoryContext(IDbClient dbClient)
        {
            _dbClient = dbClient;
        }
        public async Task Save<T>(string db, IRepository item)
        {
            await _dbClient.Save<T>(db, item);
        }

        public Task GetById<T>(string db, string id)
        {
            throw new NotImplementedException();
        }

        public Task GetAll<T>(string db)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepositoryContext<T> where T : IRepository
    {
        Task Save<T>(string db, IRepository item);
        Task GetById<T>(string db, string id);
        Task GetAll<T>(string db);
    }
}
