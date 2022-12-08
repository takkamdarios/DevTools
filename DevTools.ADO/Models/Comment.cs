using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Models
{
    internal class Comment : BaseModel
    {
        /// <summary>
        /// Represents the id of the contact concerned by this comment
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// Represents the content of the comment
        /// </summary>
        public string Content { get; set; }
    }
}
