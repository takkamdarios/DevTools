using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools
{
    public interface IDesign : IConvert
    {
        void ApplyDesign();
    }
}