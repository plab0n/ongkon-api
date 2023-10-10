using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ongkon.Contracts.Commands;

namespace Ongkon.Contracts.Interfaces
{
    public interface ICommandHandler<T>
    {
        Task<ExpandoObject> Handle(T command);
    }
}
