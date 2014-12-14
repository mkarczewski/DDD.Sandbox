using DDD.Sandbox.Modules.Employee.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Domain
{
    public interface IEngagementsMaintainer
    {
        void ApplyChanges(EmployeeFile file, IList<EmployeeEngagementItem> itemsToChange, IEnumerable<EmployeeEngagementItemDTO> requiredState);
    }
}
