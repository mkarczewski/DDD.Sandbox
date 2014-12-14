using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Contract
{
    public struct EmployeeEngagementItemDTO
    {
        public long Id { get; set; }
        public decimal TimePart { get; set; }
        public string AgreementNo { get; set; }
        public DateTime AgreementStart { get; set; }
        public DateTime? AgreementEnd { get; set; }
    }
}
