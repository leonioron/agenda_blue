using agenda_api.Data;
using agenda_api.Models;

namespace agenda_api.Repositories
{
    /// <summary>
    /// Repositório referente ao CRUD da agenda
    /// </summary>
    public class ContactRepository : IContactRepository
    {

        private ContactContext _context;

        /// <summary>
        /// Construtor do Repositório
        /// </summary>
        public ContactRepository(ContactContext context) {
            _context = context;  
        }

        /// <inheritdoc/>
        public virtual IEnumerable<Contact> FindAll(int skip, int take)
        {
            return _context.Contacts.Skip(skip).Take(take);
        }

        /// <inheritdoc/>
         public virtual Contact? FindById(int id)
        {
            return _context.Contacts.Find(id);
        }

        /// <inheritdoc/>
        public virtual void Insert(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual void Update(Contact contact)
        {
            _context.ChangeTracker.Clear();
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }
}