using DDD.Sandbox.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Contract
{
    public class EmployeeAgreementsChangedEvent : IDomainEvent
    {
        public long EmployeeId { get; set; }
    }
}
