using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Models
{
    internal class Contact : BaseModel
    {
        /// <summary>
        /// Represents the FirstName of the contact
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represents the LastName of the contact
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents the City of the contact
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Represents the PostalCode of the contact
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Represents the PhoneNumber of the contact
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Represents the Province of the contact
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// Represents Email id of the contact
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Represents all messages concerned by this contact
        /// </summary>
        public virtual ICollection<Comment> Messages { get; set; }
    }
}
