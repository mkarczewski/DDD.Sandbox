using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.CrossCutting
{
    public interface IDomainEventPublisher 
    {
	    void Publish<TEvnt>(TEvnt evnt) where TEvnt : IDomainEvent;
    }
}
