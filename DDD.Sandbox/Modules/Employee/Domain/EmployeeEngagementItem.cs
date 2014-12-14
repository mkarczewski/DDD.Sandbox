using DDD.Sandbox.CrossCutting;
using DDD.Sandbox.Modules.Employee.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Domain
{
    public class EmployeeEngagementItem : Entity<long>
    {
        private EmployeeFile _employee;
        private decimal _timePart;
        private DateTime _agreementStart;
        private DateTime? _agreementEnd;
        private string _agreementNo;

        //factory method
        public static EmployeeEngagementItem CreateForFile(EmployeeFile file, EmployeeEngagementItemDTO attributes)
        {
            var item = new EmployeeEngagementItem();

            item._employee = file;
            item.UpdateAttributes(attributes);

            return item;
        }

        public EmployeeEngagementItemDTO Attributes
        {
            get
            {
                return new EmployeeEngagementItemDTO
                {
                    TimePart = _timePart,
                    AgreementStart = _agreementStart,
                    AgreementEnd = _agreementEnd,
                    AgreementNo = _agreementNo
                };
            }
        }

        public void UpdateAttributes(EmployeeEngagementItemDTO dto)
        {
            var old = Attributes;
            if (dto.Equals(old))
                return;

            _timePart = dto.TimePart;
            _agreementStart = dto.AgreementStart;
            _agreementEnd = dto.AgreementEnd;
            _agreementNo = dto.AgreementNo;
        }
    }
}
