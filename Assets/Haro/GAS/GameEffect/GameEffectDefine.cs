using Sirenix.OdinInspector;
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

        [HideIf("durationPolicy", GameEffectDurationType.Instant)]
        public float period;

        [ShowIf("durationPolicy", GameEffectDurationType.HasDuration)]
        public float duration;

        [HideIf("durationPolicy", GameEffectDurationType.Instant)]
        public bool executeImmediately;

        public GameEffectModifierDefine[] modifierDefines;
    }
}