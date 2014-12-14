using DDD.Sandbox.CrossCutting;
using DDD.Sandbox.DomainCore;
using DDD.Sandbox.Modules.Employee.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.Modules.Employee.Domain
{
    public class EmployeeFile : AggregateRoot<long>, ICanBrowseDictionaries, ICanPublishDomainEvents
    {
        public IDictionaryBrowser DictionaryBrowser { get; set; }
        public IDomainEventPublisher EventPublisher { get; set; }

        private string _street;
        private string _postalCode;
        private string _city;
        private CountryDictionaryItem _country;

        private string _firstName;
        private string _lastName;
        private string _countryPersonalId;

        private IList<EmployeeEngagementItem> _engagementItems;
        public IReadOnlyCollection<EmployeeEngagementItem> EngagementItems
        {
            get
            {
                return _engagementItems.ToList().AsReadOnly();
            }
        }

        public EmployeeAddressDTO Address
        {
            get
            {
                return new EmployeeAddressDTO()
                {
                    Street = _street,
                    PostalCode = _postalCode,
                    City = _city,
                    Country = DictionaryBrowser.ConvertToDTO(_country)
                };
            }
        }

        public EmployeePersonalsDTO Personals
        {
            get
            {
                return new EmployeePersonalsDTO()
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    CountryPersonalID = _countryPersonalId
                };
            }
        }

        public void ChangeAddress(EmployeeAddressDTO dto)
        {
            var old = Address;

            if (dto.Equals(old))
                return;

            _street = dto.Street;
            _postalCode = dto.PostalCode;
            _city = dto.City;
            _country = DictionaryBrowser.Find<CountryDictionaryItem>(dto.Country.Id);

            EventPublisher.Publish(new EmployeeAddressChangedEvent() { EmployeeId = this.Id, Old = old, New = dto });
        }

        public void ChangePersonals(EmployeePersonalsDTO dto)
        {
            var old = Personals;

            if (dto.Equals(old))
                return;

            _firstName = dto.FirstName;
            _lastName = dto.LastName;
            _countryPersonalId = dto.CountryPersonalID;

            EventPublisher.Publish(new EmployeePersonalsChangedEvent() { EmployeeId = this.Id, Old = old, New = dto });
        }

        public void ApplyEngagementChanges(IEngagementsMaintainer maintainer, IEnumerable<EmployeeEngagementItemDTO> requiredState)
        {
            maintainer.ApplyChanges(this, _engagementItems, requiredState);

            EventPublisher.Publish(new EmployeeAgreementsChangedEvent() { EmployeeId = this.Id });
        }
    }
}
