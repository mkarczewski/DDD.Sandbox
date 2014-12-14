using DDD.Sandbox.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Contract
{
    public class EmployeeAddressChangedEvent : IDomainEvent
    {
        public long EmployeeId { get; set; }
        public EmployeeAddressDTO Old { get; set; }
        public EmployeeAddressDTO New { get; set; }
    }
}
