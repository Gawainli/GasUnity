using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Haro.GAS
{
    public class AttributeData
    {
        public float CurrentValue { get; set; }
        public float BaseValue { get; set; }
    }

    public class Attribute
    {
        private string _name;
        private readonly AttributeData _data;
        
        public AttributeSet OwnerSet { get; set; }

        public Attribute(){}

        public Attribute(AttributeData data)
        {
            _data = data;
            _name = nameof(data);
        }

        public Attribute(AttributeData data, AttributeSet ownerSet)
        {
            _data = data;
            _name = nameof(data);
            OwnerSet = ownerSet;
        }

        public bool IsAscAttribute()
        {
            return true;
        }

        public void SetCurrentValue(float newValue, AttributeSet ownerSet)
        {
            var oldValue = _data.CurrentValue;
            ownerSet?.PreAttributeChange(this, newValue);
            _data.CurrentValue = newValue;
            ownerSet?.PostAttributeChange(this, oldValue, newValue);
        }

        public float GetCurrentValue(AttributeSet ownerSet)
        {
            return _data?.CurrentValue ?? 0f;
        }

        public AttributeData GetAttributeData()
        {
            return _data;
        }
    }
}