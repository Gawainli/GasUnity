using UnityEngine.Serialization;

namespace Haro.GAS
{
    public enum GameplayModOp
    {
        Add,
        Multiply,
        Division,
        Override,
        Count
    }
    
    [System.Serializable]
    public class GameEffectModifierDefine
    {
        public string attributeName;
        public GameplayModOp modOp;
        public float value;
        public EffectValueCalculator calculator;
    }

    public class ModifierSpec
    {
        public Attribute attribute;
        public GameEffectModifierDefine modifierDefine;
        
        private float _value;
        
        public ModifierSpec(Attribute attribute, GameEffectModifierDefine modifierDefine)
        {
            this.attribute = attribute;
            this.modifierDefine = modifierDefine;
            _value = modifierDefine.value;
        }
        
        public bool CanCombine(ModifierSpec other)
        {
            return attribute == other.attribute && modifierDefine.modOp == other.modifierDefine.modOp && modifierDefine.calculator == other.modifierDefine.calculator;
        }

        public void Combine(ModifierSpec other)
        {
            _value += other._value;
        }
        
        public void UpdateValue(GameEffectSpec spec)
        {
            if (modifierDefine.calculator == null)
            {
                return;
            }
            
            _value = modifierDefine.calculator.CalculateMagnitude(spec, _value);
        }

        public void Apply()
        {
            switch (modifierDefine.modOp)
            {
                case GameplayModOp.Add:
                    attribute.SetCurrentValue(attribute.GetCurrentValue() + _value);
                    break;
                case GameplayModOp.Multiply:
                    attribute.SetCurrentValue(attribute.GetCurrentValue() * _value);
                    break;
                case GameplayModOp.Division:
                    attribute.SetCurrentValue(attribute.GetCurrentValue() / _value);
                    break;
                case GameplayModOp.Override:
                    attribute.SetCurrentValue(_value);
                    break;
            }
        }
    }
}