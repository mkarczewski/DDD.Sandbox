using DDD.Sandbox.CrossCutting;
using DDD.Sandbox.DomainCore;
using DDD.Sandbox.Modules.Employee.Contract;
using DDD.Sandbox.Modules.Employee.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Service
{
    public class EmployeeUpdateHandlerService : ApplicationService, IUpdateEmployeeFileCommandHandler
    {
        public IRepository<EmployeeFile, long> EmpRepo { get; set; }
        public IDictionaryBrowser DictBrowser { get; set; }

        public UpdateEmployeeFileResponse Invoke(UpdateEmployeeFileRequest request)
        {
            var emp = EmpRepo.Find(request.EmployeeFile.Id);

            emp.ChangeAddress(request.EmployeeFile.Address);
            emp.ChangePersonals(request.EmployeeFile.Personals);

            var engToDelete = emp.EngagementItems
                .Where(x => !request.EmployeeFile.EngagementItems.Any(i => i.Id == x.Id));

            var engToInsert = request.EmployeeFile.EngagementItems
                .Where(x => !emp.EngagementItems.Any(i => i.Id == x.Id));

            var engToEdit = request.EmployeeFile.EngagementItems
                .Where(x => emp.EngagementItems.Any(i => i.Id == x.Id));

            emp.ApplyEngagementChanges(GetMaintainerForCountry(emp), request.EmployeeFile.EngagementItems);

            return new UpdateEmployeeFileResponse()
            {
                Success = true
            };
        }

        private IEngagementsMaintainer GetMaintainerForCountry(EmployeeFile emp)
        {
            var country = DictBrowser.Find<CountryDictionaryItem>(emp.Address.Country.Id);

            if (country.IsInUE)
                return new UEEngagementMaintainer();
            else
                throw new NotImplementedException();
        }
    }
}
