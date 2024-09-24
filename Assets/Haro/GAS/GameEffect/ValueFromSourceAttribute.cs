using UnityEngine;

namespace Haro.GAS
{
    [CreateAssetMenu(menuName = "Gas/ValueFromSourceAttribute", fileName = "ValueFromSourceAttribute")]
    public class ValueFromSourceAttribute : EffectValueCalculator
    {
        public enum AttributeFromType
        {
            Source,
            Target
        }

        public AttributeFromType attributeFromType;
        public string attributeName;

        public override float CalculateMagnitude(GameEffectSpec spec, float value)
        {
            var attr = attributeFromType == AttributeFromType.Source
                ? spec.source.attributeSet.GetAttribute(attributeName)
                : spec.target.attributeSet.GetAttribute(attributeName);
            return attr?.GetCurrentValue() ?? value;
        }
    }
}