using DevTools.ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Repositories
{
    /// <summary>
    /// This class describe all methods that will be manage in contact repository
    /// </summary>
    public interface IContactRepository : IBaseRepository<Contact>
    {
        IEnumerable<Contact> GetAllContacts();

        Contact GetContactById(int id);

        void Add(Contact entity);

        void Update(Contact contact);

        void Delete(int id);
    }
}
