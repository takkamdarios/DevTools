using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Models
{
    internal class BaseModel
    {
        /// <summary>
        /// Represents the id of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the created date of the entity
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// Represents the updated date of the entity
        /// </summary>
        public DateTime? UpdateOn { get; set; }
    }
}
