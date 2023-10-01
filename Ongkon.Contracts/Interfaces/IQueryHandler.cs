using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ongkon.Contracts.Interfaces
{
    public interface IQueryHandler<T> where T : IRepository
    {
        //TODO: Replace object with typed object
        Task<T> Get(IQuery query);
    }
}
