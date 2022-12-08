using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.FileStorage
{
    public class BaseModel
    {
        public long? Id { get; set; }
        public virtual DateTime? CreateAt { get; set; }
        public virtual DateTime? UpdateAt { get; set; }
    }
}
