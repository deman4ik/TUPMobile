﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUPMobile.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}