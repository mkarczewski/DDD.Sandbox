using DDD.Sandbox.Modules.Employee.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Domain
{
    public class UEEngagementMaintainer : IEngagementsMaintainer
    {
        public void ApplyChanges(EmployeeFile file, IList<EmployeeEngagementItem> itemsToChange, IEnumerable<EmployeeEngagementItemDTO> requiredState)
        {
            UpdateItems(file, itemsToChange, requiredState);
            ValidateItems(file, itemsToChange);
        }

        private static void UpdateItems(EmployeeFile file, IList<EmployeeEngagementItem> itemsToChange, IEnumerable<EmployeeEngagementItemDTO> requiredState)
        {
            var toDelete = itemsToChange.Where(x => !requiredState.Any(r => r.Id == x.Id));
            var toInsert = requiredState.Where(x => !itemsToChange.Any(c => c.Id == x.Id));
            var toEdit = itemsToChange.Where(x => requiredState.Any(r => r.Id == x.Id));

            foreach (var delete in toDelete)
                itemsToChange.Remove(delete);

            foreach (var insert in toInsert)
                itemsToChange.Add(EmployeeEngagementItem.CreateForFile(file, insert));

            foreach (var edit in toEdit)
                edit.UpdateAttributes(requiredState.First(x => x.Id == edit.Id));
        }

        private void ValidateItems(EmployeeFile file, IList<EmployeeEngagementItem> itemsToChange)
        {
            //throw exception if not valid
        }
    }
}
