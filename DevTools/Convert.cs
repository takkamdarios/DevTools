using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools
{
    public class Convert : IConvert
    {
       public string ConvertToString(object obj)
        {
            //Conversion logic
            return obj.ToString();
        }

        public object ConvertFromString(string str)
        {
            //Conversion logic
            return System.Convert.ChangeType(str, type);
        }
    }
    public  partial class Design
    {
        
    }
}