using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Gameplay.Attributes
{
    public class EntityAttribute
    {
        private double _value;
        public double Value { get { return _value; } }

        public EntityAttribute(double val)
        {
            _value = val;
        }

        public void Increase(double amount)
        {
            _value += amount;
        }

        public void Decrease(double amount)
        {
            _value -= amount;
        }

        internal void Set(double value)
        {
            _value = value;
        }
    }
}
