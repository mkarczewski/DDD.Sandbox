using DDD.Sandbox.CrossCutting;
using DDD.Sandbox.Modules.Employee.Contract;
using DDD.Sandbox.Modules.Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Service
{
    public class EmployeeQuery : ApplicationService
    {
        public IRepository<EmployeeFile, long> EmpRepo { get; set; }

        public EmployeeFileDTO GetEmployeeDTO(long id)
        {
            var emp = EmpRepo.Find(id);

            //DTO is UI display / SOAP / whatever ready
            return new EmployeeFileDTO()
            {
                Id = id,
                Address = emp.Address,
                Personals = emp.Personals,
                EngagementItems = emp.EngagementItems.Select(x => x.Attributes)
            };
        }
    }
}
