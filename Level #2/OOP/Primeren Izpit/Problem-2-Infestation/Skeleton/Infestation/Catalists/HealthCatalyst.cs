using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class HealthCatalyst : Catalists
    {
        const int DefaultHealthEffect = 3;

        public HealthCatalyst(int powerEffect, int aggressionEffect)
            :base(powerEffect, DefaultHealthEffect, aggressionEffect)
        {

        }
    }
}
