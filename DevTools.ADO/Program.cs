using DevTools.ADO.Repositories.Comments;
using DevTools.ADO.Repositories.Contacts;
using DevTools.ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTools.Designer;

namespace DevTools.ADO
{
    internal class Program
    {
        private static readonly CommentRepository _commentRepository = new CommentRepository();
        private static readonly ContactRepository _contactRepository = new ContactRepository();
        static void Main(string[] args)
        {
            /*      COMMENT TEST       
            var comment = new Comment() { Content = "my first comment  [updated]", ContactId = 1 };
            //_commentRepository.Add(comment);
            //_commentRepository.Update(15, comment);
            _commentRepository.Delete(3);
            /*var data = _commentRepository.Get(4);
            //var datas = _commentRepository.GetAll();
            var multiDimArray = Design.GetMultiDimArrayFrom(new List<Comment>() { data});
            Design.Show(multiDimArray);*/


            /*      CONTACT TEST       */
            var contact = new Contact() 
            { 
                PhoneNumber = "695571929",
                Province = "Centre",
                Email = "sokou@bi.com",
                City = "Douala",
                FirstName = "Sokou",
                PostalCode = "aa9 14l",
                LastName = "Billionnaire"
            };
            //_contactRepository.Add(contact);
            _contactRepository.Update(2, contact);
            /*var data = _contactRepository.Get(1);
            //var datas = _contactRepository.GetAll();
            var multiDimArray = Design.GetMultiDimArrayFrom(new List<Contact>() { data});
            Design.Show(multiDimArray);*/


            Console.ReadLine();
        }
    }
}
