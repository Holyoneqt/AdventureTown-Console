using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.Models.Gameplay.Attributes
{
    public class AttributeSet
    {
        private Dictionary<AttributeType, EntityAttribute> _attributes;

        public AttributeSet()
        {
            _attributes = new Dictionary<AttributeType, EntityAttribute>()
            {
                { AttributeType.Stamina, new EntityAttribute(0) },
                { AttributeType.Power, new EntityAttribute(0) },
                { AttributeType.Lethality, new EntityAttribute(0) },
                { AttributeType.Armor, new EntityAttribute(0) }
            };
        }

        public EntityAttribute Get(AttributeType type)
        {
            return _attributes[type];
        }

        public void Set(AttributeType type, double value)
        {
            _attributes[type].Set(value);
        }
    }
}
