﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools
{
    public interface IConvert
    {
        string ConvertToString(object obj);
        object ConvertFromString(string str, Type type);
    }
}