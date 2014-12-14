using DDD.Sandbox.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Contract
{
    public class EmployeePersonalsChangedEvent : IDomainEvent
    {
        public long EmployeeId { get; set; }
        public EmployeePersonalsDTO Old { get; set; }
        public EmployeePersonalsDTO New { get; set; }
    }
}
