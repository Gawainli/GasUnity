using UnityEngine;

namespace Haro.GAS
{
    public class AttributeSet : ScriptableObject
    {
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
    }
}