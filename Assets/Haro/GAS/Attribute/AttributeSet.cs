using System.Collections.Generic;
using UnityEngine;

namespace Haro.GAS
{
    public class AttributeSet
    {
        protected Dictionary<string, Attribute> attributeNameMap = new Dictionary<string, Attribute>();
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
        
        public Attribute GetAttribute(string attrName)
        {
            return attributeNameMap[attrName];
        }
        
        protected Attribute CreateAttribute(string attrName)
        {
            var attr = new Attribute(new AttributeData(), attrName, this);
            attributeNameMap[attrName] = attr;
            return attr;
        }
    }
}