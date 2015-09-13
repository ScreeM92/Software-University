using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Weapon : Supplement
    {
        public Weapon(int powerEffect, int healthEffect, int aggressionEffect)
            :base(powerEffect, healthEffect, aggressionEffect)
        {

        }
    }
}
