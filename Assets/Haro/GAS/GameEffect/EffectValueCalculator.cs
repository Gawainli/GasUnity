using UnityEngine;

namespace Haro.GAS
{
    public abstract class EffectValueCalculator : ScriptableObject
    {
        public abstract float CalculateMagnitude(GameEffectSpec spec, float value);
    }
}