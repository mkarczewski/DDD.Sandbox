using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.CrossCutting
{
    public interface IRepository<TEn, TId>
        where TEn : AggregateRoot<TId>
        where TId : struct
    {
        TEn Find(TId id);
    }
}
