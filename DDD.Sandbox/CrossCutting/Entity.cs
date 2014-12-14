using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.CrossCutting
{
    public abstract class Entity<TId> where TId : struct
    {
        public TId Id { get; protected set; } //protected setter - ORM ready
    }
}
