using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Contract
{
    public struct EmployeeFileDTO
    {
        public long Id { get; set; }
        public EmployeeAddressDTO Address { get; set; }
        public EmployeePersonalsDTO Personals { get; set; }
        public IEnumerable<EmployeeEngagementItemDTO> EngagementItems { get; set; }
    }
}
