using agenda_api.Models;
using agenda_api.Repositories;
using FluentValidation.Results;

namespace agenda_api.Services
{
    /// <summary>
    /// Serviço referente ao CRUD da agenda
    /// </summary>
    public class ContactService : IContactService
    {
    
        private readonly IContactRepository _contactRepository;

        /// <summary>
        /// Construtor do serviço
        /// </summary>
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <inheritdoc/>
        public IEnumerable<Contact> FindAllContacts(int skip, int take) => _contactRepository.FindAll(skip, take);
        
        /// <inheritdoc/>
        public Contact? FindContactById(int id) {
            return _contactRepository.FindById(id);
        }

        private void validateContact(Contact contact) {
            var validator = new ContactValidator();
            ValidationResult result = validator.Validate(contact);
            if (result.ToString().Length > 0) {
                throw new Exception(result.ToString());
            }
        }

        /// <inheritdoc/>
        public bool InsertContact(Contact contact) {
            validateContact(contact);
            _contactRepository.Insert(contact);
            return true;
        }

        /// <inheritdoc/>
        public bool UpdateContact(int id, Contact contact) {
            Contact? contactToUpdate = _contactRepository.FindById(id);
            if (contactToUpdate != null) {
                validateContact(contact);
                contact.Id = contactToUpdate.Id;
                _contactRepository.Update(contact);
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public bool DeleteContact(int id) {
            Contact? contactToDelete = _contactRepository.FindById(id);
            if (contactToDelete != null) {
                _contactRepository.Delete(contactToDelete);
                return true;
            }
            return false;
        }
    }
}
