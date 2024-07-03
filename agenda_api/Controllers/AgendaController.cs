using Microsoft.AspNetCore.Mvc;
using agenda_api.Models;
using Microsoft.AspNetCore.Cors;
using agenda_api.Services;

namespace agenda_api.Controllers;

/// <summary>
/// Controller referente ao CRUD da agenda
/// </summary>
[EnableCors()]
[ApiController]
[Route("api")]
public class AgendaController : ControllerBase
{

   private readonly IContactService _contactService;

   /// <summary>
   /// Construtor do controller
   /// </summary>
   public AgendaController(IContactService contactService)
   {
      _contactService = contactService;
   }

   /// <summary>
   /// Lista todos os contatos da Agenda, seguindo parâmetros de paginação
   /// </summary>
   [HttpGet]
   [ProducesResponseType(typeof(IEnumerable<Contact>), 200)]
   [ProducesResponseType(404)]
   public IEnumerable<Contact> GetContacts([FromQuery] int skip = 0, [FromQuery] int  take = 10)
   {
      return _contactService.FindAllContacts(skip, take);
   }

   /// <summary>
   /// Busca um contato usando o campo Id como parâmetro
   /// </summary>
   [HttpGet("{id}")]
   [ProducesResponseType(typeof(Contact), 200)]
   [ProducesResponseType(404)]
   public Contact? GetContactById(int id)
   {
      return _contactService.FindContactById(id);
   }

   /// <summary>
   /// Adiciona um contato
   /// </summary>
   [HttpPost]
   [ProducesResponseType(typeof(bool), 200)]
   [ProducesResponseType(404)]
   public bool AddContact([FromBody] Contact contact)
   {
      return _contactService.InsertContact(contact);
   }

   /// <summary>
   /// Atualiza um contato usando o campo Id como parâmetro
   /// </summary>
   [HttpPatch("{id}")]
   [ProducesResponseType(typeof(bool), 200)]
   [ProducesResponseType(404)]
   public bool UpdateContact(int id, [FromBody] Contact contact)
   {
      return _contactService.UpdateContact(id, contact);
   }

   /// <summary>
   /// Exclui um contato usando o campo Id como parâmetro
   /// </summary>
   [HttpDelete("{id}")]
   [ProducesResponseType(typeof(bool), 200)]
   [ProducesResponseType(404)]
   public bool DeleteContact(int id)
   {
      return _contactService.DeleteContact(id);
   }
}

