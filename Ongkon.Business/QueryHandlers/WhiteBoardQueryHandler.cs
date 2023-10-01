using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ongkon.Contracts.Interfaces;
using Ongkon.Contracts.Models;

namespace Ongkon.Business.QueryHandlers
{
    public class WhiteBoardQueryHandler : IQueryHandler<WhiteBoard>
    {
        private IRepositoryContext<WhiteBoard> _repositoryContext;
        public WhiteBoardQueryHandler(IRepositoryContext<WhiteBoard> repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public Task<WhiteBoard> Get(IQuery query)
        {
            return _repositoryContext.GetItemByQuery<WhiteBoard>(query);
        }
    }

}
