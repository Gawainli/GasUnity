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

        public Attribute()
        {
        }

        public Attribute(AttributeData data)
        {
            _data = data;
            _name = nameof(data);
        }

        public string GetName()
        {
            return _name;
        }

        public Attribute(AttributeData data, string name, AttributeSet ownerSet = null)
        {
            _data = data;
            _name = name;
            OwnerSet = ownerSet;
        }

        public bool IsSystemAttribute()
        {
            return OwnerSet is null;
        }

        public void SetCurrentValue(float newValue)
        {
            var oldValue = _data.CurrentValue;
            OwnerSet?.PreAttributeChange(this, newValue);
            _data.CurrentValue = newValue;
            OwnerSet?.PostAttributeChange(this, oldValue, newValue);
        }

        public void SetBaseValue(float newValue)
        {
            var oldValue = _data.BaseValue;
            OwnerSet?.PreAttributeBaseChange(this, newValue);
            _data.BaseValue = newValue;
            OwnerSet?.PostAttributeBaseChange(this, oldValue, newValue);
        }

        public float GetCurrentValue()
        {
            return _data?.CurrentValue ?? 0f;
        }

        public AttributeData GetAttributeData()
        {
            return _data;
        }

        public override string ToString()
        {
            return $"{_name}: {_data.CurrentValue}/{_data.BaseValue}";
        }
    }
}