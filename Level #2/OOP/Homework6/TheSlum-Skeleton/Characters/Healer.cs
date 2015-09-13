using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    class Healer : Character, IHeal
    {
        private const int HealthPoints = 75;
        private const int DefensePoints = 50;
        private const int DefaultHealingPoints = 60;
        private const int Range = 6;
        private int healingPoints;

        public Healer(string id, int x, int y, Team team)
            :base(id, x, y, HealthPoints, DefensePoints, team, Range)
        {
            this.HealingPoints = DefaultHealingPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.OrderBy(c => c.HealthPoints).First(c => !c.Equals(this));
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }
            set
            {
                this.healingPoints = value;
            }
        }
    }
}
