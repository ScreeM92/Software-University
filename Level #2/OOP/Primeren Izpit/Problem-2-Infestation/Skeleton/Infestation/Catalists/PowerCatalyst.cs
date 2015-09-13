using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class PowerCatalyst : Catalists
    {
        const int DefaultPowerEffect = 3;

        public PowerCatalyst(int healthEffect, int aggressionEfect)
            :base(DefaultPowerEffect, healthEffect, aggressionEfect)
        {

        }
    }
}
