using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.CrossCutting
{
    public class AggregateRoot<TId> : Entity<TId> where TId : struct
    {
        /// <summary>
        /// Version for concurrency control
        /// </summary>
        public long Version { get; set; }
    }
}
