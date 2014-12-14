using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Contract
{
    public struct EmployeePersonalsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryPersonalID { get; set; }
    }
}
