using UnityEngine;

namespace Haro.GAS
{
    public enum GameEffectDurationType
    {
        Instant,
        Infinite,
        HasDuration
    }

    [CreateAssetMenu(menuName = "Gas/GameEffectDefine", fileName = "GameEffectDefine")]
    public class GameEffectDefine : ScriptableObject
    {
        public GameEffectDurationType durationPolicy;
        public float period;
        public float duration;
        public bool executeImmediately;
        public GameEffectModifierDefine[] modifierDefines;
    }
}