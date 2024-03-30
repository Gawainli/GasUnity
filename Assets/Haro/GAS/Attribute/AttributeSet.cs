using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haro.GAS
{
    public abstract class AttributeSet
    {
        public abstract void Initialize();
        
        public virtual void PreAttributeChange(Attribute attribute, float newValue)
        {
        }

        public virtual void PostAttributeChange(Attribute attribute, float oldValue, float newValue)
        {
        }

        public virtual void PreAttributeBaseChange(Attribute attribute, float newValue)
        {
        }

        public virtual void PostAttributeBaseChange(Attribute attribute, float oldValue, float newValue)
        {
        }

        public Attribute GetAttribute(AttributeData data)
        {
            return new Attribute(data, this);
        }
    }
}