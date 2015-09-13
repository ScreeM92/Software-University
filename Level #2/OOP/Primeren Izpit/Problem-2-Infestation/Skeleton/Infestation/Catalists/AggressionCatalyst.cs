using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class AggressionCatalyst : Catalists
    {
        const int DefaultAggressionEffect = 3;

        public AggressionCatalyst(int powerEffect, int healthEffect)
            :base(powerEffect, healthEffect, DefaultAggressionEffect)
        {
        }
    }
}
