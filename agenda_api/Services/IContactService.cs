using agenda_api.Models;

namespace agenda_api.Services
{
    /// <summary>
    /// Interface do serviço referente ao CRUD da agenda
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Lista todos os contatos da Agenda, seguindo parâmetros de paginação
        /// </summary>
        IEnumerable<Contact> FindAllContacts(int skip, int take);
        
        /// <summary>
        /// Busca um contato usando o campo Id como parâmetro
        /// </summary>
        Contact? FindContactById(int id);

        /// <summary>
        /// Adiciona um contato
        /// </summary>
        bool InsertContact(Contact contact);

        /// <summary>
        /// Atualiza um contato usando o campo Id como parâmetro
        /// </summary>
        bool UpdateContact(int id, Contact contact);

        /// <summary>
        /// Exclui um contato usando o campo Id como parâmetro
        /// </summary>
        bool DeleteContact(int id);
    }
}