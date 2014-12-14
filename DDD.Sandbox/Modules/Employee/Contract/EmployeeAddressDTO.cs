using DDD.Sandbox.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Contract
{
    public struct EmployeeAddressDTO
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public DictionaryItemDTO Country { get; set; }
    }
}
