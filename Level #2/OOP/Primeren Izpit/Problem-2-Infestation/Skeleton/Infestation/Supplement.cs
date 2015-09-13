using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Supplement : ISupplement
    {

        public Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            throw new NotImplementedException();
        }

        public int PowerEffect
        {
            get;
            private set;
        }

        public int HealthEffect
        {
            get;
            private set;
        }

        public int AggressionEffect
        {
            get;
            private set;
        }
    }
}
