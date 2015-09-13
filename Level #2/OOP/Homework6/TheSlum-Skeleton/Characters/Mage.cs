using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    class Mage : Character, IAttack
    {
        private const int HealthPoints = 150;
        private const int DefensePoints = 50;
        private const int DefaultAttackPoints = 300;
        private const int Range = 5;
        private int attackPoints;

        public Mage(string id, int x, int y, Team team)
            :base(id, x, y, HealthPoints, DefensePoints, team, Range)
        {
            this.AttackPoints = DefaultAttackPoints;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.FirstOrDefault(tar => tar.Team != this.Team && tar.IsAlive && this.IsAlive);
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }
    }
}
