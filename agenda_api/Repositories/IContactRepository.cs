using agenda_api.Models;

namespace agenda_api.Repositories
{
    /// <summary>
    /// Interface do repositório referente ao CRUD da agenda
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// Lista todos os contatos da Agenda, seguindo parâmetros de paginação
        /// </summary>
        IEnumerable<Contact> FindAll(int skip, int take);
        /// <summary>
        /// Busca um contato usando o campo Id como parâmetro
        /// </summary>
        Contact? FindById(int id);
        /// <summary>
        /// Adiciona um contato
        /// </summary>
        void Insert(Contact contact);
        /// <summary>
        /// Atualiza um contato usando o campo Id como parâmetro
        /// </summary>
        void Update(Contact contact);
        /// <summary>
        /// Exclui um contato usando o campo Id como parâmetro
        /// </summary>
        void Delete(Contact contact);
    }
}