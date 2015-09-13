using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Tank : Unit
    {
       private const int DefaultPower = 25;
       private const int DefaultHealth = 20;
       private const int DefaultAggression = 25;

        public Tank(string id, UnitClassification unitType)
            :base(id, unitType, DefaultHealth, DefaultPower, DefaultAggression)
        {

        }
    }
}
